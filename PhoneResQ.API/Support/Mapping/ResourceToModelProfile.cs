using AutoMapper;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<Resources.SaveCustomerResource, Domain.Models.Entities.Customer>();
            CreateMap<Resources.SaveDeviceResource, Domain.Models.Entities.Device>();
            CreateMap<Resources.SaveOrderResource, Domain.Models.Entities.Order>();
            CreateMap<Resources.SaveReportResource, Domain.Models.Entities.Report>();
            CreateMap<Resources.SaveSupportCenterResource, Domain.Models.Entities.SupportCenter>();
            CreateMap<Resources.SaveTechnicianResource, Domain.Models.Entities.Technician>();
            CreateMap<Resources.SaveNotificationResource, Domain.Models.Entities.Notification>();
            CreateMap<Resources.SaveRatingResource, Domain.Models.Entities.Rating>();
            CreateMap<Resources.SaveStatusUpdateResource, Domain.Models.Entities.StatusUpdate>();
        }
    }
}
