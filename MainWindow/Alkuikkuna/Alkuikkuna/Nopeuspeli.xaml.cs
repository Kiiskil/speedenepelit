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

namespace Alkuikkuna
{
    public partial class Nopeuspeli : Window
    {
        //Tilakone, millä ohjataan pelin kulkua
        enum PeliState
        {
            Arvonta,
            Valopaalla,
            GameOver
        }
        PeliState tila = PeliState.Arvonta;
        
        //Lista mihin arvotut numerot lisätään, ja mihin syötettä verrataan
        private static List<int> numerolista;
        public static List<int> Arvotutnumerot
        {
            get
            {
                return numerolista;
            }
            set
            {
                numerolista = value;
            }

        }
        //Käytetyt muuttujat
        public int syote { get; set; }
        public int arvottuvari { get; set; }
        public int indeksi { get; set; }

        private static Random rng = new Random();
        private DispatcherTimer valotimer;
        private DispatcherTimer systemtimer;

        public Nopeuspeli()
        {
            try
            {
                Arvotutnumerot = new List<int>();
                InitializeComponent();
                lblAika.Content = "Aikaväli 700";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Asettaa tilakoneen tilan ja aloittaa timerit
        private void Startbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Startbutton.IsEnabled = false;
                indeksi = 0;
                PeliTiedot.PojoTallennus = 0;
                PeliTiedot.PeliId = 2;
                tila = PeliState.Arvonta;
                TimerInit();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Aloittaa pienenevän valojen syttymistä ohjaavan timerin ja tilakonetta ajavan timerin
        public void TimerInit()
        {
            try
            {
                valotimer = new DispatcherTimer();
                valotimer.Tick += new EventHandler(valotimer_Tick);
                valotimer.Interval = new TimeSpan(0, 0, 0, 0, 900);
                valotimer.Start();

                systemtimer = new DispatcherTimer();
                systemtimer.Tick += new EventHandler(systemtimer_Tick);
                systemtimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                systemtimer.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Kutsuu tilakonetta joka timerin kierrolla (100Hz)
        private void systemtimer_Tick(object sender, EventArgs e)
        {
            Arvonta();
        }
        //Ohjaa tilakoneen arvontaan ja pienentää valotimerin intervallia
        private void valotimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tila != PeliState.GameOver)
                {
                    if(indeksi < 200)
                    {
                    indeksi++;
                    int x = 700 - (indeksi * 3);
                    valotimer.Interval = new TimeSpan(0, 0, 0, 0, x);
                    lblAika.Content = "Aikaväli: " + x.ToString();
                    }
                    else
                    {
                    valotimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                    lblAika.Content = "Aikaväli: 100";
                    }
                    tila = PeliState.Arvonta;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //tilakone, jota kutsutaan joka systemtimerin tickillä
        public void Arvonta()
        {
            try
            {
                switch (tila)
                {
                    case PeliState.Arvonta:
                        // Arpoo mikä nappi syttyy, jos sama nappi syttyisi 2. peräkkäin arpoo ohjelma uudestaan.
                        int tarkistus = 0;
                        do
                        {
                            arvottuvari = rng.Next(0, 4);
                            //Jos lista on tyhjä lisätään arvottu listaan
                            if (Arvotutnumerot.Count == 0)
                            {
                                tarkistus = 1;
                                Arvotutnumerot.Add(arvottuvari);
                                tila = PeliState.Valopaalla;
                            }
                            //Jos arvottuvari = listan viimeinen elementti arvotaan uudestaan
                            else if (arvottuvari == Arvotutnumerot[Arvotutnumerot.Count - 1])
                            {
                                tarkistus = 0;
                                tila = PeliState.Arvonta;
                            }
                            //ei ole ensimmäinen listassa, eikä sama
                            else
                            {
                                tarkistus = 1;
                                Arvotutnumerot.Add(arvottuvari);
                                tila = PeliState.Valopaalla;
                            }
                        } while (tarkistus != 1);
                        this.Dispatcher.Invoke(() =>
                        {
                            Button1.Background = Brushes.Lime;
                            Button2.Background = Brushes.Blue;
                            Button3.Background = Brushes.Gold;
                            Button4.Background = Brushes.Salmon;
                        });
                        break;

                    //Sytyttää arvottua varia vastaavan napin
                    case PeliState.Valopaalla:

                        if (arvottuvari == 0)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                Button1.Background = Brushes.White;
                            });
                        }
                        else if (arvottuvari == 1)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                Button2.Background = Brushes.White;
                            });
                        }
                        else if (arvottuvari == 2)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                Button3.Background = Brushes.White;
                            });
                        }
                        else if (arvottuvari == 3)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                Button4.Background = Brushes.White;
                            });
                        }
                        break;

                    case PeliState.GameOver:
                        valotimer.Stop();
                        systemtimer.Stop();
                        GameOver peliikkuna = new GameOver();
                        peliikkuna.Show();
                        Music.PlayPause();
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Buttonien painallukset aiheuttavat äänen, ja kutsuvat syötteen arviointia
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                syote = 1;
                SoundEffects.PlayBeep(syote);
                Syotteenarviointi();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                syote = 2;
                SoundEffects.PlayBeep(syote);
                Syotteenarviointi();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                syote = 3;
                SoundEffects.PlayBeep(syote);
                Syotteenarviointi();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                syote = 4;
                SoundEffects.PlayBeep(syote);
                Syotteenarviointi();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Syötteen arvioinnissa pelaajan syötettä verrataan arvottuun listaan
        public void Syotteenarviointi()
        {
            try
            {
                //Jos arvottu lista on tyhjä TAI lista on yhtä pitkä kun pelaajalla on pisteitä ja hän antaa syötteen -> game over
                if (Arvotutnumerot.Count == 0 || Arvotutnumerot.Count == PeliTiedot.PojoTallennus)
                {
                    tila = PeliState.GameOver;
                    lblPisteet.Content = "Game over";
                }
                //Jos pelaaja on listaa jäljessä ja syöte on oikein pisteet +1
                else if ((syote - 1) == Arvotutnumerot[PeliTiedot.PojoTallennus])
                {
                    PeliTiedot.PojoTallennus++;
                    lblPisteet.Content = PeliTiedot.PojoTallennus;
                    syote = 0;
                }
                //Syöte on väärin -> game over
                else
                {
                    tila = PeliState.GameOver;
                    lblPisteet.Content = "Game over";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
