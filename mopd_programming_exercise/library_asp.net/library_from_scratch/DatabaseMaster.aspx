<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatabaseMaster.aspx.cs" Inherits="library_from_scratch.DatabaseMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Database Master CRUD</h2>
    <h3>Student Table</h3>
    <p><asp:Literal ID="ltError" runat="server" /></p>
    <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvStudent_RowDeleting" OnRowEditing="gvStudent_RowEditing" OnRowUpdating="gvStudent_RowUpdating" OnRowCancelingEdit="gvStudent_RowCancelingEdit">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfStudentID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="first_name" HeaderText="First Name" />
            <asp:BoundField DataField="last_name" HeaderText="Last Name" />
            <asp:BoundField DataField="email" HeaderText="Email Address" />
            <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <div>
        <asp:Button ID="btnAddRow" runat="server" Text="Add Row" OnClick="btnAddRow_Click" />
    </div>

</asp:Content>
