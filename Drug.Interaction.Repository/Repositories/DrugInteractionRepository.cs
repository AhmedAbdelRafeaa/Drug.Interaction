using Drug.Interaction.Core.Entities;
using Drug.Interaction.Core.Repository.Contract;
using Drug.Interaction.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drug.Interaction.Repository.Repositories
{
    public class DrugInteractionRepository : IDrugInteractionRepository
    {
        private readonly DrugDbContext _context;

        public DrugInteractionRepository(DrugDbContext context)
        {
            _context = context;
        }

        

        public async Task<DrugInteraction?> GetInteractionAsync(string drug1, string drug2)
        {
            return await _context.DrugInteractions.FirstOrDefaultAsync(D => (D.Drug1 == drug1 || D.Drug1 == drug2) && (D.Drug2 == drug2 || D.Drug2 == drug1));
        }

        public async Task<IEnumerable<string>> GetDrugSuggestionsAsync(string query)
        {

            // Query Drug1 matches
            var drug1Matches = await _context.DrugInteractions
                .Where(d => d.Drug1.Contains(query))
                .Select(d => d.Drug1)
                .ToListAsync();

            // Query Drug2 matches
            var drug2Matches = await _context.DrugInteractions
                .Where(d => d.Drug2.Contains(query))
                .Select(d => d.Drug2)
                .ToListAsync();

            // Combine and remove duplicates
            var allMatches = drug1Matches.Concat(drug2Matches).Distinct();

            return allMatches;
        }
    }
}
