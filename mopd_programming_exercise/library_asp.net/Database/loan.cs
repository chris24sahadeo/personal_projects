namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("library.loan")]
    public partial class loan
    {
        [Key]
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] loan_id { get; set; }

        public DateTime? date_borrowed { get; set; }

        public DateTime date_due { get; set; }

        public DateTime? date_returned { get; set; }

        public int? item_id { get; set; }

        public int? user_id { get; set; }

        public virtual inventory inventory { get; set; }

        public virtual member member { get; set; }
    }
}
