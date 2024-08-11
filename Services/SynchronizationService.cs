using System.Collections.Concurrent;

namespace Source.Services;

public interface ISynchronizationService
{
    ISynchronizer GetSynchronizer(Guid id);

    void ClearSynchronizer(Guid id);
}

public class SynchronizationService : ISynchronizationService
{
    private readonly ConcurrentDictionary<Guid, ISynchronizer> _synchronizers = new();
    
    public ISynchronizer GetSynchronizer(Guid id)
    {
        return _synchronizers.GetOrAdd(id, _ => new Synchronizer());
    }

    public void ClearSynchronizer(Guid id)
    {
        _synchronizers.TryRemove(id, out _);
    }
}