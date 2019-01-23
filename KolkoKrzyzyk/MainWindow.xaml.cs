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
    }
}
