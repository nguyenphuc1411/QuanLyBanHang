using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class FrmKhachHang : Form
    {
        BUS_KhachHang bUS_KhachHang=new BUS_KhachHang();
        private string email;
        public FrmKhachHang(string email)
        {
            InitializeComponent();
            this.email = email;
        }
        private void ResetValues()
        {
            txtInput.Text = "Input Name Customer";
            txtPhone.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            txtPhone.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            rdoMale.Enabled = false;
            rdoFemale.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSkip.Enabled = false;
            btnClose.Enabled = true;
        }
        private void UnLock()
        {
            txtPhone.Enabled = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            rdoMale.Enabled = true;
            rdoFemale.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = true;
            btnSkip.Enabled = true;
        }
        private void LoadGirdview_Customer()
        {
            dGVCustomer.DataSource = bUS_KhachHang.DanhSachKhachHang();
            dGVCustomer.Columns[0].HeaderText = "Phone";
            dGVCustomer.Columns[1].HeaderText = "Name";
            dGVCustomer.Columns[2].HeaderText = "Address";
            dGVCustomer.Columns[3].HeaderText = "Gender";
            dGVCustomer.Columns[4].HeaderText = "MaNV";
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGirdview_Customer();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetValues();
            UnLock();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Input Infromation necessary");
            }
            else
            {
                if (!rdoMale.Checked && !rdoFemale.Checked)
                {
                    MessageBox.Show("Please Choose Gender");
                }
                else
                {
                    DTO_KhachHang kh = new DTO_KhachHang();
                    kh.DienThoai = txtPhone.Text;
                    kh.TenKhach = txtName.Text;
                    kh.DiaChi = txtAddress.Text;
                    if (rdoMale.Checked)
                    {
                        kh.Phai = "Nam";
                    }
                    else kh.Phai = "Nữ";
                    BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
                    kh.MaNV = bUS_NhanVien.LayMaNhanVien(email);
                    if (bUS_KhachHang.KiemTraSDT(txtPhone.Text))//sdt đã tồn tại
                    {
                        if (bUS_KhachHang.SuaKhachHang(kh))
                        {
                            MessageBox.Show("Update successfully");
                            ResetValues();
                            LoadGirdview_Customer();
                        }
                        else
                        {
                            MessageBox.Show("Update Failed");
                        }
                    }
                    else
                    {
                        if (bUS_KhachHang.LuuKhachHang(kh))
                        {
                            MessageBox.Show("Save successfully");
                            ResetValues();
                            LoadGirdview_Customer();
                        }
                        else
                        {
                            MessageBox.Show("Save Failed");
                        }
                    }
                }
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (bUS_KhachHang.XoaKhachHang(txtPhone.Text))
                {
                    MessageBox.Show("Delete successfully");
                    ResetValues();
                    LoadGirdview_Customer();
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                    ResetValues();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable ds = bUS_KhachHang.TimKiemKhachHang(txtInput.Text);
            if (ds.Rows.Count > 0)
            {
                dGVCustomer.DataSource = ds;
                dGVCustomer.Columns[0].HeaderText = "Phone";
                dGVCustomer.Columns[1].HeaderText = "Name";
                dGVCustomer.Columns[2].HeaderText = "Address";
                dGVCustomer.Columns[3].HeaderText = "Gender";
                dGVCustomer.Columns[4].HeaderText = "MaNV";
            }
            else
            {
                MessageBox.Show("Can't find customer");
                ResetValues();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UnLock();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void dGVCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dGVCustomer.Rows.Count > 0)
            {
                txtPhone.Text = dGVCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dGVCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddress.Text = dGVCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                string gt = dGVCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (gt == "Nam")
                {
                    rdoMale.Checked = true;
                }
                else
                {
                    rdoFemale.Checked = true;
                }
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
        }

        private void dGVCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
