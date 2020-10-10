using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryApp.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LibraryApp.Admin
{
    public partial class Publishers : System.Web.UI.Page
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
        public IQueryable<LibraryApp.Models.publisher> publishersGrid_GetData()
        {
            LibraryContext __db = new LibraryContext();
            var query = __db.publishers;
            return query;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void publishersGrid_UpdateItem(string publisher_name)
        {
            using (LibraryContext __db = new LibraryContext())
            {
                LibraryApp.Models.publisher item = null;
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                item = __db.publishers.Find(publisher_name);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", publisher_name));
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
        public void publishersGrid_DeleteItem(string publisher_name)
        {
            using (LibraryContext __db = new LibraryContext())
            {
                var item = new publisher { publisher_name = publisher_name };
                __db.Entry(item).State = EntityState.Deleted;
                try
                {
                    __db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",  String.Format("Item with id {0} no longer exists in the database.", publisher_name));
                }
            }
        }
    }
}