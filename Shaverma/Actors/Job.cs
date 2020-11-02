using System;

namespace Shaverma.Actors
{
    public class Job<T>
    {
        public T Assignment { get; }
        public int Attempt { get; private set; }
        public Exception LastError { get; private set; }

        public Job(T assignment, int attempt)
        {
            Assignment = assignment;
            Attempt = attempt;
        }

        public void OnError(Exception ex)
        {
            LastError = ex;
            Attempt++;
        }
    }
}
