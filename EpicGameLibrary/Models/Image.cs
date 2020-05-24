namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImgID { get; set; }

        [Required]
        public string Url { get; set; }

        public int Location { get; set; }

        public Guid ProductOrPack { get; set; }

        public virtual Product Product { get; set; }
    }
}
