using Microsoft.EntityFrameworkCore;
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
    public class Analyst : NancyModule
    {
        public Analyst(EFDBContext db)
        {
            Get("/analysts", LoggingWrapper.requestLog(this,args =>
            {
                var analysts = db.Analysts.ToList();
                return Response.AsJson(analysts);
            }));
            
            Get("/analysts/{id}", LoggingWrapper.requestLog(this, args =>
            {
                int valueId = args.id;
                var analyst  = db.Analysts.FirstOrDefault(value => value.Id == valueId);
                return Response.AsJson(analyst);
            }));
            
            Delete("/analysts/{id}", LoggingWrapper.requestLog(this,args =>
            {
                int valueId = args.id;
                var analyst = db.Analysts.FirstOrDefault(analy => analy.Id == valueId);
                db.Analysts.Remove(analyst);
                db.SaveChanges();
                return HttpStatusCode.OK;
            }));
            
            Post("/analysts/new", LoggingWrapper.requestLog(this,args =>
            {
                var analyst = this.Bind<models.Analyst>();
                db.Analysts.Add(analyst);
                db.SaveChanges();
                return Response.AsJson(analyst);
            }));
            
            Get("/analysts/seed", LoggingWrapper.requestLog(this,args =>
            {
                var testAnalysts = new Faker<models.Analyst>()
                    .RuleFor(u => u.Name, f => f.Name.FullName(Name.Gender.Female))
                    .RuleFor(u => u.SAMAccountName, f => f.Random.Word());
                
                var analysts = testAnalysts.Generate(50);
                db.Analysts.AddRange(analysts);
                db.SaveChanges();
                return HttpStatusCode.OK;
            }));
        }
    }
}