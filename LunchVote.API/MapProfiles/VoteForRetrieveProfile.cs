using AutoMapper;
using LunchVote.API.Models;
using LunchVote.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchVote.API.MapProfiles
{
    public class VoteForRetrieveProfile : Profile
    {
        public VoteForRetrieveProfile()
        {
            CreateMap<Vote, VoteForRetrieveDto>()
                .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name))
                .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.Restaurant.Id))
                .ForMember(dest => dest.ProfessionalName, opt => opt.MapFrom(src => src.Professional.Name))
                .ForMember(dest => dest.ProfessionalId, opt => opt.MapFrom(src => src.Professional.Id));
        }
    }
}
