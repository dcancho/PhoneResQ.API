using AutoMapper;
using PhoneResQ.API.Support.Resources;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCustomerResource, Customer>();
            CreateMap<SaveDeviceResource, Device>();
            CreateMap<SaveOrderResource, Order>();
            CreateMap<SaveReportResource, Report>();
            CreateMap<SaveSupportCenterResource, SupportCenter>();
            CreateMap<SaveTechnicianResource, Technician>();
            CreateMap<SaveNotificationResource, Notification>();
            CreateMap<SaveRatingResource, Rating>();
            CreateMap<SaveStatusUpdateResource, StatusUpdate>();
        }
    }
}
