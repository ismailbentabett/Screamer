using Screamer.Application.TodoLists.Queries.ExportTodos;

namespace Screamer.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
