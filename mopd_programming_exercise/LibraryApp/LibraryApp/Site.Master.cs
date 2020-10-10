using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Linq;
using LibraryApp.Models;
using LibraryApp.Logic;

namespace LibraryApp
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        private void CreateDropDownCategoryList()
        {
            // get list
            var __db = new LibraryApp.Models.LibraryContext();
            List<string> genreList = (from genre in __db.genres select genre.genre_name).ToList<string>();
            List<string> menuHtml = new List<string>();
            menuHtml.Add("<li><a runat=\"server\" href=\"../Browse\">All Genres</a></li>");
            foreach (string genre_name in genreList)
            {
                //var linkMenu = new HyperLink() { CssClass = "dropdown-item", NavigateUrl = "/Browse.aspx?id=" + genre_name, Text = "\"" + genre_name + "\"\n" };
                menuHtml.Add("<li><a runat=\"server\" href=\"../Browse.aspx?id=" + genre_name + "\">" + genre_name + "</a></li>");
                //menuHtml += "<a class=\"dropdown-item\" href=/Browse.aspx?id=" + genre_name + "></a>\n";
            }
            //DropDownCategoryList.InnerHtml = menuHtml;
            DropDownCategoryList.InnerHtml = String.Join("\n", menuHtml);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("canEdit"))
            {
                adminLink.Visible = true;
            }

            CreateDropDownCategoryList();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (WishListActions usersWishList = new WishListActions())
            {
                string wishListString = string.Format("Wish List ({0})", usersWishList.GetCount());
                wishListCount.InnerText = wishListString;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<LibraryApp.Models.genre> CategoryList_GetData()
        {
            var __db = new LibraryApp.Models.LibraryContext();
            IQueryable<genre> query = __db.genres;
            return query;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchMaster.Text.Trim(); // URL encode in case of special characters
            Response.Redirect("~/Browse.aspx?id=" + searchText);
        }
    }

}