using AutoMapper;
using CommandLinesProj.DTOs;
using CommandLinesProj.Models;

namespace CommandLinesProj.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command,CommandUpdateDto>();
        }
    }
}