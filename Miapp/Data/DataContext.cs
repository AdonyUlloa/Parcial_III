using Microsoft.EntityFrameworkCore;
using webAPIParcial.Models;

namespace webAPIParcial.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() {}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) {}

        public DbSet<Departamento> Departamentos {get; set;}
        public DbSet<Municipio> Municipios {get; set;}

    }
    
}