using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoKrzyzyk
{
    //pobieranie status aktualnego gry
    class GraStatus
    {
        public bool koniecGry;
        public bool remis;
        public string zwyciezca;

        public GraStatus()
        {
            koniecGry = false;
            remis = false;
            zwyciezca = null;
        }

        //zwrocenie status gry
        public GraStatus(bool koniecGry, string zwyciezca, bool remis)
        {
            this.koniecGry = koniecGry;
            this.zwyciezca = zwyciezca;
            this.remis = remis;
        }

        //zakonczenie gry
        public void ustawkoniecGry(bool koniecGry)
        {
            this.koniecGry = koniecGry;
        }
        
        //zakonczenie gry
        public bool jesliKoniecGry()
        {
            return koniecGry;
        }

        //ustawienie zwyciezcy
        public void ustawZwyciezce(string zwyciezca)
        {
            this.zwyciezca = zwyciezca;
        }

        //pobieranie zwyciezcy
        public string pobierzZwyciezce()
        {
            return zwyciezca;
        }

        public bool jestRemis()
        {
            return remis;
        }

    }
}
