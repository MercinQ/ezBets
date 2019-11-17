using System;

namespace ezBet.WebAPI.Model.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public TaskType Type { get; set; }
        public TaskState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Info { get; set; }
    }

    public enum TaskType : byte
    {
        ResetPassword = 1
    }

    public enum TaskState : byte
    {
        New = 1,
        Pending = 2,
        Closed = 3

    }
}
