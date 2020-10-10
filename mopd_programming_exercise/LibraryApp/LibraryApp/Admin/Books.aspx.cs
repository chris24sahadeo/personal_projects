using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryApp.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Configuration;
using System.Web.ModelBinding;

namespace LibraryApp.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<LibraryApp.Models.book> booksGrid_GetData([Control] string TextBoxSearch )
        {
            LibraryContext __db = new LibraryContext();
            IQueryable<book> query = __db.books;
            if (!string.IsNullOrEmpty(TextBoxSearch))
            {
                query = query.Where(b => b.book_name.Contains(TextBoxSearch));
            }
            return query;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void booksGrid_UpdateItem(string book_id)
        {

            using (LibraryContext __db = new LibraryContext())
            {
                LibraryApp.Models.book item = null;
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                item = __db.books.Find(book_id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", book_id));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    __db.SaveChanges();
                }
            }
        }

        public void booksGrid_UpdateItem2(string book_id)
        {
            Response.Redirect("~/Admin/AddBook2?book_id=" + book_id);
        }


        // The id parameter name should match the DataKeyNames value set on the control
        public void booksGrid_DeleteItem(string book_id)
        {
            using (LibraryContext __db = new LibraryContext())
            {
                
                try
                {
                    var item = new book { book_id = book_id };
                    //__db.books.Remove(item);
                    __db.Entry(item).State = EntityState.Deleted;
                    __db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                    String.Format("Item with id {0} no longer exists in the database.", book_id));
                    LabelResponse.Text = "Delete Error";
                }
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
    }

     
}