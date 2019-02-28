using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alkuikkuna
{
    class PeliTiedot
    {
        //Pelien pisteet tallennetaan samaan muuttujaan, joka nollataan pelien välissä
        private static int pojot;
        public static int PojoTallennus
        {
            get { return pojot; }
            set { pojot = value; }
        }
        //PeliID:tä käytetään pisteiden tallennuksessa
        private static int peliID;
        public static int PeliId
        {
            get { return peliID; }
            set { peliID = value; }
        }
    }
}
