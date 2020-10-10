namespace Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Library : DbContext
    {
        public Library()
            : base("name=Library")
        {
        }

        public virtual DbSet<author> authors { get; set; }
        public virtual DbSet<book> books { get; set; }
        public virtual DbSet<bookreview> bookreviews { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
        public virtual DbSet<loan> loans { get; set; }
        public virtual DbSet<member> members { get; set; }
        public virtual DbSet<publisher> publishers { get; set; }
        public virtual DbSet<role> roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<author>()
                .HasMany(e => e.books)
                .WithMany(e => e.authors)
                .Map(m => m.ToTable("bookauthor", "library").MapLeftKey("author_id").MapRightKey("book_id"));

            modelBuilder.Entity<book>()
                .Property(e => e.edition)
                .HasPrecision(4, 1);

            modelBuilder.Entity<book>()
                .Property(e => e.rating)
                .HasPrecision(2, 1);

            modelBuilder.Entity<book>()
                .HasMany(e => e.inventories)
                .WithOptional(e => e.book)
                .WillCascadeOnDelete();

            modelBuilder.Entity<book>()
                .HasMany(e => e.members)
                .WithMany(e => e.books)
                .Map(m => m.ToTable("wishlist", "library").MapLeftKey("book_id").MapRightKey("user_id"));

            modelBuilder.Entity<bookreview>()
                .Property(e => e.rating)
                .HasPrecision(2, 1);

            modelBuilder.Entity<genre>()
                .HasMany(e => e.books)
                .WithOptional(e => e.genre)
                .WillCascadeOnDelete();

            modelBuilder.Entity<inventory>()
                .HasMany(e => e.loans)
                .WithOptional(e => e.inventory)
                .WillCascadeOnDelete();

            modelBuilder.Entity<loan>()
                .Property(e => e.loan_id)
                .IsFixedLength();

            modelBuilder.Entity<member>()
                .HasMany(e => e.bookreviews)
                .WithRequired(e => e.member)
                .HasForeignKey(e => e.reviewer_id);

            modelBuilder.Entity<member>()
                .HasMany(e => e.loans)
                .WithOptional(e => e.member)
                .WillCascadeOnDelete();

            modelBuilder.Entity<publisher>()
                .HasMany(e => e.books)
                .WithOptional(e => e.publisher)
                .WillCascadeOnDelete();

            modelBuilder.Entity<role>()
                .HasMany(e => e.members)
                .WithOptional(e => e.role)
                .WillCascadeOnDelete();
        }
    }
}
