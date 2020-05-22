namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Specifications
    {
        public Guid SpecificationsID { get; set; }

        public Guid ProductID { get; set; }

        [StringLength(40)]
        public string OS { get; set; }

        [StringLength(40)]
        public string CPU { get; set; }

        [StringLength(40)]
        public string RAM { get; set; }

        [StringLength(40)]
        public string GPU { get; set; }

        [StringLength(40)]
        public string VRAM { get; set; }

        [StringLength(2000)]
        public string Language { get; set; }

        public virtual Produuct Produuct { get; set; }
    }
}
