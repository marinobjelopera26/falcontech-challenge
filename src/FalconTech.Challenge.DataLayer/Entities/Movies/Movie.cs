using FalconTech.Challenge.DataLayer.Entities.Base;
using FalconTech.Challenge.DataLayer.Entities.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FalconTech.Challenge.DataLayer.Entities.Movies
{
    public class Movie : TrackedEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Movie name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the movie.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Duration of the movie in minutes.
        /// </summary>
        public int? Duration { get; set; }


        public ICollection<User> Users { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Invitation> Invitations { get; set; }

        [NotMapped]
        public User Director =>
            Users?.FirstOrDefault(x => x.Role?.Name == "Director");

        [NotMapped]
        public ICollection<User> Actors =>
            Users?.Where(x => x.Role?.Name == "Actor").ToList();
    }
}
