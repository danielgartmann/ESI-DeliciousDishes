using System.Web.Http.Filters;

namespace DeliciousDishes.WebApi.Infrastructure
{
    public interface IOrderedFilter : IFilter
    {
        int Order { get; set; }
    }
}