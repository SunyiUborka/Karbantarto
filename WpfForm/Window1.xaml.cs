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
using System.Windows.Shapes;

namespace WpfForm
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        KarbantartoRepository db = new KarbantartoRepository("Server=localhost;Port=9999;Database=Karbantarto;Uid=root;Pwd=Aa123456@;");

        MainWindow parent;
        public Window1(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in db.GetAllMegrendeloName())
            {
                comboBox1.Items.Add(item);
            }
            foreach (var item in db.GetAllSzereloName())
            {
                comboBox2.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.AddKarbantartas(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), int.Parse(textBox1.Text), dateTimePicker1.SelectedDate.Value);
            }
            catch
            {
                MessageBox.Show("Hibás adat!");
            }
        }
    }
}
