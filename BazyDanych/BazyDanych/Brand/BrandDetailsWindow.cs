using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyDanych
{
    public partial class BrandDetailsWindow : Form
    {
        public BrandDetailsWindow()
        {
            InitializeComponent();
        }

        public BrandDetailsWindow(int brandID)
        {
            InitializeComponent();
            nameTextBox.Text = Brand.GetBrandById(brandID).name;
            modelsBindingSource.Clear();
            IList<Model> modelsList = Model.GetModelListForBrand(brandID);
            foreach (Model model in modelsList)
            {
                modelsBindingSource.Add(new ModelTableElement(model.id, model.name, model.category, model.brandId, model.templateId));
            }
        }

        private void modelsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var row = e.RowIndex;
                var modelId = (int)modelsDataGridView.Rows[row].Cells[0].Value;
                int? templateId = Model.GetModelById(modelId).templateId;
                if (templateId != null)
                {
                    int templateIdFinal = (int)templateId;
                    TemplateDetailsWindow obj = new TemplateDetailsWindow(templateIdFinal);
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Brak szablonu");
                }
            }
        }
    }
}
