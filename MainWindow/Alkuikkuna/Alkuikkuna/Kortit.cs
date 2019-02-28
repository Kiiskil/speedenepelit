using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Korttipeli
{
    public class Kortti
    {
        private string maa;
        private int nro;

        public Kortti(string maa, int nro)
        {
            this.maa = maa;
            this.nro = nro;
        }
        public string Maa
        {
            get { return maa; }
            set { maa = value; }
        }
        public int Nro
        {
            get { return nro; }
            set { nro = value; }
        }
    }
    public static class Korttipakka
    {
        public static Random rng = new Random();
        static int maxNro = 13;
        static string[] Maat = new string[] { "Hertta", "Risti", "Ruutu", "Pata" };


        public static List<Kortti> LuoPakka(List<Kortti> korttipakka)//Luodaan kortteja ja lisätään ne listaan, joka palautetaan
        {
            try
            {
                for (int i = 0; i < Maat.Length; i++)
                {
                    for (int a = 0; a < maxNro; a++)
                    {
                        int apunro = a + 1;
                        Kortti kortti = new Kortti(Maat[i], apunro);
                        korttipakka.Add(kortti);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return korttipakka;
        }

        public static void SekoitaPakka(List<Kortti> spakka)//Otetaan lista, sekoitetaan se, siirretään stackkiin ja tallennetaan TallennaPakka-ominaisuuteen
        {
            try
            {
                int n = spakka.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    Kortti value = spakka[k];
                    spakka[k] = spakka[n];
                    spakka[n] = value;
                }
                Stack<Kortti> sekopakka = new Stack<Kortti>();
                foreach (Kortti item in spakka)
                {
                    sekopakka.Push(item);
                }
                TallennaPakka = sekopakka;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string KuvanNimi(Kortti kortti)//tarvittavan kuvan tiedostonnimen generointi käytetyn kortin perusteella
        {            
                string nimi = "";
            try
            {
                if (kortti.Maa == "Pata")
                {
                    nimi = kortti.Nro + "S";
                    return nimi;
                }
                else if (kortti.Maa == "Hertta")
                {
                    nimi = kortti.Nro + "H";
                    return nimi;
                }
                else if (kortti.Maa == "Risti")
                {
                    nimi = kortti.Nro + "C";
                    return nimi;
                }
                else if (kortti.Maa == "Ruutu")
                {
                    nimi = kortti.Nro + "D";
                    return nimi;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
                return nimi;
        }
        private static Stack<Kortti> pakka;
        public static Stack<Kortti> TallennaPakka
        {
            get{return pakka;}
            set{pakka = value;}
        }
        private static int pojot;
        public static int PojoTallennus
        {
            get { return pojot; }
            set { pojot = value; }
        }

        private static int peliID;
        public static int PeliId
        {
            get { return peliID; }
            set { peliID = value; }
        }
    }
}
        
    

