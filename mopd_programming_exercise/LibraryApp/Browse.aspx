<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="LibraryApp.Browse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <%--grid of books--%>
            <asp:ListView ID="bookList" runat="server" DataKeyNames="book_id" GroupItemCount="4" ItemType="LibraryApp.Models.book" SelectMethod="bookList_GetData">                                
               
                <EmptyDataTemplate>
                    <table>
                        <tr><td>No data was returned from database.</td></tr>
                    </table>
                </EmptyDataTemplate>

               
                <EmptyDataTemplate>
                    <td />
                </EmptyDataTemplate>

               
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server"><td id="itemPlaceholder" runat="server"></td></tr>
                </GroupTemplate>

               
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr><td><a href="BookDetail.aspx?book_id=<%#: Item.book_id %>"><img alt="Image not found." onerror="this.src='/Images/book_covers/book-cover-placeholder.png'" src='/Images/book_covers/<%#: Item.cover_photo_path %>'  style="border: solid; height:250px" /></a></td></tr>
                            <tr><td><a href="BookDetail.aspx?book_id=<%#:Item.book_id %>"><span><%#: Item.book_name %></span></a></td></tr>
                            <tr><td><a href="/AddToWishList.aspx?book_id=<%#:Item.book_id %>"><span class="ProductListItem"><b>Add To Cart<b></span></a></td></tr>
                            <tr><td>&nbsp</td></tr>
                        </table>
                    </td>
                </ItemTemplate>

                
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr><td><table id="groupPlaceholderContainer" runat="server" style="width: 100%"><tr id="groupPlaceholder"></tr></table></td></tr>
                            <tr><td></td></tr> 
                            <tr></tr> 
                        </tbody>
                    </table>
                </LayoutTemplate>

            </asp:ListView>
        </div>
    </section>
</asp:Content>
