using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SIJA
{
    public partial class FormMasterTeacher : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        int selected_id = -1;
        public FormMasterTeacher()
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

            var teacher = db.Teacher_Tables.Where(x => x.name.StartsWith(tbSearch.Text)).Select(x => new
            {
                x.id,
                x.name,
                x.gender,
                x.address,
                x.phone,
                x.subject,
                x.password
            });

            dgvData.DataSource = teacher;
        }

        private void FormMasterTeacher_Load(object sender, EventArgs e)
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
            tbSubject.Text = "";
            tbPassword.Text = "";
            CboGender.Text = "Male";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == "" || tbSubject.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            var teacher = new Teacher_Table();
            teacher.name = tbName.Text;
            teacher.address = tbAddress.Text;
            teacher.phone = tbPhone.Text;
            teacher.subject = tbSubject.Text;
            teacher.password = tbPassword.Text;
            teacher.gender = CboGender.Text;

            db.Teacher_Tables.InsertOnSubmit(teacher);
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
                tbSubject.Text = dgvData.Rows[e.RowIndex].Cells["subject"].Value.ToString();
                tbPassword.Text = dgvData.Rows[e.RowIndex].Cells["password"].Value.ToString();
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

            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == "" || tbSubject.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            var teacher = db.Teacher_Tables.Where(x => x.id == selected_id).FirstOrDefault();
            teacher.name = tbName.Text;
            teacher.address = tbAddress.Text;
            teacher.phone = tbPhone.Text;
            teacher.subject = tbSubject.Text;
            teacher.password = tbPassword.Text;
            teacher.gender = CboGender.Text;

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
            var teacher = db.Teacher_Tables.Where(x => x.id == selected_id).FirstOrDefault();
            db.Teacher_Tables.DeleteOnSubmit(teacher);
            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data succesfully deleted");
            selected_id = -1;
        }
    }
}
