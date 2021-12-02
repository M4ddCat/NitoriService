using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NitoriService
{
    public partial class AddRemoveForm : Form
    {
        public AddRemoveForm()
        {
            InitializeComponent();
            string[] cb1 = {
            "Masters",
            "Orders",
            "Shops"};
            comboBox1.DataSource = cb1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (NitoriServiceContext db = new NitoriServiceContext())
            {
                switch (comboBox1.SelectedValue)
                {
                    case "Masters":
                        label2.Text = "FirstName(string)";
                        label3.Text = "Name(string)";
                        label4.Text = "SecondName(string)";
                        label5.Text = "Qualification(string)";
                        label6.Text = "Phone(string)";
                        textBox5.Visible = true;
                        label6.Visible = true;
                        dataGridView1.DataSource = db.Masters.ToList();
                        break;
                    case "Shops":
                        label2.Text = "Equipment_title(string)";
                        label3.Text = "Name(string)";
                        label4.Text = "Address(string)";
                        label5.Text = "Phone(string)";
                        label6.Text = "";
                        textBox5.Visible = false;
                        label6.Visible = false;
                        dataGridView1.DataSource = db.Shops.ToList();
                        break;
                    case "Orders":
                        label2.Text = "ShopID(int)";
                        label3.Text = "MasterID(int)";
                        label4.Text = "Date(date)";
                        label5.Text = "Price(int)";
                        label6.Text = "Completed(bool)";
                        textBox5.Visible = true;
                        label6.Visible = true;
                        dataGridView1.DataSource = db.Orders.ToList();
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NitoriServiceContext db = new NitoriServiceContext())
            {
                db.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (NitoriServiceContext db = new NitoriServiceContext())
            {
                switch (comboBox1.SelectedValue)
                {
                    case "Masters":
                        textBox5.Visible = false;
                        if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                            !string.IsNullOrWhiteSpace(textBox2.Text) &&
                            !string.IsNullOrWhiteSpace(textBox3.Text) &&
                            !string.IsNullOrWhiteSpace(textBox4.Text) &&
                            !string.IsNullOrWhiteSpace(textBox5.Text))
                        {
                            Master master = new Master()
                            {
                                FirstName = textBox1.Text,
                                Name = textBox2.Text,
                                SecondName = textBox3.Text,
                                Qualification = textBox4.Text,
                                Phone = textBox5.Text
                            };
                            db.Masters.Add(master);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            db.SaveChanges();
                            dataGridView1.DataSource = db.Masters.ToList();
                        }
                        break;
                    case "Shops":
                        if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                            !string.IsNullOrWhiteSpace(textBox2.Text) &&
                            !string.IsNullOrWhiteSpace(textBox3.Text) &&
                            !string.IsNullOrWhiteSpace(textBox4.Text))
                        {
                            Shop shop = new Shop()
                            {
                                EquipmentTitle = textBox1.Text,
                                Name = textBox2.Text,
                                Address = textBox3.Text,
                                Phone = textBox4.Text
                            };
                            db.Shops.Add(shop);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            db.SaveChanges();
                            dataGridView1.DataSource = db.Shops.ToList();
                        }
                        dataGridView1.DataSource = db.Shops.ToList();
                        break;
                    case "Orders":
                        if (!string.IsNullOrWhiteSpace(textBox1.Text) && 
                            !string.IsNullOrWhiteSpace(textBox2.Text) &&
                            !string.IsNullOrWhiteSpace(textBox3.Text) &&
                            !string.IsNullOrWhiteSpace(textBox4.Text) &&
                            !string.IsNullOrWhiteSpace(textBox5.Text)) {
                            Order order = new Order()
                            {
                                ShopId = Convert.ToInt32(textBox1.Text),
                                MasterId = Convert.ToInt32(textBox2.Text),
                                Date = Convert.ToDateTime(textBox3.Text),
                                Price = Convert.ToInt32(textBox4.Text),
                                Completed = Convert.ToBoolean(textBox5.Text)
                            };
                            db.Orders.Add(order);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            db.SaveChanges();
                            dataGridView1.DataSource = db.Orders.ToList();
                        }
                        dataGridView1.DataSource = db.Orders.ToList();
                        break;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (NitoriServiceContext db = new NitoriServiceContext())
            {
                switch (comboBox1.SelectedValue)
                {
                    case "Masters":
                        if (dataGridView1.SelectedCells.Count > 0)
                        {
                            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                            string fn = Convert.ToString(selectedRow.Cells["FirstName"].Value);
                            string n = Convert.ToString(selectedRow.Cells["Name"].Value);
                            string sn = Convert.ToString(selectedRow.Cells["SecondName"].Value);
                            string q = Convert.ToString(selectedRow.Cells["Qualification"].Value);
                            string pn = Convert.ToString(selectedRow.Cells["Phone"].Value);
                            Master master = new Master()
                            {
                                Id = id,
                                FirstName = fn,
                                SecondName = sn,
                                Qualification = q,
                                Phone = pn
                            };
                            db.Masters.Remove(master);
                            db.SaveChanges();
                            dataGridView1.DataSource = db.Masters.ToList();
                        }
                        break;
                    case "Shops":
                        if (dataGridView1.SelectedCells.Count > 0)
                        {
                            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                            string et = Convert.ToString(selectedRow.Cells["EquipmentTitle"].Value);
                            string ad = Convert.ToString(selectedRow.Cells["Address"].Value);
                            string n = Convert.ToString(selectedRow.Cells["Name"].Value);
                            string pn = Convert.ToString(selectedRow.Cells["Phone"].Value);
                            Shop shop = new Shop()
                            {
                                Id = id,
                                EquipmentTitle = et,
                                Address = ad,
                                Name = n,
                                Phone = pn
                            };
                            db.Shops.Remove(shop);
                            db.SaveChanges();
                            dataGridView1.DataSource = db.Shops.ToList();
                        }
                        break;
                    case "Orders":
                        if (dataGridView1.SelectedCells.Count > 0)
                        {
                                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                            DateTime dateDG = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
                            int shopIDDG = Convert.ToInt32(selectedRow.Cells["ShopId"].Value);
                            int masterIDDG = Convert.ToInt32(selectedRow.Cells["MasterId"].Value);
                            int priceIDDG = Convert.ToInt32(selectedRow.Cells["Price"].Value);
                            bool completedIDDG = Convert.ToBoolean(selectedRow.Cells["Completed"].Value);
                            Order order = new Order()
                            {
                                ShopId = shopIDDG,
                                MasterId = masterIDDG,
                                Date = dateDG,
                                Price = priceIDDG,
                                Completed = completedIDDG
                            };
                            db.Orders.Remove(order);
                            db.SaveChanges();
                            dataGridView1.DataSource = db.Orders.ToList();
                        }
                        break;
                }
            }
        }
    }
}
