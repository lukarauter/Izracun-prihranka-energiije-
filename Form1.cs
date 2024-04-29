using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Izračun_Energije_App
{
    public partial class Form1 : Form
    {

        private BackgroundWorker backgroundWorker;
        private ErrorProvider errorProvider;

        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            errorProvider = new ErrorProvider();
            cena_kolja.Validating += ValidateInput;
            cena_zemeljskega_plina.Validating += ValidateInput;
            cena_plina.Validating += ValidateInput;
            cena_elektrike.Validating += ValidateInput;

            cena_kolja.Enabled = false;
            cena_zemeljskega_plina.Enabled = false;
            cena_plina.Enabled = false;
            cena_elektrike.Enabled = false;

            this.FormClosing += Form1_FormClosing;
        }

        private void ValidateInput(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                float value;
                if (!float.TryParse(textBox.Text, out value) || value < 0)
                {
                    e.Cancel = true;
                    errorProvider.SetError(textBox, "Vnesite veljavno pozitivno število.");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(textBox, "");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string datumZapisa = DateTime.Now.ToString();

            using (StreamWriter writer = new StreamWriter("CeneEnergentov.txt", true))
            {
                writer.WriteLine($"Datum zapisa: {datumZapisa}");
                writer.WriteLine($"Kurilno olje: {cena_kolja.Text}");
                writer.WriteLine($"Zemeljski Plin: {cena_zemeljskega_plina.Text}");
                writer.WriteLine($"Utekočinjeni naftni plin plin: {cena_plina.Text}");
                writer.WriteLine();
            }

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
                float stroski = float.Parse(label2.Text.Trim()) * float.Parse(cena_kolja.Text.Trim());
                float letnokWh = float.Parse(label2.Text.Trim()) * trenutnavrednostKurilnegaOlja;

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
            label3.AutoSize = true;

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
            float originalna_vrednost_olja = 1.076f;
            float originalna_vrednost_zplina = 0.782f;
            float originalna_vrednost_plina = 0.969f;


            DialogResult result = MessageBox.Show($"Trenutne cene energentov:\nKurilno olje: {originalna_vrednost_olja}\nPlin: {originalna_vrednost_zplina}\nUtekočinjen plin: {originalna_vrednost_plina}\n\nŽelite ponastaviti cene energentov?", "Ponastavitev cen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Če uporabnik klikne "Yes", ponastavimo cene energentov na izvirne vrednosti
                MessageBox.Show("Cene energentov so bile uspešno ponastavljene.", "Ponastavitev uspešna", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ponastavimo vrednosti v tekstnih poljih na izvirne vrednosti
                cena_kolja.Text = originalna_vrednost_olja.ToString();
                cena_zemeljskega_plina.Text = originalna_vrednost_zplina.ToString();
                cena_plina.Text = originalna_vrednost_plina.ToString();


            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //OMOGOČI UPORABNIKOV VNOS CEN
            cena_kolja.Enabled = true;
            cena_zemeljskega_plina.Enabled = true;
            cena_plina.Enabled = true;
            cena_elektrike.Enabled = true;
        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cena_zemeljskega_plina_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = false;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }


        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string izbraniEnergent = (string)e.Argument;
            string izbraniNacinOgrevanja = ""; // Placeholder for selected heating method

            // Determine selected heating method
            this.Invoke((MethodInvoker)delegate
            {
                if (radioButton4.Checked)
                {
                    izbraniNacinOgrevanja = "Radiatorji";
                }
                else if (radioButton5.Checked)
                {
                    izbraniNacinOgrevanja = "Talno ogrevanje";
                }
            });

            using (StreamWriter writer = new StreamWriter("PRIHRANKI.txt", true))
            {
                for (int letnaPoraba = 1; letnaPoraba <= 50000; letnaPoraba++)
                {
                    double prihranki = IzracunLetnihPrihrankov(izbraniEnergent, izbraniNacinOgrevanja, letnaPoraba);
                    string dvedecimalkiPrihranki = prihranki.ToString("F2");
                    string line = $"{izbraniEnergent}, {izbraniNacinOgrevanja}, {dvedecimalkiPrihranki}";
                    writer.WriteLine(line);
                }
            }
        }


        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"An error occurred: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Kalkulacije so bile zaključene in podatki so shranjeni v PRIHRANKI.txt", "Obvestilo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string izbraniEnergent = ""; // Shranimo izbrani energent

            // Preverimo, kateri energent je bil izbran
            if (radioButton1.Checked)
            {
                izbraniEnergent = "Kurilno olje";
            }
            else if (radioButton2.Checked)
            {
                izbraniEnergent = "Zemeljski plin";
            }
            else if (radioButton3.Checked)
            {
                izbraniEnergent = "Utekočinjeni naftni plin";
            }

            // Preverimo, ali je bila izbrana vsaj ena možnost
            if (!string.IsNullOrEmpty(izbraniEnergent))
            {
                // Start the background worker
                backgroundWorker.RunWorkerAsync(izbraniEnergent);
            }
            else
            {
                MessageBox.Show("Prosimo, izberite energent!", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private double IzracunLetnihPrihrankov(string energent, string naciniOgrevanja, float letnaPoraba)
        {
            float currentCosts = 0;
            float currentEnergyValue = 0;
            float currentElectricityPrice = float.Parse(cena_elektrike.Text.Trim()); // Predpostavka: cena_elektrike je kontrola, ki vsebuje ceno električne energije
            float newCosts = 0;

            // Calculate current costs and energy value based on selected fuel
            switch (energent)
            {
                case "Kurilno olje":
                    currentCosts = letnaPoraba * float.Parse(cena_kolja.Text.Trim());
                    currentEnergyValue = letnaPoraba * 8.5F; // Energija kurilnega olja v kW
                    break;
                case "Zemeljski plin":
                    currentCosts = letnaPoraba * float.Parse(cena_zemeljskega_plina.Text.Trim());
                    currentEnergyValue = letnaPoraba * 9.5F; // Energija zemeljskega plina v kW
                    break;
                case "Utekocinjeni plin":
                    currentCosts = letnaPoraba * float.Parse(cena_plina.Text.Trim());
                    currentEnergyValue = letnaPoraba * 6.5F; // Energija utekočinjenega plina v kW
                    break;
                default:
                    // Handle unknown fuel type
                    break;
            }

            // Calculate new costs based on heating method
            if (naciniOgrevanja == "Radiatorji")
            {
                newCosts = (currentEnergyValue / 3.2F) * currentElectricityPrice;
            }
            else if (naciniOgrevanja == "Talno gretje")
            {
                newCosts = (currentEnergyValue / 3.6F) * currentElectricityPrice;
            }

            // Calculate savings
            return currentCosts - newCosts;
        }









    }


}




