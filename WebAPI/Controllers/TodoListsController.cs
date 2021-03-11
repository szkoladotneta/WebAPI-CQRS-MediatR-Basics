using Webinar202103.Application.TodoLists.Commands.CreateTodoList;
using Webinar202103.Application.TodoLists.Commands.DeleteTodoList;
using Webinar202103.Application.TodoLists.Commands.UpdateTodoList;
using Webinar202103.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Webinar202103.WebAPI.Controllers
{
    [Route("api/TodoLists")]

    public class TodoListsController : ApiControllerBase
    {
        [HttpGet]
        [Description("Gets all TodoLists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodosVm>> Get()
        {
            return await Mediator.Send(new GetTodosQuery());
        }

        [HttpPost]
        [Description("Creates new TodoItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        [Route("{id}")]
        [Description("Updates TodoItem. Id must match Command Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, UpdateTodoListCommand command)
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
            await Mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}
