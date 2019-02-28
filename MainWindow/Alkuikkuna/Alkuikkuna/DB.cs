using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows;

namespace Alkuikkuna
{
    class DB
    {
        public class PelaajanEnkat
        {
            public string GameName { get; set; }
            public int PelaajaID { get; set; }
            public string PelaajaNimi { get; set; }
            public int Pisteet { get; set; }
            public DateTime pvm { get; set; }
        }
        public class Pelaaja
        {
            public int PelaajaID { get; set; }
            public string PelaajaNimi { get; set; }
        }
        public class Rekka
        {
            public string PID { get; set; }
            public int Pojot { get; set; }
            public DateTime pvm { get; set; }
        }
        public static void VertaaPelaaja(string uusinimi,int pisteet, int PeliID)
        {
            int ID;
            try
            {
                List<Pelaaja> Pelaajat = new List<Pelaaja>();
                //kerrotaan että yhteystiedot löytyvät app.configista
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                //Sql-kysely
                string sql = "SELECT PelaajaID,Nick FROM Pelaaja";
                //luodaan yhteys ja avataan yhteys tietokantaan
                using (MySqlConnection conn = new MySqlConnection(cs))//using kertoo, että muuttuja conn on käytettävissä vain seuraavassa lohkossa. Muistinhallinnan kannalta näin on parempi, sillä yhteydet kuluttavat paljon muistia.
                {
                    conn.Open();
                    //suoritetaan kysely tietokantaan
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //käydään tulokset läpi ja muutetaan kukin tietue(rivi) Student-olioksi
                        while (rdr.Read())
                        {
                            Pelaaja s = new Pelaaja();
                            s.PelaajaID = rdr.GetInt32(0);
                            s.PelaajaNimi = rdr.GetString(1);
                            Pelaajat.Add(s);
                        }
                    }
                    if(Pelaajat.Exists(x => x.PelaajaNimi==uusinimi))
                    {
                        int index = Pelaajat.FindIndex(a => a.PelaajaNimi == uusinimi);
                        ID = Pelaajat.ElementAt(index).PelaajaID;
                        Addpisteet(pisteet, PeliID, ID);  
                    }
                    else
                    {
                        AddPelaaja(uusinimi);
                        VertaaPelaaja(uusinimi, pisteet, PeliID);
                    }      
                }
            }
            catch (Exception db)
            {
                MessageBox.Show(db.Message);
            }
        }
        public static bool AddPelaaja(string PelaajaNimi)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;//kerrotaan että yhteystiedot löytyvät app.configista
                //Sql-kysely
                string sql = string.Format("INSERT INTO Pelaaja (Nick) VALUES ('{0}')", PelaajaNimi);
                //luodaan yhteys ja avataan yhteys tietokantaan
                using (MySqlConnection conn = new MySqlConnection(cs))//using kertoo, että muuttuja conn on käytettävissä vain seuraavassa lohkossa. Muistinhallinnan kannalta näin on parempi, sillä yhteydet kuluttavat paljon muistia.
                {
                    conn.Open();
                    //suoritetaan kysely tietokantaan
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int lkm = cmd.ExecuteNonQuery();//ExecuteNonQuery kertoo moneenko riviin SQL vaikuttaa, tässä tapauksessa lisättävään oppilaaseen eli yhteen.
                    if (lkm == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            { throw; }
            }
          
        
         public static bool Addpisteet(int pisteet,int PeliID, int PelaajaID)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;//kerrotaan että yhteystiedot löytyvät app.configista
                //Sql-kysely
                string sql = string.Format("INSERT INTO HiScore (Score,PeliID,PelaajaID) VALUES ('{0}','{1}','{2}')", pisteet, PeliID,PelaajaID);
                //luodaan yhteys ja avataan yhteys tietokantaan
                using (MySqlConnection conn = new MySqlConnection(cs))//using kertoo, että muuttuja conn on käytettävissä vain seuraavassa lohkossa. Muistinhallinnan kannalta näin on parempi, sillä yhteydet kuluttavat paljon muistia.
                {
                    conn.Open();
                    //suoritetaan kysely tietokantaan
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int lkm = cmd.ExecuteNonQuery();//ExecuteNonQuery kertoo moneenko riviin SQL vaikuttaa, tässä tapauksessa lisättävään oppilaaseen eli yhteen.
                    if (lkm == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public static List<Rekka> HaePisteet (int peliID)
        {
            List<Rekka> enkat = new List<Rekka>();
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;//kerrotaan että yhteystiedot löytyvät app.configista
                string sql = string.Format("SELECT HiScore.Score, HiScore.reg_date, Pelaaja.Nick FROM HiScore JOIN Pelaaja on Pelaaja.PelaajaID = HiScore.PelaajaID WHERE PeliID='{0}' order by Score desc", peliID);
                //luodaan yhteys ja avataan yhteys tietokantaan
                using (MySqlConnection conn = new MySqlConnection(cs))//using kertoo, että muuttuja conn on käytettävissä vain seuraavassa lohkossa. Muistinhallinnan kannalta näin on parempi, sillä yhteydet kuluttavat paljon muistia.
                {
                    conn.Open();
                    //suoritetaan kysely tietokantaan
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //käydään tulokset läpi ja muutetaan kukin tietue(rivi) Student-olioksi
                        while (rdr.Read())
                        {
                            Rekka s = new Rekka();
                            s.PID = rdr.GetString(2);
                            s.Pojot = rdr.GetInt32(0);
                            s.pvm = rdr.GetDateTime(1);
                            enkat.Add(s);
                        }

                    }
                }
            }
            catch (Exception db)
            {
                MessageBox.Show(db.Message);
            }
            //palautus
            return enkat;
        }

        public static List<PelaajanEnkat> PelaajanPisteet(string nick)
        {
            List<PelaajanEnkat> pelaajanenkat = new List<PelaajanEnkat>();
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;//kerrotaan että yhteystiedot löytyvät app.configista
                string sql = string.Format("SELECT HiScore.Score, HiScore.reg_date, Pelaaja.Nick, Pelit.PNimi FROM HiScore JOIN Pelaaja on Pelaaja.PelaajaID = HiScore.PelaajaID JOIN Pelit on HiScore.PeliID = Pelit.PeliID WHERE Pelaaja.Nick='{0}' order by Pelit.Pnimi, HiScore.Score desc", nick);
                //luodaan yhteys ja avataan yhteys tietokantaan
                using (MySqlConnection conn = new MySqlConnection(cs))//using kertoo, että muuttuja conn on käytettävissä vain seuraavassa lohkossa. Muistinhallinnan kannalta näin on parempi, sillä yhteydet kuluttavat paljon muistia.
                {
                    conn.Open();
                    //suoritetaan kysely tietokantaan
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //käydään tulokset läpi ja muutetaan kukin tietue(rivi) Student-olioksi
                        while (rdr.Read())
                        {
                            PelaajanEnkat s = new PelaajanEnkat();
                            s.PelaajaNimi = rdr.GetString(2);
                            s.GameName = rdr.GetString(3);
                            s.Pisteet = rdr.GetInt32(0);
                            s.pvm = rdr.GetDateTime(1);
                            pelaajanenkat.Add(s);
                        }
                    }
                }
            }
            catch (Exception db)
            {
                MessageBox.Show(db.Message);
            }
            //palautus
            return pelaajanenkat;
        }
    }
}
