using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ATX_POS
{
    public partial class Credentials : Form
    {
        private string level = "";
        private string user = "";
        int idcashout = 0;
        public Credentials()
        {
            InitializeComponent();
            txtusuario.Focus();
        }

        private void Credentials_Load(object sender, EventArgs e)
        {
            txtusuario.Focus();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand selectpermission = new SqlCommand();
                selectpermission.Parameters.Clear();
                selectpermission.Connection = con;
                selectpermission.CommandText = "select [PermisseLevel], [User] from Users where [User]=@user and [Password]=@password";
                selectpermission.Parameters.AddWithValue("@user", txtusuario.Text.ToString());
                selectpermission.Parameters.AddWithValue("@password", txcontraseña.Text.ToString());
                SqlDataAdapter sda = new SqlDataAdapter(selectpermission);
                DataTable users = new DataTable();
                if (sda != null)
                {
                    sda.Fill(users);
                }
                foreach (DataRow rowuser in users.Rows)
                {
                    level = rowuser[0].ToString();
                    user = rowuser[1].ToString();
                    //terminal = rowuser[2].ToString();
                    //password = rowuser[3].ToString();
                }
                if ((level == "1") || (level == "2"))
                {
                    cashout cashoutinterface = this.Owner as cashout;
                    if (cashoutinterface != null)
                    {
                        idcashout = cashoutinterface.aceptcashout(txtusuario.Text.ToString());
                        if (idcashout > 0)
                        {
                            MessaComments();
                        }
                    }

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El usuario: " + txtusuario.Text.ToString()+" no tiene el nivel de privilegios requeridos para el retiro de efectivo en caja", "Usuario sin Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txcontraseña.Text = "";
                    txcontraseña.Focus();
                }
            }
        }

        private void MessaComments()
        {
            Coments comments = new Coments();
            comments.idcashout = idcashout;
            comments.ShowDialog(this);
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
