using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form2 : Form
    {
        Form1 parent;
        KarbantartoRepository db = new KarbantartoRepository("Server=localhost;Port=9999;Database=Karbantarto;Uid=root;Pwd=Aa123456@;");
        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.SaveFile(textBox1.Text);
            this.Close();
        }
    }
}
