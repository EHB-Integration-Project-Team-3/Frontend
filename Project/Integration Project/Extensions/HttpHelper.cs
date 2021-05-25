using Integration_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Extensions {
    public class HttpHelper {
      
        public static InternalUser CheckLoggedUser() {
            // check for the current user
            HttpContextAccessor context = new HttpContextAccessor();
            var userSes = context.HttpContext.Session.Get("User");
            var user = new InternalUser();
            if (userSes != null) {
                user = (InternalUser) ModelHelper<InternalUser>.ObjectFromByteArray(userSes);
            } else {
                context.HttpContext.Response.Redirect("/Home/Index");
            }

            return user;
        }
    }
}
