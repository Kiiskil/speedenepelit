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
using System.Timers;
using System.Windows.Threading;
using System.Threading;
using Alkuikkuna;

namespace Korttipeli
{
    /// <summary>
    /// Interaction logic for PeliKaynnissa.xaml
    /// </summary>
    public partial class PeliKaynnissa : Window
    {
        Stack<Kortti> sekopakka = new Stack<Kortti>();
        private DispatcherTimer kvajastin;
        int pisteet = 0;
        int klikkeri=0;
        int ticker = 0;
        bool gameover = false;
               
        public PeliKaynnissa()
        {
            try
            {

                InitializeComponent();
                sekopakka = Korttipakka.TallennaPakka;
                lblPisteet.Content = pisteet;
                kvajastin = new DispatcherTimer();
                kvajastin.Interval = new TimeSpan(0, 0, 0, 0, 40);
                kvajastin.Tick += new EventHandler(kvajastin_Tick);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void kvajastin_Tick(object sender, EventArgs e)//kortin kutistumis-animaatio luotu ajastimen avulla.
        {
            try
            {
                if (gameover == false)
                {
                    btnMusta.IsEnabled = false;
                    btnPuna.IsEnabled = false;
                    if (ticker == 0)
                    {
                        Odota();
                        ticker++;
                    }
                    else if (imgKortti2.Width > 15)
                    {
                        imgKortti2.Width -= 15;
                        imgKortti2.Height -= 25;
                    }
                    else
                    {
                        imgKortti2.Height = 260;
                        imgKortti2.Width = 161;
                        imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\purple_back.png", UriKind.Relative));
                        ticker = 0;
                        btnPuna.IsEnabled = true;
                        btnMusta.IsEnabled = true;
                        kvajastin.Stop();
                    }
                }
                else { kvajastin.Stop(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMusta_Click(object sender, RoutedEventArgs e)//käyttäjän syöte tulee painetun kuvan mukaan (musta tai punainen). Syötettä verrataan arvattavaan korttiin.
        {
            try
            {
                Alkuikkuna.SoundEffects.PlayEffect("cardflip.wav");
                Kortti apukortti = sekopakka.ElementAt(klikkeri);
                KortinVaihto();
                if (apukortti.Maa == "Pata" || apukortti.Maa == "Risti")
                {
                    pisteet++;
                    lblPisteet.Content = pisteet;
                }
                else
                {
                    PeliLoppu();
                }
                kvajastin.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPuna_Click(object sender, RoutedEventArgs e)//käyttäjän syöte tulee painetun kuvan mukaan (musta tai punainen). Syötettä verrataan arvattavaan korttiin.
        {
            try
            {
                Alkuikkuna.SoundEffects.PlayEffect("cardflip.wav");
                Kortti apukortti = sekopakka.ElementAt(klikkeri);
                KortinVaihto();
                if (apukortti.Maa == "Hertta" || apukortti.Maa == "Ruutu")
                {
                    pisteet++;
                    lblPisteet.Content = pisteet;
                }
                else
                {
                    PeliLoppu();
                }
                
                kvajastin.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)   
        {
            Alkuikkuna.Pelinakyma1 peliikkuna = new Alkuikkuna.Pelinakyma1();
            peliikkuna.Show();
            this.Close();
        }
        private void KortinVaihto()//metodi, jolla vaihdetaan kortin kuvan source.
        {
            try
            {
                if (klikkeri > 51)
                {
                    imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\redx.PNG", UriKind.Relative));
                    klikkeri = 52;
                    PeliLoppu();
                }
                else
                {
                    imgKortti2.Source = new BitmapImage(new Uri(@"Kuvat\" + Korttipakka.KuvanNimi(sekopakka.ElementAt(klikkeri)) + ".PNG", UriKind.Relative));
                    imgKortti2.InvalidateArrange();
                    imgKortti2.InvalidateVisual();
                    klikkeri++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void Odota()
        {
            Thread.Sleep(600);
        }
        private void PeliLoppu()//pisteet kirjataan pojotallennus-metodiin, peli-ikkuna suljetaan ja GameOver-ikkuna avataan.
        {
            try
            {
                gameover = true;
                btnMusta.IsEnabled = false;
                btnPuna.IsEnabled = false;
                lblPisteet.Foreground = Brushes.White;
                lblPisteet.Background = Brushes.Black;
                PeliTiedot.PojoTallennus = pisteet;
                PeliTiedot.PeliId = 1;
                GameOver peliikkuna = new GameOver();
                peliikkuna.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
