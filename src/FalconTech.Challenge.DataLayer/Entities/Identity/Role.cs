using FalconTech.Challenge.DataLayer.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FalconTech.Challenge.DataLayer.Entities.Identity
{
    public class Role : TrackedEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
