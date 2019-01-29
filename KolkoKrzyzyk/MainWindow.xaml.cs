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

namespace KolkoKrzyzyk
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> graPrzyciski;

        public bool AKCJA { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            //implementacja przyciskanych pol do gry
            graPrzyciski = new List<Button>();
        
            graPrzyciski.Add(wiersz1pole1);
            graPrzyciski.Add(wiersz1pole2);
            graPrzyciski.Add(wiersz1pole3);

            graPrzyciski.Add(wiersz2pole1);
            graPrzyciski.Add(wiersz2pole2);
            graPrzyciski.Add(wiersz2pole3);

            graPrzyciski.Add(wiersz3pole1);
            graPrzyciski.Add(wiersz3pole2);
            graPrzyciski.Add(wiersz3pole3);
        }

        //przyciski do gry na planszy
        private void startGry_Przycisk(object sender, RoutedEventArgs e)
        {

            Button nacisnieciePrzycisku = (Button)sender;
            if (AKCJA)
            {
                nacisnieciePrzycisku.Content = Stale.X_ZNAK;
                nacisnieciePrzycisku.IsEnabled = false;
                AKCJA = false;
            }
            else
            {
                nacisnieciePrzycisku.Content = Stale.O_ZNAK;
                nacisnieciePrzycisku.IsEnabled = false;
                AKCJA = true;
            }

            if (sprawdzStatusGry())
            {
                return;
            }
            sprawdzStatusGry();
        }


        //sprawdzam kto wygral gre
        private bool sprawdzStatusGry()
        {
            GraStatus status = sprawdzPoziom();
            if (status.jesliKoniecGry())
            {
                     
                if (status.zwyciezca == Stale.O_ZNAK)
                    MessageBox.Show("gracz 2 wygrywa!");
                else
                    MessageBox.Show("gracz 1 wygrywa!");
                return true;
            }

            //sprawdzanie poziomu
            status = sprawdzPoziom();

            //sprawdzanie statusu gry
            if (status.jesliKoniecGry())
            {
                zakonczGre();
                aktualizujStatus(status);

                if (status.zwyciezca == Stale.O_ZNAK)
                    MessageBox.Show("gracz 2 wygrywa!");
                else
                    MessageBox.Show("gracz 1 wygrywa!");
                return true;
            }

            status = sprawdzPoziom();
            if (status.jesliKoniecGry())
            {
                  
                if (status.zwyciezca == Stale.O_ZNAK)
                    MessageBox.Show("gracz 2 wygrywa!");
                else
                    MessageBox.Show("gracz 1 wygrywa!");
                return true;
            }
            return false;
        }

        //zakonczenie gry
        private void zakonczGre()
        {
            foreach (Button przycisk in graPrzyciski)
            {
                przycisk.IsEnabled = false;
            }
        }

        //aktualizuje status gry
        private void aktualizujStatus(GraStatus status)
        {
            if (status.jesliKoniecGry())
            {
                if (status.pobierzZwyciezce().Equals(Stale.X_ZNAK))
                {
                    int obecnyWynik = Convert.ToInt32(wygrywaX.Content);
                    wygrywaX.Content = "" + (obecnyWynik + 1);
                }
                else if (status.pobierzZwyciezce().Equals(Stale.O_ZNAK))
                {
                    int obecnyWynik = Convert.ToInt32(wygrywa0.Content);
                    wygrywa0.Content = "" + (obecnyWynik + 1);
                }
            }
        }

        //sprawdzam wynik poziomu
        private GraStatus sprawdzPoziom()
        {
            bool koniecGry = false;
            string zwyciezca = "";
            
            //sprawdzanie co w danym momencie jest nacisniete
            if ( wiersz1pole1.Content.Equals( wiersz1pole2.Content)
                &&  wiersz1pole1.Content.Equals( wiersz1pole3.Content)
                &&  wiersz1pole2.Content.Equals( wiersz1pole3.Content)
                && !wiersz1pole1.Content.Equals(""))
            {
                
                koniecGry = true;
                zwyciezca = Convert.ToString( wiersz1pole1.Content);
            }
            else if ( wiersz2pole1.Content.Equals( wiersz2pole2.Content)
                    &&  wiersz2pole1.Content.Equals( wiersz2pole3.Content)
                    &&  wiersz2pole2.Content.Equals( wiersz2pole3.Content)
                    && !wiersz2pole1.Content.Equals(""))
            {
                
                koniecGry = true;
                zwyciezca = Convert.ToString( wiersz2pole1.Content);
            }
            else if ( wiersz3pole1.Content.Equals( wiersz3pole2.Content)
                    &&  wiersz3pole1.Content.Equals( wiersz3pole3.Content)
                    &&  wiersz3pole2.Content.Equals( wiersz3pole3.Content)
                    && !wiersz3pole1.Content.Equals(""))
            {
                
                koniecGry = true;
                zwyciezca = Convert.ToString( wiersz3pole1.Content);
            }
            return new GraStatus(koniecGry, zwyciezca);
        }


    }
}
