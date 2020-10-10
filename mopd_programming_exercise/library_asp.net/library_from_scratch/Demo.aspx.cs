using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library_from_scratch
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=DESKTOP-VIJNBSN\SQLEXPRESS;Initial Catalog=Library ;Integrated Security=True";

            cnn = new SqlConnection(connetionString);

            cnn.Open();
            Response.Write("<h1>Connection Made</h1>");
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, output = "";
            sql = "SELECT * FROM book";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                output += dataReader.GetValue(1) + "</br>";
            }
            Response.Write(output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

        }

        protected void btn_Click(object sender, EventArgs e)
        {

        }
    }
}