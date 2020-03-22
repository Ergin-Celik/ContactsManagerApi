using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class CustomController: Controller
    {
        public CustomController(): base()
        {

        }

        public Guid UserId
        {
            get
            {
                return Guid.Parse(HttpContext.User.FindFirst("userId").Value);
            }
        }

        public Guid PersonId { 
            get {
                return Guid.Parse(HttpContext.User.FindFirst("personId").Value);
            }
        }
    }
}
