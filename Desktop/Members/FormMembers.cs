using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.common.MessageBoxHelper;
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

namespace Desktop.Members
{
    public partial class FormMembers : Form
    {
        private ColumnHeader UserNameColumn = new ColumnHeader("Name") { Text = "Name" };
        private ColumnHeader UserEmailColumn = new ColumnHeader("Email") { Text = "Email" };
        private ColumnHeader UserPasswordColumn = new ColumnHeader("Password") { Text = "Password" };
        private ColumnHeader UserCityColumn = new ColumnHeader("City") { Text = "City" };
        private ColumnHeader UserCountryColumn = new ColumnHeader("Country") { Text = "Country" };
        private ColumnHeader UserCompanyColumn = new ColumnHeader("Company name") { Text = "Company name" };
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;

        public FormMembers(UnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this.serviceProvider = serviceProvider;
            InitializeComponent();
            _initListView();
            _restoreFilterInput();
            _reloadMembers();
        }

        private void _restoreFilterInput() {
            txtFilterCity.Text = Filter.city;
            txtFilterCountry.Text = Filter.country;
            txtFilterName.Text = Filter.name;
            txtFilterId.Text = Filter.id;
        }

        private static (string id, string name, string city, string country) Filter;

        private void _initListView()
        {
            lvMembers.View = View.Details;
            lvMembers.CheckBoxes = true;
            lvMembers.FullRowSelect = true;
            lvMembers.GridLines = true;
            lvMembers.Columns.Add(UserNameColumn);
            lvMembers.Columns.Add(UserEmailColumn);
            lvMembers.Columns.Add(UserPasswordColumn);
            lvMembers.Columns.Add(UserCityColumn);
            lvMembers.Columns.Add(UserCountryColumn);
            lvMembers.Columns.Add(UserCompanyColumn);
        }

        private void AddMembers(List<Member> members)
        {
            members.ForEach(member => AddMember(member));
        }

        private void AddMember(Member member)
        {
            var newItem = new ListViewItem();
            newItem.Tag = member;
            newItem.Text = member.Name;
            newItem.SubItems.Add
                (new ListViewItem.ListViewSubItem()
                {
                    Text = member.Email
                }); ;
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = member.Password
            });

            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = member.City
            });

            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = member.Country
            });

            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = member.CompanyName
            });


            lvMembers.Items.Add(newItem);
        }

        internal void ClearMembers()
        {
            lvMembers.Items.Clear();
        }

        private void lvMembers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvMembers.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                        menuStrip.Show(Cursor.Position);
                }
            }
        }

        private void OnMenuStrip_click(object sender, EventArgs e)
        {
            var focusedItem = lvMembers.FocusedItem;
            if (focusedItem != null)
            {
                Member focusedMember = (Member)focusedItem.Tag;

                string eventName = (sender as ToolStripItem).Text;
                if (eventName == "Delete")
                {
                    DialogResult result = this.ShowYesNoInfoMessageBox("Are you sure to delete member " + focusedMember.Name, "Confirm");

                    if (result == DialogResult.Yes)
                    {
                        using (var work = _unitOfWorkFactory.UnitOfWork)
                        {
                            work.MemberRepository.RemoveById(focusedMember.Id);
                            work.Save();
                        }

                        _reloadMembers();
                    }
                    return;
                }
                if (eventName == "Update")
                {
                    FormUpdateMember formUpdateMember = ActivatorUtilities.CreateInstance<FormUpdateMember>(serviceProvider, focusedMember);
                    formUpdateMember.ShowDialog();
                    _reloadMembers();
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<Member> selectedMember = new List<Member>();

            for (int i = 0; i < lvMembers.CheckedItems.Count; i++)
            {
                var item = lvMembers.CheckedItems[i];
                selectedMember.Add((Member)item.Tag);
            }
            DialogResult result = this.ShowYesNoInfoMessageBox("Are you sure to delete " + selectedMember.Count + " members", "Confirm");

            if (result == DialogResult.Yes)
            {
                // delete all selected members
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    selectedMember.ForEach(p => work.MemberRepository.RemoveById(p.Id));

                    work.Save();
                }

                _reloadMembers();
                return;

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
                FormCreateMember createMemberForm = serviceProvider.GetRequiredService<FormCreateMember>();
                createMemberForm.ShowDialog();
                _reloadMembers();
                return;
        }

        private void _reloadMembers()
        {
                lvMembers.Items.Clear();
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    AddMembers(work.MemberRepository.GetWithFilters(Filter.name, Filter.id, Filter.country, Filter.city).ToList());
                }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter = (txtFilterId.Text, txtFilterName.Text, txtFilterCity.Text, txtFilterCountry.Text);
            _reloadMembers();
        }
    }
}
