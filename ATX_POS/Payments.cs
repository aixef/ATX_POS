using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace ATX_POS
{
    public partial class Payments : Form
    {
        int TransId;
        int BackTransfer;
        public int IdTerminal;
        public string IDUser;
        static DataGridView DataTicket = new DataGridView();
        static DataGridView DataUser = new DataGridView();
        public DataGridView Datacompany = new DataGridView();
        public DataGrid DataSales = new DataGrid();
        static DataGridView DataSucursal = new DataGridView();
        public string Username;
        public string terminaluser;
        public decimal changeremaing = 0M;
        static decimal getcreditamount = 0M;
        static decimal getcomision = 0M;
        static decimal totalgetcomision = 0M;
        private decimal totalcomision = 0M;
        public Payments()
        {
            InitializeComponent();

        }

        private void Payments_Load(object sender, EventArgs e)
        {
            decimal totalin = decimal.Parse(Totalling.Text.ToString());
            bool isInt = (int)totalin == totalin;
            /*if (isInt == false)
            {
                DialogResult dialogresult = MetroFramework.MetroMessageBox.Show(this, "Desea Redondear el total", "Redondeo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogresult == DialogResult.Yes)
                {
                    decimal NewTotalling = Convert.ToDecimal(Totalling.Text.ToString());
                    Totalling.Text = Math.Ceiling(NewTotalling).ToString();
                }
            }
            */
            paymenCash2_Load(sender, e);
            paymenCash2.Visible = false;
            paymentCredit2.Visible = false;
            paymentVales2.Visible = false;
        }

        private void Centerscreen()
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        private void SalesCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro de Cancelar el proceso de venta", "Cancelar Venta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelSales cancelInterface = this.Owner as CancelSales;
                if (cancelInterface != null)
                {
                    cancelInterface.cleardatagrid();
                    UpdateValues updateval = this.Owner as UpdateValues;
                    if (updateval != null)
                    {
                        updateval.UpdateValues();
                        this.Close();
                    }
                }
            }
        }


        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            int salesTransId;
            bool mixpayment = false;
            bool RegCorrect = false;
            decimal cashclient = 0M;
            
            if ((efectivo.Checked == true) && (MixPayment.Checked == false))
            {
                string paymentCode = "01";
                string recived = paymenCash2.TotalRecived.Text.ToString();
                cashclient = decimal.Parse(recived);
                salesTransId = PaymentWithCash(paymentCode, mixpayment, cashclient);
                if (salesTransId > 0)
                    RegCorrect = DetailSales(salesTransId);
            }
            if (credito.Checked == true && MixPayment.Checked == false)
            {

                bool checkCr = checkCreditValues();
                if (checkCr)
                {
                    string paymentCode = "04";
                    salesTransId = PaymentWithCredit(paymentCode, mixpayment);
                    RegCorrect = InsertCardsDetails(paymentCode, salesTransId);
                    RegCorrect = DetailSales(salesTransId);
                }
            }
            if (debito.Checked == true && MixPayment.Checked == false)
            {
                string paymentCode = "";
                bool checking = checkDebitValues();
                if (checking)
                {
                    if (paymentVales2.Type.Text == "Vales")
                    {
                        paymentCode = "08";
                    }
                    else if (paymentVales2.Type.Text == "Debito")
                    {
                        paymentCode = "28";
                    }
                    salesTransId = PaymentWithDebit(paymentCode, mixpayment);
                    RegCorrect = InsertCardsDetails(paymentCode, salesTransId);
                    RegCorrect = DetailSales(salesTransId);
                }
            }
            if (MixPayment.Checked == true)
            {
                decimal totalsales = Convert.ToDecimal(Totalling.Text.ToString());
                string paymentcode = "|", codepay = "100";
                decimal totalcards = 0M;
                bool check = false;
                mixpayment = true;
                decimal totalcubierto = 0M;
                string creditamount = "", debitamount = "", cashamount = "";
                decimal creditamountM = 0M, debitamountM = 0M, cashamountM = 0M, totaltopay = 0M;
                if (credito.Checked == true)
                {
                    check = checkCreditValues();
                    if (check)
                    {
                        creditamount = paymentCredit2.Credit.Text.ToString();
                        creditamountM = Convert.ToDecimal(creditamount);
                        paymentcode += "04|";
                        totalcubierto += creditamountM;
                    }
                }
                if (debito.Checked == true)
                {
                    check = checkDebitValues();
                    if (check)
                    {
                        debitamount = paymentVales2.debittotal.Text.ToString();
                        debitamountM = Convert.ToDecimal(debitamount);
                        if (paymentVales2.Type.Text == "Vales")
                        {
                            paymentcode += "08|";
                        }
                        else if (paymentVales2.Type.Text == "Debito")
                        {
                            paymentcode += "28|";
                        }
                        totalcubierto += debitamountM;
                    }

                }
                if (efectivo.Checked == true)
                {
                    check = checkcashdetails();
                    if (check)
                    {
                        paymentcode += "01|";
                        cashamount = paymenCash2.TotalRecived.Text.ToString();
                        cashamountM = Convert.ToDecimal(cashamount);

                        totaltopay = creditamountM + debitamountM + cashamountM;
                        
                        if (totaltopay >= totalsales)
                        {
                            totalcards = creditamountM + debitamountM;
                            if (totalcards > totalsales)
                            {
                                MetroFramework.MetroMessageBox.Show(this, "El monto usado por las Tarjetas excede el total de la venta", "Cubrir Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                check = false;
                            }
                            else
                            {
                                decimal totalrema = totalsales - totalcards;
                                if (cashamountM >= totalrema)
                                {
                                    changeremaing = cashamountM - totalrema;
                                    //paymenCash2.Remainingtext.Text = changeremaing.ToString();
                                    check = true;
                                    string recived = paymenCash2.TotalRecived.Text.ToString();
                                    cashclient = decimal.Parse(recived);
                                    totalcubierto += cashclient;
                                }
                            }

                        }
                        else if (totaltopay < totalsales)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "El monto total por los metodos seleccionados no cubre el total de la venta", "Cubrir Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            check = false;
                        }
                    }
                }
                if (totalcubierto >= totalsales)
                {
                    check = true;
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El monto total por los metodos seleccionados no cubre el total de la venta", "Cubrir Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                }
                if (check)
                {
                    salesTransId = PaymentMix(codepay, mixpayment, paymentcode, totalsales, cashclient);
                    if (salesTransId > 0)
                    {
                        if (debito.Checked == true)
                        {
                            if (paymentVales2.Type.Text == "Debito")
                            {
                                codepay = "28";
                            }
                            else if (paymentVales2.Type.Text == "Vales")
                            {
                                codepay = "08";
                            }
                            RegCorrect = InsertCardsDetails(codepay, salesTransId);
                            
                        }
                        if (credito.Checked == true)
                        {
                            codepay = "04";
                            RegCorrect = InsertCardsDetails(codepay, salesTransId);
                        }
                        RegCorrect = DetailSales(salesTransId);
                    }
                }

            }
            if (RegCorrect)
            {
                PrintTicket();
                this.Close();
            }

        }

        private int PaymentMix(string paymentcode, bool mixpayment, string detailCode, decimal totalpays, decimal cashcuto)
        {
            if (paymentcode == "100")
            {
                if (totalpays.ToString().Length > 0)
                {
                    DialogResult result = MetroFramework.MetroMessageBox.Show(this, "¿Está seguro de que desea Registrar la Venta?", "Registrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        RegSales formInterface = this.Owner as RegSales;
                        if (formInterface != null)
                        {

                            cashpay Payinterface = this.Owner as cashpay;
                            if (Payinterface != null)
                            {
                                Payinterface.cash(cashcuto);
                            }
                            TransId = formInterface.RegisterSales(totalpays.ToString(), changeremaing.ToString(), detailCode.ToString(), mixpayment);
                            if (TransId > 0)
                            {
                                BackTransfer = TransId;
                            }
                        }
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El monto recibidio no cubre el total de la venta", "Cubrir Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            return BackTransfer;
        }

        private int PaymentWithDebit(string paymentCode, bool mixpayment)
        {
            if ((paymentCode == "08") || (paymentCode == "28"))
            {
                if (paymentVales2.debittotal.Text.Length > 0)
                {
                    DialogResult result = MetroFramework.MetroMessageBox.Show(this, "¿Está seguro de que desea Registrar la Venta?", "Registrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        RegSales formInterface = this.Owner as RegSales;
                        if (formInterface != null)
                        {

                            TransId = formInterface.RegisterSales(paymentVales2.debittotal.Text.ToString(), "0.00", paymentCode.ToString(), mixpayment);
                            //         MessageBox.Show(TransId.ToString());
                            if (TransId > 0)
                            {
                                BackTransfer = TransId;
                            }
                        }
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El monto recibidio no cubre el total de la venta", "Cubrir Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            return BackTransfer;
        }

        private bool InsertCardsDetails(string paymentCode, int salesTransId)
        {
            bool correcto = false;
            bool credit = false;
            bool debit = false;
            bool vales = false;
            if (salesTransId > 0)
            {
                if ((paymentCode == "04"))
                {
                    credit = true;
                }
                if (paymentCode == "08")
                {
                    vales = true;
                }
                if (paymentCode == "28")
                {
                    debit = true;
                }

                #region creditdetail
                using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    string datework = DateTime.Today.ToString("MM/dd/yyyy");
                    cn.Open();
                    SqlCommand InsertCreditDetails = new SqlCommand();
                    InsertCreditDetails.Parameters.Clear();
                    InsertCreditDetails.Connection = cn;
                    if (credit)
                    {
                        InsertCreditDetails.CommandText = "insert into CardsDetail " +
                        "(IdSalesReg,BankName,BankIdSAT,Credit,Debit,Total,CardNumber,CodeAuto,Vales,[DateReg],[UserReg],[NumTerm]) " +
                        "values(@Idreg,@BankName,(Select CodeBank from BankSAT where Name= @BankName),@Credit,@Debit,@Total,@Card,@Autori,@Vales,@Datework,@UserReg,@NumTerm)";

                        InsertCreditDetails.Parameters.AddWithValue("@Idreg", salesTransId);
                        InsertCreditDetails.Parameters.AddWithValue("@BankName", paymentCredit2.Banks.Text.ToString());
                        InsertCreditDetails.Parameters.AddWithValue("@Credit", credit);
                        InsertCreditDetails.Parameters.AddWithValue("@Debit", debit);
                        InsertCreditDetails.Parameters.AddWithValue("@Vales", vales);
                        InsertCreditDetails.Parameters.AddWithValue("@Total", paymentCredit2.Credit.Text.ToString());
                        //InsertCreditDetails.Parameters.AddWithValue("@Comision", paymentCredit2.comision.Text.ToString());
                        //((totalcomision = getTotalcomision(paymentCredit2.Credit.Text.ToString(), paymentCredit2.comision.Text.ToString());

                        //InsertCreditDetails.Parameters.AddWithValue("@TotalComision", totalcomision);
                        InsertCreditDetails.Parameters.AddWithValue("@Card", paymentCredit2.BankAccount.Text.ToString());
                        InsertCreditDetails.Parameters.AddWithValue("@Autori", paymentCredit2.AutCod.Text.ToString());
                        InsertCreditDetails.Parameters.AddWithValue("@Datework", datework);
                        InsertCreditDetails.Parameters.AddWithValue("@UserReg", Username);
                        InsertCreditDetails.Parameters.AddWithValue("@NumTerm", terminaluser);
                    }
                    else if (debit || vales)
                    {
                        InsertCreditDetails.CommandText = "insert into CardsDetail " +
                        "(IdSalesReg,BankName,BankIdSAT,Credit,Debit,Total,CardNumber,CodeAuto,Vales,[DateReg],[UserReg],[NumTerm]) " +
                        "values(@Idreg,@BankName,(Select CodeBank from BankSAT where Name= @BankName),@Credit,@Debit,@Total,@Card,@Autori,@Vales,@Datework,@UserReg,@NumTerm)";

                        InsertCreditDetails.Parameters.AddWithValue("@Idreg", salesTransId);
                        InsertCreditDetails.Parameters.AddWithValue("@BankName", paymentVales2.Banks.Text.ToString());
                        InsertCreditDetails.Parameters.AddWithValue("@Credit", credit);
                        InsertCreditDetails.Parameters.AddWithValue("@Debit", debit);
                        InsertCreditDetails.Parameters.AddWithValue("@Vales", vales);
                        InsertCreditDetails.Parameters.AddWithValue("@Total", paymentVales2.debittotal.Text.ToString());
                        //InsertCreditDetails.Parameters.AddWithValue("@Comision", 0);
                        //InsertCreditDetails.Parameters.AddWithValue("@TotalComision", 0);
                        InsertCreditDetails.Parameters.AddWithValue("@Card", paymentVales2.BankAccount.Text.ToString());
                        InsertCreditDetails.Parameters.AddWithValue("@Autori", paymentVales2.AutCod.Text.ToString());
                        InsertCreditDetails.Parameters.AddWithValue("@Datework", datework);
                        InsertCreditDetails.Parameters.AddWithValue("@UserReg", Username);
                        InsertCreditDetails.Parameters.AddWithValue("@NumTerm", terminaluser);
                    }
                    InsertCreditDetails.ExecuteNonQuery();

                    correcto = true;
                }
                #endregion

            }
            return correcto;
        }

        private decimal getTotalcomision(string creditamount, string comisionporcentage)
        {
            getcomision = Convert.ToDecimal(comisionporcentage);
            getcreditamount = Convert.ToDecimal(creditamount);

            if (getcomision > 0)
            {
                totalgetcomision = getcreditamount + ((getcomision / 100) * getcreditamount);
            }
            else
            {
                totalgetcomision = getcreditamount;
            }
            return totalgetcomision;
        }

        private bool DetailSales(int salesTransId)
        {
            bool correct = false;
            string workdate = DateTime.Today.ToString("MM/dd/yyyy");
            decimal TotalSales = Convert.ToDecimal(Totalling.Text.ToString());
            string creditbank = "", debitbank = "", creditcard = "", debitcard = "";
            decimal creditcomsion = 0M, debitmont = 0M, cashmount = 0M, creditmount = 0M, changesales = 0M;

            if (efectivo.Checked)
            {
                cashmount = decimal.Parse(paymenCash2.TotalRecived.Text.ToString());
                changesales = decimal.Parse(paymenCash2.Remainingtext.Text.ToString());
            }
            if (credito.Checked)
            {
                creditbank = paymentCredit2.Banks.Text.ToString();
                creditcard = paymentCredit2.BankAccount.Text.ToString();
                creditcomsion = totalcomision;
                creditmount = decimal.Parse(paymentCredit2.Credit.Text.ToString());
            }
            if (debito.Checked)
            {
                debitbank = paymentVales2.Banks.Text.ToString();
                debitcard = paymentVales2.BankAccount.Text.ToString();
                debitmont = decimal.Parse(paymentVales2.debittotal.Text.ToString());
            }
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                try
                {
                    cn.Open();
                    SqlCommand SalesDetail = new SqlCommand();
                    SalesDetail.Parameters.Clear();
                    SalesDetail.Connection = cn;
                    //
                    SalesDetail.CommandText = "Insert into PaymentsDetail (DateReg,SalesTotal,CreditMont,DebitMont,CreditComision,CreditMount,CashMont,ChangeCash,IdSales,UserName,terminalUse) " +
                        "values (@WorkDate,@SalesTotal,@CreditMont,@DebitMont,@CreditComision,@CreditMount,@CashMont,@changeCash,@IdSales,@UserName,@TerminalUser)";
                    //int
                    SalesDetail.Parameters.AddWithValue("@IdSales", salesTransId);
                    //decimal
                    SalesDetail.Parameters.AddWithValue("@SalesTotal", TotalSales);
                    //nvarchar
                    SalesDetail.Parameters.AddWithValue("@WorkDate", workdate);
                    //nvarchar
                    SalesDetail.Parameters.AddWithValue("@Payment1", "");
                    SalesDetail.Parameters.AddWithValue("@Payment2", "");
                    SalesDetail.Parameters.AddWithValue("@Payment3", "");
                    SalesDetail.Parameters.AddWithValue("@CreditBank", creditbank);
                    SalesDetail.Parameters.AddWithValue("@DebitBank", debitbank);
                    SalesDetail.Parameters.AddWithValue("@CreditCard", creditcard);
                    SalesDetail.Parameters.AddWithValue("@DebitCard", debitcard);
                    //decimal totalcomision = 0M;
                    SalesDetail.Parameters.AddWithValue("@CreditComision", creditcomsion);
                    SalesDetail.Parameters.AddWithValue("@CreditMount", 1);
                    SalesDetail.Parameters.AddWithValue("@DebitMont", debitmont);
                    SalesDetail.Parameters.AddWithValue("@CreditMont", creditmount);
                    SalesDetail.Parameters.AddWithValue("@CashMont", cashmount);
                    SalesDetail.Parameters.AddWithValue("@changeCash", changesales);
                    SalesDetail.Parameters.AddWithValue("@UserName", Username);
                    SalesDetail.Parameters.AddWithValue("@TerminalUser", terminaluser);

                    SalesDetail.ExecuteScalar();
                    correct = true;
                }
                catch (SqlException sq)
                {
                    correct = false;
                    MetroFramework.MetroMessageBox.Show(this, "Error Al insertar el registro, detalle: " + sq.ToString(),
                        "Error al Registrar la venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }
            return correct;
        }
        private bool checkcashdetails()
        {
            bool checkCorrect = true;
            if (paymenCash2.TotalRecived.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "La cantidad efectivo esta vacia", "Falta Capturar total Efectivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkCorrect = false;
            }
            return checkCorrect;
        }

        public bool checkDebitValues()
        {
            bool checkCorrect = true;
            if (paymentVales2.Banks.Text != "")
            {
                if (paymentVales2.BankAccount.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "El numero de tarjeta no puede ser vacio", "Falta Número Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkCorrect = false;
                }
                if (paymentVales2.AutCod.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "Debe Capturar primero el código de Autorización", "Falta Código Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkCorrect = false;
                }

            }
            return checkCorrect;

        }

        public bool checkCreditValues()
        {
            bool checkCorrect = true;
            if (paymentCredit2.Banks.Text != "")
            {
                if (paymentCredit2.BankAccount.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "El numero de tarjeta no puede ser vacio", "Falta Número Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkCorrect = false;
                }
                else if (paymentCredit2.BankAccount.Text.Length < 4)
                {
                    MetroFramework.MetroMessageBox.Show(this, "El numero de tarjeta no puede ser menor a 4", "Número Tarjeta incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkCorrect = false;
                }

                if (paymentCredit2.AutCod.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "Debe Capturar primero el código de Autorización", "Falta Código Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkCorrect = false;
                }

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "El nombre del Banco no puede ser vacio", "Falta Seleccionar Banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkCorrect = false;
            }
            return checkCorrect;
        }

        private void PrintTicket()
        {
            string NameCompany = "", Expedicion = "", Direccion = "", Tel = "", RFC = "", Email = "", LocationExpe = "", PhoneSuc = "", CodeStore = "", FullNameUser = "";
            string footer = "";
            CrearTicket ticket = new CrearTicket();

            DataTable TableCompany = new DataTable();
            TableCompany = GetDataCompany(Datacompany);
            //da.Fill(ds, "Company");"0NameCompany,1Location,2RFC,3City,4PCode,5StateMex,6Email,7Phone
            foreach (DataRow datacom in TableCompany.Rows)
            {
                NameCompany = datacom[0].ToString();
                Direccion = datacom[1].ToString() + " " + datacom[3].ToString() + " " + datacom[4].ToString();
                Tel = datacom[7].ToString();
                Email = datacom[6].ToString();
                RFC = datacom[2].ToString();
            }
            ticket.TextoCentro(NameCompany);
            string direccion = "Direccion";
            int otilde = 243;
            char x = (char)otilde;
            string direccionwitouttilde = direccion.Replace('ó','o');
            //ticket.TextoCentro("Dirección");
            ticket.TextoCentro(direccionwitouttilde);
            ticket.TextoCentro(Direccion);
            ticket.TextoCentro("TELEF: " + Tel);
            ticket.TextoCentro("R.F.C: " + RFC);
            ticket.TextoCentro("EMAIL: " + Email);
            DataTable TableSucursal = new DataTable();
            TableSucursal = GetdataSucursal(DataSucursal);
            //0NameStore, 1Location, 2statemex, 3city, 4Tel, 5CodeStore from StoresDetail
            foreach (DataRow datasu in TableSucursal.Rows)
            {
                Expedicion = datasu[0].ToString();
                LocationExpe = datasu[1].ToString() + " " + datasu[3].ToString() + ", " + datasu[2].ToString();
                PhoneSuc = datasu[4].ToString();
                CodeStore = datasu[5].ToString();
                footer = datasu[6].ToString();
            }


            ticket.TextoCentro("EXPEDIDO EN: " + Expedicion);
            ticket.TextoCentro(LocationExpe);
            ticket.TextoCentro("Telefono Suc.: " + PhoneSuc);
            //Datos Vendedor y No.Ticket
            string No_ticket = CodeStore + terminaluser.ToString() + "-00" + BackTransfer.ToString();
            //ID TICKET
            if (BackTransfer >= 1)
            {
                using (SqlConnection con = ConexionSQL.Cadenaconexion("ATX_POS"))
                {
                    con.Open();
                    SqlCommand ticketNoDoc = new SqlCommand();
                    ticketNoDoc.Parameters.Clear();
                    ticketNoDoc.Connection = con;
                    ticketNoDoc.CommandText = "Update Sales SET [NoTicket]=@IdTicket where [NoVenta] =@salesId ";
                    ticketNoDoc.Parameters.AddWithValue("@salesId", BackTransfer);
                    ticketNoDoc.Parameters.AddWithValue("@IdTicket", No_ticket);
                    ticketNoDoc.ExecuteNonQuery();
                }
            }
            DataTable TableUser = new DataTable();
            TableUser = GetUser(DataUser, IDUser);
            foreach (DataRow UserRow in TableUser.Rows)
            {
                FullNameUser = UserRow[0].ToString() + " " + UserRow[1].ToString();
            }
            //FullNameUser = TableUser.Rows[0].Cells[0].ToString() + " " + TableUser.Rows[0].Cells[1].ToString();
            ticket.TextoIzquierda("ATENDIO: " + FullNameUser);
            ticket.TextoExtremos("Caja # " + terminaluser.ToString(), "Ticket:" + No_ticket);
            //FIN DATOS CABECERA
            ticket.lineasAsteriscos();
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToString("MM/dd/yyyy"), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();
            //ticket.TextoIzquierda("");

            //Datos Detalle Ticket
            DataTable tickectdetail = new DataTable();
            tickectdetail = GetDataTicket(DataTicket, TransId);
            ticket.EncabezadoVenta();
            ticket.lineasAsteriscos();


            foreach (DataRow rowItem in tickectdetail.Rows)
            {
                decimal importe = GetImport(rowItem[2].ToString(), rowItem[1].ToString());
                ticket.AgregaArticulo(rowItem[3].ToString(), rowItem[2].ToString(),
                        Convert.ToDecimal(rowItem[1].ToString()), importe);
            }

            /*ticket.AgregaArticulo("Articulo A", 2, 20, 40);
            ticket.AgregaArticulo("Articulo B", 1, 10, 10);
            ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
            */
            ticket.lineasIgual();


            //Resumen de la venta
            string Subtotal = "", IVA = "", Total = "", Change = "", TotalItems = "", codepayments = "", mix = "", CashPaycusto = "";
            bool mixbol = false;
            string custCodepayment = "";
            DataTable TableSales = new DataTable();
            //0SalesTotal, 1SalesSubtotal, 2IVA, 3ChangeSales, 4TotalItems,5Mixpayment,6codePayment, 7CashPay, 8CustomCode
            TableSales = GetDataSales(DataSales, TransId);
            foreach (DataRow rowSales in TableSales.Rows)
            {
                Subtotal = rowSales[1].ToString();
                IVA = rowSales[2].ToString();
                Total = rowSales[0].ToString();
                Change = rowSales[3].ToString();
                TotalItems = rowSales[4].ToString();
                mix = rowSales[5].ToString();
                codepayments = rowSales[6].ToString();
                mixbol = bool.Parse(mix);
                CashPaycusto = rowSales[7].ToString();
                custCodepayment = rowSales[8].ToString();
            }
            //MessageBox.Show(mix+mixbol);
            ticket.AgregarTotales("      SUBTOTAL......$", Subtotal);
            ticket.AgregarTotales("      IVA...........$", IVA);
            ticket.AgregarTotales("      TOTAL.........$", Total);
            ticket.TextoIzquierda("");

            DataTable detailcards = new DataTable();
            //Detalle de Pago
            #region singlepayment
            if (mixbol == false)
            {
                //PagoEfectivo
                if (codepayments == "01")
                {
                    ticket.TextoExtremos("Forma de Pago: ", "Efectivo");
                    ticket.AgregarTotales("       EFECTIVO......$", CashPaycusto);
                    ticket.AgregarTotales("       CAMBIO........$", Change);
                }
                else if ((codepayments == "04") || (codepayments == "28") || (codepayments == "08"))
                {
                    string Meses = "", Totalcard = "", Interese = "", Numcard = "";
                    detailcards = GetdetailPaymentCards(TransId, codepayments);
                    foreach (DataRow rowcard in detailcards.Rows)
                    {
                        //0BankName, 1Total, 2CardNumber, 3CodeAuto
                        if (codepayments == "04")
                        {
                            ticket.TextoExtremos("Forma de Pago: ", "Tarjeta de Crédito");
                            ticket.AgregarTotales("  Tarjeta Credito......$", rowcard[1].ToString());
                        }
                        if (codepayments == "08")
                        {
                            ticket.TextoExtremos("Forma de Pago: ", "Tarjeta de Vales");
                            ticket.AgregarTotales("  Tarjeta Vales......$", rowcard[1].ToString());
                        }
                        if (codepayments == "28")
                        {
                            ticket.TextoExtremos("Forma de Pago: ", "Tarjeta de Débito");
                            ticket.AgregarTotales("  Tarjeta Débito......$", rowcard[1].ToString());
                        }
                        ticket.TextoIzquierda("");

                        ticket.TextoExtremos("Banco", rowcard[0].ToString());
                        string NoCard = rowcard[2].ToString();
                        //int lengthCard = NoCard.Length;
                        //int startpoint = lengthCard - 4;
                        //string Card = NoCard.Substring(startpoint);//, lengthCard);
                        ticket.TextoExtremos("No. Tarjeta", "****-" + NoCard);
                        ticket.TextoExtremos("Codigo Autorización", rowcard[3].ToString());

                    }
                }
            }
            #endregion
            else if (mixbol == true)
            {
                char[] delimiterChars = { '|', '|' };
                string[] codes = custCodepayment.Split(delimiterChars);
                foreach (string code in codes)
                {
                    if (code == "01")
                    {
                        ticket.TextoExtremos("Forma de Pago: ", "Efectivo");
                        ticket.AgregarTotales("       EFECTIVO......$", CashPaycusto);
                        ticket.AgregarTotales("       CAMBIO........$", Change);
                    }
                    else if ((code == "04") || (code == "28") || (code == "08"))
                    {
                        string Meses = "", Totalcard = "", Interese = "", Numcard = "";
                        detailcards = GetdetailPaymentCards(TransId, code);
                        foreach (DataRow rowcard in detailcards.Rows)
                        {
                            bool detailadd = false;
                            //0BankName, 1Total, 2CardNumber, 3CodeAuto, 4Debit, 5Credit, 6Vales
                            //BankName, Total,CardNumber,CodeAuto,Debit,Credit,Vales
                            if ((code == "04") && (bool.Parse(rowcard[5].ToString()) == true))
                            {
                                ticket.TextoExtremos("Forma de Pago: ", "Tarjeta de Crédito");
                                ticket.AgregarTotales("  Tarjeta Credito......$", rowcard[1].ToString());
                                detailadd = true;
                                ticket.TextoExtremos("Banco", rowcard[0].ToString());
                                string NoCard = rowcard[2].ToString();
                                int lengthCard = NoCard.Length;
                                int startpoint = lengthCard - 4;
                                string Card = NoCard.Substring(startpoint);//, lengthCard);
                                ticket.TextoExtremos("No. Tarjeta", "****-" + Card);
                                ticket.TextoExtremos("Codigo Autorización", rowcard[3].ToString());
                            }
                            if ((code == "08") && (bool.Parse(rowcard[6].ToString()) == true))
                            {
                                ticket.TextoExtremos("Forma de Pago: ", "Tarjeta de Vales");
                                ticket.AgregarTotales("  Tarjeta Vales......$", rowcard[1].ToString());
                                detailadd = true;
                                ticket.TextoExtremos("Banco", rowcard[0].ToString());
                                string NoCard = rowcard[2].ToString();
                                int lengthCard = NoCard.Length;
                                int startpoint = lengthCard - 4;
                                string Card = NoCard.Substring(startpoint);//, lengthCard);
                                ticket.TextoExtremos("No. Tarjeta", "****-" + Card);
                                ticket.TextoExtremos("Codigo Autorización", rowcard[3].ToString());
                            }
                            if ((code == "28") && (bool.Parse(rowcard[4].ToString()) == true))
                            {
                                ticket.TextoExtremos("Forma de Pago: ", "Tarjeta de Débito");
                                ticket.AgregarTotales("  Tarjeta Débito......$", rowcard[1].ToString());
                                detailadd = true;
                                ticket.TextoExtremos("Banco", rowcard[0].ToString());
                                string NoCard = rowcard[2].ToString();
                                int lengthCard = NoCard.Length;
                                int startpoint = lengthCard - 4;
                                string Card = NoCard.Substring(startpoint);//, lengthCard);
                                ticket.TextoExtremos("No. Tarjeta", "****-" + Card);
                                ticket.TextoExtremos("Codigo Autorización", rowcard[3].ToString());
                            }
                            ticket.TextoIzquierda("");

                            if (detailadd)
                                break;
                        }
                    }
                }
            }

            //Texto final del Ticket.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ARTICULOS VENDIDOS: " + TotalItems);
            ticket.TextoIzquierda("");
            ticket.lineasAsteriscos();
            /*ticket.TextoIzquierda("LOS CAMBIOS DE PRODUCTO Y REALIZACION DE FACTURA SON  DENTRO DE LOS PRIMEROS QUINCE DIAS HABILES A PARTIR DE LA FECHA DE COMPRA");
            ticket.TextoIzquierda("LAS GARANTIAS DE PRODUCTOS SERAN LAS ESTABLECIDAS POR LOS FABRICANTES.");
            ticket.TextoIzquierda("EN CASO DE DEVOLUCION DE PRODUCTO NO ES POSIBLE HACER REEMBOLSO DEL DINERO, EN ESTE CASO SE PODRA INTERCAMBIAR POR OTRO PRODUCTO.");
            ticket.TextoIzquierda("EN CABLES, FOCOS NO HAY GARANTIA");
            ticket.TextoIzquierda("EN PRENDAS INTIMAS NO HAY CAMBIOS NI DEVOLUCIONES");*/
            ///DataTable FooterTb = GetFooterTable(CodeStore);
            ticket.TextoIzquierda(footer);
            ticket.lineasAsteriscos();
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.CortaTicket();
            //cn.Close();
            string printname = System.Configuration.ConfigurationManager.AppSettings["PrinterName"];
            ticket.ImprimirTicket(printname);//Nombre de la impresora ticketera




            CrearTicket InternalTicket = new CrearTicket();
            InternalTicket.TextoCentro(NameCompany);
            InternalTicket.TextoCentro("EXPEDIDO EN: " + Expedicion);
            InternalTicket.TextoCentro("TELEF: " + Tel);
            InternalTicket.TextoCentro("R.F.C: " + RFC);
            InternalTicket.TextoIzquierda("ATENDIO: " + FullNameUser);
            InternalTicket.TextoExtremos("Caja # " + terminaluser.ToString(), "Ticket:" + No_ticket);
            InternalTicket.lineasAsteriscos();
            InternalTicket.AgregarTotales("      SUBTOTAL......$", Subtotal);
            InternalTicket.AgregarTotales("      IVA...........$", IVA);
            InternalTicket.AgregarTotales("      TOTAL.........$", Total);
            InternalTicket.lineasAsteriscos();
              if (mixbol == false)
            {
                //PagoEfectivo
                if (codepayments == "01")
                {
                    InternalTicket.TextoExtremos("Forma de Pago: ", "Efectivo");
                    InternalTicket.AgregarTotales("       EFECTIVO......$", CashPaycusto);
                    InternalTicket.AgregarTotales("       CAMBIO........$", Change);
                }
                else if ((codepayments == "04") || (codepayments == "28") || (codepayments == "08"))
                {
                    string Meses = "", Totalcard = "", Interese = "", Numcard = "";
                    detailcards = GetdetailPaymentCards(TransId, codepayments);
                    foreach (DataRow rowcard in detailcards.Rows)
                    {
                        //0BankName, 1Total, 2CardNumber, 3CodeAuto
                        if (codepayments == "04")
                        {
                            InternalTicket.TextoExtremos("Forma de Pago: ", "Tarjeta de Crédito");
                            InternalTicket.AgregarTotales("  Tarjeta Credito......$", rowcard[1].ToString());
                        }
                        if (codepayments == "08")
                        {
                            InternalTicket.TextoExtremos("Forma de Pago: ", "Tarjeta de Vales");
                            InternalTicket.AgregarTotales("  Tarjeta Vales......$", rowcard[1].ToString());
                        }
                        if (codepayments == "28")
                        {
                            InternalTicket.TextoExtremos("Forma de Pago: ", "Tarjeta de Débito");
                            InternalTicket.AgregarTotales("  Tarjeta Débito......$", rowcard[1].ToString());
                        }
                        InternalTicket.TextoIzquierda("");

                        InternalTicket.TextoExtremos("Banco", rowcard[0].ToString());
                        string NoCard = rowcard[2].ToString();
                        int lengthCard = NoCard.Length;
                        int startpoint = lengthCard - 4;
                        string Card = NoCard.Substring(startpoint);//, lengthCard);
                        InternalTicket.TextoExtremos("No. Tarjeta", "****-" + Card);
                        InternalTicket.TextoExtremos("Codigo Autorización", rowcard[3].ToString());

                    }
                }
            }
            else if (mixbol == true)
            {
                char[] delimiterChars = { '|', '|' };
                string[] codes = custCodepayment.Split(delimiterChars);
                foreach (string code in codes)
                {
                    if (code == "01")
                    {
                        InternalTicket.TextoExtremos("Forma de Pago: ", "Efectivo");
                        InternalTicket.AgregarTotales("       EFECTIVO......$", CashPaycusto);
                        InternalTicket.AgregarTotales("       CAMBIO........$", Change);
                    }
                    else if ((code == "04") || (code == "28") || (code == "08"))
                    {
                        string Meses = "", Totalcard = "", Interese = "", Numcard = "";
                        detailcards = GetdetailPaymentCards(TransId, code);
                        foreach (DataRow rowcard in detailcards.Rows)
                        {
                            bool detailadd = false;
                            //0BankName, 1Total, 2CardNumber, 3CodeAuto, 4Debit, 5Credit, 6Vales
                            //BankName, Total,CardNumber,CodeAuto,Debit,Credit,Vales
                            if ((code == "04") && (bool.Parse(rowcard[5].ToString()) == true))
                            {
                                InternalTicket.TextoExtremos("Forma de Pago: ", "Tarjeta de Crédito");
                                InternalTicket.AgregarTotales("  Tarjeta Credito......$", rowcard[1].ToString());
                                detailadd = true;
                                InternalTicket.TextoExtremos("Banco", rowcard[0].ToString());
                                string NoCard = rowcard[2].ToString();
                                int lengthCard = NoCard.Length;
                                int startpoint = lengthCard - 4;
                                string Card = NoCard.Substring(startpoint);//, lengthCard);
                                InternalTicket.TextoExtremos("No. Tarjeta", "****-" + Card);
                                InternalTicket.TextoExtremos("Codigo Autorización", rowcard[3].ToString());
                            }
                            if ((code == "08") && (bool.Parse(rowcard[6].ToString()) == true))
                            {
                                InternalTicket.TextoExtremos("Forma de Pago: ", "Tarjeta de Vales");
                                InternalTicket.AgregarTotales("  Tarjeta Vales......$", rowcard[1].ToString());
                                detailadd = true;
                                InternalTicket.TextoExtremos("Banco", rowcard[0].ToString());
                                string NoCard = rowcard[2].ToString();
                                int lengthCard = NoCard.Length;
                                int startpoint = lengthCard - 4;
                                string Card = NoCard.Substring(startpoint);//, lengthCard);
                                InternalTicket.TextoExtremos("No. Tarjeta", "****-" + Card);
                                InternalTicket.TextoExtremos("Codigo Autorización", rowcard[3].ToString());
                            }
                            if ((code == "28") && (bool.Parse(rowcard[4].ToString()) == true))
                            {
                                InternalTicket.TextoExtremos("Forma de Pago: ", "Tarjeta de Débito");
                                InternalTicket.AgregarTotales("  Tarjeta Débito......$", rowcard[1].ToString());
                                detailadd = true;
                                InternalTicket.TextoExtremos("Banco", rowcard[0].ToString());
                                string NoCard = rowcard[2].ToString();
                                int lengthCard = NoCard.Length;
                                int startpoint = lengthCard - 4;
                                string Card = NoCard.Substring(startpoint);//, lengthCard);
                                InternalTicket.TextoExtremos("No. Tarjeta", "****-" + Card);
                                InternalTicket.TextoExtremos("Codigo Autorización", rowcard[3].ToString());
                            }
                            InternalTicket.TextoIzquierda("");

                            if (detailadd)
                                break;
                        }
                    }
                }
            }
              InternalTicket.TextoIzquierda("");
              InternalTicket.TextoIzquierda("");
              InternalTicket.TextoIzquierda("");
              InternalTicket.TextoIzquierda("");
              InternalTicket.CortaTicket();
              //cn.Close();
              string printname2 = System.Configuration.ConfigurationManager.AppSettings["PrinterName"];
              InternalTicket.ImprimirTicket(printname2);//Nombre de la impresora ticketera

            //ticket.ImprimirTicket("EPSON TM-T88V Receipt");//Nombre de la impresora ticketera
        }

        private DataTable GetFooterTable(string CodeStore)
        {
            DataTable FooterTable = new DataTable();
            using (SqlConnection cone = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cone.Open();
                SqlCommand comand = new SqlCommand();
                comand.Parameters.Clear();
                comand.CommandText = "select TOP 1 [FooterTicket] from StoresDetail WHERE [no] <> 0";
                comand.Connection = cone;
                cone.Close();
            }
            return FooterTable;
        }
        //Detalles tarjeta
        private DataTable GetdetailPaymentCards(int TransId, string codepayment)
        {
            DataTable tablecards = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cn.Open();
                SqlCommand datacards = new SqlCommand();
                datacards.Parameters.Clear();
                datacards.CommandText = "select BankName, Total,CardNumber,CodeAuto,Debit,Credit,Vales from CardsDetail where IdSalesReg = @IdSalesReg";
                datacards.Parameters.AddWithValue("@IdSalesReg", TransId);

                datacards.Connection = cn;
                SqlDataAdapter sdadc = new SqlDataAdapter(datacards);

                sdadc.Fill(tablecards);
            }
            return tablecards;
        }

        private DataTable GetUser(DataGridView DataUser, string IDUser)
        {
            DataTable userdata = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cn.Open();
                SqlCommand UserData = new SqlCommand();
                UserData.Parameters.Clear();
                UserData.Connection = cn;
                UserData.CommandText = "select [First Name],LastName from UsersDetails where ID =(select UserDetail from Users where [User] = @IdUser)";
                UserData.Parameters.AddWithValue("@IdUser", Username.ToString());

                SqlDataAdapter dataus = new SqlDataAdapter(UserData);
                dataus.Fill(userdata);
                if (dataus != null)
                {
                    DataUser.DataSource = userdata;
                }
                checkConection(cn);
            }
            return userdata;
        }

        private DataTable GetdataSucursal(DataGridView DataSucursal)
        {
            DataTable dts = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cn.Open();
                SqlCommand dataSuc = new SqlCommand();
                dataSuc.Parameters.Clear();
                dataSuc.Connection = cn;
                dataSuc.CommandText = "Select NameStore, Location, statemex, city, Tel, CodeStore, [FooterTicket] from StoresDetail";
                SqlDataAdapter sdas = new SqlDataAdapter(dataSuc);
                sdas.Fill(dts);
                if (sdas != null)
                {
                    DataSucursal.DataSource = dts;
                }

                checkConection(cn);
            }
            return dts;
        }

        private void checkConection(SqlConnection cn)
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        private void GetTimeSales()
        {
            throw new NotImplementedException();
        }

        private int GetQuantity(string p)
        {
            //int can = Int32.Parse(p);
            int can = Convert.ToInt32(p.ToString());

            return can;
        }

        private decimal GetImport(string Quantity, string Price)
        {
            decimal q = Convert.ToDecimal(Quantity);
            decimal p = Convert.ToDecimal(Price);
            decimal total = Convert.ToDecimal((q * p).ToString("0.00"));
            return total;
        }

        public int PaymentWithCash(string payment, bool mixpayments, decimal cashpayments)
        {
            //paymenCash2.TotalRecived.Text.ToString() != null ||
            #region
            if (payment == "01")
            {
                if (paymenCash2.TotalRecived.Text.Length > 0)
                {
                    var remaing = Convert.ToDecimal(paymenCash2.Remainingtext.Text.ToString());
                    if (remaing >= 0M)
                    {
                        DialogResult result = MetroFramework.MetroMessageBox.Show(this, "¿Está seguro de que desea Registrar la Venta?", "Registrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            cashpay Payinterface = this.Owner as cashpay;
                            if (Payinterface != null)
                            {
                                Payinterface.cash(cashpayments);
                            }
                            RegSales formInterface = this.Owner as RegSales;
                            if (formInterface != null)
                            {

                                TransId = formInterface.RegisterSales(Totalling.Text.ToString(), paymenCash2.Remainingtext.Text.ToString(), payment.ToString(), mixpayments);
                                //         MessageBox.Show(TransId.ToString());
                                if (TransId > 0)
                                {
                                    BackTransfer = TransId;
                                }
                            }
                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El monto recibidio no cubre el total de la venta", "Cubrir Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            #endregion

            return BackTransfer;
        }
        public int PaymentWithCredit(string payment, bool mixpayments)
        {
            #region
            if (payment == "04")
            {
                if (paymentCredit2.Credit.Text.Length > 0)
                {
                    DialogResult result = MetroFramework.MetroMessageBox.Show(this, "¿Está seguro de que desea Registrar la Venta?", "Registrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        RegSales formInterface = this.Owner as RegSales;
                        if (formInterface != null)
                        {

                            TransId = formInterface.RegisterSales(paymentCredit2.Credit.Text.ToString(), "0.00", payment.ToString(), mixpayments);
                            //         MessageBox.Show(TransId.ToString());
                            if (TransId > 0)
                            {
                                BackTransfer = TransId;
                            }
                        }
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El monto recibidio no cubre el total de la venta", "Cubrir Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            #endregion

            return BackTransfer;
        }

        private DataTable GetDataSales(DataGrid DataSales, int BackTransfer)
        {
            DataTable TableDataSales = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cn.Open();
                SqlCommand Sales = new SqlCommand();
                Sales.Parameters.Clear();
                Sales.Connection = cn;
                //
                Sales.CommandText = "Select SalesTotal, SalesSubtotal, IVA, ChangeSales, TotalItems,Mixpayment,codePayment,CashPay,CustomCode from Sales where NoVenta = @IdTrans";
                Sales.Parameters.AddWithValue("@IdTrans", BackTransfer);
                SqlDataAdapter sqaSales = new SqlDataAdapter(Sales);

                if (sqaSales != null)
                {
                    sqaSales.Fill(TableDataSales);
                }
                checkConection(cn);
            }
            return TableDataSales;
        }

        public DataTable GetDataCompany(DataGridView Datacompany)
        {
            DataTable dtsd = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cn.Open();
                SqlCommand DataCompanyCommand = new SqlCommand();
                DataCompanyCommand.Parameters.Clear();
                DataCompanyCommand.Connection = cn;
                //
                DataCompanyCommand.CommandText = "Select NameCompany,Location,RFC,City,PCode,StateMex,Email,Phone from Company";
                //DataCompany.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(DataCompanyCommand);
                sda.Fill(dtsd);
                Datacompany.DataSource = dtsd;

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                //return DataCompany;
            }
            return dtsd;

        }

        public DataTable GetDataTicket(DataGridView Ddata, int BackTransfer)
        {
            DataTable dtsd = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cn.Open();
                SqlCommand DataPayment = new SqlCommand();
                DataPayment.Parameters.Clear();
                DataPayment.Connection = cn;
                DataPayment.CommandText = "select SalesID, price, Quantity,ProductName from SalesDetail Detail Inner Join Sales Sal on Detail.SalesID = Sal.NoVenta where NoVenta = @SalesID";
                DataPayment.Parameters.AddWithValue("@SalesID", BackTransfer);

                SqlDataAdapter sda = new SqlDataAdapter(DataPayment);
                sda.Fill(dtsd);
                Ddata.DataSource = dtsd;

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return dtsd;
        }
        public void TotalRemaining()
        {

            if (paymenCash2.TotalRecived.Text.Length > 0)
            {
                var Totals = Convert.ToDecimal(Totalling.Text.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
                var PayTotal = Convert.ToDecimal(paymenCash2.TotalRecived.Text.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
                var Remaining = decimal.Subtract(PayTotal, Totals);
                paymenCash2.Remainingtext.Text = Remaining.ToString();

            }
            else
            {
                paymenCash2.Remainingtext.Text = "";
            }


        }

        private void paymenCash2_Load(object sender, EventArgs e)
        {
            //Totalling
            var Totals = Convert.ToDecimal(Totalling.Text.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
            paymenCash2.totalfromform = Totals;
        }

        private void paymenCash2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void metroTextButton2_Click(object sender, EventArgs e)
        {
            //Clear Values
            //paymentCash
            paymenCash2.TotalRecived.Text = "";
            paymenCash2.Remainingtext.Text = "";
            //Paymentvales
            paymentVales2.Banks.Text = "";
            paymentVales2.BankAccount.Text = "";
            paymentVales2.debittotal.Text = "";
            paymentVales2.AutCod.Text = "";
            //paymentCredit
            paymentCredit2.Banks.Text = "";
            paymentCredit2.BankAccount.Text = "";
            //paymentCredit2.comision.Text = "";
            paymentCredit2.Credit.Text = "";
            paymentCredit2.AutCod.Text = "";
            //RadioButtons
            MixPayment.Checked = false;
            efectivo.Checked = false;
            credito.Checked = false;
            debito.Checked = false;
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Payments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_Click(object sender, EventArgs e)
        {
            if (MixPayment.Checked != true)
            {
                credito.Checked = false;
                debito.Checked = false;

                //botones
                efectivo.Checked = true;
                if (efectivo.Checked)
                {
                    paymenCash2.Visible = true;
                    paymentCredit2.Visible = false;
                    paymentVales2.Visible = false;
                    //paymentMix1.Visible = false;

                    EfectivoImagen.Visible = true;
                    CreditImagen.Visible = false;
                    DebitImagen.Visible = false;
                    Centerscreen();
                }
            }
            else
                if (credito.Checked || debito.Checked)
                {
                    paymenCash2.Visible = true;
                    paymentCredit2.Visible = false;
                    paymentVales2.Visible = false;

                    paymenCash2.Visible = true;
                    paymentCredit2.Visible = false;
                    paymentVales2.Visible = false;
                }
        }

        private void metroCheckBox3_Click(object sender, EventArgs e)
        {
            if (MixPayment.Checked != true)
            {
                efectivo.Checked = false;
                credito.Checked = false;

                if (debito.Checked)
                {
                    paymenCash2.Visible = false;
                    paymentCredit2.Visible = false;
                    paymentVales2.Visible = true;
                    decimal totallin = decimal.Parse(Totalling.Text.ToString());
                    paymentVales2.debittotal.Text = totallin.ToString();

                    EfectivoImagen.Visible = false;
                    CreditImagen.Visible = false;
                    DebitImagen.Visible = true;

                }

            }
            else
                if (credito.Checked || efectivo.Checked)
                {
                    paymenCash2.Visible = false;
                    paymentCredit2.Visible = false;
                    paymentVales2.Visible = true;

                    paymenCash2.Visible = false;
                    paymentCredit2.Visible = false;
                    paymentVales2.Visible = true;
                }
        }

        private void metroCheckBox2_Click(object sender, EventArgs e)
        {
            if (MixPayment.Checked != true)
            {
                efectivo.Checked = false;
                debito.Checked = false;

                if (credito.Checked)
                {
                    paymenCash2.Visible = false;
                    paymentCredit2.Visible = true;
                    decimal totallin = decimal.Parse(Totalling.Text.ToString());
                    paymentCredit2.Credit.Text = totallin.ToString();
                    paymentVales2.Visible = false;
                    EfectivoImagen.Visible = false;
                    CreditImagen.Visible = true;
                    DebitImagen.Visible = false;
                }
            }
            else
                if (debito.Checked || efectivo.Checked)
                {
                    paymenCash2.Visible = false;
                    paymentCredit2.Visible = true;
                    paymentVales2.Visible = false;
                    EfectivoImagen.Visible = false;
                    CreditImagen.Visible = true;
                    DebitImagen.Visible = false;
                }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Totalling_TextChanged(object sender, EventArgs e)
        {

        }

        private void debito_CheckedChanged(object sender, EventArgs e)
        {
            if (debito.Checked)
                paymentVales2.Visible = true;//debito.Visible = true;
            else
                paymentVales2.Visible = false;
        }

        private void efectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (efectivo.Checked)
            {
                paymenCash2.Visible = true;
                if (MixPayment.Checked)
                {
                    decimal totalscredit = GetTotalsCredits();
                    decimal newtotal = totalscredit;
                    paymenCash2.setnewtotal(newtotal);
                }
                else
                {
                    decimal newtotal = decimal.Parse(Totalling.Text.ToString());
                    paymenCash2.setnewtotal(newtotal);
                }
            }
            else
                paymenCash2.Visible = false;//efectivo.Visible = true;

        }

        private decimal GetTotalsCredits()
        {
            decimal credits = 0M;
            if (MixPayment.Checked)
            {
                if (debito.Checked)
                {
                    if (paymentVales2.debittotal.Text.ToString() != "")
                    {
                        credits += decimal.Parse(paymentVales2.debittotal.Text.ToString());
                    }
                }
                if (credito.Checked)
                {
                    if (paymentCredit2.Credit.Text.ToString() != "")
                    {
                        credits += decimal.Parse(paymentCredit2.Credit.Text.ToString());
                    }
                }
            }
            decimal newtotalswitcredit = decimal.Parse(Totalling.Text.ToString()) - credits;
            return newtotalswitcredit;
        }

        private void credito_CheckedChanged(object sender, EventArgs e)
        {
            if (credito.Checked)
                paymentCredit2.Visible = true;
            else
                paymentCredit2.Visible = false;//credito.Visible = true;
        }
        #region members UpdateChangeRemaing
        public void updatechangeremaing()
        {
            MessageBox.Show("Calcular total restante");
        }
        #endregion

        private void paymenCash2_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                MessageBox.Show("Calcular total restante enter");
                return;
            }

        }

        private void paymentVales2_Load(object sender, EventArgs e)
        {

        }
    }

}
