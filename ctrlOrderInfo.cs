using StoreBisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreProject
{
    public partial class ctrlOrderInfo : UserControl
    {
        private int _orderID;
        private clsOrder _order;

        public ctrlOrderInfo()
        {
            InitializeComponent();
        }
        public int OrderID
        {
        get { return _orderID;  }
        }
        public void loadOrderInfo(int orderID)
        {
            _orderID = orderID;
            _order = clsOrder.FindByID(_orderID);
            if(_order == null)
            {
                MessageBox.Show("No order found with ID =" + _orderID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillOrderInfo();

        }
        public void _FillOrderInfo()
        {
            lblOrderID.Text = _orderID.ToString();
            lblCustumorID.Text = _order.CustumorID.ToString();
            lblCustumorName.Text = clsCustumor.Find(_order.CustumorID).Username;
            lblOrderDate.Text = _order.OrderDate.ToShortDateString();
            lblAmount.Text = _order.TotalAmount.ToString();
            lblStatus.Text = _order.StatusText();
           
        }

        private void btnSeeAlItems_Click(object sender, EventArgs e)
        {
        }
    }
}
