using DemExam.Controller;
using DemExam.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DemExam
{
    public partial class PartnerHistory : Form
    {

        private readonly DatabaseController _databaseController;

        public PartnerHistory()
        {
            InitializeComponent();

            _databaseController = new DatabaseController();
        }

        private void historybtn_Click(object sender, EventArgs e)
        {      
            string text = namePartnertxt.Text;

            if(text == "")
            {
                MessageBox.Show("Введите наименование партнёра", "Ошибка");
                return;
            }

            List<Product> products = _databaseController.GetProductPartner(text);

            if(products.Count == 0)
            {
                MessageBox.Show("У партнёра нету истории", "Ошибка");
                return;
            }

            foreach(Product product in products)
            {
                AddProduct(product);
            }
        }

        private Panel CreateHistoryCard(Product product)
        {
            Panel historyCard = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(400, 80),
                BackColor = Color.LightGray
            };

            Label productNameLabel = new Label
            {
                Text = $"Продукт: {product.Name}",
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label productCountLabel = new Label
            {
                Text = $"Количество: {product.Count}",
                Location = new Point(10, 30),
                AutoSize = true
            };

            Label productDateLabel = new Label
            {
                Text = $"Дата: {product.DateTime.ToShortDateString()}",
                Location = new Point(10, 50),
                AutoSize = true
            };

            historyCard.Controls.Add(productNameLabel);
            historyCard.Controls.Add(productCountLabel);
            historyCard.Controls.Add(productDateLabel);

            return historyCard;
        }

        private void AddProduct(Product product)
        {
            Panel historyCard = CreateHistoryCard(product);

            int newY = 0;
            if (historyPanel.Controls.Count > 0)
            {
                Control lastCard = historyPanel.Controls[historyPanel.Controls.Count - 1];
                newY = lastCard.Bottom + 10;
            }

            historyCard.Location = new Point((historyPanel.ClientSize.Width - historyCard.Width) / 2, newY);

            historyPanel.Controls.Add(historyCard);
        }
    }
}
