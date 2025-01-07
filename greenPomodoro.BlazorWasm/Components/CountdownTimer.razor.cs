using Microsoft.AspNetCore.Components;
using System.Timers;
using Timer = System.Timers.Timer;

namespace greenPomodoro.BlazorWasm.Components
{
    public partial class CountdownTimer : ComponentBase
    {
        public bool IsRunning { get; set; } = false;

        private Timer _timer = new Timer(1000);
        private readonly TimeSpan oneSecond = new TimeSpan(0, 0, 1);
        private TimeSpan initialTime;
        private TimeSpan RemainingTime { get; set; }


        protected override void OnInitialized()
        {
            _timer.Elapsed += OnTimerElapsed;

            initialTime = new TimeSpan(0, 25, 0);
            RemainingTime = initialTime;
        }

        public string DisplayCountdownTimer()
        {
            return $"{RemainingTime.Minutes:D2}:{RemainingTime.Seconds:D2}";
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (RemainingTime > TimeSpan.Zero)
            {
                RemainingTime = RemainingTime.Subtract(oneSecond);
                InvokeAsync(StateHasChanged);
            }
            else
            {
                _timer.Stop();
                IsRunning = false;
                InvokeAsync(StateHasChanged);
            }
        }

        private void ToggleTimer()
        {
            if (IsRunning)
            {
                _timer.Stop();
                IsRunning = false;
            }
            else
            {
                _timer.Start();
                IsRunning = true;
            }
        }
    }

}
