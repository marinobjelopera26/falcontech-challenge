using FalconTech.Challenge.DataLayer.Entities.Base;
using FalconTech.Challenge.DataLayer.Entities.Movies;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FalconTech.Challenge.DataLayer.Entities.Identity
{
    public class User : TrackedEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public bool? EmailConfirmed { get; set; }

        public Role Role { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
    }
}
