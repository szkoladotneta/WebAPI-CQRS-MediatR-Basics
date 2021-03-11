using Webinar202103.Domain.Common;
using Webinar202103.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Webinar202103.Domain.Entities
{
    public class TodoItem : AuditableEntity
    {
        public int Id { get; set; }

        public TodoList List { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }
    }
}
