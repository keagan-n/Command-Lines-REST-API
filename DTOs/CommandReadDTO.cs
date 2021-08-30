namespace CommandLinesProj.DTOs
{
    public class CommandReadDto
    {
        //properties of the data model
        
        public int ID {get;set;}

        
        public string HowTo {get;set;}
        
      
        public string Line{get;set;}
        
        //we don't need platform because implementation details don't need to be exposed to client
        //***for illustration purposes***
        //public string Platform{get;set;}
    }
}