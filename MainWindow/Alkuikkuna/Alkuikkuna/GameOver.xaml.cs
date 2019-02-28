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
using System.Text.RegularExpressions;

namespace Alkuikkuna
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        public GameOver()
        {
            try
            {
                InitializeComponent();
                SoundEffects.PlayEffect("gameover.wav");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Tallennetaan pisteet viimeksi pelatun peliID:n ja annetun Nickin mukaan
        private void btnTallenna_Click(object sender, RoutedEventArgs e)
        {
            string nimi = PelaajaNick.Text;
            if (Regex.IsMatch(nimi, @"^[a-zA-Z]+$"))
            {
                try
                {
                    DB.VertaaPelaaja(nimi, PeliTiedot.PojoTallennus, PeliTiedot.PeliId);
                    if (PeliTiedot.PeliId == 1)
                    {
                        Pelinakyma1 peliikkuna = new Pelinakyma1();
                        peliikkuna.Show();
                        this.Close();
                    }
                    else if (PeliTiedot.PeliId == 2)
                    {
                        Pelinakyma2 peliikkuna = new Pelinakyma2();
                        peliikkuna.Show();
                        this.Close();
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
        //Ohjaa Back painikkeen klikillä oikeaan pelinäkymään
        private void btnBack1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PeliTiedot.PeliId == 1)
                {
                    Pelinakyma1 peliikkuna = new Pelinakyma1();
                    peliikkuna.Show();
                    this.Close();
                }
                else if (PeliTiedot.PeliId == 2)
                {
                    Pelinakyma2 peliikkuna = new Pelinakyma2();
                    peliikkuna.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
