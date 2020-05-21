namespace EpicGameLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PackDetail")]
    public partial class PackDetail
    {
        public Guid PackDetailID { get; set; }

        public Guid PackID { get; set; }

        public Guid ProductID { get; set; }

        public virtual Pack Pack { get; set; }

        public virtual Product Product { get; set; }
    }
}
