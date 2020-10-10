using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryApp.Models;


namespace LibraryApp.Admin
{
    public partial class AddAuthors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addAuthorForm_InsertItem()
        {
            var item = new LibraryApp.Models.author { author_id = Guid.NewGuid() };
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                using (LibraryContext __db = new LibraryContext())
                {
                    __db.authors.Add(item);
                    __db.SaveChanges();
                }
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Authors");
        }

        protected void addAuthorForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Admin/Authors");
        }
    }
}