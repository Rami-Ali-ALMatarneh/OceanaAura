﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Models.Identity.UserInfo
{
    public class UpdateInfoRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? ModifyOn { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
