namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PackDetail")]
    public partial class PackDetail
    {
        [Key]
        [Column(Order = 0)]
        public Guid PackID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ProductID { get; set; }

        public virtual Pack Pack { get; set; }
    }
}
