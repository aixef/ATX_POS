using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATX_POS
{
    /*public interface Iform
    {
        int RegisterSales();
    }*/
    public interface CancelSales
    {
        void cleardatagrid();
    }
    public interface UpdateValues
    {
        void UpdateValues();
    }
    public interface RegSales
    {
        int RegisterSales(string total, string Remainingtext, string codepayment, bool paymentmix);
    }
    public interface cashpay
    {
        void cash(decimal cashfrompayment);
    }
    public interface cashout
    {
        int aceptcashout(string user);
    }
    public interface getidcomment
    {
        void getid(int idcoment);
    }
    public interface restartApp
    {
        void RestartAplication();
    }
    public interface UpdateChangeRemaing
    {
        void updatechangeremaing();
    }
}
