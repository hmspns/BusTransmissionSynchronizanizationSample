
using Source.Models;

namespace Source.Services;

public interface IConsumer<T>
{
    Task Consume(T response);
}

public class BusConsumer : IConsumer<BusResponseModel>
{
    private ISynchronizationService _synchronizationService;

    public BusConsumer(ISynchronizationService sycnSynchronizationService)
    {
        _synchronizationService = sycnSynchronizationService;
    }
    
    public Task Consume(BusResponseModel response)
    {
        ISynchronizer synchronizer = _synchronizationService.GetSynchronizer(response.Id);
        synchronizer.SetData(response.Data);
        return Task.CompletedTask;
    }
}

