namespace greenPomodoro.BlazorUI.Models
{
    public class TaskVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedPomodoros { get; set; }
        public int PomodoroLength { get; set; }
        public int FinishedPomodoros { get; set; }
        public int ShortBreakLength { get; set; }
        public int LongBreakLength { get; set; }
    }
}
