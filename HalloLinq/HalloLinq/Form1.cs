using Bogus;
using System.Collections.Generic;
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
                    .UseSeed(1)
                    .RuleFor(x => x.Id, f => ids++)
                    .RuleFor(x => x.Hersteller, f => f.Vehicle.Manufacturer())
                    .RuleFor(x => x.Modell, f => f.Vehicle.Model())
                    .RuleFor(x => x.Baujahr, f => f.Date.PastOffset(10))
                    .RuleFor(x => x.Farbe, f => f.Commerce.Color())
                    .RuleFor(x => x.PS, f => f.Random.Int(60, 500));

        }
    }
}
