namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pack")]
    public partial class Pack
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pack()
        {
            PackDetail = new HashSet<PackDetail>();
        }

        public Guid PackID { get; set; }

        public Guid ProductID { get; set; }

        [Required]
        [StringLength(60)]
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public int Type { get; set; }

        public DateTime Date { get; set; }

        public Guid DeveloperID { get; set; }

        public Guid PulisherID { get; set; }

        [Required]
        [StringLength(2)]
        public string Restriction { get; set; }

        public Guid RelateProductID { get; set; }

        public decimal Discount { get; set; }

        public virtual Company Company { get; set; }

        public virtual Company Company1 { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackDetail> PackDetail { get; set; }
    }
}
