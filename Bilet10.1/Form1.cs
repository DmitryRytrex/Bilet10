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

namespace Bilet10._1
{
    public partial class Form1 : Form
    {
        public void loaddata()
        {
            using (ConnectDB db = new ConnectDB())
            {
                DataTable users = db.ExecuteSql("Select * from contacts");
                dataGridView1.DataSource = users;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCreate create = new FormCreate();
            create.Show();
            loaddata();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            loaddata();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ConnectDB db = new ConnectDB())
            {
                int num = dataGridView1.CurrentCell.RowIndex;
                db.ExecuteSqlNonQuery($"Delete from contacts where ID = {num+1};");
            }
            MessageBox.Show("Пользователь удалён!");
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ConnectDB db = new ConnectDB())
            {
                int num = dataGridView1.CurrentCell.RowIndex;
                num++;
                //db.ExecuteSqlNonQuery($"Update contacts set column2 = {Name}, column3 = {Surname}, column4 = {patronymic}, column5 = {} ");
            }    
                loaddata();
        }
    }
}
