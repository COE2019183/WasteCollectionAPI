using AutoMapper;
using System.Runtime.CompilerServices;
using WMS_API.Models.Domain;
using WMS_API.Models.DTO.BinDTO;

namespace WMS_API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bin, BinDTO>().ReverseMap();

            CreateMap<Bin, UpdateBinDTO>().ReverseMap();

            CreateMap<Bin, DeleteBinDTO>().ReverseMap();

            CreateMap<Bin, CreateBinDTO>().ReverseMap();
        }
    }
}
