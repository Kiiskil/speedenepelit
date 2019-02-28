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

namespace Alkuikkuna
{
    /// <summary>
    /// Interaction logic for Pelinakyma2.xaml
    /// </summary>
    public partial class Pelinakyma2 : Window
    {
        public Pelinakyma2()
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
                enkat = DB.HaePisteet(2);
                foreach (DB.Rekka item in enkat)
                {
                    txtHiscore2.Text += item.Pojot + " " + item.PID + "\n";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Siirtyy takaisin pääikkunnaan
        private void btnBack2_Click(object sender, RoutedEventArgs e)
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

        //Aloittaa uuden pelin ja lopettaa musiikin
        private void btnUusiPeli2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Nopeuspeli peliikkuna = new Nopeuspeli();
                Music.PlayPause();
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

        //Vaihtaa hiscorejen tilalle peliohjeen
        private void btnOhje2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnOhje2.Content.ToString() == "Ohje")
                {
                    txtHiscore2.Text = "----Nopeuspeli---- \nKlikkaa painikkeita syttymisjärjestyksessä hiirellä tai niissä ilmoitetuilla painikkeilla. Väärä syöte lopettaa pelin ja peli nopenee jokaisella painikkeen syttymisellä.";
                    btnOhje2.Content = "Hiscores";
                }
                else if (btnOhje2.Content.ToString() == "Hiscores")
                {
                    txtHiscore2.Text = "";
                    Ennatykset();
                    btnOhje2.Content = "Ohje";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
