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

        public Guid ProductID { get; set; }

        [StringLength(20)]
        public string Author { get; set; }

        [StringLength(20)]
        public string NewsTitle { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public Guid NewsImg { get; set; }
    }
}
