using System.Collections.Generic;
using AutoMapper;
using CommandLinesProj.Data;
using CommandLinesProj.DTOs;
using CommandLinesProj.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

//consistency as long as we have a consistent interface to pull and derive from

namespace CommandLinesProj.Controllers
{

    [Route("api/commands")] // similar to routes in Flask
    [ApiController] //decorator for class
    public class CommandsController : ControllerBase
    {

        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;
        

        //create a constructor for dependency injection system
        public CommandsController(ICommandRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
            //"Ok" returns "200 success"
        }

        //GET api/commands/{id}  -->beyond basic route above
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandByID(id);
            if(commandItem != null)
            {

                //read dto with data mapped to empty command object
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
            
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto cmdCreateDto)
        {
            //returns CommandReadDto

            //createDto to empty command
            var commandModel = _mapper.Map<Command>(cmdCreateDto);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {id = commandReadDto},commandReadDto);

            
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto cmdUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            //both UpdateDto and commandModel contain data before mapping
            _mapper.Map(cmdUpdateDto,commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges(); //saves changes to DB

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            //have to apply patch document to command model

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            //                              target              source

            patchDoc.ApplyTo(commandToPatch,ModelState);
            //modelstate makes sures that the validations are valid

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch,commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //DELETE doesn't need a DTO 
        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
        
            return NoContent();
        }

    }
}