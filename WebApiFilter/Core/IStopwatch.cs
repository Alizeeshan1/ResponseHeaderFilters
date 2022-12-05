namespace Cpm.Web.Api.Core
{
    public interface IStopwatch
    {
        long ElapsedMilliseconds { get; }
        void Start();
        void Stop();
        void Reset();
    }
}
