using System;
using System.Threading;

namespace ConvertTacho
{
    public delegate void stCallBackDelegate();
    public class ScheduledTimer
    {
        private Timer _timer;
        public ScheduledTimer() { }
        public static TimeSpan GetDueTime(TimeSpan A, TimeSpan B)
        {
            if (A < B)
            {
                return B.Subtract(A);
            }
            else
            {
                return new TimeSpan(24, 0, 0).Subtract(B.Subtract(A));
            }
        }
        public void SetTime(TimeSpan _time, stCallBackDelegate callback)
        {
            if (this._timer != null)
            {
                // Change 매서드 사용 가능.
                this._timer = null;
            }
            TimeSpan Now = DateTime.Now.TimeOfDay;
            TimeSpan DueTime = GetDueTime(Now, _time);

            this._timer = new Timer(new TimerCallback(delegate(object _callback)
            {
                ((stCallBackDelegate)_callback)();
            }), callback, DueTime, new TimeSpan(24, 0, 0));
        }
    }
}
