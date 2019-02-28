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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Korttipeli;

namespace Alkuikkuna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Korttipeli : Window
    {
        Stack<Kortti> sekopakka;
        int alkuapuri = 0;
        List<Kortti> korttipakka = new List<Kortti>();
        int klikkeri = -1;


        public Korttipeli()
        {
            InitializeComponent();
            korttipakka = Korttipakka.LuoPakka(korttipakka);
            
        }
        public void btnAloita_Click(object sender, RoutedEventArgs e)//sekoitettu pakka tallennetaan luokan getsetteriin ja uusi ikkuna avataan
        {
            Korttipakka.TallennaPakka = sekopakka;
            PeliKaynnissa peliikkuna = new PeliKaynnissa();

            peliikkuna.Show();
            this.Close();
        }
        public void btnSekoita_Click(object sender, RoutedEventArgs e)//sekoittamaton korttilista lähetetään luokan sekoitus-metodiin ja Aloita-nappi enabloidaan. imgKortti2 muutetaan läpinäkyväksi.
        {
            try
            {
                SoundEffects.PlayEffect("cardshuffle.mp3");

                Korttipakka.SekoitaPakka(korttipakka);
                sekopakka = Korttipakka.TallennaPakka;
                btnAloita.IsEnabled = true;

                alkuapuri++;
                klikkeri = -1;
                imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\redx.PNG", UriKind.Relative));
                imgKortti2.Opacity = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void imgKortti1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//imgKOrtti2 muutetaan näkyväksi, ja lisäksi sen source muutetaan kuvannimi-metodin avulla pakan seuraavan kortin sijanniksi.
        {
            try
            {
                klikkeri++;
                imgKortti2.Opacity = 100;
                if (klikkeri > 51)
                {
                    klikkeri = 52;
                    imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\redx.png", UriKind.Relative));
                }
                else if (alkuapuri == 0)
                {
                    imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\" + Korttipakka.KuvanNimi(korttipakka.ElementAt(klikkeri)) + ".png", UriKind.Relative));
                }
                else
                {
                    imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\" + Korttipakka.KuvanNimi(sekopakka.ElementAt(klikkeri)) + ".png", UriKind.Relative));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void imgKortti2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//imgKortti2.elementin source muutetaan edellisen kortin sijainniksi kuvannimi-metodin avulla.
        {
            try
            {
                klikkeri--;
                if (klikkeri < 0)
                {
                    imgKortti2.Opacity = 0;
                    klikkeri = -1;
                    imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\\redx.PNG", UriKind.Relative));
                }
                else if (alkuapuri == 0)
                {
                    imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\" + Korttipakka.KuvanNimi(korttipakka.ElementAt(klikkeri)) + ".png", UriKind.Relative));
                }
                else if (alkuapuri > 0)
                {
                    imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\" + Korttipakka.KuvanNimi(sekopakka.ElementAt(klikkeri)) + ".png", UriKind.Relative));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnTakaisin_Click(object sender, RoutedEventArgs e)
        {
            Pelinakyma1 peliikkuna = new Pelinakyma1();
            peliikkuna.Show();
            this.Close();
        }
    }
}
