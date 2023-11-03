using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IRatingService
    {
        Task<IEnumerable<Rating>> ListAsync();
        Task<RatingResponse> SaveAsync(Rating rating);
        Task<RatingResponse> UpdateAsync(int id, Rating rating);
        Task<RatingResponse> DeleteAsync(int id);
    }
}
