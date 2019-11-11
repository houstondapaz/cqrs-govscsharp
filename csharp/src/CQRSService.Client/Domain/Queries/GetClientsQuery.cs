using CQRSService.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSService.Client.Domain.Queries
{
    public class GetClientsQuery : IQuery<IEnumerable<Client>>
    {
    }
}
