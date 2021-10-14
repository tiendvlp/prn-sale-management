using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.common.MessageBoxHelper;
using Desktop.common.Roles;
using Desktop.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.common.MessageBoxHelper;

namespace Desktop.Orders
{
    public partial class FormOrders : Form
    {
        public static int ADMIN_MODE = 1;
        public static int MEMBER_MODE = 2;
        private int _mode;
        private ColumnHeader ProductIdColumn = new ColumnHeader("Id") { Text = "Id" };
        private ColumnHeader ProductNameColumn = new ColumnHeader("Name") { Text = "Name" };
        private ColumnHeader ProductPriceColumn = new ColumnHeader("Price") { Text = "Price" };
        private ColumnHeader ProductCategoryColumn = new ColumnHeader("Category") { Text = "Category" };
        private ColumnHeader ProducWeightColumn = new ColumnHeader("Weight") { Text = "Weight" };
        private ColumnHeader ProductUnitColumn = new ColumnHeader("Unit") { Text = "Unit" };
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
