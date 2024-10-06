using Microsoft.EntityFrameworkCore;

namespace Hackaton.Database
{
    public class DatabaseContex : DbContext
    {
        public DatabaseContex(DbContextOptions<DatabaseContex> options): base(options)
        {

        }
    }
}