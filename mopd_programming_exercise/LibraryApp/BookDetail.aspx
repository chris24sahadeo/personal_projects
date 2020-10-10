<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="LibraryApp.BookDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="bookDetail" runat="server" ItemType="LibraryApp.Models.book" SelectMethod="bookDetail_GetItem" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#: Item.book_name %></h1>
            </div>
            </br>
            <table>
                <tr>
                    <td><img alt="Image not found." onerror="this.src='/Images/book_covers/book-cover-placeholder.png'" src='/Images/book_covers/<%#: Item.cover_photo_path %>' style="border: solid; height: 500px" /></td>
                    <td>&nbsp</td>
                    <td style="vertical-align:top; text-align:left; margin:1em">
                        <b>by <%#: string.Join(", ", Item.bookauthors.Where(ba => ba.book_id == Item.book_id).Select(ba => ba.author.full_name).ToArray()) %></b>
                        </br>
                        <b style="margin-top:1em">Summary</b>
                        </br>
                        <p><%#:Item.summary %></p>
                        </br>
                        <span><b>ISBN: </b><%#:Item.book_id %></span>
                        </br>
                        <a href="/AddToWishList.aspx?book_id=<%#:Item.book_id %>">               
                            <span class="ProductListItem">
                                <b>Add To Cart<b>
                            </span>           
                        </a>
                        </br>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
