using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class Form1 : Form
    {
        Customer_BUS cusBUS = new Customer_BUS();
        Area_BUS areaBUS = new Area_BUS();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "")
                MessageBox.Show("mã sinh viên không được để trống", "Cảnh Báo");
            else if (tbName.Text == "")
                MessageBox.Show("Tên sinh viên không được để trống", "Cảnh Báo");
            else
            {
                Customer_DTO cus = new Customer_DTO();
                cus.CustomerId = tbId.Text;
                cus.CustomerName = tbName.Text;
                cus.Area = (Area_DTO)cbArea.SelectedItem;

                cusBUS.NewCustomer(cus);

                dgvCustomer.Rows.Add(cus.CustomerId, cus.CustomerName, cus.Area.AreaName);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?",
                                     "Cảnh Báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Customer_DTO cus = new Customer_DTO();
                cus.CustomerId = tbId.Text;
                cus.CustomerName = tbName.Text;
                cus.Area = (Area_DTO)cbArea.SelectedItem;

                cusBUS.DeleteCustomer(cus);

                int idx = dgvCustomer.CurrentCell.RowIndex;
                dgvCustomer.Rows.RemoveAt(idx);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "")
                MessageBox.Show("mã sinh viên không được để trống", "Cảnh Báo");
            else if (tbName.Text == "")
                MessageBox.Show("Tên sinh viên không được để trống", "Cảnh Báo");
            else
            {
                Customer_DTO cus = new Customer_DTO();
                cus.CustomerId = tbId.Text;
                cus.CustomerName = tbName.Text;
                cus.Area = (Area_DTO)cbArea.SelectedItem;

                cusBUS.EditCustomer(cus);

                DataGridViewRow row = dgvCustomer.CurrentRow;
                row.Cells[0].Value = cus.CustomerId;
                row.Cells[1].Value = cus.CustomerName;
                row.Cells[2].Value = cus.Area.AreaName;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvCustomer.Rows[idx];
            if(row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                cbArea.Text = row.Cells[2].Value.ToString();
            }
        }

        private void CustomerGUI_Load(object sender, EventArgs e)
        {
            List<Customer_DTO> lstCus = cusBUS.ReadCustomer();
            foreach (Customer_DTO cus in lstCus)
            {
                dgvCustomer.Rows.Add(cus.CustomerId, cus.CustomerName,cus.Area.AreaName);
            }

            List<Area_DTO> lstArea = areaBUS.ReadAreaList();
            foreach (Area_DTO area in lstArea)
            {
                cbArea.Items.Add(area);
            }
            cbArea.DisplayMember = "AreaName";

        }
    }
}
