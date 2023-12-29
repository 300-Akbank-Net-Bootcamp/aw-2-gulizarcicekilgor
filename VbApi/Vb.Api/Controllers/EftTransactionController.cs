using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EftTransactionController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public EftTransactionController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<List<EftTransaction>> Get()
    {
        return await dbContext.Set<EftTransaction>()
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<EftTransaction> Get(int id)
    {
        var eftTransaction =  await dbContext.Set<EftTransaction>()
            .Include(x=> x.Account)
            .Where(x => x.Id == id).FirstOrDefaultAsync();
       
        return eftTransaction;
    }
    [HttpPost]
    public async Task Post([FromBody] EftTransaction eftTransaction)
    {
        await dbContext.Set<EftTransaction>().AddAsync(eftTransaction);
        await dbContext.SaveChangesAsync();
    }
    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] EftTransaction eftTransaction)
    {
        var fromdb = await dbContext.Set<EftTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
        fromdb.SenderName = eftTransaction.SenderName;
        fromdb.ReferenceNumber = eftTransaction.ReferenceNumber;

        await dbContext.SaveChangesAsync();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var fromdb = await dbContext.Set<EftTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
        fromdb.IsActive = false;
        await dbContext.SaveChangesAsync();
    }

    
}