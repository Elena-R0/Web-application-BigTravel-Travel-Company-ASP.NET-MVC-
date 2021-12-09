using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BigTravel_Company.Models;

namespace BigTravel_Company
{
    public class NewRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (BigTravelEntities db = new BigTravelEntities())
            {
               
                    string[] roles = new string[1];
                    if (db.Customer.Where(a => a.Email == username).Any())
                    {
                        roles[0] = "Customer";
                        return roles;
                    }
                    else if (db.Employes.Where(a => a.Email == username).Any())
                    {
                        roles[0] = "Employes";
                        return roles;
                    }
                else return null;
            }
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            string roles = GetRolesForUser(username)[0];
            if (roleName.Equals(roles, StringComparison.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}