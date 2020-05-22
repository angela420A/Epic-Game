namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Library")]
    public partial class Library
    {
        public Guid LibraryID { get; set; }

        public Guid UserID { get; set; }

        public Guid ProductID { get; set; }

        [Required]
        [StringLength(20)]
        public string Condition { get; set; }

        public virtual Produuct Produuct { get; set; }
    }
}
