using Webinar202103.Application.Common.Models;
using Webinar202103.Application.TodoItems.Commands.CreateTodoItem;
using Webinar202103.Application.TodoItems.Commands.DeleteTodoItem;
using Webinar202103.Application.TodoItems.Commands.UpdateTodoItem;

using Webinar202103.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Webinar202103.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Webinar202103.WebAPI.Controllers
{
    [Route("api/TodoItems")]
    public class TodoItemsController : ApiControllerBase
    {
        [HttpGet]
        [Description("Gets all TodoItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PaginatedList<TodoItemDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
        {
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Description("Creates new TodoItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        [Route("{id}")]
        [Description("Updates TodoItem. Id must match Command Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
