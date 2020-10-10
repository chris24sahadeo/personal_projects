using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryApp.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.ModelBinding;


namespace LibraryApp.Admin
{
    public partial class Authors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<author> authorsGrid_GetData([QueryString] string book_id)
        {
            var __db = new LibraryContext();
            IQueryable<author> query = __db.authors;
            if (!string.IsNullOrEmpty(book_id))
            {
                query = (from a in __db.authors from ba in __db.bookauthors where ba.book_id == book_id && ba.author_id == a.author_id select a);

                string book_name = __db.books.Where(b => b.book_id == book_id).Select(b => b.book_name).FirstOrDefault().ToString();
                LabelAuthor.Text = "of " + book_name;
                LabelAuthor.Visible = true;
            }           

            return query;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void authorsGrid_UpdateItem(Guid author_id)
        {
            using (LibraryContext __db = new LibraryContext())
            {
                //System.Guid guid = Guid.Parse(id);

                LibraryApp.Models.author item = null;
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                item = __db.authors.Find(author_id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", author_id));
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

        // The id parameter name should match the DataKeyNames value set on the control
        public void authorsGrid_DeleteItem(Guid author_id)
        {
            //System.Guid guid = id;
            using (LibraryContext __db = new LibraryContext())
            {
                var item = new author { author_id = author_id };
                __db.Entry(item).State = EntityState.Deleted;
                try
                {
                    __db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                    String.Format("Item with id {0} no longer exists in the database.", author_id));
                }
            }
        }
    }
}