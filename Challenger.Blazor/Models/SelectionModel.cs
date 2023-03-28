namespace Challenger.Blazor.Models;

public class SelectionModel<T>
{
    public SelectionType Type { get; set; }
    public T Model { get; set; } = default!;
}
