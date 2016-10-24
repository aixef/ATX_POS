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
    public partial class ConfigUsers : MetroFramework.Forms.MetroForm
    {
        bool newuser = false;
        bool edituser = false;
        bool deleteuser = false;
        public string useruse = "";

        public ConfigUsers()
        {
            InitializeComponent();
            Acept.Enabled = false;
            Canceler.Enabled = false;
            Edit.Enabled = false;
            EditPic.Enabled = false;
            CancelPic.Enabled = false;
            Delete.Enabled = false;
        }

        private void ConfigUsers_Load(object sender, EventArgs e)
        {

        }

        private void NewUser_Click(object sender, EventArgs e)
        {
            ClearSpace(groupBox1);
            ListUsers.Items.Clear();
            ListUsers.Text = "";
            ListUsers.SelectedIndex = -1;
            disablebootons();
            newuser = true;
            activecontrolsbox();
            edituser = false;
            deleteuser = false;
            Acept.Enabled = true;
            Acept.Text = "Registrar";
        }

        private void disablebootons()
        {
            ListUsers.Enabled = false;
            EditPic.Enabled = false;
            Edit.Enabled = false;
            Delete.Enabled = false;
            CancelPic.Enabled = false;
            pictureBox1.Enabled = false;
            NewUser.Enabled = false;
        }

        private void activecontrolsbox()
        {
            if (newuser)
            {
                UserName.Enabled = true;
                UserName.ReadOnly = false;
                UserName.Focus();
                Canceler.Enabled = true;
            }
            Password.Enabled = true;
            Password.ReadOnly = false;
            FirstName.Enabled = true;
            FirstName.ReadOnly = false;
            if (edituser)
            {
                FirstName.Focus();
            }
            SecondName.Enabled = true;
            SecondName.ReadOnly = false;
            LastName.Enabled = true;
            LastName.ReadOnly = false;
            SecondLastname.Enabled = true;
            SecondLastname.ReadOnly = false;
            Address.Enabled = true;
            Address.ReadOnly = false;
            City.Enabled = true;
            City.ReadOnly = false;
            State.Enabled = true;
            State.ReadOnly = false;
            References.Enabled = true;
            References.ReadOnly = false;
            Datepick.Enabled = true;
            NoTerminal.Enabled = true;
            NumTerm.Enabled = true;
            LevelPermiss.Enabled = true;

        }

        private void metroLabel14_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            edituser = true;
            newuser = false;
            activecontrolsbox();
            disablebootons();
            Canceler.Enabled = true;
            Acept.Enabled = true;
            Acept.Text = "Update";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (((ListUsers.Text != "admin") || (ListUsers.Text != "Super")))
            {
                if (ListUsers.Text != useruse)
                {
                    string usercombobox = ListUsers.SelectedItem.ToString();
                    DialogResult result = MetroFramework.MetroMessageBox.Show(this, "El Usuario: " + usercombobox + " no podra inicar sesion nuevamente", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DisableUser(usercombobox);
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "No se puede eliminar el usuario porque esta en uso", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "No se puede eliminar el usuario 'Admin' ", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearSpace(groupBox1);
            DisableRead(groupBox1);
            ActiveOptions();
            newuser = false;
            edituser = false;
            deleteuser = false;
            ListUsers.Items.Clear();
            ListUsers.Text = "";
            ListUsers.SelectedIndex = -1;
        }

        private void DisableUser(string usercombobox)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand disablecomand = new SqlCommand();
                disablecomand.Parameters.Clear();
                disablecomand.Connection = con;
                disablecomand.CommandText = "Update Users set [Activeted] = @activeted where [User] = @SelectUser";
                disablecomand.Parameters.AddWithValue("@SelectUser", usercombobox);
                disablecomand.Parameters.AddWithValue("@activeted",false);
                disablecomand.ExecuteNonQuery();
                con.Close();
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            bool valuesok = CheckNoNullValues();
            if (valuesok)
            {
                if (Acept.Text.ToString() == "Registrar")
                {
                    InsertUser();
                }
                else if (Acept.Text.ToString() == "Update")
                {
                    string usercombobox = ListUsers.SelectedItem.ToString();
                    DialogResult aceptupdate = MetroFramework.MetroMessageBox.Show(this, "¿Esta Seguro de que quiere actualizar los datos del usuario: " + usercombobox + " ?", "Actualizar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    UpdateUser(usercombobox);
                    if (useruse == usercombobox)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Se han actualizado los datos de la sesión actual: " + usercombobox + " La aplicación se reiniciara", "Actualizar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        /*restartApp restartapp = this.Owner as restartApp;
                        if (restartapp != null)
                        {
                            restartapp.RestartAplication();
                        }*/
                        Application.Restart();
                    }
                }
            }
        }

        private void UpdateUser(string usercombobox)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand UpdateUser = new SqlCommand();
                UpdateUser.Parameters.Clear();
                con.Open();
                UpdateUser.Connection = con;
                UpdateUser.CommandText = "Update UsersDetails set [First Name] = @FirstName, [Second Name] = @SecondName, [LastName] = @LastName, [Second LastName] = @SecondLastName, [Birthday] = @Birthday, [Adress] = @Adress, [City] = @City, [Refe.] = @Refe, [State] = @State where [ID] = (select [UserDetail] from Users where [User] = @SelectUser)";
                UpdateUser.Parameters.AddWithValue("@FirstName", FirstName.Text.ToString());
                UpdateUser.Parameters.AddWithValue("@SecondName", SecondName.Text.ToString());
                UpdateUser.Parameters.AddWithValue("@LastName", LastName.Text.ToString());
                UpdateUser.Parameters.AddWithValue("@SecondLastName", SecondLastname.Text.ToString());
                DateTime time = Datepick.Value;
                string datebirth = time.ToString("MM/dd/yyyy");
                UpdateUser.Parameters.AddWithValue("@Birthday", datebirth);
                UpdateUser.Parameters.AddWithValue("@Adress", Address.Text.ToString());
                UpdateUser.Parameters.AddWithValue("@City", City.Text.ToString());
                UpdateUser.Parameters.AddWithValue("@Refe", References.Text.ToString());
                UpdateUser.Parameters.AddWithValue("@State", State.Text.ToString());
                UpdateUser.Parameters.AddWithValue("@SelectUser", usercombobox);
                UpdateUser.ExecuteNonQuery();

                SqlCommand updeteusersesion = new SqlCommand();
                updeteusersesion.Parameters.Clear();
                updeteusersesion.Connection = con;
                updeteusersesion.CommandText = "Update Users set [Name] = @Name, [Password] =@Password, [Termina] = @Termina, [PermisseLevel] = @PermisseLevel where [User] = @SelectUser";
                updeteusersesion.Parameters.AddWithValue("@Name", FirstName.Text.ToString());
                updeteusersesion.Parameters.AddWithValue("@Password", Password.Text.ToString());
                updeteusersesion.Parameters.AddWithValue("@Termina", NoTerminal.Text.ToString());
                updeteusersesion.Parameters.AddWithValue("@PermisseLevel", LevelPermiss.Text.ToString());
                updeteusersesion.Parameters.AddWithValue("@SelectUser", usercombobox);
                updeteusersesion.ExecuteNonQuery();
                con.Close();
            }
        }

        private void InsertUser()
        {
            bool useralredyexist = checkuser(UserName.Text.ToString());
            if (useralredyexist == false)
            {
                using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    con.Open();
                    SqlCommand InsertUser = new SqlCommand();
                    InsertUser.Parameters.Clear();
                    InsertUser.Connection = con;
                    InsertUser.CommandText = "insert into UsersDetails ([First Name],[Second Name],[LastName],[Second LastName],[Birthday],[Adress],[City],[Refe.],[State]) " +
                        "values(@FirstName,@SecondName,@LastName,@SecondLastName,@Birthday,@Adress,@City,@Refe,@State) SELECT SCOPE_IDENTITY()";
                    InsertUser.Parameters.AddWithValue("@FirstName", FirstName.Text.ToString());
                    InsertUser.Parameters.AddWithValue("@SecondName", SecondName.Text.ToString());
                    InsertUser.Parameters.AddWithValue("@LastName", LastName.Text.ToString());
                    InsertUser.Parameters.AddWithValue("@SecondLastName", SecondLastname.Text.ToString());
                    DateTime time = Datepick.Value;
                    string datebirth = time.ToString("MM/dd/yyyy");
                    InsertUser.Parameters.AddWithValue("@Birthday", datebirth.ToString());
                    InsertUser.Parameters.AddWithValue("@Adress", Address.Text.ToString());
                    InsertUser.Parameters.AddWithValue("@City", City.Text.ToString());
                    InsertUser.Parameters.AddWithValue("@Refe", References.Text.ToString());
                    InsertUser.Parameters.AddWithValue("@State", State.Text.ToString());

                    int idUserDetail = Convert.ToInt32(InsertUser.ExecuteScalar());
                    if (idUserDetail > 0)
                    {
                        SqlCommand insertUser = new SqlCommand();
                        InsertUser.Parameters.Clear();
                        insertUser.Connection = con;
                        insertUser.CommandText = "insert into Users ([Name],[User],[Password],[Termina],[PermisseLevel],[UserDetail],[StoreAsigned],[Active],[Activeted])" +
                            "values(@Name,@User,@Password,@Termina,@PermisseLevel,@UserDetail,@StoreAsigned,@Active,@Activeted)";
                        insertUser.Parameters.AddWithValue("@Name", FirstName.Text.ToString());
                        insertUser.Parameters.AddWithValue("@User", UserName.Text.ToString());
                        insertUser.Parameters.AddWithValue("@Password", Password.Text.ToString());
                        insertUser.Parameters.AddWithValue("@Termina", NoTerminal.Text.ToString());
                        insertUser.Parameters.AddWithValue("@PermisseLevel", LevelPermiss.Text.ToString());
                        insertUser.Parameters.AddWithValue("@UserDetail", idUserDetail);
                        insertUser.Parameters.AddWithValue("@StoreAsigned", 1);
                        insertUser.Parameters.AddWithValue("@Active",false);
                        insertUser.Parameters.AddWithValue("@Activeted", true);
                        insertUser.ExecuteNonQuery();
                        ClearSpace(groupBox1);
                        DisableRead(groupBox1);
                        ActiveOptions();
                        newuser = false;
                        edituser = false;
                        deleteuser = false;
                        ListUsers.Items.Clear();
                        ListUsers.Text = "";
                        ListUsers.SelectedIndex = -1;
                        NoTerminal.Items.Clear();
                        MetroFramework.MetroMessageBox.Show(this, "Usuario Agregado Correctamente", "Usuario Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    con.Close();
                }
            }
        }

        private bool checkuser(string User)
        {
            bool exist = false;
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand userexist = new SqlCommand();
                userexist.Parameters.Clear();
                userexist.Connection = con;
                userexist.CommandText = "select count([User]) from Users where [User] = @User";
                userexist.Parameters.AddWithValue("@User", User);
                int existco = (int)userexist.ExecuteScalar();
                if (existco > 0)
                {
                    exist = true;
                }
                con.Close();
            }
            return exist;
        }

        private bool CheckNoNullValues()
        {
            bool correct = true;
            if (UserName.Text == "")
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El campo Nombre de Usuario no puede ser vacio", "Campo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (UserName.Text.Length < 4)
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El nombre de usuario no puede ser menor 4 caracteres", "Usuario Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (FirstName.Text == "")
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El campo Nombre no puede ser vacio", "Campo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (LastName.Text == "")
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El campo Apellido no puede ser vacio", "Campo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Address.Text == "")
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El campo Dirección no puede ser vacio", "Campo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (NoTerminal.Text == "")
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El campo Terminal no puede ser vacio", "Campo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (LevelPermiss.Text == "")
            {
                correct = false;
                MetroFramework.MetroMessageBox.Show(this, "El campo Nivel Permiso no puede ser vacio", "Campo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return correct;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ClearSpace(groupBox1);
            DisableRead(groupBox1);
            ActiveOptions();
            newuser = false;
            edituser = false;
            deleteuser = false;
            ListUsers.Items.Clear();
            ListUsers.Text = "";
            ListUsers.SelectedIndex = -1;
        }

        private void ActiveOptions()
        {
            ListUsers.Enabled = Enabled;
            //EditPic.Enabled = Enabled;
            //Edit.Enabled = Enabled;
            Delete.Enabled = Enabled;
            CancelPic.Enabled = Enabled;
            pictureBox1.Enabled = Enabled;
            NewUser.Enabled = Enabled;
        }

        private void DisableRead(GroupBox groupBox1)
        {
            foreach (Control c in groupBox1.Controls)
            {
                var textBox = c as TextBox;
                var comboBox = c as ComboBox;
                var calendar = c as DateTimePicker;

                if (textBox != null)
                    if (textBox.Text == "")
                        (textBox).ReadOnly = true;

                if (comboBox != null)
                    if (comboBox.Text == "")
                        comboBox.Enabled = false;

                if (calendar != null)
                    if (calendar.Text != "")
                        calendar.Enabled = false;

                if (c.HasChildren)
                    ClearSpace(c);
            }
            Acept.Enabled = false;
        }

        private void EnableReadOnly(GroupBox groupBox1)
        {
            foreach (Control c in groupBox1.Controls)
            {
                var textBox = c as TextBox;
                var comboBox = c as ComboBox;
                var calendar = c as DateTimePicker;

                if (textBox != null)
                    if (textBox.Text == "")
                    {
                        (textBox).ReadOnly = true;
                        (textBox).Enabled = false;
                    }

                if (comboBox != null)
                    if (comboBox.Text == "")
                        comboBox.Enabled = false;

                if (calendar != null)
                    if (calendar.Text != "")
                        calendar.Enabled = false;

                if (c.HasChildren)
                    ClearSpace(c);
            }
            Acept.Enabled = false;
        }

        public static void ClearSpace(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextBox;
                var comboBox = c as ComboBox;

                if (textBox != null)
                    (textBox).Clear();

                if (comboBox != null)
                {
                    comboBox.SelectedIndex = -1;
                    if (comboBox.Text != "")
                        comboBox.Text = "";
                }

                if (c.HasChildren)
                    ClearSpace(c);
            }
        }

        private void ListUsers_Click(object sender, EventArgs e)
        {
            if (ListUsers.Items.Count <= 0)
            {

                DataTable dt = new DataTable();
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    SqlCommand UserList = new SqlCommand();
                    UserList.Parameters.Clear();
                    UserList.Connection = cn;
                    UserList.CommandText = "select Users.[User] from dbo.[Users] where [Activeted] = @Activeted";
                    UserList.Parameters.AddWithValue("@Activeted", true);
                    SqlDataAdapter UserSDA = new SqlDataAdapter(UserList);

                    if (UserSDA != null)
                    {
                        UserSDA.Fill(dt);
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        ListUsers.Items.Add(row[0].ToString());
                    }
                    cn.Close();
                }
            }
        }

        private void ListUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListUsers.SelectedItem != null)
            {
                string usercombobox = ListUsers.SelectedItem.ToString();
                getdatauserdetail(usercombobox);
                getdataterminal(usercombobox);
                EditPic.Enabled = true;
                Edit.Enabled = true;
                Delete.Enabled = true;
            }
        }

        private void getdataterminal(string usercombobox)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand comandterm = new SqlCommand();
                comandterm.Parameters.Clear();
                con.Open();
                comandterm.Connection = con;
                comandterm.CommandText = "select [Terminal], [Number] from Terminals where [Terminal] = (select [Termina] from Users where [User] = @UserSelect)";
                comandterm.Parameters.AddWithValue("@UserSelect", usercombobox);
                SqlDataAdapter sdaterm = new SqlDataAdapter(comandterm);
                DataTable sdatermtb = new DataTable();
                if (sdaterm != null)
                {
                    sdaterm.Fill(sdatermtb);
                }
                foreach (DataRow row in sdatermtb.Rows)
                {
                    NoTerminal.Text = row[0].ToString();
                    NumTerm.Text = row[1].ToString();
                }
            }
        }

        private void getdatauserdetail(string usercombobox)
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                con.Open();
                SqlCommand usersdetail = new SqlCommand();
                usersdetail.Parameters.Clear();
                usersdetail.CommandText = "select [First Name], [Second Name], [LastName], [Second LastName], [Adress], [Birthday], [City], [Refe.], [State] from UsersDetails where [ID] = (select [UserDetail] from Users where [User] = @UserSelect)";
                usersdetail.Connection = con;
                usersdetail.Parameters.AddWithValue("@UserSelect", usercombobox);
                SqlDataAdapter sda = new SqlDataAdapter(usersdetail);
                DataTable dtus = new DataTable();
                if (sda != null)
                {
                    sda.Fill(dtus);
                }
                foreach (DataRow row in dtus.Rows)
                {
                    DisplayDetailUser(row);
                }
                SqlCommand users = new SqlCommand();
                users.Parameters.Clear();
                users.CommandText = "select [User], [Password],[PermisseLevel] from Users where [User] = @UserSelect";
                users.Connection = con;
                users.Parameters.AddWithValue("@UserSelect", usercombobox);
                SqlDataAdapter sdau = new SqlDataAdapter(users);
                DataTable dtu = new DataTable();
                if (sdau != null)
                {
                    sdau.Fill(dtu);
                }
                foreach (DataRow row in dtu.Rows)
                {
                    UserName.Text = row[0].ToString();
                    Password.Text = row[1].ToString();
                    LevelPermiss.Text = row[2].ToString();
                }
                con.Close();
            }
        }

        private void DisplayDetailUser(DataRow row)
        {
            //0[First Name], 1[Second Name], 2[LastName], 3[Second LastName], 4[Adress], 
            //5[Birthday], 6[City], 7[Refe.], 8[State]
            FirstName.Text = row[0].ToString();
            SecondName.Text = row[1].ToString();
            LastName.Text = row[2].ToString();
            SecondLastname.Text = row[3].ToString();
            Address.Text = row[4].ToString();
            City.Text = row[6].ToString();
            References.Text = row[7].ToString();
            State.Text = row[8].ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LevelPermiss.SelectedItem != null)
            {
                string usercombobox = LevelPermiss.SelectedItem.ToString();
                DisplayPermiss(usercombobox);
            }
        }

        private void DisplayPermiss(string usercombobox)
        {
            if (usercombobox.ToString() == "1")
            {
                PermDetail.Text = "Administrador";
            }
            else if (usercombobox.ToString() == "2")
            {
                PermDetail.Text = "Supervisor de Caja";
            }
            else if (usercombobox.ToString() == "3")
            {
                PermDetail.Text = "Cajero";
            }
        }

        private void NoTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void NoTerminal_Click(object sender, EventArgs e)
        {
            if (NoTerminal.Items.Count <= 0)
            {

                DataTable dt = new DataTable();
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    cn.Open();
                    SqlCommand TermList = new SqlCommand();
                    TermList.Parameters.Clear();
                    TermList.Connection = cn;
                    TermList.CommandText = "select [Terminal] from Terminals";
                    SqlDataAdapter UserSDA = new SqlDataAdapter(TermList);

                    if (UserSDA != null)
                    {
                        UserSDA.Fill(dt);
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        NoTerminal.Items.Add(row[0].ToString());
                    }
                    cn.Close();
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ActiveSessions sessions = new ActiveSessions();
            sessions.user = useruse;
            sessions.ShowDialog(this);
            //this.ShowDialog(sessions);
        }
    }
}
