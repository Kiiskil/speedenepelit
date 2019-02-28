using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Alkuikkuna
{
    public static class Music
    {
        //Taustamusiikin mediaplayer
        public static MediaPlayer backgroundmusic = new MediaPlayer();
        //Tallennetaan tieto onko musiikki play asennossa vai ei
        public static int paalla { get; set; }
        //Käytetään siihen, että alkuikkuna aukaisee musiikin vain kerran
        public static int kaynnistys { get; set; }

        //Haetaan musiikki ja laitetaan se päälle
        public static void InitMusic()
        {
            try
            {
                backgroundmusic.Open(new Uri(@"Sounds\\Arpanauts.mp3", UriKind.Relative));
                backgroundmusic.Position = TimeSpan.Zero;
                backgroundmusic.Play();
                paalla = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Play / Pause control
        public static void PlayPause()
        {
            try
            {
                if (paalla == 1)
                {
                    backgroundmusic.Pause();
                    paalla = 0;
                }
                else if (paalla == 0)
                {
                    backgroundmusic.Play();
                    paalla = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
