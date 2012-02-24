using System.Collections.Concurrent;
using System.Threading;

namespace DotnetKoeln.STS.Services
{
    public interface ISleepService
    {
        void Sleep(string key);
        void DoubleTime(string key);
        void Clear(string key);
    }

    public class SleepService : ISleepService
    {
        readonly ConcurrentDictionary<string, int> sleepTimes = new ConcurrentDictionary<string, int>();

        public void Sleep(string key)
        {
            int milliseconds;
            if (sleepTimes.TryGetValue(CleanKey(key), out milliseconds))
            {
                Thread.Sleep(milliseconds);
            }
            else
            {
                DoubleTime(CleanKey(key));
            }
        }

        public void DoubleTime(string key)
        {
            var currentMilliseconds = GetCurrentMilliseconds(key);
            sleepTimes[CleanKey(key)] = currentMilliseconds*2;
        }

        int GetCurrentMilliseconds(string key)
        {
            int currentMilliseconds = 50;
            sleepTimes.TryGetValue(CleanKey(key), out currentMilliseconds);
            if (currentMilliseconds == 0)
                currentMilliseconds = 50;
            if (currentMilliseconds > 30000)
                currentMilliseconds = 200;
            return currentMilliseconds;
        }

        static string CleanKey(string key)
        {
            return key.ToLower();
        }

        public void Clear(string key)
        {
            int value;
            sleepTimes.TryRemove(key, out value);
        }
    }
}