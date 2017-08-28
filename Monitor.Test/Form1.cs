using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitor.Business;
using System.Net;

namespace Monitor.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            while (true)
            {
                var list = Monitor.Business.Test.List();

                foreach (var item in list)
                {
                    int status = 0;

                    HttpWebResponse response = null;
                    try
                    {
                        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(item.Value);
                        webRequest.AllowAutoRedirect = false;
                        try
                        {
                            response = (HttpWebResponse)webRequest.GetResponse();
                        }
                        catch (Exception)
                        {
                            status = 404;
                        }
                        if (response != null)
                            status = (int)response.StatusCode;
                    }
                    catch (UriFormatException)
                    {
                        status = 404;
                    }
                    Monitor.Business.Test.SaveTestResult(item.Key, status);
                    //TODO : Business'da SaveTestResult gibi bir metodumuz olacak sonucu veri tabanındaki TestResult Tablosuna Insert edicez.

                    // Status Code 302'nin anlamı Bulundu(Found) ve yönlendiriliyor.(Redirect)
                }
            }
        }
    }
}
