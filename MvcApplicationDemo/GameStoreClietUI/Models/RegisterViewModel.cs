﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStoreClietUI.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
    }
}