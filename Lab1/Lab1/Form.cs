using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labs.AddForm
{
    public partial class Form1 : Form
    {
        bool flag = false;
        GetTvshow tvshows;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flag)
                TrashContent.ADD = tvshows;
            else
                TrashContent.ADD = new GetTvshow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("Необходимо ввести название ТВ-ШОУ");
            else if (textBox2.Text.Trim() == "")
                MessageBox.Show("Необходимо ввести ведущего");
            else if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Необходимо выбрать оценку");
            else if (comboBox2.SelectedIndex == -1)
                MessageBox.Show("Необходимо выбрать тип");
            else
            {
                char t;
                if (comboBox2.SelectedIndex == 0) t = 'T';
                else if (comboBox2.SelectedIndex == 1) t = 'A';
                else t = 'И';
                tvshows = new GetTvshow(textBox1.Text, textBox2.Text,(ValueOfTV)comboBox1.SelectedIndex, t,-1);
                flag = true;
                Close();
            }

        }

    }

    public static class Program
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
       public static void Begin()
        {
            Application.Run(new Form1());

        }
    }

}