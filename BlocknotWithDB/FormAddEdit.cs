using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlocknotWithRepo.Data.Entites;

namespace BlocknotWithDB
{
    public partial class FormAddEdit : Form
    {
        Record record;
        public Record Record { get { return record; } }
        Address address;
        public Address Address { get { return address; } }
        Form1 form = new Form1 ();
        
        public FormAddEdit()
        {
            InitializeComponent();
        }
        public FormAddEdit(Record record) : this()
        {
            this.record = record;
            textBox1.Text = record.Name;
            textBox2.Text = record.Surname;
        }
        public FormAddEdit(Address address) : this()
        {
            this.address = address;
            textBox1.Text = address.Street;
            textBox2.Text = address.City;

        }

        private  void btnSave_Click(object sender, EventArgs e)
        {
            if (form.tabPage1.Focused)
            {
                record = new Record();
                record.Name = textBox1.Text;
                record.Surname = textBox2.Text;
            }
            else
            {
                address = new Address();
                address.Street = textBox1.Text;
                address.City = textBox2.Text;
            }

            DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
