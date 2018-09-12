using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using MembershipApps.Models;

namespace MembershipApps.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserFirstName(this IIdentity identity)
        {
            var db = ApplicationDbContext.Create();
            var user = db.Users.FirstOrDefault(u => u.UserName.Equals(identity.Name));
            return user != null ? user.FirstName : string.Empty;
        }

        public static async Task GerUsers(this List<UserViewModel> userView)
        {
            var db = ApplicationDbContext.Create();
            userView.AddRange(await (from u in db.Users
                select new UserViewModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName
                }).OrderBy(o=>o.Email).ToListAsync());
        }
    }
}