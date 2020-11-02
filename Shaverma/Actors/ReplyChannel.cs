using System.Threading.Tasks;

namespace Shaverma.Actors
{
    /// <summary>
    /// Класс для получение ответа от актора
    /// </summary>
    /// <typeparam name="T">Тип ответа</typeparam>
    public class ReplyChannel<T>
    {
        private readonly TaskCompletionSource<T> _tsc;

        /// <summary>
        /// Ответ
        /// </summary>
        public Task<T> Reply => _tsc.Task;

        public ReplyChannel() => _tsc = new TaskCompletionSource<T>();

        /// <summary>
        /// Установить ответ
        /// </summary>
        /// <param name="reply">Ответ</param>
        public void SetReply(T reply)
        {
            _tsc.SetResult(reply);
        }

    }
}
