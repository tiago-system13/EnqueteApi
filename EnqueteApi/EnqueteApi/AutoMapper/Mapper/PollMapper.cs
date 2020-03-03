using AutoMapper;
using EnqueteApi.Core.Entity;
using EnqueteApi.Models.Dto;
using EnqueteApi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnqueteApi.AutoMapper.Mapper
{
    public class PollMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<Option, OptionViewModel>();

            profile.CreateMap<Poll, PollViewModel>();

            profile.CreateMap<Option, OptionViewsViewModel>();

            profile.CreateMap<Poll, PollViewsViewModel>()
                 .ForMember(h => h.Views, opt => opt.MapFrom(op => op.CountViews))
                 .ForMember(h => h.Votes, opt => opt.MapFrom(op => op.Options));

            profile.CreateMap<Poll, PollReturnPostViewModel>()
                .ForMember(h => h.PollId, opt => opt.MapFrom(op => op.Id));

            profile.CreateMap<OptionDto, Option>();

            profile.CreateMap<PollDto, Poll>();
        }
    }
}
