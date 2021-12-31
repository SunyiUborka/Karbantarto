using System;
using System.Windows.Forms;


namespace WinForm
{
    public partial class Form1 : Form
    {
        KarbantartoRepository db = new KarbantartoRepository("Server=localhost;Port=9999;Database=Karbantarto;Uid=root;Pwd=Aa123456@;");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in db.GetKarbantartasok())
            {
                listView1.Items.Add(new ListViewItem(new string[] { item.megNev, item.cim, item.tipus, item.telefon, item.szerNev, item.date.ToString("yyyy/MM/dd"), item.ar.ToString() }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var win = new Form2(this);
            win.ShowDialog();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text, out int cost) && textBox1.Text != "" && int.Parse(textBox1.Text) > 5000 && int.Parse(textBox1.Text) % 1000 == 0)
            {
                listView1.Items.Clear();
                foreach (var item in db.SelectedItem(textBox2.Text, int.Parse(textBox1.Text)))
                {
                    listView1.Items.Add(new ListViewItem(new string[] { item.megNev, item.cim, item.tipus, item.telefon, item.szerNev, item.date.ToString("yyyy/MM/dd"), item.ar.ToString() }));
                }
            }
            else MessageBox.Show("Hibás érték");   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var win = new Form3(this);
            win.ShowDialog();
        }
    }
}