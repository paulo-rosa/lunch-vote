﻿using AutoMapper;
using LunchVote.API.Models;
using LunchVote.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchVote.API.MapProfiles
{
    public class ElectionForRetrieveProfile : Profile
    {
        public ElectionForRetrieveProfile()
        {
            CreateMap<Election, ElectionForRetrieveDto>();
        }
    }
}
