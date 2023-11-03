using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> ListAsync();
        Task<NotificationResponse> SaveAsync(Notification notification);
        Task<NotificationResponse> UpdateAsync(int id, Notification notification);
        Task<NotificationResponse> DeleteAsync(int id);
    }
}
