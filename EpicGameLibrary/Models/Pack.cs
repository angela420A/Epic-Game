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

        [Required]
        [StringLength(100)]
        public string PackName { get; set; }

        public Guid ProductID { get; set; }

        public string Img { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public decimal? Discount { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackDetail> PackDetail { get; set; }
    }
}
