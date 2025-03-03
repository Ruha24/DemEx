using DemExam.Controller;
using DemExam.Model;
using System;
using System.Windows.Forms;

namespace DemExam
{
    public partial class PartnerWnd : Form
    {
        public Partner Partner { get; set; }

        public bool Save {  get; set; }

        private readonly DatabaseController _databaseController;

        public PartnerWnd(Partner partner)
        {
            InitializeComponent();

            _databaseController = new DatabaseController();

            foreach (var type in _databaseController.GetPartnerTypes())
            {
                typecmb.Items.Add(type.Name);
            }

            if (partner != null) {
                Partner = partner;

                typecmb.Text = partner.Type;
                nametxt.Text = partner.Name;
                directortxt.Text = partner.Director;
                phonetxt.Text = partner.Phone;
                ratingtxt.Text = partner.Rating.ToString();
                emailtxt.Text = partner.Email;
            }    
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string text = ratingtxt.Text;

            if (text.Length > 0 && Convert.ToInt32(text) < 0)
            {
                MessageBox.Show("Рейтинг должен быть целым неотрицательным числом", "Ошибка");
                return;
            }

            Partner.Type = typecmb.Text;
            Partner.Name = nametxt.Text;
            Partner.Director = directortxt.Text;
            Partner.Phone = phonetxt.Text;
            Partner.Rating = Convert.ToInt32(ratingtxt.Text);
            Partner.Email = emailtxt.Text;

            Save = true;

            Close();
        }
    }
}
