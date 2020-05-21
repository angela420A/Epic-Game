namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        [Column(Order = 0)]
        public int CategoryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Type { get; set; }
    }
}
