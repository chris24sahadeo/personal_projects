using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryApp.Models;
using LibraryApp.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;
using System.Diagnostics;

namespace LibraryApp
{
    public partial class WishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // total calc
        }

        public List<wishlistitem> GetWishListItems()
        {
            WishListActions wishListActions = new WishListActions();
            return wishListActions.GetWishListItems();
        }

        // updates the GridView
        public List<wishlistitem> UpdateWishListItems()
        {
            using (WishListActions usersWishList = new WishListActions())
            {
                // get user id
                String wishListId = usersWishList.GetWishListId();

                // get list of updates from current GridView state
                WishListActions.WishListUpdates[] wishListUpdates = new WishListActions.WishListUpdates[WishListGridViewId.Rows.Count];
                for (int i = 0; i < WishListGridViewId.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(WishListGridViewId.Rows[i]);
                    wishListUpdates[i].book_id = Convert.ToString(rowValues["book_id"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)WishListGridViewId.Rows[i].FindControl("Remove");
                    wishListUpdates[i].removeItem = cbRemove.Checked;
                }
                usersWishList.UpdateWishListDatabase(wishListId, wishListUpdates);
                WishListGridViewId.DataBind();
                return usersWishList.GetWishListItems();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateWishListItems();
            Debug.WriteLine("Update Btn Clicked.");
        }

        //checkout btn
    }
}