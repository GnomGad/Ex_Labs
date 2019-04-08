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
        bool flagEdit = false;
        GetTvshow tvshows;
        int i = -1;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(GetTvshow tv)
        {
            i = tv.n;
            flagEdit = true;
            InitializeComponent();
            SetForm(tv);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!flag)// кнопка не жалась отправляем пустоту
            {
                TrashContent.ADD = new GetTvshow();
                TrashContent.UP = new GetTvshow();
            }
            else if (flag && !flagEdit)// это добавление
            {
                tvshows.n = i;
                TrashContent.ADD = tvshows;
            }
            else if (flag && flagEdit) // это обновление
            {
                tvshows.n = i;
                TrashContent.UP = tvshows;
            }
            

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
                char t = tvshows.Type;
                if (comboBox2.SelectedIndex == 2) t = 'T';
                else if (comboBox2.SelectedIndex == 1) t = 'A';
                else if (comboBox2.SelectedIndex == 0) t = 'И';

                tvshows = new GetTvshow(textBox1.Text, textBox2.Text,(ValueOfTV)comboBox1.SelectedIndex+1, t,-1);
                flag = true;
                Close();
            }

        }

        private void SetForm(GetTvshow tv)
        {
            textBox1.Text = tv.NameTV;
            textBox2.Text = tv.NameArtist;
            comboBox1.SelectedIndex =-1+(int)tv.Value;
            if (tv.Type == 'A' || tv.Type == 'А') comboBox2.SelectedIndex = 1; 
            else if (tv.Type == 'T' || tv.Type == 'Т') comboBox2.SelectedIndex = 2;
            else if (tv.Type == 'I' || tv.Type == 'И') comboBox2.SelectedIndex = 0;

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
        [STAThread]
        public static void Begin( GetTvshow tv)
        {
            Application.Run(new Form1(tv));

        }
    }

}