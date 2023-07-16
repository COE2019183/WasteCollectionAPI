using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_API.Models.Domain;
using WMS_API.Models.DTO.BinDTO;
using WMS_API.Repositories;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainBinController : ControllerBase
    {
        private readonly IBinRepository binRepository;
        private readonly IMapper mapper;

        public MainBinController(IBinRepository binRepository, IMapper mapper)
        {
            this.binRepository = binRepository;
            this.mapper = mapper;
        }

        //Creating the Bin
        [HttpPost]
        public async Task<IActionResult> CreateBin([FromBody]CreateBinDTO createBinDTO)
        {
            var binDomainModel = mapper.Map<Bin>(createBinDTO);

            binDomainModel = await binRepository.CreateBinAsync(binDomainModel);

            return Ok(mapper.Map<CreateBinDTO>(binDomainModel));
        }

        //Getting All the Bins End Point
        [HttpGet]
        public async Task<IActionResult> GetAllBin()
        {
            var bins = await binRepository.GetAllBinAsync();

            var binsdto = mapper.Map<List<BinDTO>>(bins);

            return Ok(binsdto);
        }

        //Get Bin By Id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBinById([FromRoute] Guid id)
        {
            var bin = await binRepository.GetBinByIdAsync(id);

            var binDTO = mapper.Map<BinDTO>(bin);

            return Ok(binDTO);
        }

        //Update the Bin
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBin([FromRoute]Guid id, [FromBody]UpdateBinDTO updateBinDTO)
        {
            var binDomainModel = mapper.Map<Bin>(updateBinDTO);

            binDomainModel = await binRepository.UpdateBinAsync(id,binDomainModel);

            if(binDomainModel == null)
            {
                return NotFound();
            }
            var binDTO = mapper.Map<BinDTO>(binDomainModel);

            return Ok(binDTO);

        }

        //Delete the bin
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBin([FromRoute]Guid id)
        {
            var binDomainModel = await binRepository.DeletBinAsync(id);

            if (binDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BinDTO>(binDomainModel));
        }
    }
}
