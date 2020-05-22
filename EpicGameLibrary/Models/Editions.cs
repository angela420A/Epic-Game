namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Editions
    {
        public Guid EditionsID { get; set; }

        public Guid ProductID { get; set; }

        public Guid Img { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }

        [StringLength(20)]
        public string Condition { get; set; }

        public virtual Produuct Produuct { get; set; }
    }
}
