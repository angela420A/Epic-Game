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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActivityID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public Guid IMG { get; set; }
    }
}
