using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryApp.Models;

namespace LibraryApp.Logic
{
    public class BookActions : IDisposable
    {
        private LibraryContext __db = new LibraryContext();


        public bool AddBook(string book_id, string book_name, string edition, string year_published, string publisher_name, string genre_name, string cover_photo_path, string rating, string summary)
        {
            var book = new book();
            book.book_id = book_id;
            book.book_name = book_name;
            book.edition = Convert.ToDecimal(edition);
            book.year_published = Convert.ToInt16(year_published);
            book.publisher_name = publisher_name;
            book.genre_name = genre_name;
            book.cover_photo_path = cover_photo_path;
            book.rating = Convert.ToDecimal(rating);
            book.summary = summary;

           
            __db.books.Add(book);
            __db.SaveChanges();
            
            return true;
        }

        public bool UpdateBook(string old_id, string book_id, string book_name, string edition, string year_published, string publisher_name, string genre_name, string cover_photo_path, string rating, string summary)
        {
            var book = __db.books.Where(b => b.book_id == old_id).FirstOrDefault();

            if(book != null)
            {
                book.book_id = book_id;
                book.book_name = book_name;
                book.edition = Convert.ToDecimal(edition);
                book.year_published = Convert.ToInt16(year_published);
                book.publisher_name = publisher_name;
                book.genre_name = genre_name;
                if (!string.IsNullOrEmpty(cover_photo_path))
                {
                    book.cover_photo_path = cover_photo_path;
                }

                book.rating = Convert.ToDecimal(rating);
                book.summary = summary;

                __db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                __db.SaveChanges();

                return true;
            }
            return true;

        }

        public void Dispose()
        {
            if(__db != null)
            {
                __db.Dispose();
                __db = null;
            }
        }
    }
}