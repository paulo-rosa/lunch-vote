using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using LunchVote.API.Models;
using LunchVote.LIB.Entities;
using LunchVote.LIB.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LunchVote.API.Controllers
{
    [Route("professionals")]
    [ApiController]
    public class ProfessionalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProfessionalService _professionalService;

        public ProfessionalsController(IMapper mapper, IProfessionalService professionalService)
        {
            _mapper = mapper;
            _professionalService = professionalService;
        }

        /// <summary>
        /// GET professionals
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Professionals" })]
        [SwaggerResponse(200, Type = typeof(List<ProfessionalForRetrieveDto>))]
        public async Task<ActionResult<List<ProfessionalForRetrieveDto>>> Get()
        {
            var professionals = await _professionalService.GetProfessionals();

            return Mapper.Map<List<ProfessionalForRetrieveDto>>(professionals);
        }

        /// <summary>
        /// Get professionals/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Professionals" })]
        [SwaggerResponse(200, Type = typeof(ProfessionalForRetrieveDto))]
        public ActionResult<ProfessionalForRetrieveDto> Get(int id)
        {
            return new ProfessionalForRetrieveDto();
        }
    }
}
