using DemExam.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DemExam.Controller
{
    public class PartnerController
    {
        private readonly Panel _panel;

        private readonly List<Partner> _partners = new List<Partner>();

        public readonly DatabaseController DatabaseController;

        public PartnerController(Panel panel) { 
            _panel = panel;

            DatabaseController = new DatabaseController();

            foreach(var partner in DatabaseController.GetAllPartners())
            {
                AddPartnerCard(partner);
            }
        }

        private void AddPartnerCard(Partner partner)
        {
            Panel card = CreatePartnerCard(partner);

            int newY = 0;
            if (_panel.Controls.Count > 0)
            {
                Control lastCard = _panel.Controls[_panel.Controls.Count - 1];
                newY = lastCard.Bottom + 10;
            }

            card.Location = new Point((_panel.ClientSize.Width - card.Width) / 2, newY);

            card.Click += Panel_Click;

            _partners.Add(partner);
            _panel.Controls.Add(card);
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            var partner = panel.Tag as Partner;

            PartnerWnd partnerWnd = new PartnerWnd(partner)
            {
                Text = "Редактирование партнёра"
            };
            partnerWnd.Show();

            partnerWnd.FormClosed += PartnerWnd_FormClosed;
        }

        private void RefreshPartner()
        {
            _panel.Controls.Clear();

            var partnersCopy = new List<Partner>(_partners);

            foreach (var partner in partnersCopy)
            {
                AddPartnerCard(partner);
            }
        }

        public void PartnerWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is PartnerWnd partnerWnd)
            {
                Partner partner = partnerWnd.Partner;

                var existingPartner = _partners.FirstOrDefault(p => p.Name == partner.Name);

                if (existingPartner == null)
                {
                    _partners.Add(partner);
                }

                if (partnerWnd.Save)
                {
                    DatabaseController.UpdatePartner(partner);

                    RefreshPartner();

                    MessageBox.Show("Данные партнёра обновлены", "Успешно");
                }
            }
        }

        private Panel CreatePartnerCard(Partner partner)
        {
            Panel panel = new Panel
            {
                Size = new Size(550, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            Label titleLbl = new Label
            {
                Text = $"{partner.Type} | {partner.Name}",
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label directorLbl = new Label
            {
                Text = partner.Director,
                Location = new Point(10, 30),
                AutoSize = true
            };

            Label phoneLbl = new Label
            {
                Text = partner.Phone,
                Location = new Point(10, 50),
                AutoSize = true
            };

            Label ratingLbl = new Label
            {
                Text = $"Рейтинг: {partner.Rating}",
                Location = new Point(10, 70),
                AutoSize = true
            };

            Label discountLbl = new Label
            {
                Text = $"{GetDiscount(partner.Count)}%",
                Location = new Point(500, 30),
                AutoSize = true
            };

            panel.Tag = partner; 
            panel.Controls.Add(titleLbl);
            panel.Controls.Add(directorLbl);
            panel.Controls.Add(phoneLbl);
            panel.Controls.Add(ratingLbl);
            panel.Controls.Add(discountLbl);

            return panel;
        }

        /// <summary>
        /// Расчёт скидки партнёра
        /// </summary>
        /// <param name="amount">Количество продукции партнёра</param>
        /// <returns></returns>
        private int GetDiscount(int amount)
        {
            if (amount <= 10000)
            {
                return 0;
            }
            else if (amount > 10000 && amount <= 50000)
            {
                return 5;
            }
            else if (amount > 50000 && amount <= 300000)
            {
                return 10;
            }
            else
            {
                return 15;
            }
        }
    }
}
