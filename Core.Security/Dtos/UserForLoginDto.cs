﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Dtos
{
    public class UserForLoginDto
    {
        public string IdentityNumber { get; set; } = string.Empty;
        public string Password { get; set; }

    }
}
