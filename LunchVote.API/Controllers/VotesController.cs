using System;
using System.Collections.Generic;
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

        // GET api/values
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Votes" })]
        [SwaggerResponse(200, Type = typeof(IEnumerable<string>))]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "Votes" })]
        [SwaggerResponse(200, Type = typeof(string))]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Votes" })]
        [SwaggerResponse(200, Type = typeof(VoteForRetrieveDto))]
        public async Task<ActionResult<VoteForRetrieveDto>> Post([FromBody] VoteForPostDto voteForPost)
        {
            Vote vote = _mapper.Map<Vote>(voteForPost);

            return _mapper.Map<VoteForRetrieveDto> (await _voteService.PostVoteAsync(vote));            
        }
    }
}
