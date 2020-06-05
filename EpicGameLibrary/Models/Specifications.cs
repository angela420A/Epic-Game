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
        [Column(Order = 0)]
        public Guid ProductID { get; set; }

        [StringLength(200)]
        public string OS { get; set; }

        [StringLength(200)]
        public string CPU { get; set; }

        [StringLength(200)]
        public string GPU { get; set; }

        [StringLength(200)]
        public string Processor { get; set; }

        [StringLength(200)]
        public string RAM { get; set; }

        [StringLength(50)]
        public string Memory { get; set; }

        [StringLength(50)]
        public string Storage { get; set; }

        [StringLength(200)]
        public string GraphiceCard { get; set; }

        [StringLength(50)]
        public string HDD { get; set; }

        [StringLength(50)]
        public string DirectX { get; set; }

        [Column("Additional Features")]
        [StringLength(200)]
        public string Additional_Features { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Type { get; set; }

        public virtual Product Product { get; set; }
    }
}
