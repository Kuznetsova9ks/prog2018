using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mannik;

namespace Mannik.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboBox1();
        }
        Mannik.Manik GetModel()
        {
            return new Mannik.Manik()
            {
                Name = textBox1.Text,
                PhoneNumber = Double.Parse(textBox2.Text),
                Date = textBox3.Text,
                addService = listBox1.Items.OfType<string>().ToList()
            };
        }
        private void SetModel(Mannik.Manik info)
        {
            textBox1.Text = info.Name;
            textBox2.Text = info.PhoneNumber.ToString();
            textBox3.Text = info.Date;
            listBox1.Items.Clear();
            foreach (var i in info.addService)
            {
                listBox1.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Файлы заявок|*.mana" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var info = GetModel();
                Serializer.WriteToFile(sfd.FileName, info);
                Service_Saver(info);
                Style_saver(info);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Файл заявок|*.mana" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var info = Serializer.LoadFromFile(ofd.FileName);
                SetModel(info);
                Service_Get(info);
                Style_getter(info);
            }
        }
        private void Service_Saver(Mannik.Manik i)
        {
            if (radioButton1.Checked)
            {
                i.ServiceManicure = TypesManicure.Manicure;
            }
            if (radioButton2.Checked)
            {
                i.ServiceManicure = TypesManicure.Covering;
            }
            if (radioButton3.Checked)
            {
                i.ServiceManicure = TypesManicure.Cut;
            }
        }
        private void Service_Get(Mannik.Manik i)
        {
            if (i.ServiceManicure.Equals(TypesManicure.Manicure))
            {
                radioButton1.Checked = true;
            }
            if (i.ServiceManicure.Equals(TypesManicure.Covering))
            {
                radioButton2.Checked = true;
            }
            if (i.ServiceManicure.Equals(TypesManicure.Cut))
            {
                radioButton3.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox1.Items.Add("Маникюр");
            }
            if (radioButton2.Checked)
            {
                listBox1.Items.Add("Покрытие");
            }
            if (radioButton3.Checked)
            {
                listBox1.Items.Add("Снятие");
            }
        }
        private void ComboBox1()
        {
            comboBox1.Items.Add(StyleManicure.однотипно);
            comboBox1.Items.Add(StyleManicure.френч);
            comboBox1.Items.Add(StyleManicure.градиент);
        }
        private void Style_saver(Mannik.Manik info)
        {
            if (comboBox1.SelectedIndex == 0)
                info.Manicure = StyleManicure.однотипно;
            if (comboBox1.SelectedIndex == 1)
                info.Manicure = StyleManicure.френч;
            if (comboBox1.SelectedIndex == 2)
                info.Manicure = StyleManicure.градиент;
        }
        private void Style_getter(Mannik.Manik info)
        {
            if (info.Manicure == StyleManicure.однотипно)
                comboBox1.SelectedIndex = 0;
            if (info.Manicure == StyleManicure.френч)
                comboBox1.SelectedIndex = 1;
            if (info.Manicure == StyleManicure.градиент)
                comboBox1.SelectedIndex = 2;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = monthCalendar1.SelectionRange.Start.ToString();
        }
    }
}
