using System.ComponentModel.DataAnnotations;

namespace CommandLinesProj.Models
{
    public class Command
    {
        //properties of the data model
        
        [Key]
        public int ID {get;set;}

        [Required]
        [MaxLength(150)]
        public string HowTo {get;set;}
        
        [Required]
        public string Line{get;set;}
        
        [Required]
        public string Platform{get;set;}
    }
}