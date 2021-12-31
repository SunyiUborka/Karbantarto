using System;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form3 : Form
    {
        KarbantartoRepository db = new KarbantartoRepository("Server=localhost;Port=9999;Database=Karbantarto;Uid=root;Pwd=Aa123456@;");
        Form1 parent;
        public Form3(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Form3_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db.AddKarbantartas(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), (int)numericUpDown1.Value, dateTimePicker1.Value);
            }
            catch
            {
                MessageBox.Show("Hibás adat!");
            }
        }
    }
}
