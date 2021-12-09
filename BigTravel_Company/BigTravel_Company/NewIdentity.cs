using BigTravel_Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BigTravel_Company
{
    public static class MyIdentity
    {
        private static BigTravelEntities db = new BigTravelEntities();

        public static string FullName(this IIdentity identity)
        {
            if (db.Customer.Where(u => u.Email == identity.Name).Select(u => u.sername + " " + u.name + " " + u.patronymic).Any())
            {
                string FullName = db.Customer.Where(u => u.Email == identity.Name).Select(u => u.sername + " " + u.name + " " + u.patronymic).FirstOrDefault();
                return FullName;
            }
            else if (db.Employes.Where(u => u.Email == identity.Name).Select(u => u.sername + " " + u.name + " " + u.patronymic).Any())
            {
                string FullName = db.Employes.Where(u => u.Email == identity.Name).Select(u =>  u.name).FirstOrDefault();
                return FullName;
            }
            else
            {
                return null;
            }
        }
    }
}