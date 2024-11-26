using Drug.Interaction.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drug.Interaction.Repository.Data.Contexts
{
    public class DrugDbContext : DbContext
    {
        public DrugDbContext(DbContextOptions<DrugDbContext> options) :base(options) 
        {
            
        }
        public DbSet<DrugInteraction>  DrugInteractions { get; set; }
    }
}
