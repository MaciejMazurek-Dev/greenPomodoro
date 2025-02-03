namespace greenPomodoro.Application.Features.Task.Queries.GetAllTasks
{
    public class TaskDto
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
