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
    public partial class RePrintTicket : MetroFramework.Forms.MetroForm
    {
        static DataGridView DataTicket = new DataGridView();
        static DataGridView DataUser = new DataGridView();
        public DataGridView Datacompany = new DataGridView();
        public DataGrid DataSales = new DataGrid();
        static DataGridView DataSucursal = new DataGridView();

        public RePrintTicket()
        {
            InitializeComponent();
            TicketCode.Focus();
        }

        private void RePrintTicket_Load(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (TicketCode.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "No ha introducido el codigo de ticket", "Capture el codigo primero", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string codeticket = "";
            int idregsalesTicket = 0;
            if (TicketCode.Text.Length > 5)
            {
                codeticket = TicketCode.Text.ToString();
            }
            else
            {
                idregsalesTicket = int.Parse(TicketCode.Text.ToString());
            }
            DataTable datareprint = new DataTable();
            
            int reg = 0;
            datareprint = getdatareprint(codeticket, idregsalesTicket, ref reg);
            if (reg > 0)
                try
                {
                    string NameCompany = "", Expedicion = "", Direccion = "", Tel = "", RFC = "", Email = "", LocationExpe = "", PhoneSuc = "", CodeStore = "", FullNameUser = "";
                    string footer = "";
                    string codeticketdata = "";
                    int TransId = 0;
                    int iduserreg = 0;
                    bool mixbol = false;
                    string datereg = "";
                    string timereg = "";
                    string terminaluser = "";
                    CrearTicket ticket = new CrearTicket();
                    foreach (DataRow row in datareprint.Rows)
                    {
                        //0[NoVenta], 1[User], 2[Mixpayment], 3[Terminal], 4[Date], 5[Time], 6[NoTicket]
                        TransId = int.Parse(row[0].ToString());
                        iduserreg = int.Parse(row[1].ToString());
                        mixbol = bool.Parse(row[2].ToString());
                        terminaluser = row[3].ToString();
                        datereg = row[4].ToString();
                        timereg = row[5].ToString();
                        codeticketdata = row[6].ToString();
                    }

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
                    string direccionwitouttilde = direccion.Replace('ó', 'o');
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

                    //ID TICKET
                    DataTable TableUser = new DataTable();
                    TableUser = GetUser(DataUser, iduserreg);
                    foreach (DataRow UserRow in TableUser.Rows)
                    {
                        FullNameUser = UserRow[0].ToString() + " " + UserRow[1].ToString();
                    }
                    //FullNameUser = TableUser.Rows[0].Cells[0].ToString() + " " + TableUser.Rows[0].Cells[1].ToString();
                    ticket.TextoIzquierda("ATENDIO: " + FullNameUser);
                    ticket.TextoExtremos("Caja # " + terminaluser.ToString(), "Ticket:" + codeticketdata);
                    //FIN DATOS CABECERA
                    ticket.lineasAsteriscos();
                    string shorttime = timereg.Substring(0, 5);
                    ticket.TextoExtremos("FECHA: " + datereg, "HORA: " + shorttime);
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
                    TicketCode.Text = "";
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show(sqlex.ErrorCode + " " + sqlex.Message.ToString() + ", " + sqlex.LineNumber);
                }
                catch (FormatException formatex)
                {
                    MessageBox.Show(formatex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

        }

        private DataTable getdatareprint(string codeticket, int codeticketID, ref int regis)
        {
            DataTable datareprintersales = new DataTable();
            using (SqlConnection conex = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                checkConection(conex);
                conex.Open();
                SqlCommand datasalesticket = new SqlCommand();
                datasalesticket.Parameters.Clear();
                datasalesticket.Connection = conex;
                datasalesticket.CommandText = "select [NoVenta], [User], [Mixpayment], [Terminal], [Date], [Time], [NoTicket] from Sales where [NoTicket] = @CodeTicket or [NoVenta]=@CodeTicketID";
                datasalesticket.Parameters.AddWithValue("@CodeTicket", codeticket);
                datasalesticket.Parameters.AddWithValue("@CodeTicketID", codeticketID);
                regis = Convert.ToInt32(datasalesticket.ExecuteScalar());
                //conex.Open();
                if (regis > 0)
                {
                    SqlDataAdapter sqda = new SqlDataAdapter(datasalesticket);
                    if (sqda != null)
                    {
                        sqda.Fill(datareprintersales);
                    }
                }

                checkConection(conex);
            }
            return datareprintersales;
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

        private DataTable GetUser(DataGridView DataUser, int IDUser)
        {
            DataTable userdata = new DataTable();
            using (SqlConnection cn = ConexionSQL.Cadenaconexion("ATX_POS"))
            {
                cn.Open();
                SqlCommand UserData = new SqlCommand();
                UserData.Parameters.Clear();
                UserData.Connection = cn;
                UserData.CommandText = "select [First Name],LastName from UsersDetails where ID = @IdUser";
                UserData.Parameters.AddWithValue("@IdUser", IDUser);

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

        private void checkConection(SqlConnection cn)
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        private decimal GetImport(string Quantity, string Price)
        {
            decimal q = Convert.ToDecimal(Quantity);
            decimal p = Convert.ToDecimal(Price);
            decimal total = Convert.ToDecimal((q * p).ToString("0.00"));
            return total;
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
