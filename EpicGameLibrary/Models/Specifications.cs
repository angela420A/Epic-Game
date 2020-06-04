namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Specifications
    {
        [Key]
        public Guid ProductID { get; set; }

        [StringLength(100)]
        public string OS { get; set; }

        [StringLength(100)]
        public string Processor { get; set; }

        [StringLength(50)]
        public string RAM { get; set; }

        [StringLength(200)]
        public string GraphicsCard { get; set; }

        [StringLength(50)]
        public string HDD { get; set; }

        public int? Typ { get; set; }
    }
}
