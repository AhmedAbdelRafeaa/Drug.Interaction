using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drug.Interaction.Core.Entities
{
    public class DrugInteraction
    {
        public int Id { get; set; }
        public string Drug1 { get; set; }
        public string Drug2 { get; set; }
        public string InteractionType { get; set; }
        public string Effect { get; set; }
    }
}
