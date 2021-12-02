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
    public partial class DataBasesForm : Form
    {
        public DataBasesForm()
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
                        string[] cbm =
                        {
                            "",
                            "ID",
                            "FirstName",
                            "Name",
                            "SecondName",
                            "Qualification",
                            "Phone"
                        };
                        comboBox2.DataSource = cbm;
                        dataGridView1.DataSource = db.Masters.ToList();
                        break;
                    case "Shops":
                        string[] cbs =
                        {
                            "",
                            "ID",
                            "Equipment_title",
                            "Name",
                            "Address",
                            "Phone"
                        };
                        dataGridView1.DataSource = db.Shops.ToList();
                        comboBox2.DataSource = cbs;
                        break;
                    case "Orders":
                        string[] cbo =
                        {
                            "",
                            "ShopID",
                            "MasterID",
                            "Date",
                            "Price",
                            "Completed"
                        };
                        comboBox2.DataSource = cbo;
                        dataGridView1.DataSource = db.Orders.ToList();
                        break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NitoriServiceContext db = new NitoriServiceContext())
            {
                switch (comboBox1.SelectedValue)
                {
                    case "Masters":
                        switch (comboBox2.SelectedValue)
                        {
                            case "ID":
                                dataGridView1.DataSource = db.Masters.Where(m => m.Id.ToString() == textBox1.Text).ToList();
                                break;
                            case "FirstName":
                                dataGridView1.DataSource = db.Masters.Where(m => m.FirstName.ToString() == textBox1.Text).ToList();
                                break;
                            case "Name":
                                dataGridView1.DataSource = db.Masters.Where(m => m.Name.ToString() == textBox1.Text).ToList();
                                break;
                            case "SecondName":
                                dataGridView1.DataSource = db.Masters.Where(m => m.SecondName.ToString() == textBox1.Text).ToList();
                                break;
                            case "Qualification":
                                dataGridView1.DataSource = db.Masters.Where(m => m.Qualification.ToString() == textBox1.Text).ToList();
                                break;
                            case "Phone":
                                dataGridView1.DataSource = db.Masters.Where(m => m.Phone.ToString() == textBox1.Text).ToList();
                                break;
                            default:
                                dataGridView1.DataSource = db.Masters.ToList();
                                break;
                        }
                        break;
                    case "Shops":
                        switch (comboBox2.SelectedValue)
                        {
                            case "ID":
                                dataGridView1.DataSource = db.Shops.Where(s => s.Id.ToString() == textBox1.Text).ToList();
                                break;
                            case "Equipment_title":
                                dataGridView1.DataSource = db.Shops.Where(s => s.EquipmentTitle.ToString() == textBox1.Text).ToList();
                                break;
                            case "Name":
                                dataGridView1.DataSource = db.Shops.Where(s => s.Name.ToString() == textBox1.Text).ToList();
                                break;
                            case "Address":
                                dataGridView1.DataSource = db.Shops.Where(s => s.Address.ToString() == textBox1.Text).ToList();
                                break;
                            case "Phone":
                                dataGridView1.DataSource = db.Shops.Where(s => s.Phone.ToString() == textBox1.Text).ToList();
                                break;
                            default:
                                dataGridView1.DataSource = db.Shops.ToList();
                                break;
                        }
                        break;
                    case "Orders":
                        switch (comboBox2.SelectedValue)
                        {
                            case "ShopID":
                                dataGridView1.DataSource = db.Orders.Where(o => o.ShopId.ToString() == textBox1.Text).ToList();
                                break;
                            case "MasterID":
                                dataGridView1.DataSource = db.Orders.Where(s => s.MasterId.ToString() == textBox1.Text).ToList();
                                break;
                            case "Date":
                                dataGridView1.DataSource = db.Orders.Where(s => s.Date.ToString() == textBox1.Text).ToList();
                                break;
                            case "Price":
                                dataGridView1.DataSource = db.Orders.Where(s => s.Price.ToString() == textBox1.Text).ToList();
                                break;
                            case "Completed":
                                dataGridView1.DataSource = db.Orders.Where(s => s.Completed.ToString() == textBox1.Text).ToList();
                                break;
                            default:
                                dataGridView1.DataSource = db.Orders.ToList();
                                break;
                        }
                        break;
                }
            }
        }
    }
}
