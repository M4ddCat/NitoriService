using System.Linq;

namespace NitoriService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (NitoriServiceContext db = new NitoriServiceContext())
            {
                var shops = db.Shops.Select(x => x.Name).Distinct().ToList();
                comboBox1.DataSource = shops;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (NitoriServiceContext db = new NitoriServiceContext())
            {
                var orders = (
                from o in db.Orders
                join m in db.Masters on o.MasterId equals m.Id
                join s in db.Shops on o.ShopId equals s.Id
                where s.Name == comboBox1.SelectedValue &&
                (o.Completed == null || o.Completed == false) 
                select new
                {
                    Имя = m.FirstName,
                    Фамилия = m.Name,
                    Магазин = s.Name,
                    Дата = o.Date,
                    Статус = "Не выполнено"
                }).ToList();
                dataGridView1.DataSource = orders;
            }
        }
    }
}