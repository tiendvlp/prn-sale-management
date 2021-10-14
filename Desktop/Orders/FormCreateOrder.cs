﻿using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.common;
using Desktop.common.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Orders
{
    public partial class FormCreateOrder : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        private List<Product> _boughtProducts;
        private UCOrderInfo OrderInfo;
        private DateTime _shippedDate;
        private DateTime _orderDate;
        private double _freight;

        public FormCreateOrder(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole, List<Product> boughtProducts)
        {
            _serviceProvider = serviceProvider;
            _boughtProducts = boughtProducts;
            _unitOfWorkFactory = unitOfWorkFactory;
            _appSetting = appSetting;
            _appRole = appRole;
            InitializeComponent();
            _initOrder();
        }

        private void _initOrder()
        {
            _orderDate = DateTime.Now;
            _shippedDate = DateTime.Now.AddDays(3);
            _initUcLayout();
            if (_appRole.IsAdmin)
            {

            } else
            {
                OrderInfo.SetProducts(_boughtProducts);
                OrderInfo.CallBack = _onUcCEvent;
                Member m = (_appRole.CurrentRole as UserRole.Member).Info;
                OrderInfo.SetUserInfo(m.City,m.CompanyName, m.Country, m.Email);
                OrderInfo.SetOrderInfo(_orderDate, _shippedDate);
            }
        }

        private void _onUcCEvent (UCOrderInfo.EVENT_TYPE type, Object data)
        {
            if (type == UCOrderInfo.EVENT_TYPE.CANCEL)
            {
                this.Close();
            }
        }
        private void _initUcLayout ()
        {
            OrderInfo = new UCOrderInfo();
            mainLayoutContainer.Controls.Add(OrderInfo);
            OrderInfo.Dock = DockStyle.Fill;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var data = OrderInfo.getData();

            data.Products.ForEach(p => {
                _freight += p.Weight * 0.5;
            });

            // create orders

            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                Order newOrder = work.OrderRepository.Add((_appRole.CurrentRole as UserRole.Member).Info.Id, _orderDate, data.RequiredDate,_shippedDate,_freight);

                data.Products.ForEach(product => {
                    work.OrderDetailRepository.Add(newOrder.Id, product.Id, product.Price, data.Quantity[product.Id], 1);
                });

                work.Save();
            }

            MessageBox.Show("Thank you ! Your order has been processed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ucOrderInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}