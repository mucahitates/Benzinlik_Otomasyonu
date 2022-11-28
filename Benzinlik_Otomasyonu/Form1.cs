using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benzinlik_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //D► depo E►eklenen F►fiyat S►Satılan
        double D_benzin95 = 0, D_benzin97 = 0, D_dizel = 0, D_eurodizel = 0, D_LPG = 0;
        double E_benzin95 = 0, E_benzin97 = 0, E_dizel = 0, E_eurodizel = 0, E_LPG = 0;
        double F_benzin95 = 0, F_benzin97 = 0, F_dizel = 0, F_eurodizel = 0, F_LPG = 0;
        double S_benzin95 = 0, S_benzin97 = 0, S_dizel = 0, S_eurodizel = 0, S_LPG = 0;
        string[] depo_bilgileri;
        string[] fiyat_bilgileri;
        string[] yakit_turleri = { "Benzin (95)", "Benzin (97)", "Dizel", "Euro Dizel", "LPG" };


        private void button3_Click(object sender, EventArgs e)
        {
            S_benzin95 = double.Parse(numericUpDown1.Value.ToString());
            S_benzin97 = double.Parse(numericUpDown2.Value.ToString());
            S_dizel = double.Parse(numericUpDown3.Value.ToString());
            S_eurodizel= double.Parse(numericUpDown4.Value.ToString());
            S_LPG = double.Parse(numericUpDown5.Value.ToString());
            double a = 0;
            if (numericUpDown1.Enabled==true)
            {
                D_benzin95 = D_benzin95 - S_benzin95;
                a = Math.Round(S_benzin95 * Convert.ToDouble(fiyat_bilgileri[0]), 2);
                label29.Text =Convert.ToString(a)+" TL";
            }

            else if (numericUpDown2.Enabled==true)
            {
                D_benzin97 = D_benzin97 - S_benzin97;
                a = Math.Round(S_benzin97 * Convert.ToDouble(fiyat_bilgileri[1]),2);
                label29.Text = Convert.ToString(a)+" TL";
            }
            else if (numericUpDown3.Enabled == true)
            {
                D_dizel = D_dizel - S_dizel;
                a = Math.Round(S_dizel * Convert.ToDouble(fiyat_bilgileri[2]),2);
                label29.Text = Convert.ToString(a)+" TL";
            }
            else if (numericUpDown4.Enabled == true)
            {
                D_eurodizel = D_eurodizel- S_eurodizel;
                a = Math.Round(S_eurodizel * Convert.ToDouble(fiyat_bilgileri[3]),2);
                label29.Text = Convert.ToString(a)+" TL";
            }
            else if (numericUpDown5.Enabled == true)
            {
                D_LPG = D_LPG - S_LPG;
                a = Math.Round(S_LPG * Convert.ToDouble(fiyat_bilgileri[4]),2);
                label29.Text = Convert.ToString(a)+" TL";

            }

            depo_bilgileri[0] = D_benzin95.ToString();
            depo_bilgileri[1] = D_benzin97.ToString();
            depo_bilgileri[2] = D_dizel.ToString();
            depo_bilgileri[3] = D_eurodizel.ToString();
            depo_bilgileri[4] = D_LPG.ToString();
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt",depo_bilgileri);
            txt_depo_oku();
            depo_yaz();
            progressbar_degeri();
            numericupdown_value();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
           

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()==yakit_turleri[0])
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false; numericUpDown2.Text = "0";
                numericUpDown3.Enabled = false; numericUpDown3.Text = "0";
                numericUpDown4.Enabled = false; numericUpDown4.Text = "0";
                numericUpDown5.Enabled = false; numericUpDown5.Text = "0";

            }
            else if (comboBox1.SelectedItem.ToString()==yakit_turleri[1])
            {
                numericUpDown1.Enabled = false; numericUpDown1.Text = "0";
                numericUpDown2.Enabled =true; 
                numericUpDown3.Enabled = false; numericUpDown3.Text = "0";
                numericUpDown4.Enabled = false; numericUpDown4.Text = "0";
                numericUpDown5.Enabled = false; numericUpDown5.Text = "0";
            }
            else if (comboBox1.SelectedItem.ToString() ==yakit_turleri[2])
            {
                numericUpDown1.Enabled = false; numericUpDown1.Text = "0";
                numericUpDown2.Enabled = false; numericUpDown2.Text = "0";
                numericUpDown3.Enabled = true; 
                numericUpDown4.Enabled = false; numericUpDown4.Text = "0";
                numericUpDown5.Enabled = false; numericUpDown5.Text = "0";
            }
            else if (comboBox1.SelectedItem.ToString() ==yakit_turleri[3] )
            {
                numericUpDown1.Enabled = false; numericUpDown1.Text = "0";
                numericUpDown2.Enabled = false ; numericUpDown2.Text = "0";
                numericUpDown3.Enabled = false; numericUpDown3.Text = "0";
                numericUpDown4.Enabled = true; 
                numericUpDown5.Enabled = false; numericUpDown5.Text = "0";
            }
            else if (comboBox1.SelectedItem.ToString() == yakit_turleri[4])
            {
                numericUpDown1.Enabled = false; numericUpDown1.Text = "0";
                numericUpDown2.Enabled = false; numericUpDown2.Text = "0";
                numericUpDown3.Enabled = false; numericUpDown3.Text = "0";
                numericUpDown4.Enabled = false; numericUpDown4.Text = "0";
                numericUpDown5.Enabled = true; 
            }
            label29.Text = "____";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Akaryakıt Otomasyonu";
            progressBar1.Maximum = 10000; 
            progressBar2.Maximum = 10000;
            progressBar3.Maximum = 10000;
            progressBar4.Maximum = 10000;
            progressBar5.Maximum = 10000;

            txt_depo_oku();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            depo_yaz();
            progressbar_degeri();
            numericupdown_value();

            
            comboBox1.Items.AddRange(yakit_turleri);
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown1.DecimalPlaces = 2; //virgülden sonra kaç basamak
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;
            numericUpDown1.Increment = 20M; // artış miktarı "20 şer artacak"
            numericUpDown2.Increment = 20M;  // sonunda M olmalı
            numericUpDown3.Increment = 20M;
            numericUpDown4.Increment = 20M;
            numericUpDown5.Increment = 20M;
            numericUpDown1.ReadOnly = true;  // dışarıdan veri girişi kapatıldı
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;
           


        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;

            }
            else if (checkBox2.Checked == false)
            {
                checkBox1.Enabled = true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;

            }
            else if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
           
            if (checkBox1.Checked==true)
            {
                try
                {
                    F_benzin95 = F_benzin95 - (F_benzin95 * Convert.ToDouble(textBox6.Text) / 100);
                    fiyat_bilgileri[0] = Convert.ToString(F_benzin95);

                }
                catch (Exception)
                {

                    textBox6.Text = "Hata!";
                }
                try
                {
                    F_benzin97 = F_benzin97 - (F_benzin97 * Convert.ToDouble(textBox7.Text) / 100);
                    fiyat_bilgileri[1] = Convert.ToString(F_benzin97);

                }
                catch (Exception)
                {

                    textBox7.Text = "Hata!";
                }
                try
                {
                    F_dizel = F_dizel - (F_dizel * Convert.ToDouble(textBox8.Text) / 100);
                    fiyat_bilgileri[2] = Convert.ToString(F_dizel);

                }
                catch (Exception)
                {

                    textBox8.Text = "Hata!";
                }
                try
                {
                    F_eurodizel = F_eurodizel - (F_eurodizel * Convert.ToDouble(textBox9.Text)) / 100;
                    fiyat_bilgileri[3] = Convert.ToString(F_eurodizel);

                }
                catch (Exception)
                {

                    textBox9.Text = "Hata!";
                }
                try
                {
                    F_LPG = F_LPG - (F_LPG * Convert.ToDouble(textBox10.Text)) / 100;
                    fiyat_bilgileri[4] = Convert.ToString(F_LPG);

                }
                catch (Exception)
                {

                    textBox10.Text = "Hata!";
                }
                System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt", fiyat_bilgileri);
                //yapılan değişiklikler fiyat.txt dosyasında güncellendi;
                txt_fiyat_oku();
                txt_fiyat_yaz(); 
            }
            if (checkBox2.Checked == true)
            {
                try
                {
                    F_benzin95 = F_benzin95 + (F_benzin95 * Convert.ToDouble(textBox6.Text) / 100);
                    fiyat_bilgileri[0] = Convert.ToString(F_benzin95);

                }
                catch (Exception)
                {

                    textBox6.Text = "Hata!";
                }
                try
                {
                    F_benzin97 = F_benzin97 +(F_benzin97 * Convert.ToDouble(textBox7.Text) / 100);
                    fiyat_bilgileri[1] = Convert.ToString(F_benzin97);

                }
                catch (Exception)
                {

                    textBox7.Text = "Hata!";
                }
                try
                {
                    F_dizel = F_dizel+ (F_dizel * Convert.ToDouble(textBox8.Text) / 100);
                    fiyat_bilgileri[2] = Convert.ToString(F_dizel);

                }
                catch (Exception)
                {

                    textBox8.Text = "Hata!";
                }
                try
                {
                    F_eurodizel = F_eurodizel + (F_eurodizel * Convert.ToDouble(textBox9.Text)) / 100;
                    fiyat_bilgileri[3] = Convert.ToString(F_eurodizel);

                }
                catch (Exception)
                {

                    textBox9.Text = "Hata!";
                }
                try
                {
                    F_LPG = F_LPG + (F_LPG * Convert.ToDouble(textBox10.Text)) / 100;
                    fiyat_bilgileri[4] = Convert.ToString(F_LPG);

                }
                catch (Exception)
                {

                    textBox10.Text = "Hata!";
                }
                System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt", fiyat_bilgileri);

                txt_fiyat_oku();
                txt_fiyat_yaz();
            }





        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                E_benzin95 = Convert.ToDouble(textBox1.Text);
                if (E_benzin95 + D_benzin95 > 10000 || D_benzin95 <= 0)
                    textBox1.Text = "Hata!";
               
                else
                    depo_bilgileri[0] = Convert.ToString(D_benzin95 + E_benzin95);
               
            }
            catch (Exception)
            {
                if (textBox1.Text == "")
                    textBox1.Text = "...";
                else
                    textBox1.Text = "Hata!";
            }
            try
            {
                E_benzin97 = Convert.ToDouble(textBox2.Text);
                if (E_benzin97 + D_benzin97 > 10000 || D_benzin97 <= 0)
                    textBox2.Text = "Hata!";

                else
                    depo_bilgileri[1] = Convert.ToString(D_benzin97 + E_benzin97);

            }
            catch (Exception)
            {
                if (textBox2.Text == "")
                    textBox2.Text = "...";
                else
                    textBox2.Text = "Hata!";
            }
            try
            {
                E_dizel = Convert.ToDouble(textBox3.Text);
                if (E_dizel + D_dizel > 10000 || D_dizel <= 0)
                    textBox3.Text = "Hata!";

                else
                    depo_bilgileri[2] = Convert.ToString(D_dizel + E_dizel);

            }
            catch (Exception)
            {
                if (textBox3.Text == "")
                    textBox3.Text = "...";
                else
                    textBox3.Text = "Hata!";
            }
            try
            {
                E_eurodizel = Convert.ToDouble(textBox4.Text);
                if (E_eurodizel + D_eurodizel > 10000 || D_eurodizel <= 0)
                    textBox4.Text = "Hata!";

                else
                    depo_bilgileri[3] = Convert.ToString(D_eurodizel + E_eurodizel);

            }
            catch (Exception)
            {
                if (textBox4.Text == "")
                    textBox4.Text = "...";
                else
                    textBox4.Text = "Hata!";
            }
            try
            {
                E_LPG = Convert.ToDouble(textBox5.Text);
                if (E_LPG + D_LPG > 10000 || D_LPG <= 0)
                    textBox5.Text = "Hata!";

                else
                    depo_bilgileri[4] = Convert.ToString(D_LPG + E_LPG);

            }
            catch (Exception)
            {
                if (textBox5.Text == "")
                    textBox5.Text = "...";
                else
                    textBox5.Text = "Hata!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo_bilgileri);
            txt_depo_oku();
            progressbar_degeri();
            numericupdown_value();
            depo_yaz();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void txt_depo_oku()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            D_benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            D_dizel = Convert.ToDouble(depo_bilgileri[2]);
            D_eurodizel = Convert.ToDouble(depo_bilgileri[3]);
            D_LPG = Convert.ToDouble(depo_bilgileri[4]);
           
            
        }
        private void depo_yaz()
        {
            label6.Text = D_benzin95.ToString("N")+" LT";
            label7.Text = D_benzin97.ToString("N")+" LT";
            label8.Text = D_dizel.ToString("N")+" LT";
            label9.Text = D_eurodizel.ToString("N")+" LT";
            label10.Text = D_LPG.ToString("N")+" m³";
        }
        private void txt_fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            F_dizel = Convert.ToDouble(fiyat_bilgileri[2]);
            F_eurodizel = Convert.ToDouble(fiyat_bilgileri[3]);
            F_LPG = Convert.ToDouble(fiyat_bilgileri[4]);

        }
        private void txt_fiyat_yaz()
        {
            label17.Text = F_benzin95.ToString() + " TL";
            label18.Text = F_benzin97.ToString() + " TL";
            label19.Text = F_dizel.ToString() + " TL";
            label20.Text = F_eurodizel.ToString() + " TL";
            label21.Text = F_LPG.ToString() + " TL";
        }
        private void progressbar_degeri()
        {
            progressBar1.Value = Convert.ToInt32(D_benzin95);
            progressBar2.Value = Convert.ToInt32(D_benzin97);
            progressBar3.Value = Convert.ToInt32(D_dizel);
            progressBar4.Value = Convert.ToInt32(D_eurodizel);
            progressBar5.Value = Convert.ToInt32(D_LPG);
        }
        private void numericupdown_value()
        {
            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(D_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_eurodizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(D_LPG.ToString());
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
