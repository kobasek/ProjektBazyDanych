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
    }
}
