namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public Guid OrderID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public Guid ProductID { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        public virtual Pack Pack { get; set; }

        public virtual Produuct Produuct { get; set; }
    }
}