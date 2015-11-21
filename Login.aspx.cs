using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace SamaraParking
{
    public partial class Login : System.Web.UI.Page
    {
        protected User ValidateUser(object sender, EventArgs e)
        {
            int userId = 0;
            User currentUser = new User();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", Login1.UserName);
                    cmd.Parameters.AddWithValue("@Password", Login1.Password);
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                switch (userId)
                {
                    case -1:
                        Login1.FailureText = "Username is incorrect.";
                        break;
                    case -2:
                        Login1.FailureText = "Password is incorrect.";
                        break;
                    case -3:
                        Login1.FailureText = "Account has not been activated.";
                        break;
                    default:
                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                        //User is converted to object from database if found
                        //o(command) is to reference object search
                         string oString = "Select * from Users where Username=@Username";
                         SqlCommand oCmd = new SqlCommand(oString, con);
                         oCmd.Parameters.AddWithValue("@Username", Login1.UserName);           
                         con.Open();
                         using (SqlDataReader oReader = oCmd.ExecuteReader())
                         {
                              while (oReader.Read())
                              {    
                                  currentUser.Id = (int)oReader["Id"];
                                  currentUser.Name = oReader["Name"].ToString();
                                  currentUser.LastName = oReader["Lastname"].ToString();
                                  currentUser.Username = oReader["Username"].ToString();
                                  currentUser.Password = oReader["Password"].ToString();
                                  currentUser.Email = oReader["Email"].ToString();
                                  currentUser.Roletype = (int)oReader["Roletype"];
                                  currentUser.Registry = (bool)oReader["Registry"];
                              }

                              con.Close();
                         }               

                        break;
                }
            }
            return currentUser;
        }
}
}