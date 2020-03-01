using AutoMapper;
using EnqueteApi.AutoMapper.Mapper;

namespace EnqueteApi.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            PollMapper.Map(this);            
        }
    }
}
