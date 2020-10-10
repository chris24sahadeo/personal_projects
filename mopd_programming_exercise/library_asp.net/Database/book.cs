namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("library.book")]
    public partial class book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public book()
        {
            bookreviews = new HashSet<bookreview>();
            inventories = new HashSet<inventory>();
            authors = new HashSet<author>();
            members = new HashSet<member>();
        }

        [Key]
        [StringLength(13)]
        public string book_id { get; set; }

        [Required]
        [StringLength(100)]
        public string book_name { get; set; }

        public decimal edition { get; set; }

        public short year_published { get; set; }

        [StringLength(60)]
        public string publisher_name { get; set; }

        [StringLength(60)]
        public string genre_name { get; set; }

        [MaxLength(8000)]
        public byte[] cover_photo { get; set; }

        public decimal? rating { get; set; }

        [StringLength(4000)]
        public string summary { get; set; }

        public virtual genre genre { get; set; }

        public virtual publisher publisher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookreview> bookreviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inventory> inventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<author> authors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<member> members { get; set; }
    }
}
