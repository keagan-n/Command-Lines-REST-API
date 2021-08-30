using System.ComponentModel.DataAnnotations;

namespace CommandLinesProj.DTOs
{
    public class CommandUpdateDto
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

//same as CommandCreateDto but it is just security for scalability of the methods