namespace greenPomodoro.Domain
{
    public class PomodoroTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedPomodoros { get; set; }
        public int PomodoroLength { get; set; }
        public int FinishedPomodoros { get; set; }
        public int ShortBreakLength { get; set; }
        public int LongBreakLength { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
