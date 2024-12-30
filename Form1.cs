using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void button2_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.Name = textName.Text;
            guide.Surname = textSurname.Text;
            guide.Age = byte.Parse(textAge.Text);
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla eklendi.");
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textId.Text);
            var removeValues = db.Guide.Find(id);
            db.Guide.Remove(removeValues);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla eklendi.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textId.Text);
            var updateValues = db.Guide.Find(id);
            updateValues.Name = textName.Text;
            updateValues.Surname = textSurname.Text;
            updateValues.Age = byte.Parse(textAge.Text);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);



        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textId.Text);
            var values = db.Guide.Where(x =>x.GuideId==id).ToList();//x=> türkçede öyleki anlamına geldiği düşünülebilir.
            dataGridView1.DataSource = values;
        }
    }
}
