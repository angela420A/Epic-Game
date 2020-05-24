namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Social Media")]
    public partial class Social_Media
    {
        [Key]
        public Guid FollowID { get; set; }

        public Guid ProductID { get; set; }

        public string Community { get; set; }

        public string URL { get; set; }

        public virtual Product Product { get; set; }
    }
}
