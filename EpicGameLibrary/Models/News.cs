namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public Guid NewsID { get; set; }

        public Guid ProductID { get; set; }

        public Guid AuthorID { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Product Product { get; set; }
    }
}
