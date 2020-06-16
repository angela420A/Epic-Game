namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public Guid NewsID { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(500)]
        public string NewsTitle { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        public string NewsImg { get; set; }
    }
}
