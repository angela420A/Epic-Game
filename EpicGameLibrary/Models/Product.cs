namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Comment = new HashSet<Comment>();
            Image = new HashSet<Image>();
            Order = new HashSet<Order>();
            Pack = new HashSet<Pack>();
            Social_Media = new HashSet<Social_Media>();
            Library = new HashSet<Library>();
            Specifications = new HashSet<Specifications>();
        }

        public Guid ProductID { get; set; }

        [Required]
        [StringLength(20)]
        public string ContentType { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        [Required]
        [StringLength(100)]
        public string Developer { get; set; }

        [Required]
        [StringLength(100)]
        public string Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Category { get; set; }

        public int AgeRestriction { get; set; }

        public int OS { get; set; }

        [Required]
        public string Description { get; set; }

        public string LanguagesSupported { get; set; }

        public string PrivacyPolicy { get; set; }

        public string PrivacyPolicyUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pack> Pack { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Social_Media> Social_Media { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Library> Library { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specifications> Specifications { get; set; }
    }
}
