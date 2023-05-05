using Screamer.Application.Common.Mappings;
using Screamer.Domain.Entities;

namespace Screamer.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
