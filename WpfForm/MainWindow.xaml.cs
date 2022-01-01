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
using WpfForm.models;
using WpfForm;

namespace WpfForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KarbantartoRepository db = new KarbantartoRepository("Server=localhost;Port=9999;Database=Karbantarto;Uid=root;Pwd=Aa123456@;");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window1(this);
            win.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in db.GetKarbantartasok())
            {
                listView.Items.Add($"{item.megNev}\t{item.cim}\t{item.tipus}\t{item.telefon}\t{item.szerNev}\t{item.date.ToString("yyyy/MM/dd")}\t{item.ar.ToString()}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new Window2(this);
            win.ShowDialog();
        }
    }
}
