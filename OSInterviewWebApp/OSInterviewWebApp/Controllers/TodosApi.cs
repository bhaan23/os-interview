using Microsoft.AspNetCore.Mvc;
using OSInterviewWebApp.Client;

namespace OSInterviewWebApp.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosApi : ControllerBase
{
	private static readonly List<TodoItem> Todos = [];

	[HttpGet]
	public async Task<IActionResult> GetTodoItems()
	{
		await Task.Delay(1000);
		return Ok(Todos);
	}

	[HttpPost]
	public async Task<IActionResult> AddTodoItem(TodoItem newItem)
	{
		await Task.Delay(500);
		Todos.Add(newItem);
		return new StatusCodeResult(StatusCodes.Status201Created);
	}
}
