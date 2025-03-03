using DemExam.Controller;
using DemExam.Model;
using System;
using System.Windows.Forms;

namespace DemExam
{
    public partial class MainWindow : Form
    {
        private readonly PartnerController _partnerController;

        public MainWindow()
        {
            InitializeComponent();
            _partnerController = new PartnerController(partnerPanel);
        }

        private void addPartner_Click(object sender, EventArgs e)
        {
            PartnerWnd partnerWnd = new PartnerWnd(new Partner())
            {
                Text = "Добавление партнёра"
            };
            partnerWnd.Show();

            partnerWnd.FormClosed += _partnerController.PartnerWnd_FormClosed;
        }

        private void historyPartnerbtn_Click(object sender, EventArgs e)
        {
            PartnerHistory partnerHistory = new PartnerHistory();
            partnerHistory.Show();
        }

        private void downloadDbbtn_Click(object sender, EventArgs e)
        {
            var excelReader = new ExcelReader();
            var dbImporter = new DatabaseImporter();

            var productTypes = excelReader.ReadProductTypes("DataXml/Product_type_import.xlsx");
            var products = excelReader.ReadProducts("DataXml/Products_import.xlsx");
            var partnerTypes = excelReader.ReadPartnerTypes("DataXml/Material_type_import.xlsx");
            var partners = excelReader.ReadPartners("DataXml/Partners_import.xlsx");
            var partnerProducts = excelReader.ReadPartnerProducts("DataXml/Partner_products_import.xlsx");
            var materials = excelReader.ReadMaterials("DataXml/Material_type_import.xlsx");

            dbImporter.ImportProductTypes(productTypes);
            dbImporter.ImportProducts(products);
            dbImporter.ImportPartnerTypes(partnerTypes);
            dbImporter.ImportPartners(partners);
            dbImporter.ImportPartnerProducts(partnerProducts);
            dbImporter.ImportMaterials(materials);
        }
    }
}
