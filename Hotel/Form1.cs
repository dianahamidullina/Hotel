using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace Hotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Clients> clients = new List<Clients>();
            foreach (var line in File.ReadLines(@"C:\Users\Diana\OneDrive\Рабочий стол\HotelData.txt"))
            {
                var array = line.Split('/');
                clients.Add(new Clients(array[0], array[1], array[2], array[3], array[4]));
            }
            foreach(var a in clients)
            {
                
                DataTable dt = new DataTable();
                
               dt.Columns.Add("Ф.И.О.", typeof(string));
                dt.Columns.Add("Статус", typeof(string));
                dt.Columns.Add("Номер", typeof(int));
                dt.Columns.Add("Дата заезда", typeof(string));
                dt.Columns.Add("Дата выезда", typeof(string));


                dt.Rows.Add(a.full_name, a.status, a.room, a.check, a.departure);
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if (dataGridView1[2, i].Value.ToString().Trim() != dataGridView1[2, dataGridView1.Rows.Count - 1].Value.ToString().Trim())
                {
                    continue;
                }
                else
                {
                    dataGridView1.Rows.RemoveAt(i);
                    clients.RemoveAt(i);
                    break;
                }

            }
        }

        private void CurrentTime(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Enabled = true;
            timer1.Start();

            DataTable dt = new DataTable();
            dt.Columns.Add("Ф.И.О.", typeof(string));
            dt.Columns.Add("Статус", typeof(string));
            dt.Columns.Add("Номер", typeof(int));
            dt.Columns.Add("Дата заезда", typeof(string));
            dt.Columns.Add("Дата выезда", typeof(string));


            dataGridView1.DataSource = dt;

            string[] dataString = File.ReadAllLines(@"C:\Users\Diana\OneDrive\Рабочий стол\HotelData.txt");
            string[] ss;
            for (int i = 0; i < dataString.Length; i++)
            {
                ss = dataString[i].ToString().Split('/');
                string[] row = new string[ss.Length];
                for (int j = 0; j < ss.Length; j++)
                {
                    row[j] = ss[j].Trim();
                }
                List<string> list = row.ToList();
                dt.Rows.Add(list[0], list[1], list[2] , list[3] , list[4]);
            }
        }


        private void TimerTick(object sender, EventArgs e)
        {
            timer.Text = DateTime.Now.ToLongTimeString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                if (radioButton1.Text == "Reserved")
                {

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Ф.И.О.", typeof(string));
                    dt.Columns.Add("Статус", typeof(string));
                    dt.Columns.Add("Номер", typeof(int));
                    dt.Columns.Add("Дата заезда", typeof(string));
                    dt.Columns.Add("Дата выезда", typeof(string));

                    dataGridView1.DataSource = dt;

                    string[] dataString = File.ReadAllLines(@"C:\Users\Diana\OneDrive\Рабочий стол\HotelData.txt");
                    string[] ss;
                    for (int i = 0; i < dataString.Length; i++)
                    {
                        ss = dataString[i].ToString().Split('/');
                        string[] row = new string[ss.Length];
                        for (int j = 0; j < ss.Length; j++)
                        {
                            row[j] = ss[j].Trim();
                        }
                        List<string> list = row.ToList();
                        dt.Rows.Add(list[0], list[1], list[2], list[3], list[4]);
                    }

                    DataView productDataView1 = new DataView(dt, $"Статус = 'Зарезервированно'", "", DataViewRowState.CurrentRows);
                    dt = productDataView1.ToTable();
                    dataGridView1.DataSource = dt;

                }
            }




        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {

                if (radioButton2.Text == "Available")
                {

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Ф.И.О.", typeof(string));
                    dt.Columns.Add("Статус", typeof(string));
                    dt.Columns.Add("Номер", typeof(int));
                    dt.Columns.Add("Дата заезда", typeof(string));
                    dt.Columns.Add("Дата выезда", typeof(string));


                    dataGridView1.DataSource = dt;

                    string[] dataString = File.ReadAllLines(@"C:\Users\Diana\OneDrive\Рабочий стол\HotelData.txt");
                    string[] ss;
                    for (int i = 0; i < dataString.Length; i++)
                    {
                        ss = dataString[i].ToString().Split('/');
                        string[] row = new string[ss.Length];
                        for (int j = 0; j < ss.Length; j++)
                        {
                            row[j] = ss[j].Trim();
                        }
                        List<string> list = row.ToList();
                        dt.Rows.Add(list[0], list[1], list[2], list[3], list[4]);

                        DataView productDataView1 = new DataView(dt, $"Статус = 'Свободно'", "", DataViewRowState.CurrentRows);
                        dt = productDataView1.ToTable();
                        dataGridView1.DataSource = dt;

                    }
                }

            }
        }



        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked == true)
            {

                if (radioButton3.Text == "Occupied")
                {

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Ф.И.О.", typeof(string));
                    dt.Columns.Add("Статус", typeof(string));
                    dt.Columns.Add("Номер", typeof(int));
                    dt.Columns.Add("Дата заезда", typeof(string));
                    dt.Columns.Add("Дата выезда", typeof(string));


                    dataGridView1.DataSource = dt;

                    string[] dataString = File.ReadAllLines(@"C:\Users\Diana\OneDrive\Рабочий стол\HotelData.txt");
                    string[] ss;
                    for (int i = 0; i < dataString.Length; i++)
                    {
                        ss = dataString[i].ToString().Split('/');
                        string[] row = new string[ss.Length];
                        for (int j = 0; j < ss.Length; j++)
                        {
                            row[j] = ss[j].Trim();
                        }
                        List<string> list = row.ToList();
                        dt.Rows.Add(list[0], list[1], list[2], list[3], list[4]);
                    }

                    DataView productDataView1 = new DataView(dt, $"Статус = 'Занято'", "", DataViewRowState.CurrentRows);
                    dt = productDataView1.ToTable();
                    dataGridView1.DataSource = dt;
                }


            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {

                if (radioButton4.Text == "Checked out")
                {

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Ф.И.О.", typeof(string));
                    dt.Columns.Add("Статус", typeof(string));
                    dt.Columns.Add("Номер", typeof(int));
                    dt.Columns.Add("Дата заезда", typeof(string));
                    dt.Columns.Add("Дата выезда", typeof(string));


                    dataGridView1.DataSource = dt;

                    string[] dataString = File.ReadAllLines(@"C:\Users\Diana\OneDrive\Рабочий стол\HotelData.txt");
                    string[] ss;
                    for (int i = 0; i < dataString.Length; i++)
                    {
                        ss = dataString[i].ToString().Split('/');
                        string[] row = new string[ss.Length];
                        for (int j = 0; j < ss.Length; j++)
                        {
                            row[j] = ss[j].Trim();
                        }
                        List<string> list = row.ToList();
                        dt.Rows.Add(list[0], list[1], list[2], list[3], list[4]);
                    }

                    DataView productDataView1 = new DataView(dt, $"Статус = 'Выписываются'", "", DataViewRowState.CurrentRows);
                    dt = productDataView1.ToTable();
                    dataGridView1.DataSource = dt;

                }
            }
        }

        private void searching_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ф.И.О.", typeof(string));
            dt.Columns.Add("Статус", typeof(string));
            dt.Columns.Add("Номер", typeof(int));
            dt.Columns.Add("Дата заезда", typeof(string));
            dt.Columns.Add("Дата выезда", typeof(string));


            dataGridView1.DataSource = dt;

            string[] dataString = File.ReadAllLines(@"C:\Users\Diana\OneDrive\Рабочий стол\HotelData.txt");
            string[] ss;
            for (int i = 0; i < dataString.Length; i++)
            {
                ss = dataString[i].ToString().Split('/');
                string[] row = new string[ss.Length];
                for (int j = 0; j < ss.Length; j++)
                {
                    row[j] = ss[j].Trim();
                }
                List<string> list = row.ToList();
                dt.Rows.Add(list[0], list[1], list[2], list[3], list[4]);
            }
             (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                String.Format("Статус like '%" + textBox1.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            List<Clients> clients = new List<Clients>();
            foreach (var line in File.ReadLines(@"C:\Users\Diana\OneDrive\Рабочий стол\HotelData.txt"))
            {
                var array = line.Split('/');
                clients.Add(new Clients(array[0], array[1], array[2], array[3], array[4]));
            }
            foreach (var a in clients)
            {

              
                
                dataGridView1.Rows.Add(a.full_name, a.status, a.room, a.check, a.departure);
            }
            int number = dataGridView1.CurrentCell.RowIndex; 
            CardOfClient cardOfClient = new CardOfClient();
            Name = clients[number].full_name;


        }




        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                textBox5.Text = row.Cells["Ф.И.О."].Value.ToString();
                comboBox1.Text = row.Cells["Статус"].Value.ToString();
                textBox4.Text = row.Cells["Номер"].Value.ToString();
                richTextBox1.Text = row.Cells["Дата заезда"].Value.ToString();
                richTextBox2.Text = row.Cells["Дата выезда"].Value.ToString();
            }
        }
    }
}