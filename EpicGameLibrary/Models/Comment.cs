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

        [StringLength(20)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public int Rank { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Product Product { get; set; }
    }
}
