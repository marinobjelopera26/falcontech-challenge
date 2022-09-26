using FalconTech.Challenge.DataLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FalconTech.Challenge.DataLayer.Entities.Movies
{
    public class Genre : TrackedEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
