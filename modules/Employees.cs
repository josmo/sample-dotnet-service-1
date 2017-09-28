using System;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using Nancy;
using Nancy.ModelBinding;
using NancyService.contexts;
using NancyService.helpers;
using NancyService.models;

namespace NancyService.modules
{
   public class Employees : NancyModule
    {
        public Employees(EFDBContext db)
        {
            Get("/employees", LoggingWrapper.requestLog(this,args =>
            {
                    var employes = db.Employees.ToList();
                    return Response.AsJson(employes);
            }));
            
            Get("/employees/{id}", LoggingWrapper.requestLog(this, args =>
            {
                int empId = args.id;
                var employee = db.Employees.FirstOrDefault(emp => emp.Id == empId);
                return Response.AsJson(employee);
            }));
            
            Delete("/employees/{id}", LoggingWrapper.requestLog(this,args =>
            {
                int empId = args.id;
                var employee = db.Employees.FirstOrDefault(emp => emp.Id == empId);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return HttpStatusCode.OK;
            }));
            
            Post("/employees/new", LoggingWrapper.requestLog(this,args =>
            {
                var employee = this.Bind<Employee>();
                db.Employees.Add(employee);
                db.SaveChanges();
                return Response.AsJson(employee);
            }));
            
            Get("/generate", LoggingWrapper.requestLog(this,args =>
            {
                
                var testEmployees = new Faker<Employee>()
                    .RuleFor(u => u.Name, f => f.Name.FullName(Name.Gender.Male))
                    .RuleFor(u => u.Age, f => f.Random.Int(15, 60))
                    .RuleFor(u => u.Status, f => f.Random.Word());
                var employees = testEmployees.Generate(1000);
                db.Employees.AddRange(employees);
                db.SaveChanges();
                return HttpStatusCode.OK;
            }));
        }
    }


}

