using System.Linq;

namespace NitoriService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NitoriServiceContext db = new NitoriServiceContext();
            var shops = (
                from s in db.Shops
                select s.Name
                ).Distinct().ToList();
            comboBox1.DataSource = shops;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NitoriServiceContext db = new NitoriServiceContext();
            var orders = (
            from o in db.Orders
            join m in db.Masters on o.MasterId equals m.Id
            where o.Completed == null || o.Completed == false
            join s in db.Shops on o.ShopId equals s.Id
            where s.Name == comboBox1.SelectedValue
            select new
            {
                ID = m.Id,
                FirstName = m.FirstName,
                Name = m.Name,
                SecondName = m.SecondName,
                Order = o.Date,
                Completed = o.Completed
            }).ToList();
            dataGridView1.DataSource = orders;
        }
    }
}