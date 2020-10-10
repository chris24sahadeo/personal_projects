using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryApp.Models;
using System.Web.ModelBinding;

namespace LibraryApp
{
    public partial class BookDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IQueryable<book> bookDetail_GetItem([QueryString("book_id") ]string book_id)
        {
            var __db = new LibraryApp.Models.LibraryContext();
            IQueryable<book> query = __db.books;
            if(!string.IsNullOrEmpty(book_id))
            {
                query = query.Where(p => p.book_id == book_id);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}