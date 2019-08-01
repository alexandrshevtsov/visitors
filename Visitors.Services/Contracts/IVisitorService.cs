using System.Collections.Generic;
using Visitors.Services.DTO;

namespace Visitors.Services.Contracts
{
    public interface IVisitorService
    {
        ICollection<DeltaItem> GetDelta();
    }
}
