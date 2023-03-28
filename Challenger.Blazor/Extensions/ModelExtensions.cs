using Challenger.Blazor.Models;

namespace Challenger.Blazor.Extensions;

public static class ModelExtensions
{
    public static IEnumerable<SelectionModel<T>> ToSelectionsModel<T>(this IEnumerable<T> collection)
        => collection.Select(x => new SelectionModel<T>
        {
            Model = x,
            Type = SelectionType.NotSelected
        });
}
