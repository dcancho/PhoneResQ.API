using AutoMapper;

namespace PhoneResQ.API.Support.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile() 
        {
            CreateMap<Domain.Models.Entities.Report, Resources.ReportResource>();
            CreateMap<Domain.Models.Entities.Rating, Resources.RatingResource>();
            CreateMap<Domain.Models.Entities.Device, Resources.DeviceResource>();
            CreateMap<Domain.Models.Entities.Customer, Resources.CustomerResource>();
            CreateMap<Domain.Models.Entities.Technician, Resources.TechnicianResource>();
            CreateMap<Domain.Models.Entities.SupportCenter, Resources.SupportCenterResource>();
            CreateMap<Domain.Models.Entities.Order, Resources.OrderResource>();
            CreateMap<Domain.Models.Entities.Notification, Resources.NotificationResource>();
            CreateMap<Domain.Models.Entities.StatusUpdate, Resources.StatusUpdateResource>();
        }
    }
}
