using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nancy;
using NancyService.contexts;
using NancyService.models;

namespace NancyService.endpoints
{
   public class Employees : NancyModule
    {
        public Employees(EFDBContext db)
        {
            Get("/employees", args =>
            {
                    var employes = db.Employees.ToList();
                    return Response.AsJson(employes);
            });
        }
    }


}

