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
    public partial class Browse : System.Web.UI.Page
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
        public IQueryable<LibraryApp.Models.book> bookList_GetData([QueryString("id")] string query_string)
        {
            var __db = new LibraryApp.Models.LibraryContext();
            IQueryable<book> query = __db.books;
            if(!string.IsNullOrEmpty(query_string))           
                query = query.Where(p => p.genre_name == query_string || p.book_name.Contains(query_string));
            return query;
        }
    }
}