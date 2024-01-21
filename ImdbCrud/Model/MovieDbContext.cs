using Microsoft.EntityFrameworkCore;
using static ImdbCrud.Model.MovieDbContext;

namespace ImdbCrud.Model
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
            {

            }
            public DbSet<Movies> movies { get; set; }
        }
    }
