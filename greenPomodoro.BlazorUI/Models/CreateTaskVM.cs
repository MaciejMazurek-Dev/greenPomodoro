namespace greenPomodoro.BlazorUI.Models
{
    public class CreateTaskVM
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedPomodoros { get; set; }
        public int PomodoroLength { get; set; }
        public int ShortBreakLength { get; set; }
        public int LongBreakLength { get; set; }
    }
}
