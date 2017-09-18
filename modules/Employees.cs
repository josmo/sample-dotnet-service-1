using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using NancyService.contexts;
using NancyService.models;

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
                var employee = db.Employees.FirstOrDefault(emp => emp.Id == empId);
                return Response.AsJson(employee);
            });
            
            Delete("/employees/{id}", args =>
            {
                int empId = args.id;
                var employee = db.Employees.FirstOrDefault(emp => emp.Id == empId);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return HttpStatusCode.OK;
            });
            
            Post("/employees/new", args =>
            {
                var employee = this.Bind<Employee>();
                db.Employees.Add(employee);
                db.SaveChanges();
                return Response.AsJson(employee);
            });
        }
    }


}

