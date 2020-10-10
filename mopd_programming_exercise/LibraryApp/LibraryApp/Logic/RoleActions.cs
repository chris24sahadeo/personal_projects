using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibraryApp.Logic
{
    internal class RoleActions
    {
        internal static void AdduserAndRole()
        {
            //throw new NotImplementedException();

            // application context inherited from asp identity
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult idRoleResult, idUserResult;

            //to store and manage roles??
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // make edit role
            string roleName1 = "canEdit";
            if(!roleManager.RoleExists(roleName1))
            {
                idRoleResult = roleManager.Create(new IdentityRole { Name = roleName1 });
            }

            // to manage users??
            string userNameAndEmail = "chris@chrislibrary.com";
            string password = "Ab!234";
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = userNameAndEmail,
                Email = userNameAndEmail
            };
            idUserResult = userManager.Create(appUser, password);

            // check if created then add to the canEdit role once it doesn't already exist
            if (!userManager.IsInRole(userManager.FindByEmail(userNameAndEmail).Id, roleName1))
            {
                idUserResult = userManager.AddToRole(userManager.FindByEmail(userNameAndEmail).Id, roleName1);
            }

        }
    }
}