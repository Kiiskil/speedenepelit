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
using System.Windows.Threading;
using System.Diagnostics;
using System.Threading;

namespace Alkuikkuna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer naurutimer;
        public int count { get; set; }
        public int suuauki { get; set; }
        public int pelivalinta { get; set; }
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                StartMusic();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Aloittaa taustamusiikin, käyttää käynnistysmuuttujaa siihen että avaa sen vain kerran jos sivulle siirrytään uudestaan
        public void StartMusic()
        {
            try
            {
                if (Music.kaynnistys != 1)
                {
                    Music.InitMusic();
                    Music.kaynnistys = 1;
                }
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
        private void spedeTimer()
        {
            count = 0;
            naurutimer = new DispatcherTimer();
            naurutimer.Tick += new EventHandler(naurutimer_Tick);
            naurutimer.Interval = new TimeSpan(0, 0, 0, 0, 75);
            naurutimer.Start();
            suuauki = 0;
            SoundEffects.PlayEffect("LAUGH.wav");
        }
        private void naurutimer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    imgSpede.Source = new BitmapImage(new Uri(@"Kuvat\EvilSpeedeNoBackground.png", UriKind.Relative));
                });
                if (suuauki == 0)
                    {
                    this.Dispatcher.Invoke(() =>
                        {
                        imgSpede.Source = new BitmapImage(new Uri(@"Kuvat\EvilSpeedeNoBackgroundMouthOpen.png", UriKind.Relative));
                        });
                    suuauki = 1;
                    }
                else if (suuauki == 1)
                    {
                    this.Dispatcher.Invoke(() =>
                        {
                            imgSpede.Source = new BitmapImage(new Uri(@"Kuvat\EvilSpeedeNoBackground.png", UriKind.Relative));
                        });
                    suuauki = 0;
                    }
                count++;
                if(count > 14)
                {
                    try
                    {
                        if(pelivalinta == 1) { 
                        Pelinakyma1 peliikkuna = new Pelinakyma1();
                        peliikkuna.Show();
                        naurutimer.Stop();
                        this.Close();
                        }
                        else if(pelivalinta == 2)
                        {
                        Pelinakyma2 peliikkuna = new Pelinakyma2();
                        peliikkuna.Show();
                        naurutimer.Stop();
                        this.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Siirtyy pelinäkymä ykköseen, soittaa ääniefektin ja sulkee nykyisen ikkunan
        private void btnPeli1_Click(object sender, RoutedEventArgs e)
        {
            btnPeli1.IsEnabled = false;
            spedeTimer();
            pelivalinta = 1;
        }
        //Siirtyy pelinäkymä kakkoseen, soittaa ääniefektin ja sulkee nykyisen ikkunan
        private void btnPeli2_Click(object sender, RoutedEventArgs e)
        {
            btnPeli2.IsEnabled = false;
            spedeTimer();
            pelivalinta = 2;
        }
        //Siirtyy ennätyksiin ja sulkee nykyisen ikkunan
        private void btnHiScore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HiScore peliikkuna = new HiScore();
                peliikkuna.Show();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Sulkee ohjelman
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
