using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class LocationController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkInterface _unitOfWork;
        public LocationController(IUnitOfWorkInterface unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           
            _mapper = mapper;
        }

        [HttpGet("{regcode}")]
        public async Task<ActionResult<RegionsDto>> GetRegionsByCodeAsync(string regcode)
        {
            var regionsByCode = await _unitOfWork.RegionsAndDistrictsRepository.GetRegionByCodeAsync(regcode);
                var regionsReturned = _mapper.Map<RegionsDto>(regionsByCode);
            return Ok(regionsReturned);

        }

         [HttpGet("regions")]
        public async Task<ActionResult<IEnumerable<RegionsDto>>> GetAllRegionsAsync()
        {
            var regionsAll = await _unitOfWork.RegionsAndDistrictsRepository.GetRegionsAsync();
                var regionsReturned = _mapper.Map<IEnumerable<RegionsDto>>(regionsAll);
            return Ok(regionsReturned);

        }

        //  [HttpGet("{discode}")]
        // public async Task<ActionResult<DistrictsDto>> GetDistrictByIDAsync(string discode)
        // {
        //     var districtBtID = await _unitOfWork.RegionsAndDistrictsRepository.GetDistrictByCodeAsync(discode);
        //         var districtsReturned = _mapper.Map<DistrictsDto>(districtBtID);
        //     return Ok(districtsReturned);

        // }

         [HttpGet("districts")]
        public async Task<ActionResult<IEnumerable<DistrictsDto>>> GetAllDistrictsAsync()
        {
            var districtsAll = await _unitOfWork.RegionsAndDistrictsRepository.GetDistrictsAsync();
                var districtsReturned = _mapper.Map<IEnumerable<DistrictsDto>>(districtsAll);
            return Ok(districtsReturned);

        }
    }
}