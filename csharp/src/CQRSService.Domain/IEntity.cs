using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSService.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
