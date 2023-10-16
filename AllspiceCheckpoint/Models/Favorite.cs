using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllspiceCheckpoint.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int RecipeId { get; set; }
    }
}