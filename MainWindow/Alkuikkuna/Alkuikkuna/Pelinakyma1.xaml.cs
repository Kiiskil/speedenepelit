using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Korttipeli;

namespace Alkuikkuna
{
    /// <summary>
    /// Interaction logic for Pelinakyma1.xaml
    /// </summary>
    public partial class Pelinakyma1 : Window
    {
        public Pelinakyma1()
        {
            try
            {
                InitializeComponent();
                //Määrittää Play/Pause buttonin teksin sen mukaan onko musiikki käynnissä vai ei
                if (Music.paalla == 1)
                {
                    btnMute.Content = "Pause";
                }
                else if (Music.paalla == 0)
                {
                    btnMute.Content = "Play";
                }
                Ennatykset();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Listaa pelin ennätykset pisteiden mukaan
        private void Ennatykset()
        {
            try
            {
                List<DB.Rekka> enkat = new List<DB.Rekka>();
                enkat = DB.HaePisteet(1);
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
        //Siirtyy takaisin pääikkunnaan
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

        //Siirtyy Korttipelin valmistelu ikkunaan
        private void btnUusiPeli1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Korttipeli peliikkuna = new Korttipeli();
                peliikkuna.Show();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Pysäyttää tai aloittaa musiikin riippuen sen nykyisestä tilasta
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

        //Vaihtaa hiscorejen tilalle peliohjeen, uudelleen klikattaessa vaihtaa hiscoret takaisin
        private void btnOhje1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnOhje1.Content.ToString() == "Ohje")
                {
                    txtHiscore1.Text = "----Punainen vai musta---- \nKlikkaa sekoita painikkeita. Tämän jälkeen voit selata pakkaa eteen- ja taaksepäin klikkaamalla kortteja. Yritä opetella korttien värijärjestys. Kun olet valmis aloittamaan klikkaa aloita-painiketta. Peliä pelataan mustalla ja punaisella napilla.";
                    btnOhje1.Content = "Hiscores";
                }
                else if (btnOhje1.Content.ToString() == "Hiscores")
                {
                    txtHiscore1.Text = "";
                    Ennatykset();
                    btnOhje1.Content = "Ohje";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
