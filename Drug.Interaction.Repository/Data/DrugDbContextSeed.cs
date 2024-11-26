using Drug.Interaction.Core.Entities;
using Drug.Interaction.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Drug.Interaction.Repository.Data
{
    public static class DrugDbContextSeed
    {
        public async static Task SeedAsync(DrugDbContext _context)
        {
            if(_context.DrugInteractions.Count() == 0)
            {
                // 1.Read Data From Json File

                var drugData = File.ReadAllText(@"..\Drug.Interaction.Repository\Data\DataSeed\DrugInteraction.json");

                // 2. Confert Json String To List<T>

                var drugs = JsonSerializer.Deserialize<List<DrugInteraction>>(drugData);

                // 3. Seed Data To DB
                if (drugs is not null && drugs.Count() > 0)
                {
                    await _context.DrugInteractions.AddRangeAsync(drugs);

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
