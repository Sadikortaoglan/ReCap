using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
   public class UserUpdateDto:IDto
    {
        public int User { get; set; }
        public string Password { get; set; }
    }
}
