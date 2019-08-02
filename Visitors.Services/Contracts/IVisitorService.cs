using System.Collections.Generic;
using System.Threading.Tasks;
using Visitors.Services.DTO;

namespace Visitors.Services.Contracts
{
    public interface IVisitorService
    {
        Task<ICollection<DeltaItem>> GetDelta();
    }
}
