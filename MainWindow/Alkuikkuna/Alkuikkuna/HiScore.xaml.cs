using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Alkuikkuna
{
    /// <summary>
    /// Interaction logic for HiScore.xaml
    /// </summary>
    public partial class HiScore : Window
    {
        public HiScore()
        {
            try
            {
                InitializeComponent();
                if (Music.paalla == 1)
                {
                    btnMute.Content = "Pause";
                }
                else if (Music.paalla == 0)
                {
                    btnMute.Content = "Play";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow peliikkuna = new MainWindow();
                peliikkuna.Show();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPeli1HiScore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtHiscore1.Text = "";
                Ennatykset(1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPel21HiScore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtHiscore1.Text = "";
                Ennatykset(2);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void Ennatykset(int peliId)
        {
            try
            {
                List<DB.Rekka> enkat = new List<DB.Rekka>();
                enkat = DB.HaePisteet(peliId);
                foreach (DB.Rekka item in enkat)
                {
                    txtHiscore1.Text += item.Pojot + " " + item.PID + "\n";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPelaajaHiscore_Click(object sender, RoutedEventArgs e)
        {
            string nimi = txtPelaajaHaku.Text;
            if (Regex.IsMatch(nimi, @"^[a-zA-Z]+$"))
            {
                try
                {
                    txtHiscore1.Text = "";
                    List<DB.PelaajanEnkat> pelaajanenkat = new List<DB.PelaajanEnkat>();
                    pelaajanenkat = DB.PelaajanPisteet(nimi);
                    foreach (DB.PelaajanEnkat item in pelaajanenkat)
                    {
                        txtHiscore1.Text += item.GameName + " " + item.PelaajaNimi + " " + item.Pisteet + " " + item.pvm + "\n";
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Väärä syöte. Vain kirjaimet sallittuja. Yrititköhän jotain hämyä");
            }
        }

        private void btnMute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Music.PlayPause();
                if (Music.paalla == 1)
                {
                    btnMute.Content = "Pause";
                }
                else if (Music.paalla == 0)
                {
                    btnMute.Content = "Play";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
