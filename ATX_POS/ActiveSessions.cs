using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATX_POS
{
    public partial class ActiveSessions : MetroFramework.Forms.MetroForm
    {
        public string user;
        bool status;
        public ActiveSessions()
        {
            InitializeComponent();
        }

        private void ActiveSessions_Load(object sender, EventArgs e)
        {
            Updatestatus.Enabled = false;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (UserList.Items.Count <= 0)
            {

                DataTable dt = new DataTable();
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    SqlCommand UserListcomnmand = new SqlCommand();
                    UserListcomnmand.Parameters.Clear();
                    UserListcomnmand.Connection = cn;
                    UserListcomnmand.CommandText = "select [User],[Active] from dbo.[Users] where [User] <> @User";
                    UserListcomnmand.Parameters.AddWithValue("@User",user);
                    SqlDataAdapter UserSDA = new SqlDataAdapter(UserListcomnmand);

                    if (UserSDA != null)
                    {
                        UserSDA.Fill(dt);
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        UserList.Items.Add(row[0].ToString());
                    }
                    cn.Close();
                }
            }
        }

        private void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserList.SelectedItem != null)
            {
                Updatestatus.Enabled = true;
                using (SqlConnection cone = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    DataTable dt = new DataTable();
                    cone.Open();
                    SqlCommand selectuserscomand = new SqlCommand();
                    selectuserscomand.Parameters.Clear();
                    selectuserscomand.Connection = cone;
                    selectuserscomand.CommandText = "select [Active] from Users where [User] = @user";
                    selectuserscomand.Parameters.AddWithValue("@user", UserList.SelectedItem.ToString());
                    SqlDataAdapter UserSDA = new SqlDataAdapter(selectuserscomand);

                    if (UserSDA != null)
                    {
                        UserSDA.Fill(dt);
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        status = bool.Parse(row[0].ToString());
                        if (status)
                        {
                            Status.Text = "Activo";
                            Status.Style = MetroFramework.MetroColorStyle.Red;
                        }
                        else
                        {
                            Status.Text = "Inactivo";
                            Status.Style = MetroFramework.MetroColorStyle.Green;
                        }
                    }
                    cone.Close();
                }
            }
        }

        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            if (status)
            {
                UpdateActiveStatus();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "El Usuario no se encuentra Activo", "Usuario No valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateActiveStatus()
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand comandUpdate = new SqlCommand();
                comandUpdate.Parameters.Clear();
                comandUpdate.Connection = con;
                comandUpdate.CommandText = "Update Users set [Active] = @Inactive where [User] = @User";
                comandUpdate.Parameters.AddWithValue("@Inactive",false);
                comandUpdate.Parameters.AddWithValue("@User", UserList.SelectedItem.ToString());
                comandUpdate.ExecuteNonQuery();
                con.Close();
            }
            Status.Text = "None";
            Status.Style = MetroFramework.MetroColorStyle.Blue;
            UserList.Items.Clear();
            UserList.Text = "";
            Updatestatus.Enabled = false; 
        }
    }
}
