using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIJA
{
    public partial class FormMasterStudent : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        int selected_id = -1;
        public FormMasterStudent()
        {
            InitializeComponent();
        }

        void showDataCbo()
        {
            var data = new List<string>();
            data.Add("Male");
            data.Add("Female");

            CboGender.DataSource = data;
        }

        void showData()
        {
            dgvData.Columns.Clear();

            var student = db.Student_Tables.Where(x => x.name.Contains(tbSearch.Text)).Select(x => new
            {
                x.id,
                x.name,
                x.@class,
                x.gender,
                x.address,
                x.phone,
            });

            dgvData.DataSource = student;
        }

        private void FormMasterStudent_Load(object sender, EventArgs e)
        {
            showData();
            showDataCbo();
        }

        private void tbSearch_TextChange(object sender, EventArgs e)
        {
            showData();
        }

        void clearFields()
        {
            tbName.Text = "";
            tbAddress.Text = "";
            tbPhone.Text = "";
            tbClass.Text = "";
            CboGender.Text = "Male";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == "" || tbClass.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            var student = new Student_Table();
            student.name = tbName.Text;
            student.address = tbAddress.Text;
            student.phone = tbPhone.Text;
            student.@class = tbClass.Text;
            student.gender = CboGender.Text;

            db.Student_Tables.InsertOnSubmit(student);
            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data succesfully added");
            selected_id = -1;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                selected_id = (int)dgvData.Rows[e.RowIndex].Cells["id"].Value;
                tbName.Text = dgvData.Rows[e.RowIndex].Cells["name"].Value.ToString();
                tbAddress.Text = dgvData.Rows[e.RowIndex].Cells["address"].Value.ToString();
                tbPhone.Text = dgvData.Rows[e.RowIndex].Cells["phone"].Value.ToString();
                tbClass.Text = dgvData.Rows[e.RowIndex].Cells["class"].Value.ToString();
                CboGender.Text = dgvData.Rows[e.RowIndex].Cells["gender"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selected_id == -1)
            {
                MessageBox.Show("Please select a row to update");
                return;
            }

            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == "" || tbClass.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            var student = db.Student_Tables.Where(x => x.id == selected_id).FirstOrDefault();
            student.name = tbName.Text;
            student.address = tbAddress.Text;
            student.phone = tbPhone.Text;
            student.@class = tbClass.Text;
            student.gender = CboGender.Text;

            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data succesfully update");
            selected_id = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected_id == -1)
            {
                MessageBox.Show("Please select a row to delete");
                return;
            }
            var student = db.Student_Tables.Where(x => x.id == selected_id).FirstOrDefault();
            db.Student_Tables.DeleteOnSubmit(student);
            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data succesfully deleted");
            selected_id = -1;
        }
    }
}