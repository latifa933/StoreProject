using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreBisness;

namespace StoreProject
{
    public partial class ctrProductInfo : UserControl
    {
        private int _productID;
        private clsProductCatalog _product;
       
        public ctrProductInfo()
        {
            InitializeComponent();
        }
        public int productID
        {
            get { return _productID; }
        }
        public void loadProductInfo(int ID)
        {
            _product = clsProductCatalog.FindProductByID(ID);
            if(_product == null)
            {
                _ResetProductInfo();
                MessageBox.Show("No product with ID " + ID, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillProductInfo();
            _loadPictures();
            
        }
        private void _ResetProductInfo()
        {
            lblProductID.Text = "[????]";
            lblProdctname.Text = "[????]";
            lbldescription.Text = "[????]";
            lblprice.Text = "[????]";
            lblQuantityInstock.Text = "[????]";
            lblCategory.Text = "[????]";

        }
        private void _loadPictures()
        {
            clsProductImage image1 = clsProductImage.FindbyProductID(_productID, 1);
            if(image1 != null)
            {
                pb1.Visible = true;
                pb1.ImageLocation = image1.ImageURL;
            }
            clsProductImage image2 = clsProductImage.FindbyProductID(_productID, 2);
            if(image2 != null)
            {
                pb2.Visible = true;
                pb2.ImageLocation = image2.ImageURL;
            }
            clsProductImage image3 = clsProductImage.FindbyProductID(_productID, 3);
            if(image3 != null)
            {
                pb3.Visible = true;
                pb3.ImageLocation = image3.ImageURL;
            }
            clsProductImage image4 = clsProductImage.FindbyProductID(_productID, 4);
            if(image4 != null)
            {
                pb4.Visible = true;
                pb4.ImageLocation = image4.ImageURL;
            }
        }
        private void _FillProductInfo()
        {
            _productID = _product.ProductID;
            lblProductID.Text = _product.ProductID.ToString();
            lblProdctname.Text = _product.ProductName;
            lbldescription.Text = _product.description;
            lblprice.Text = _product.Price.ToString();
            lblQuantityInstock.Text = _product.QuantityInStock.ToString();
            lblCategory.Text = _product.categoryInfo.categoryName;

        }
        private void ctrProductInfo_Load(object sender, EventArgs e)
        {
           
            
        }

       
    }
}
