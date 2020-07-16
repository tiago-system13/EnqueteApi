using System.Collections.Generic;
using AutoMapper;
using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Services.Interfaces;
using EnqueteApi.Models.Dto;
using EnqueteApi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EnqueteApi.Controller
{
    [Route("api/poll")]
    [ApiController]
    public class PollController : ControllerBase
    {
        #region Fields
        private readonly IPollService _pollService;
        private readonly IOptionsService _optionsService;
        private readonly IMapper _mapper;
        #endregion


        #region Constructor
        public PollController(IPollService pollService, IOptionsService optionsService, IMapper mapper)
        {
            _pollService = pollService;
            _optionsService = optionsService;
            _mapper = mapper;
        }
        #endregion

        #region Method

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<List<PollViewModel>> Get(int id)
        {
            var poll = _pollService.GetbyId(id, true);
            return Ok(_mapper.Map<PollViewModel>(poll));
        }

        [HttpGet]
        [Route("{id:int}/stats")]
        public ActionResult<List<PollViewsViewModel>> GetStats(int id)
        {
            var poll = _pollService.GetbyId(id, false);
            return Ok(_mapper.Map<PollViewsViewModel>(poll));
        }

        [HttpPost]
        public ActionResult Post([FromBody] PollDto poll)
        {
            var result = _pollService.Add(_mapper.Map<Poll>(poll));
            return Ok(_mapper.Map<PollReturnPostViewModel>(result));
        }

        [HttpPost]
        [Route("{id:int}/vote")]
        public ActionResult PostVote(int id)
        {
            var result = _optionsService.Update(id);
            return Ok(_mapper.Map<OptionViewModel>(result));
        }

        #endregion


    }
}