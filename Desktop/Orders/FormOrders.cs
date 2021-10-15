using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.common.MessageBoxHelper;
using Desktop.common.Roles;
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
        public class ItemDataBinding
        {
            public Order Order { get; internal set; }
            public Member Member { get; internal set; }
            public double TotalPrice { get; internal set; }
            public ItemDataBinding(Order order, double totalPrice, Member member)
            {
                Order = order;
                TotalPrice = totalPrice;
                Member = member;
            }
        }

        public static int ADMIN_MODE = 1;
        public static int MEMBER_MODE = 2;
        private int _mode;
        private ColumnHeader IdColumn = new ColumnHeader("Id") { Text = "Id" };
        private ColumnHeader MemberEmail = new ColumnHeader("Member email") { Text = "Member email" };
        private ColumnHeader OrderDateColumn = new ColumnHeader("Order date") { Text = "Order date" };
        private ColumnHeader RequiredDateColumn = new ColumnHeader("Required date") { Text = "Required date" };
        private ColumnHeader ShippedDateColumn = new ColumnHeader("Shipped date") { Text = "Shipped date" };
        private ColumnHeader FreightColumn = new ColumnHeader("Freight") { Text = "Freight" };
        private ColumnHeader TotalPriceColumn = new ColumnHeader("Total price") { Text = "Total price" };
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;

        private static (DateTime startDate, DateTime endDate) CurrentFilter = (new DateTime(2001, 1, 1), DateTime.Now);
        private static List<ItemDataBinding> CurrentItems = new List<ItemDataBinding>();
        public FormOrders(UnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this.serviceProvider = serviceProvider;
            InitializeComponent();
            _initFilter();
            _initListView();
            if (CurrentItems.Count == 0)
            {
                _reloadOrders();
            } else
            {
                ClearOrders();
                AddOrders(CurrentItems);
            }
        }

        private void _initFilter()
        {
            dateTimeFromPicker.Value = CurrentFilter.startDate;
            dateTimeToPicker.Value = CurrentFilter.endDate;
        }


        private void _initListView()
        {
            lvOrders.View = View.Details;
            lvOrders.CheckBoxes = true;
            lvOrders.FullRowSelect = true;
            lvOrders.GridLines = true;
            lvOrders.Columns.Add(IdColumn);
            lvOrders.Columns.Add(MemberEmail);
            lvOrders.Columns.Add(OrderDateColumn);
            lvOrders.Columns.Add(RequiredDateColumn);
            lvOrders.Columns.Add(ShippedDateColumn);
            lvOrders.Columns.Add(FreightColumn);
            lvOrders.Columns.Add(TotalPriceColumn);

            IdColumn.Width = 100;
            MemberEmail.Width = 130;
            OrderDateColumn.Width = 130;
            RequiredDateColumn.Width = 130;
            ShippedDateColumn.Width = 80;
            TotalPriceColumn.Width = 80;
        }

        public void AddOrders(List<ItemDataBinding> orders)
        {
            orders.ForEach(order => AddOrder(order));
        }

        public void AddOrder(ItemDataBinding itemData)
        {
            var newItem = new ListViewItem();
            newItem.Tag = itemData;
            newItem.Text = itemData.Order.Id;
            newItem.SubItems.Add
               (new ListViewItem.ListViewSubItem()
               {
                   Text = itemData.Member.Email + ""
               });
            newItem.SubItems.Add
                (new ListViewItem.ListViewSubItem()
                {
                    Text = itemData.Order.OrderDate.ToString("dd-MM-yyyy") + ""
                });
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = itemData.Order.RequiredDate.ToString("dd-MM-yyyy")
            });

            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = itemData.Order.ShippedDate.ToString("dd-MM-yyyy")
            });
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = itemData.Order.Freight.ToString()
            });
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = itemData.TotalPrice.ToString()
            });

            lvOrders.Items.Add(newItem);
        }

        internal void ClearOrders()
        {
            CurrentItems.Clear();
            lvOrders.Items.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void _reloadOrders()
        {
            ClearOrders();
            double totalEarns = 0;
            int totalSales = 0;
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                List<Order> queryOrder = work.OrderRepository.GetWithFilter(CurrentFilter.startDate, CurrentFilter.endDate).ToList();
               
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                queryOrder.ForEach(order =>
                {
                    double totalPrice = 0;
                    orderDetails = work.OrderDetailRepository.GetByOrderId(order.Id);
                    orderDetails.ForEach(orderDetail => { totalPrice += orderDetail.UnitPrice * orderDetail.Quantity; });
                    totalEarns += totalPrice;
                    totalSales++;
                    CurrentItems.Add(new ItemDataBinding(order, totalPrice, order.Member));
                });
            }

            lblTotalEarn.Text = totalEarns + "$";
            lblTotalSales.Text = totalSales + "";
            AddOrders(CurrentItems);
        }


        private void btnCreateStatistic_Click(object sender, EventArgs e)
        {
            CurrentFilter = (dateTimeFromPicker.Value, dateTimeToPicker.Value);
            _reloadOrders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<ItemDataBinding> selectedOrders = new List<ItemDataBinding>();

            for (int i = 0; i < lvOrders.CheckedItems.Count; i++)
            {
                var item = lvOrders.CheckedItems[i];
                selectedOrders.Add((ItemDataBinding)item.Tag);
            }
            DialogResult result = this.ShowYesNoInfoMessageBox("Are you sure to delete " + selectedOrders.Count + " orders", "Confirm");

            if (result == DialogResult.Yes)
            {
                // delete all selected products
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    selectedOrders.ForEach(item => {
                        work.OrderDetailRepository.RemoveByOrderId(item.Order.Id);
                        work.OrderRepository.RemoveById(item.Order.Id);
                    });

                    work.Save();
                }

                _reloadOrders();
                return;
            }
        }
    }
}
