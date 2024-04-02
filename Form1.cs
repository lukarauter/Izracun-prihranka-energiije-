using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Izračun_Energije_App
{
    public partial class Form1 : Form
    {

        private ErrorProvider errorProvider;
        public Form1()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();

        }

        


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CENA KURILNEGA OLJA
            if (radioButton1.Checked)
            {
                float stroski = float.Parse(label2.Text.Trim())*float.Parse(cena_kolja.Text.Trim());
                float letnokWh = float.Parse(label2.Text.Trim()) * trenutnavrednostKurilnegaOlja;

                //RADIATOR
                if (radioButton4.Checked)
                {
                    float novstrosek = (letnokWh / 3.2F)* float.Parse(cena_elektrike.Text.Trim());
                    float prihranek = stroski - novstrosek;
                    label9.Text = prihranek.ToString("n2");
                }
                //TALNO GRETJE 
                else
                {
                    float novstrosek = (letnokWh / 3.6F) * float.Parse(cena_elektrike.Text.Trim());
                    float prihranek = stroski - novstrosek;
                    label9.Text = prihranek.ToString("n2");
                }
            }
            //CENA PLINA
            if (radioButton2.Checked)
            {
                float stroski = float.Parse(label2.Text.Trim()) * float.Parse(cena_zemeljskega_plina.Text.Trim());
                float letnokWh = float.Parse(label2.Text.Trim()) * trenutnavrednostPlin;

                //RADIATOR
                if (radioButton4.Checked)
                {
                    float novstrosek = (letnokWh / 3.2F) * float.Parse(cena_elektrike.Text.Trim());
                    float prihranek = stroski - novstrosek;
                    label9.Text = prihranek.ToString("n2");
                }
                //TALNO GRETJE 
                else
                {
                    float novstrosek = (letnokWh / 3.6F) * float.Parse(cena_elektrike.Text.Trim());
                    float prihranek = stroski - novstrosek;
                    label9.Text = prihranek.ToString("n2");
                }
            }
            //CENA UTEKOČINJENEGA PLINA
            if (radioButton3.Checked)
            {
                float stroski = float.Parse(label2.Text.Trim()) * float.Parse(cena_plina.Text.Trim());
                float letnokWh = float.Parse(label2.Text.Trim()) * trenutnavrednostUtekočinjenPlin;

                //RADIATOR
                if (radioButton4.Checked)
                {
                    float novstrosek = (letnokWh / 3.2F) * float.Parse(cena_elektrike.Text.Trim());
                    float prihranek = stroski - novstrosek;
                    label9.Text = prihranek.ToString("n2");
                }
                //TALNO GRETJE 
                else
                {
                    float novstrosek = (letnokWh / 3.6F) * float.Parse(cena_elektrike.Text.Trim());
                    float prihranek = stroski - novstrosek;
                    label9.Text = prihranek.ToString("n2");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void label3_Click_2(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Koliko litrov kurilnega olja porabite za ogrevanje";
        }

        private void cena_kolja_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Koliko kubičnih metrov zemeljskega plina porabite za ogrevanje";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            label1.Text = "Koliko litrov utekočinjenega plina porabite za ogrevanje";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
    }
}
