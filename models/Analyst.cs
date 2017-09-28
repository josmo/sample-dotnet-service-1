using System.ComponentModel.DataAnnotations;
namespace NancyService.models
{
    public class Analyst
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SAMAccountName { get; set; } 
    }
}