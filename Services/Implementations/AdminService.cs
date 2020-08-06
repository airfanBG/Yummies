using Services.Common;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AdminService
    {
        private IServiceConnector ServiceConnector { get; }
        private readonly Statistics _statistics;
        public AdminService(IServiceConnector connector, Statistics statistics)
        {
            ServiceConnector = connector;
            _statistics = statistics;
        }
        public async Task<int> GetNewClients()
        {
            
            var res = await ServiceConnector.Users.GetAll(x => x.CreatedAt > _statistics.LastDateCheckUsers);
            _statistics.LastDateCheckUsers = DateTime.UtcNow;
            return res.Count;
        }
    }
}
