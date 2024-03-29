namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        public int ActivityID { get; set; }

        [Required]
        [StringLength(100)]
        public string ActivityName { get; set; }

        [Required]
        [StringLength(100)]
        public string Slogan { get; set; }

        [Required]
        [StringLength(300)]
        public string Information { get; set; }

        [Required]
        public string IMG { get; set; }

        public DateTime Date { get; set; }
    }
}
