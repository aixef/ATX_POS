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
    public partial class LoginFirst : MetroFramework.Forms.MetroForm
    {

        public LoginFirst()
        {
            InitializeComponent();
            txtusuario.Focus();
            pictureBox1.Image = Image.FromFile("navonazurelogo_azul.png");
            pictureBox2.Image = Image.FromFile("header-SMB-NAV_679.png");

        }

        private void LoginSesion(SqlConnection Conect)
        {
            bool activesesion = false;
            SqlCommand comando = new SqlCommand("select Users.[User], Users.[Password], Users.[Termina], PermisseLevel, [Active]" +
                                                "from dbo.[Users] where Users.[User] = '"
                                                + txtusuario.Text + "' And Password = '" + txcontraseña.Text + "' ", Conect);
            //ejecuta una instruccion de sql devolviendo el numero de las filas afectadas
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            try
            {
                da.Fill(ds, "Users");
                DataRow DR;
                DR = ds.Tables["Users"].Rows[0];
                if ((txtusuario.Text == DR["User"].ToString()) || (txcontraseña.Text == DR["Password"].ToString()))
                {
                    SyncPriceLists frmPrincipal = new SyncPriceLists();
                    //Sistema frmPrincipal = new Sistema();
                    if (txtusuario.Text.ToString() != "super")
                    {
                        activesesion = bool.Parse(DR["Active"].ToString());
                        if (activesesion == false)
                        {
                            try
                            {
                                frmPrincipal.UserLabel.Text = DR["User"].ToString();
                                frmPrincipal.PermisseLevel = Convert.ToInt32(DR["PermisseLevel"]);
                                SqlCommand GetTerminal = new SqlCommand("Select Number from dbo.[Terminals] where (Terminals.[Terminal] = (select Termina From dbo.[Users] where Terminals.[Terminal] = " + DR["Termina"].ToString() + "and Users.[User] = '" + DR["User"] + "'))", Conect);
                                GetTerminal.ExecuteNonQuery();
                                DataSet ds2 = new DataSet();
                                SqlDataAdapter da2 = new SqlDataAdapter(GetTerminal);
                                da2.Fill(ds2, "Terminals");
                                DataRow DR2;
                                DR2 = ds2.Tables["Terminals"].Rows[0];
                                frmPrincipal.NoTerminal.Text = DR2["Number"].ToString();

                            }
                            catch (SqlException sql)
                            {
                                MessageBox.Show(sql.Message.ToString());
                            }
                            this.TopMost = false;
                            frmPrincipal.Show();
                            frmPrincipal.InitTerminalCash(txtusuario.Text.ToString());
                            frmPrincipal.checkcloseturn();
                            updateactivesesion(DR);
                            this.Hide();
                        }
                        this.TopMost = false;

                    }
                    else
                    {
                        frmPrincipal.UserLabel.Text = DR["User"].ToString();
                        frmPrincipal.PermisseLevel = 1;
                        frmPrincipal.SuperSession();
                        frmPrincipal.Show();
                        this.Hide();
                        this.TopMost = false;
                        //this.Close();
                    }
                }
            }
            catch (SqlException sql2)
            {
                MessageBox.Show(sql2.Message.ToString());
                //MessageBox.Show(this,"El usuario tiene una sesion activa, no se puede iniciar sesion con este usario, cierre la sesion o contacte a su administrador","Usuario Bloqueado",MessageBoxButtons.OK);
            }
            if (activesesion)
            {
                MetroFramework.MetroMessageBox.Show(this, System.Environment.NewLine + "El usuario tiene una sesion activa" + System.Environment.NewLine + "No se puede iniciar sesion con este usario, cierre la sesion o contacte a su administrador", "Usuario Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void updateactivesesion(DataRow DR)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand updatesesionsqlc = new SqlCommand();
                updatesesionsqlc.Parameters.Clear();
                updatesesionsqlc.CommandText = "Update Users set [Active] = @Active where [User]=@User";
                updatesesionsqlc.Parameters.AddWithValue("@Active", true);
                updatesesionsqlc.Parameters.AddWithValue("@User", DR["User"].ToString());
                con.Open();
                updatesesionsqlc.Connection = con;
                updatesesionsqlc.ExecuteNonQuery();
                con.Close();
            }
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            //Salir de la aplicacion
            Application.Exit();
        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                IniciarBoton.Enabled = false;
            }
            else
            {
                IniciarBoton.Enabled = true;
            }

        }


        private void StatusConection(SqlConnection conect)
        {
            if (conect.State == ConnectionState.Open)
            {
                conect.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            //Salir de la aplicacion
            Application.Exit();
        }

        private void txcontraseña_TextChanged_1(object sender, EventArgs e)
        {
            txcontraseña.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkLabel1.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://atx.mx/");
        }

        private void txcontraseña_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                    {
                        cn.Open();
                        try
                        {
                            LoginSesion(cn);
                        }
                        catch (SqlException slq)
                        {
                            txcontraseña.Text = "";
                            MessageBox.Show(slq.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        StatusConection(cn);
                    }
                }
                catch
                {
                    MessageBox.Show("Error! Su contraseña y/o usuario son invalidos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txcontraseña.Text = "";
                }
            }

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    try
                    {
                        LoginSesion(cn);
                    }
                    catch (SqlException slq)
                    {
                        txcontraseña.Text = "";
                        MessageBox.Show(slq.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    StatusConection(cn);
                }
            }
            catch
            {
                MessageBox.Show("Error! Su contraseña y/o usuario son invalidos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txcontraseña.Text = "";
            }
        }

        private void IniciarBoton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    try
                    {
                        LoginSesion(cn);
                    }
                    catch (SqlException slq)
                    {
                        txcontraseña.Text = "";
                        MessageBox.Show(slq.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    StatusConection(cn);
                }
            }
            catch
            {
                MessageBox.Show("Error! Su contraseña y/o usuario son invalidos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txcontraseña.Text = "";
            }
        }

        private void LoginFirst_Load(object sender, EventArgs e)
        {

        }

        private void txcontraseña_KeyDown(object sender, KeyEventArgs e)
        {

        }

    }
}
