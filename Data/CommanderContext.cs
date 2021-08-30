using CommandLinesProj.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLinesProj.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt): base(opt)
        {

        }

        //need to map models to database --> we only have one model
        public DbSet<Command> Commands {get; set; }
    }
}