using BusinessObject;
using DataAccess.repositories.Members;
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
        private ColumnHeader UserIdColumn = new ColumnHeader("ID") { Text = "ID" };
        private ColumnHeader UserNameColumn = new ColumnHeader("Name") { Text = "Name" };
        private ColumnHeader UserEmailColumn = new ColumnHeader("Email") { Text = "Email" };
        private ColumnHeader UserPasswordColumn = new ColumnHeader("Password") { Text = "Password" };
        private ColumnHeader UserCityColumn = new ColumnHeader("City") { Text = "City" };
        private ColumnHeader UserCountryColumn = new ColumnHeader("Country") { Text = "Country" };
        private ColumnHeader UserCompanyColumn = new ColumnHeader("Company name") { Text = "Company name" };
        private IServiceProvider serviceProvider;
        private IMemberRepository MemberRepository;

        public FormMembers(IServiceProvider serviceProvider, IMemberRepository memberRepository)
        {
            this.serviceProvider = serviceProvider;
            MemberRepository = memberRepository;
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
            lvMembers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvMembers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvMembers.Columns.Add(UserIdColumn);
            lvMembers.Columns.Add(UserNameColumn);
            lvMembers.Columns.Add(UserEmailColumn);
            lvMembers.Columns.Add(UserPasswordColumn);
            lvMembers.Columns.Add(UserCityColumn);
            lvMembers.Columns.Add(UserCountryColumn);
            lvMembers.Columns.Add(UserCompanyColumn);

            UserNameColumn.Width = 130;
            UserEmailColumn.Width = 130;
            UserCountryColumn.Width = 80;
            UserCityColumn.Width = 70;
            UserCompanyColumn.Width = 70;
        }

        private void AddMembers(List<Member> members)
        {
            members.ForEach(member => AddMember(member));
        }

        private void AddMember(Member member)
        {
            var newItem = new ListViewItem();
            newItem.Tag = member;
            newItem.Text = member.Id;
            newItem.SubItems.Add
               (new ListViewItem.ListViewSubItem()
               {
                   Text = member.Name
               }); ;
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
                            MemberRepository.RemoveById(focusedMember.Id);

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
               selectedMember.ForEach(p => MemberRepository.RemoveById(p.Id));

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
                    AddMembers(MemberRepository.GetWithFilters(Filter.name, Filter.id, Filter.country, Filter.city).ToList());
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter = (txtFilterId.Text, txtFilterName.Text, txtFilterCity.Text, txtFilterCountry.Text);
            _reloadMembers();
        }
    }
}
