using AutoMapper;
using Domain.OutlookEntities;
using ExternalServices.Outlook.Dtos;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<EventDto, EventCalendar>();
            CreateMap<EventBodyDto, EventCalendarBody>();
            CreateMap<EventDateDto, EventCalendarDate>();

            CreateMap<EventCalendar, EventDto>();
            CreateMap<EventCalendarBody, EventBodyDto>();
            CreateMap<EventCalendarDate, EventDateDto>();
            #endregion
        }
    }
}
