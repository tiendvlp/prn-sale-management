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

        private ColumnHeader IdColumn = new ColumnHeader("Id") { Text = "Id" };
        private ColumnHeader MemberEmail = new ColumnHeader("Member email") { Text = "Member email" };
        private ColumnHeader OrderDateColumn = new ColumnHeader("Order date") { Text = "Order date" };
        private ColumnHeader RequiredDateColumn = new ColumnHeader("Required date") { Text = "Required date" };
        private ColumnHeader ShippedDateColumn = new ColumnHeader("Shipped date") { Text = "Shipped date" };
        private ColumnHeader FreightColumn = new ColumnHeader("Freight") { Text = "Freight" };
        private ColumnHeader TotalPriceColumn = new ColumnHeader("Total price") { Text = "Total price" };
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;

        public static (DateTime startDate, DateTime endDate) CurrentFilter = (new DateTime(2001, 1, 1), DateTime.Now);
        public static (int totalSales, double totalEarn) currentStatistic;
        public static List<ItemDataBinding> CurrentItems = new List<ItemDataBinding>();
        private AppRoles _appRoles;
        public FormOrders(UnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, AppRoles appRoles)
        {
            _appRoles = appRoles;
            _unitOfWorkFactory = unitOfWorkFactory;
            this.serviceProvider = serviceProvider;
            InitializeComponent();
            _initFilter();
            _initListView();
            _setupLayoutByRole();
            if (CurrentItems.Count == 0)
            {
                CurrentFilter = (new DateTime(2001, 1, 1), DateTime.Now);
                _reloadOrders();
            } else
            {
                lvOrders.Items.Clear();
                AddOrders(CurrentItems);
                lblTotalEarn.Text = currentStatistic.totalEarn + "$";
                lblTotalSales.Text = currentStatistic.totalSales + "";
            }
        }

        private void _setupLayoutByRole() {
            if (_appRoles.IsAdmin) {
                dateTimeFromPicker.Enabled = true;
                dateTimeToPicker.Enabled = true;
                btnCreateStatistic.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                lblTotalEarn.Enabled = true;
                lblTotalSales.Enabled = true;
                dateTimeFromPicker.Visible = true;
                dateTimeToPicker.Visible = true;
                btnCreateStatistic.Visible = true;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
            } else
            {
                dateTimeFromPicker.Enabled = false;
                dateTimeToPicker.Enabled = false;
                btnCreateStatistic.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                lblTotalEarn.Enabled = false;
                lblTotalEarn.Visible = false;
                lblTotalSales.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                dateTimeFromPicker.Visible = false;
                dateTimeToPicker.Visible = false;
                btnCreateStatistic.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
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
            if (lvOrders.FocusedItem == null) { return; }
            ItemDataBinding focusedItem = (ItemDataBinding) lvOrders.FocusedItem.Tag;
            focusedItem.Order.Member = focusedItem.Member;
            FormUpdateOrder formUpdateOrder = ActivatorUtilities.CreateInstance<FormUpdateOrder>(serviceProvider, focusedItem.Order);
            formUpdateOrder.ShowDialog();
        }

        private void _reloadOrders()
        {
            ClearOrders();
            double totalEarns = 0;
            int totalSales = 0;
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                List<Order> queryOrder;
                if (_appRoles.IsAdmin) { 
                    queryOrder = work.OrderRepository.GetWithFilter(CurrentFilter.startDate, CurrentFilter.endDate).ToList();
                } else
                {
                    queryOrder = work.OrderRepository.GetByMemberId((_appRoles.CurrentRole as UserRole.Member).Info.Id);
                }
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
            currentStatistic = (totalSales, totalEarns);
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

            if (selectedOrders.Count == 0)
            {
                return;
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
