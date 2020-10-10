using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryApp.Models;

namespace LibraryApp.Logic
{
    public class BookAuthorActions
    {
        public bool AddBookAuthor(string book_id, string author_id)
        {
            var bookauthor = new bookauthor
            {
                book_author_id = Guid.NewGuid(),
                book_id = book_id,
                author_id = new Guid(author_id)
            };

            using (LibraryContext __db = new LibraryContext())
            {
                __db.bookauthors.Add(bookauthor);
                __db.SaveChanges();
            }

            return true;
        }

        public bool RemoveBookAuthor(string book_id, string author_id)
        {
            using (LibraryContext __db = new LibraryContext())
            {
                try
                {
                    var bookauthor = (from ba in __db.bookauthors where ba.book_id == book_id && ba.author_id.ToString() == author_id select ba).FirstOrDefault();
                    if(bookauthor != null)
                    {
                        __db.bookauthors.Remove(bookauthor);
                        __db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception exp)
                {
                    throw new Exception("Remove ERROR: " + exp.Message.ToString(), exp);                    
                }                               
            }
        }
    }
}