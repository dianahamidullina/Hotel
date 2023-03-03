using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel
{
    public partial class CardOfClient : Form
    {
        public CardOfClient()
        {
            InitializeComponent();
        }

        private void CardOfClient_Load(object sender, EventArgs e)
        {
       
        }
        public new string Name
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public new string bday
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public new string pay
        {
            get
            {
                return comboBox1.Text;
            }
            set
            {
                comboBox1.Text = value;
            }
        }
        public new char pet
        {
            get { return char.Parse(checkBox1.Text); }
            set
            {
                char a = char.Parse(checkBox1.Text);
                a = value;
            }
        }
        public new string days
        {
            get
            {
                return numericUpDown1.Text;
            }
            set
            {

                numericUpDown1.Text = value;
            }
        }
    }
}


