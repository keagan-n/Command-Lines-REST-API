using System.Collections.Generic;
using CommandLinesProj.Models;

//don't implement anything --> just definitions

namespace CommandLinesProj.Data
{
    public interface ICommandRepo
    //interface is list of method signatures of operations
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandByID(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}