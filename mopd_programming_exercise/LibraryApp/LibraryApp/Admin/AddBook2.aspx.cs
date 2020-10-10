using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryApp.Models;
using LibraryApp.Logic;
using System.Web.ModelBinding;
using System.Diagnostics;

namespace LibraryApp.Admin
{
    public partial class AddBook2 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //    addOrEdit();
            if (!IsPostBack)
            {
                string query_string = Request.QueryString["book_id"];
                // if not empty query string
                // update book
                if (!string.IsNullOrEmpty(query_string))
                {
                    id_row.Visible = false;
                    // populate form                    
                    populateForm(query_string);
                    //BookButton.OnClientClick = "UpdateBookButton_Clicked";
                    this.Title = "Edit Book";
                    BookButton.Text = "Update Book";

                }
                else // add new book
                {
                    //BookButton.OnClientClick = "AddBookButton_Clicked";
                    this.Title = "Add Book";
                    //BookButton.Text = "Add Book";
                }
            }
           
        }

        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    addOrEdit();   
        //}

        //public void addOrEdit()
        //{
            
        //}

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            string query_string = Request.QueryString["book_id"];
            string book_id = query_string;
            var __db = new LibraryContext();
            book book = __db.books.Where(b => b.book_id == book_id).FirstOrDefault();
            if (!string.IsNullOrEmpty(query_string))
            {
                foreach (bookauthor bookauthor in book.bookauthors)
                {
                    foreach (ListItem li in AddAuthors.Items)
                    {
                        //li.Selected = false;
                        if (li.Value == bookauthor.author_id.ToString() && bookauthor.book_id == book_id)
                        {
                            li.Selected = true;
                        }
                    }
                }
            }
        }

        public void CancelButton_Clicked (object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Books");
        }

        public void populateForm(string book_id)
        {
            var __db = new LibraryContext();
            book book = __db.books.Where(b => b.book_id == book_id).FirstOrDefault();

            AddISBN.Text = book.book_id;
            AddBookName.Text = book.book_name;
            AddEdition.Text = book.edition.ToString();
            AddYear.Text = book.year_published.ToString();
            DropDownAddPublisher.SelectedValue = book.publisher_name;
            DropDownAddGenre.SelectedValue = book.genre_name;
            //BookImage.FileName = book.cover_photo_path;
            AddRating.Text = book.rating.ToString();
            AddSummary.Text = book.summary;            
        }

        private bool addBookAuthors()
        {
            bool addBookAuthorSuccess = true;
            foreach (ListItem li in AddAuthors.Items)
            {
                if (li.Selected == true)
                {
                    var bookauthoractions = new BookAuthorActions();
                    addBookAuthorSuccess = bookauthoractions.AddBookAuthor(AddISBN.Text, li.Value);
                    if (!addBookAuthorSuccess)
                    {
                        return false;                        
                    }
                }
            }
            return true;
        }

        private bool removeBookAuthors()
        {
            string book_id = Request.QueryString["book_id"];
            var baa = new BookAuthorActions();

            foreach (ListItem li in AddAuthors.Items)
            {              
                
               baa.RemoveBookAuthor(book_id, li.Value);
                
            }
            return true;
        }

        protected void AddBookButton_Clicked(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String file_path = Server.MapPath("~/Images/book_covers/");
            if(BookImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(BookImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                foreach(String extention in allowedExtensions)
                {
                    if(fileExtension == extention)
                    {
                        fileOK = true;
                        break;
                    }
                }
            }

            if (fileOK || !BookImage.HasFile)
            {
                try
                {
                    BookImage.PostedFile.SaveAs(file_path + BookImage.FileName);
                }
                catch (Exception ex)
                {
                    Debug.Fail("ERROR: " + ex.Message);
                    //LabelAddStatus.Text = "ERROR: " + ex.Message;
                }

                string query_string = Request.QueryString["book_id"];
                if (!string.IsNullOrEmpty(query_string)) // update book
                {
                    // update book
                    BookActions bookActions = new BookActions();
                    bool updateBookSuccess = bookActions.UpdateBook(
                        query_string,
                        AddISBN.Text,
                        AddBookName.Text,
                        AddEdition.Text,
                        AddYear.Text,
                        DropDownAddPublisher.SelectedValue,
                        DropDownAddGenre.SelectedValue,
                        BookImage.FileName,
                        AddRating.Text,
                        AddSummary.Text
                     );

                    // remove related bookauthors
                    bool removeBookAuthorSuccess = removeBookAuthors();

                    // add new authors
                    bool addBookAuthorSuccess = addBookAuthors();

                    if (updateBookSuccess && addBookAuthorSuccess && removeBookAuthorSuccess)
                    {
                        //string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        //Response.Redirect(pageUrl);
                        LabelAddStatus.Text = "Book Updated!";
                        Response.Redirect("~/Admin/Books");
                    }
                    else
                    {
                        Debug.Fail("ERROR updating book");
                        LabelAddStatus.Text = "ERROR updating book";
                    }

                }
                else // new book
                {
                    BookActions bookActions = new BookActions();
                    bool addBookSuccess = bookActions.AddBook(
                        AddISBN.Text,
                        AddBookName.Text,
                        AddEdition.Text,
                        AddYear.Text,
                        DropDownAddPublisher.SelectedValue,
                        DropDownAddGenre.SelectedValue,
                        BookImage.FileName,
                        AddRating.Text,
                        AddSummary.Text
                        );

                    bool addBookAuthorSuccess = addBookAuthors();                   

                    if (addBookSuccess && addBookAuthorSuccess)
                    {
                        //string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        //Response.Redirect(pageUrl);
                        LabelAddStatus.Text = "Book Added!";
                        Response.Redirect("~/Admin/Books");
                    }
                    else
                    {
                        Debug.Fail("ERROR adding book");
                        LabelAddStatus.Text = "ERROR adding book";
                    }
                }                
            }
            else
            {
                LabelAddStatus.Text = "Invalid file type";
            }
        }

        public IQueryable getPublishers()
        {
            var __db = new LibraryContext();
            IQueryable query = __db.publishers;
            return query;
        }

        public IQueryable getGenres()
        {
            var __db = new LibraryContext();
            IQueryable query = __db.genres;
            return query;
        }

        public IQueryable getAuthors()
        {
            var __db = new LibraryContext();
            IQueryable query = __db.authors;
            return query;
        }
    }
}