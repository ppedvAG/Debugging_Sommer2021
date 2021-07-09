using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HalloLinq
{
    public partial class Form1 : Form
    {
        List<Auto> autos = new List<Auto>();
        public Form1()
        {
            InitializeComponent();

            var ids = 0;
            var autoFaker = new Faker<Auto>()
                    .UseSeed(1) // immer gleicher zufall
                    .RuleFor(x => x.Id, f => ids++)
                    .RuleFor(x => x.Hersteller, f => f.Vehicle.Manufacturer())
                    .RuleFor(x => x.Modell, f => f.Vehicle.Model())
                    .RuleFor(x => x.Baujahr, f => f.Date.Past(10))
                    .RuleFor(x => x.Farbe, f => f.Commerce.Color())
                    .RuleFor(x => x.PS, f => f.Random.Int(60, 500));

            autos.AddRange(autoFaker.Generate(100));

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = autos;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var nurBlau = new List<Auto>();

            foreach (var a in autos)
            {
                if (a.Farbe == "blue")
                    nurBlau.Add(a);
            }

            dataGridView1.DataSource = nurBlau;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var query = from a in autos
                        where a.Farbe == "blue" && a.PS > 50
                        orderby a.Baujahr
                        select a;

            dataGridView1.DataSource = query.ToList();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = autos.Where(a => a.Farbe == "blue" && a.PS > 50).OrderBy(a => a.Baujahr).ToList();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            var ps = autos.Average(x => x.PS);
            MessageBox.Show($"⌀ {ps}PS");
        }
    }
}
