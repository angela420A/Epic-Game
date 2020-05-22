namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produuct")]
    public partial class Produuct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produuct()
        {
            Comment = new HashSet<Comment>();
            Editions = new HashSet<Editions>();
            Follow = new HashSet<Follow>();
            Library = new HashSet<Library>();
            News = new HashSet<News>();
            Order = new HashSet<Order>();
            Pack = new HashSet<Pack>();
            Specifications = new HashSet<Specifications>();
        }

        [Key]
        public Guid ProductID { get; set; }

        [Required]
        public string OutImg { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        public string InImg { get; set; }

        [Required]
        public string GameLogo { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }

        [Required]
        [StringLength(20)]
        public string Developer { get; set; }

        [Required]
        [StringLength(20)]
        public string Publisher { get; set; }

        public DateTime Date { get; set; }

        public int Label { get; set; }

        public int Age { get; set; }

        public int Os { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public Guid Img_ListID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Editions> Editions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Follow> Follow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Library> Library { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        public virtual P_Img P_Img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pack> Pack { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specifications> Specifications { get; set; }
    }
}
