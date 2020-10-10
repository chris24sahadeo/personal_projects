using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace library_from_scratch
{
    public partial class DatabaseMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                bindDataToGridView();
            }
        }

        public void bindDataToGridView()
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = "SELECT id, first_name, last_name, email, dob FROM Student";
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    if(dataSet.Tables[0].Rows.Count > 0)
                    {
                        gvStudent.DataSource = dataSet;
                        gvStudent.DataBind();
                    }
                }
                catch(SqlException ex)
                {
                    ltError.Text = "Error! " + ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }

        protected void gvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ltError.Text = string.Empty;
            GridViewRow gvRow = (GridViewRow)gvStudent.Rows[e.RowIndex];
            HiddenField hfStudentID = (HiddenField)gvRow.FindControl("hfStudentID");

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = string.Format("DELETE FROM Student WHERE id={0}", hfStudentID.Value);
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvStudent.EditIndex = -1;
                    bindDataToGridView();
                }
                catch (SqlException ex)
                {
                    ltError.Text = "Error! " + ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }


        protected void gvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ltError.Text = string.Empty;
            gvStudent.EditIndex = e.NewEditIndex;
            bindDataToGridView();
        }

        protected void gvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ltError.Text = string.Empty;
            GridViewRow gvRow = (GridViewRow)gvStudent.Rows[e.RowIndex];
            HiddenField hfStudentID = (HiddenField)gvRow.FindControl("hfStudentID");
            TextBox txtFirstName = (TextBox)gvRow.Cells[1].Controls[0];
            TextBox txtLastName = (TextBox)gvRow.Cells[2].Controls[0];
            TextBox txtEmail = (TextBox)gvRow.Cells[3].Controls[0];
            TextBox txtDob = (TextBox)gvRow.Cells[4].Controls[0];

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = string.Format("UPDATE Student set first_name='{0}', last_name='{1}', email='{2}', dob='{3}' WHERE id={4}", txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtDob.Text, hfStudentID.Value);
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvStudent.EditIndex = -1;
                    bindDataToGridView(); 
                }
                catch (SqlException ex)
                {
                    ltError.Text = "Error! " + ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }

        protected void gvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudent.EditIndex = -1;
            bindDataToGridView();
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = string.Format("INSERT INTO Student(first_name, last_name, email, dob) VALUES('','','','')");
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    bindDataToGridView();
                }
                catch (SqlException ex)
                {
                    ltError.Text = "Error! " + ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }
    }
}