using FalconTech.Challenge.DataLayer.Entities.Base;
using FalconTech.Challenge.DataLayer.Entities.Identity;

namespace FalconTech.Challenge.DataLayer.Entities.Movies
{
    public class Invitation : TrackedEntity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public bool WasAccepted { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
