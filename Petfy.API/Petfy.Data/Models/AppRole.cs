using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Data.Models
{
    public class AppRole: IdentityRole<int>
    {
        public IEnumerable<AppUserRole> UserRoles { get; set; }
    }
}
