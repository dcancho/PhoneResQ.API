using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface INotificationService
    {
            public Task<IEnumerable<Notification>> ListAsync();
            public Task<NotificationResponse> SaveAsync(Notification notification);
        public Task<NotificationResponse> UpdateAsync(int id, Notification notification);
        public Task<NotificationResponse> DeleteAsync(int id);
    }
}
