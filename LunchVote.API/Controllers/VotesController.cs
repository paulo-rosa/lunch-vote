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
    [Route("votes")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVoteService _voteService;

        public VotesController(IMapper mapper, IVoteService voteService)
        {
            _mapper = mapper;
            _voteService = voteService;
        }

        /// <summary>
        /// POST votes
        /// </summary>
        /// <param name="voteForPost"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Votes" })]
        [SwaggerResponse(200, Type = typeof(VoteForRetrieveDto))]
        public async Task<ActionResult<VoteForRetrieveDto>> Post([FromBody] VoteForInsertDto voteForPost)
        {
            try
            {
                Vote vote = _mapper.Map<Vote>(voteForPost);
                vote.VoteDate = DateTime.Now;

                var ret = _mapper.Map<VoteForRetrieveDto>(await _voteService.PostVoteAsync(vote));
                return ret;
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
