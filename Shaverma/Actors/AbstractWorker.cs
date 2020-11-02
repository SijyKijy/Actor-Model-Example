using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Shaverma.Actors
{
    /// <summary>
    /// Абстрактный работник
    /// </summary>
    /// <typeparam name="T">Объект для работы</typeparam>
    public abstract class AbstractWorker<T>
    {
        private readonly BufferBlock<Job<T>> _jobs;

        public AbstractWorker()
        {
            _jobs = new BufferBlock<Job<T>>();

            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var job = await _jobs.ReceiveAsync();
                        await Handle(job);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Fatal error] {ex}");
                    }
                }
            });
        }

        protected abstract Task HandleJob(T msg);
        protected abstract Task HandleError(Job<T> job, Exception ex);

        public void Post(T jobName)
        {
            var job = new Job<T>(jobName, 0);
            _jobs.Post(job);
        }

        private async Task Handle(Job<T> job)
        {
            try
            {
                await HandleJob(job.Assignment);
            }
            catch (Exception e)
            {
                job.OnError(e);
                await HandleError(job, e);
            }
        }
    }
}
