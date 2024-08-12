
using Source.Models;

namespace Source.Services;

public interface IConsumer<T>
{
    Task Consume(T response);
}

public class BusConsumer(ISynchronizationService synchronizationService) : IConsumer<BusResponseModel>
{
    public Task Consume(BusResponseModel response)
    {
        ISynchronizer synchronizer = synchronizationService.GetSynchronizer(response.Id);
        synchronizer.SetData(response.Data);
        return Task.CompletedTask;
    }
}

