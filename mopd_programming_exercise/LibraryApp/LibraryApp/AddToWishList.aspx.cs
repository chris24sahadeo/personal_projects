using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using LibraryApp.Logic;

namespace LibraryApp
{
    public partial class AddToWishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string book_id = Request.QueryString["book_id"];
            if(!String.IsNullOrEmpty(book_id))
            {
                using (WishListActions usersWishList = new WishListActions())
                {
                    usersWishList.AddToWishList(book_id);
                }
            }
            else
            {
                Debug.Fail("No book_id was specified!");
                throw new Exception("ERROR: Illegal to get to this page without book_id");
            }
            Response.Redirect("WishList.aspx");
        }
    }
}