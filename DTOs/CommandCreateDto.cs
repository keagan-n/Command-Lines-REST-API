using System.ComponentModel.DataAnnotations;

namespace CommandLinesProj.DTOs
{
    public class CommandCreateDto
    {
        //public int Id{get ; set;}

        [Required]
        [MaxLength(150)]
        public string HowTo {get; set;}

        [Required]
        public string Line {get; set;}

        [Required]
        public string Platform {get; set;}
    }
}