using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using WMS_API.Data;
using WMS_API.Models.Domain;

namespace WMS_API.Repositories
{
    public class PostgreSQLBinRepository : IBinRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PostgreSQLBinRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Bin> CreateBinAsync(Bin bin)
        {
            await dbContext.bins.AddAsync(bin);
            await dbContext.SaveChangesAsync();
            return bin;
        }

        public async Task<List<Bin>> GetAllBinAsync()
        {
            return await dbContext.bins.Include("binStatus").ToListAsync();
        }

        public async Task<Bin?> GetBinByIdAsync(Guid id)
        {
            return await dbContext.bins.Include("binStatus").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Bin?> UpdateBinAsync(Guid id, Bin bin)
        {
            var ExistingBin = await dbContext.bins.FirstOrDefaultAsync(x => x.Id == id);

            if (ExistingBin == null)
            {
                return null;
            }

            ExistingBin.Latitude = bin.Latitude;
            ExistingBin.Longtitude = bin.Longtitude;
            ExistingBin.AreaCode = bin.AreaCode;
            ExistingBin.BinSize = bin.BinSize;
            ExistingBin.Capacity_In_KG = bin.Capacity_In_KG;

            await dbContext.SaveChangesAsync();
            return ExistingBin;
        }

        public async Task<Bin?> DeletBinAsync(Guid id)
        {
            var ExistingBin = await dbContext.bins.FirstOrDefaultAsync(x => x.Id == id);

            if (ExistingBin == null)
            {
                return null;
            }

            dbContext.bins.Remove(ExistingBin);
            await dbContext.SaveChangesAsync();
            return ExistingBin;
        }
    }
}
