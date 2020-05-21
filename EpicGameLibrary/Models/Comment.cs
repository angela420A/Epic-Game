namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public Guid CommentID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public Guid ProductID { get; set; }

        [StringLength(1000)]
        public string Text { get; set; }

        public int Rank { get; set; }

        public DateTime DateTime { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Product Product { get; set; }
    }
}
