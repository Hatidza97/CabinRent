using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class KorisniciLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
