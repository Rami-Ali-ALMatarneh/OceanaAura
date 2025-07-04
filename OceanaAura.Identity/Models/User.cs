﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Identity.Models
{
    public class User : IdentityUser
    {
    public string? OTP { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifyOn { get; set; }
    public string? ModifyBy { get; set; }
    public string CreatedBy { get; set; }

    }
}
