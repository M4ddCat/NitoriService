namespace NitoriService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBasesForm DBF = new DataBasesForm();
            DBF.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddRemoveForm ARF = new AddRemoveForm();
            ARF.Show();
        }
    }
}