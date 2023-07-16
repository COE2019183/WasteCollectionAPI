using Microsoft.AspNetCore.Mvc.ActionConstraints;
using WMS_API.Models.Domain;

namespace WMS_API.Repositories
{
    public interface IBinRepository
    {
        Task<Bin> CreateBinAsync(Bin bin);
        Task<List<Bin>> GetAllBinAsync();
        Task<Bin?> GetBinByIdAsync(Guid id);
        Task<Bin?> UpdateBinAsync(Guid id,Bin bin);
        Task<Bin?> DeletBinAsync(Guid id);
    }
}
