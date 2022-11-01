namespace TaskBoardManagementApp.Application.Common.Behaviours.Caching;
public interface ICachableRequest
{
    bool BypassCache { get; }
    string CacheKey { get; }
    TimeSpan? SlidingExpiration { get; }
}
