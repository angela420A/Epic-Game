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

        [Column(TypeName = "money")]
        public decimal? Payment { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Product Product { get; set; }
    }
}
