namespace Source.Services;

public interface ISynchronizer
{
    Task<byte[]> GetData();

    void SetData(byte[] data);
}

public class Synchronizer : ISynchronizer
{
    private readonly TaskCompletionSource<byte[]> _taskCompletionSource = new(); 
    
    public Task<byte[]> GetData()
    {
        return _taskCompletionSource.Task;
    }

    public void SetData(byte[] data)
    {
        _taskCompletionSource.SetResult(data);
    }
}