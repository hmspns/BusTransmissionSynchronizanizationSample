using System.Buffers.Text;
using System.Text;
using Source.Models;

namespace Source.Services;

public interface IBus
{
    Task Send(BusRequestModel model);
}

public sealed class MockBus(IConsumer<BusResponseModel> consumer) : IBus
{
    public Task Send(BusRequestModel model)
    {
        // имитируем ожидание ответа
        Task.Delay(TimeSpan.FromSeconds(2)).ContinueWith(async _ =>
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello world!");
            await consumer.Consume(new BusResponseModel(model.Id, data));
        });
        return Task.CompletedTask;
    }
}