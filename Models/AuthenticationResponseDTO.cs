using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //pro chyby pri SIGNIN operaci
    public class AuthenticationResponseDTO
    {
        public bool IsAuthenticationSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public UserDTO? userDTO { get; set;}
    }
}
