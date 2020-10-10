namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("library.bookreview")]
    public partial class bookreview
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string book_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reviewer_id { get; set; }

        [Required]
        [StringLength(1000)]
        public string review { get; set; }

        public decimal? rating { get; set; }

        public virtual book book { get; set; }

        public virtual member member { get; set; }
    }
}
