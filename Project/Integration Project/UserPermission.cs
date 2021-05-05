using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Integration_Project
{
    public class UserPermission : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Permissions { get; set; } //Permission string to get from controller

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Validate if any permissions are passed when using attribute at controller or action level
            //if (string.IsNullOrEmpty(Permissions)) {
            //    //Validation cannot take place without any permissions so returning unauthorized
            //    context.Result = new UnauthorizedResult();
            //    return;
            //}
            //The below line can be used if you are reading permissions from token
            //var permissionsFromToken=context.HttpContext.User.Claims.Where(x=>x.Type=="Permissions").Select(x=>x.Value).ToList()

            //Identity.Name will have windows logged in user id, in case of Windows Authentication
            //Indentity.Name will have user name passed from token, in case of JWT Authenntication and having claim type "ClaimTypes.Name"

            // Hier gaan we dus onze custom checker schrijven voor de controle of de user is aangemeld ofniet
            // Hoe gebruiken?
            /// door in klasses, controllers etc.. bovenaan de method of gehele klasse de naam van deze klasse te schrijven
            /// ex: [UserPermission], dan zal onderstaande check worden uitgevoerd bij IEDERE request binnen deze klasse
            // hoe werkt het?
            /// return => geldige validatie
            /// redirectResult => ongeldige valdatie
            ///

            //var userName = AuthService.CheckLoggedUser();
            //if (userName.IsAdmin)
            return;

            //context.Result = new RedirectResult(string.Format("/Admin/Home/Index"));
            //return;
        }
    }
}