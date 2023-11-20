using PhoneResQ.API.Shared.Infrastructure.Configuration;
using PhoneResQ.API.Shared.Infrastructure.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;

namespace PhoneResQ.API.Support.Infrastructure.Repositories;

public class SupportCenterRepository : BaseRepository<SupportCenter>, ISupportCenterRepository
{
    public SupportCenterRepository(AppDbContext context) : base(context)
    {
    }
    
}