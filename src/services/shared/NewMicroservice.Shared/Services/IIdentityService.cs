using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMicroservice.Shared.Services
{
    public interface IIdentityService
    {
        public Guid UserId { get; }
        public string UserName { get; }

        List<string> Roles { get; }
    }
}
