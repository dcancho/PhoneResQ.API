using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IRatingService
    {
        public Task<IEnumerable<Rating>> ListAsync();
        public Task<RatingResponse> SaveAsync(Rating rating);
        public Task<RatingResponse> UpdateAsync(int id, Rating rating);
        public Task<RatingResponse> DeleteAsync(int id);
    }
}
