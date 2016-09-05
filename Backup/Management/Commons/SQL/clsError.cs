/*
 * Copyright (c) 2013 BTMU
 * $Author: pthyen $
 * $Date: 2013-03-12 20:37:30 +0700 (Tue, 12 mar 2013) $
 * $Revision: 3978 $ 
 * ========================================================
 * This class is used to show error screen
 * of Log module.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Management.Commons.Popup;


namespace Management.Commons.SQL
{
    public class clsError
    {
        private static Form inputForm = new Form();
        public delegate void InvokeDelegate();

        public static void ShowErrorScreen(string msg, Form input)
        {
            try
            {
                frmCommonError frm = new frmCommonError(msg);
                frm.StartPosition = FormStartPosition.CenterScreen;

                frm.ShowDialog();
                inputForm = input;
                inputForm.BeginInvoke(new InvokeDelegate(CloseTheForm));
            }
            catch (Exception ex) { }
        }
        
        public static void ShowErrorScreen(string msg)
        {
            frmCommonError frm = new frmCommonError(msg);         
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.ShowDialog();

        }
        private static void CloseTheForm()
        {            
            inputForm.Dispose();
            inputForm.Close();            
        }
    }
}
