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
    public partial class Coments : MetroFramework.Forms.MetroForm
    {
        public bool turno = false, casho = false, daycut = false, countingup = false;
        public int IdCorte = 0, IdCashOut = 0, IdCorteDia = 0, IdCountingUp = 0;
        public int idcomment = 0;
        int letterscount = 0, lettersremaing = 0;
        public string commentfrom = "", user = "", terminal = "", datework =DateTime.Today.ToString("MM/dd/yyyy");
        public Coments()
        {
            InitializeComponent();
        }
        public int idcashout = 0;

        private void Coments_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //bool credentialsAuthorize = false;
            if (turno)
            {
                commentfrom = "Turn";
            }
            else if(casho)
            {
                commentfrom = "CashOut";
            }
            else if(daycut)
            {
                commentfrom = "CutDay";

            }
            else if(countingup)
            {
                commentfrom = "CountingUp";
            }

            RecComments();
            this.Close();
        }

        private void RecComments()
        {
            using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                SqlCommand CommentsCloseTurn = new SqlCommand();
                CommentsCloseTurn.Parameters.Clear();
                con.Open();
                CommentsCloseTurn.Connection = con;
                CommentsCloseTurn.CommandText = "insert into Comments ([Coment],[commentfrom],[IdCorte],[IdCashOut],[IdCorteDia],[IdCountingUp], [Datereg], [UserReg],[RegTerminal]) values "+
                    "(@Coment,@comentfrom,@IdCorte,@Idcashout,@IdCortedia,@idcontingup, @datework, @user, @terminal) SELECT SCOPE_IDENTITY()";
                CommentsCloseTurn.Parameters.AddWithValue("@Coment", Comments.Text.ToString());
                CommentsCloseTurn.Parameters.AddWithValue("@comentfrom", commentfrom);
                CommentsCloseTurn.Parameters.AddWithValue("@IdCorte", IdCorte);
                CommentsCloseTurn.Parameters.AddWithValue("@Idcashout", IdCashOut);
                CommentsCloseTurn.Parameters.AddWithValue("@IdCortedia", IdCorteDia);
                CommentsCloseTurn.Parameters.AddWithValue("@idcontingup", IdCountingUp);
                CommentsCloseTurn.Parameters.AddWithValue("@datework", datework);
                CommentsCloseTurn.Parameters.AddWithValue("@user", user);
                CommentsCloseTurn.Parameters.AddWithValue("@terminal", terminal);
                idcomment = Convert.ToInt32(CommentsCloseTurn.ExecuteNonQuery());
                con.Close();
                
            }
        }

        private void Comments_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void Comments_KeyPress(object sender, KeyPressEventArgs e)
        {
            letterscount = Comments.Text.ToString().Length;
            lettersremaing = 150 - letterscount;
            letters.Text = lettersremaing.ToString();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
