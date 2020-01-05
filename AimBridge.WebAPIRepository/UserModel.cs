using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AimBridge.WebAPIRepository
{
   public class UserModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Completed { get; set; }
    }
}
