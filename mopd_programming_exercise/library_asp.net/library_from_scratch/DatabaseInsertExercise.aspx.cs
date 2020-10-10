using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace library_from_scratch
{
    public partial class DatabaseInsertExercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var connection = WebConfigurationManager.ConnectionStrings["DBConnection"];
            using (SqlConnection dbConnection = new SqlConnection(connection.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = string.Format("INSERT INTO Student(first_name, last_name, email, dob) VALUES ('{0}', '{1}', '{2}', '{3}')", tbFirstName.Text, tbLastName.Text, tbEmailAddress.Text, tbDateOfBirth.Text);
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    ltMessage.Text = "Write successful!";
                }
                catch (SqlException ex)
                {
                    ltMessage.Text = "Write failed! </br>" + ex.Message;
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