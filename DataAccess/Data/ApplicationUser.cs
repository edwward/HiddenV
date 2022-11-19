using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    //K identityUser pridavam jeste Name property
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
