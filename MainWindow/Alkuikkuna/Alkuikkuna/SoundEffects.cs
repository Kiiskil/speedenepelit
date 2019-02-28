using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Alkuikkuna
{
    public static class SoundEffects
    {
        //Uusi mediaplayer lyhyille äänille, mitä käytetään peleissä, tarvitaan uusi, että voi käyttää yhtäaikaa
        public static MediaPlayer SoundEffect = new MediaPlayer();

        //Yleisohjain satunnaisille äänille
        public static void PlayEffect(string syote)
        {
            try
            {
                SoundEffect.Open(new Uri(@"Sounds\\" + syote, UriKind.Relative));
                SoundEffect.Position = TimeSpan.Zero;
                SoundEffect.Play();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public static MediaPlayer beepSound = new MediaPlayer();
        //Nappien painalluksien äänet nopeuspelissä
        public static void PlayBeep(int syote)
        {
            try
            {
                beepSound.Open(new Uri(@"Sounds\\Beeup" + syote + ".wav", UriKind.Relative));
                beepSound.Position = TimeSpan.Zero;
                beepSound.Play();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
