using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet10._1
{
    public partial class FormCreate : Form
    {
        public FormCreate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (ConnectDB db = new ConnectDB())
            {
                DataTable dt = db.ExecuteSql($"Select * from contacts where phone_number = '{textBox4.Text}';");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Пользователь с таким номером телефона уже существует!");
                }
                else
                {
                    db.ExecuteSqlNonQuery($"insert into contacts values('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}');");
                    MessageBox.Show("Пользователь успешно добавлен!");
                    Form1 main = new Form1();
                    main.loaddata();
                    main.Update();
                    main.Refresh();
                    this.Close();
                }
            }
        }
    }
}
