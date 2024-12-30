using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapasity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapasity.Text = db.Location.Average(x=>(decimal?)x.Capacity)?.ToString("0.");
            lblAvgPrice.Text = db.Location.Average(x => (decimal?)x.Price)?.ToString("0.00") + "₺";

            int lastCountry = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == lastCountry).Select(y => y.Country).FirstOrDefault();

            lblCapadociaCapasity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeCapasityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y =>(decimal?) y.Capacity)?.ToString("0.");

            var romeGuideId = db.Location.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.Name+y.Surname).FirstOrDefault().ToString();

            var maxCapasity = db.Location.Max(x => x.Capacity);
            lblMaxCapacity.Text = db.Location.Where(x => x.Capacity == maxCapasity).Select(y => y.City).FirstOrDefault().ToString();

            var MaxPriceLocation = db.Location.Max(x => x.Price);
            lblMaxPrice.Text = db.Location.Where(x => x.Price == MaxPriceLocation).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdByNameAysegulCinar = db.Guide.Where(x => x.Name == "Ayşegül" && x.Surname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinar.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();

        }
    }
}
