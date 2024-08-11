using Microsoft.AspNetCore.Mvc;
using Source.Models;
using Source.Services;

namespace Source.Controllers;

[Route("~/data")]
[ApiController]
public class DataController(ISynchronizationService synchronizationService, IBus bus) : Controller
{
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetData(Guid id)
    {
        try
        {
            await bus.Send(new BusRequestModel(id));
            
            ISynchronizer synchronizer = synchronizationService.GetSynchronizer(id);
            byte[] data = await synchronizer.GetData();
            
            return File(data, "application/octet-stream", "data.txt");
        }
        finally
        {
            synchronizationService.ClearSynchronizer(id);
        }
    }
}