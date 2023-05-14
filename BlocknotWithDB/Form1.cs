using BlocknotWithRepo.Data.Abstract;
using BlocknotWithRepo.Data.Concrete;
using BlocknotWithRepo.Data.Entites;
using System.Net;
using System.Windows.Forms;

namespace BlocknotWithDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (IRepository<Record> recordRepo = new RecordRepository())
            {

                var records = recordRepo.GetAll();
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = records.ToString();
                this.listView2.Items.Add(listViewItem);
            }
            using (IRepository<Address> addressRepo = new AddressRepository())
            {

                var records = addressRepo.GetAll();
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = records.ToString();
                this.listView1.Items.Add(listViewItem);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddEdit form = new FormAddEdit();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (tabPage1.Focused)
                {
                    Record record = form.Record;
                    using (IRepository<Record> recordRepo = new RecordRepository())
                    {
                        recordRepo.Add(record);
                    }
                }
                if (tabPage2.Focused)
                {
                    Address address = form.Address;
                    using (IRepository<Address> addressRepo = new AddressRepository())
                    {
                        addressRepo.Add(address);
                    }
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a book to Edit");
                return;
            }
            int? id = listView1.SelectedItems[0].Tag as int?;
            if (tabPage1.Focused)
            {
                using (IRepository<Record> recordRepo = new RecordRepository())
                {
                    Record record = recordRepo.GetById(id);
                    FormAddEdit form = new FormAddEdit(record);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        recordRepo.Update(record);
                    }
                }
            }
            if (tabPage2.Focused)
            {
                using (IRepository<Address> addressRepo = new AddressRepository())
                {
                    Address address = addressRepo.GetById(id);
                    FormAddEdit form = new FormAddEdit(address);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        addressRepo.Update(address);
                    }

                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a book to Delete");
                return;
            }
            int? id = listView1.SelectedItems[0].Tag as int?;
            if (tabPage1.Focused)
            {
                using (IRepository<Record> recordRepo = new RecordRepository())
                {
                    Record record = recordRepo.GetById(id);
                    recordRepo.Delete(record);
                }

            }
            if (tabPage2.Focused)
            {
                using (IRepository<Address> recordRepo = new AddressRepository())
                {
                    Address address = recordRepo.GetById(id);
                    recordRepo.Delete(address);
                }

            }
        }
    }
}