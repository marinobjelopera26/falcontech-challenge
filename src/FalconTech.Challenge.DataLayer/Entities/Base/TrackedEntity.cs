using System;
using System.ComponentModel.DataAnnotations;

namespace FalconTech.Challenge.DataLayer.Entities.Base
{
    public class TrackedEntity
    {
        [Required]
        public string SYSUSER { get; set; }

        [Required]
        public DateTime SYSDATE { get; set; }
    }
}
