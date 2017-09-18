using System.Linq;
using Nancy;
using NancyService.contexts;

namespace NancyService.modules
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
            
            Get("/employees/{id}", args =>
            {
                int empId = args.id;
                var employee = db.Employees.First(emp => emp.Id == empId);
                return Response.AsJson(employee);
            });
        }
    }


}

