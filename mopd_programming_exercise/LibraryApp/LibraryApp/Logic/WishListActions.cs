using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryApp.Models;

namespace LibraryApp.Logic
{
    public class WishListActions : IDisposable
    {
        public string WishListId { get; set; }

        private LibraryContext __db = new LibraryContext();

        public const string WishListSessionKey = "WishListId";

        public void AddToWishList(string book_id)
        {
            // get wishlist id - same as the user id
            WishListId = GetWishListId();

            // checks if the item is already in the wishlist
            var wishListItem = __db.wishlistitems.SingleOrDefault(wl => wl.user_id == WishListId && wl.book_id == book_id);
            if(wishListItem == null)
            {
                // make a new wishlistitem and add to list
                wishListItem = new wishlistitem
                {
                    wish_list_item_id = Guid.NewGuid(),
                    book_id = book_id,
                    user_id = WishListId,
                    book = __db.books.SingleOrDefault(b => b.book_id == book_id),
                    date_created = DateTime.Now
                };

                __db.wishlistitems.Add(wishListItem);
            }
            else
            {
                // TODO: AJAX modal popup
            }
            __db.SaveChanges();
        }

        public void Dispose()
        {
            if(__db != null)
            {
                __db.Dispose();
                __db = null;
            }
        }

        // gets user id associated with the current wishlist
        public string GetWishListId()
        {
            if (HttpContext.Current.Session[WishListSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[WishListSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // generate new random GUID
                    Guid tempWishListId = Guid.NewGuid();
                    HttpContext.Current.Session[WishListSessionKey] = tempWishListId.ToString();
                }
            }
            return HttpContext.Current.Session[WishListSessionKey].ToString();
        }

        public WishListActions GetWishList(HttpContext context)
        {
            using (var wishListActions = new WishListActions())
            {
                wishListActions.WishListId = wishListActions.GetWishListId();
                return wishListActions;
            }
        }

        internal void UpdateWishListDatabase(string wishListId, WishListUpdates[] wishListUpdates)
        {
            //throw new NotImplementedException();
            using (var db = new LibraryApp.Models.LibraryContext())
            {
                try
                {
                    int wishListItemCount = wishListUpdates.Count();
                    List<wishlistitem> myWishList = GetWishListItems();
                    foreach (var wishListItem in myWishList)
                    {
                        for (int i = 0; i < wishListItemCount; i++)
                        {
                            if (wishListItem.book.book_id == wishListUpdates[i].book_id)
                            {
                                if(wishListUpdates[i].removeItem == true)
                                {
                                    RemoveItem(wishListId, wishListItem.book_id);
                                }
                                else
                                {
                                    // update
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Update ERROR: " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeWishListId, string removeBookId)
        {
            using (var __db = new LibraryApp.Models.LibraryContext())
            {
                try
                {
                    var myItem = (from i in __db.wishlistitems where i.user_id == removeWishListId && i.book_id == removeBookId select i).FirstOrDefault();
                    if(myItem != null)
                    {
                        __db.wishlistitems.Remove(myItem);
                        __db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Remove ERROR: " + exp.Message.ToString(), exp);
                }
            }
        }

        // UpdateItem

        // EmptyCart

        // count for wishlist icon
        public int GetCount()
        {
            WishListId = GetWishListId();
            int? count = (from wishListItem in __db.wishlistitems
                          where wishListItem.user_id == WishListId
                          select wishListItem).Count();
            return count ?? 0;
        }

        public List<wishlistitem> GetWishListItems()
        {
            WishListId = GetWishListId();

            return __db.wishlistitems.Where(wl => wl.user_id == WishListId).ToList();
        }

        public struct WishListUpdates
        {
            public string book_id;
            public bool removeItem;
        }

        public void MigrateWishList(string wishListId, string userName)
        {
            var wishList = __db.wishlistitems.Where(wl => wl.user_id == wishListId);
            foreach (wishlistitem wishListItem in wishList)
            {
                wishListItem.user_id = userName;
            }
            HttpContext.Current.Session[WishListSessionKey] = userName;
            __db.SaveChanges();
        }

    }
}