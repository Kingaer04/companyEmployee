using Microsoft.AspNetCore.Mvc.Filters;

public abstract class ActionFilterAttribute : Attribute, IActionFilter,
IFilterMetadata, IAsyncActionFilter, IResultFilter, IAsyncResultFilter, IOrderedFilter 