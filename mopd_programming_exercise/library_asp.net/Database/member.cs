namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("library.member")]
    public partial class member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public member()
        {
            bookreviews = new HashSet<bookreview>();
            loans = new HashSet<loan>();
            books = new HashSet<book>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(30)]
        public string first_name { get; set; }

        [Required]
        [StringLength(30)]
        public string last_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime dob { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [Required]
        [StringLength(60)]
        public string email { get; set; }

        [Required]
        [StringLength(15)]
        public string phone { get; set; }

        public DateTime? date_joined { get; set; }

        public int? role_id { get; set; }

        [MaxLength(8000)]
        public byte[] profile_pic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookreview> bookreviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loan> loans { get; set; }

        public virtual role role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<book> books { get; set; }
    }
}
