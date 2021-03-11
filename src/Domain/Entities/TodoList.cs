using Webinar202103.Domain.Common;
using System.Collections.Generic;

namespace Webinar202103.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
