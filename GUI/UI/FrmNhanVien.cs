using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class FrmNhanVien : Form
    {
        BUS_NhanVien bUS_NhanVien=new BUS_NhanVien();
        GUI_NhanVien gUI_NhanVien= new GUI_NhanVien();
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        private void ResetValues()
        {
            txtInput.Text = "Input Name Staff";
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            rdoActive.Enabled = false;
            rdoDeactive.Enabled = false;
            rdoStaff.Enabled = false;
            rdoAdmin.Enabled = false;
            rdoActive.Checked = false;
            rdoDeactive.Checked = false;
            rdoAdmin.Checked = false;
            rdoStaff.Checked = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSkip.Enabled = false;
            btnClose.Enabled = true;
        }
        private void UnLock()
        {
            txtEmail.Enabled = true;
            txtName.Enabled=true;
            txtAddress.Enabled=true;
            rdoActive.Enabled=true;
            rdoDeactive.Enabled=true;
            rdoStaff.Enabled=true;
            rdoAdmin.Enabled = true;
            btnDelete.Enabled=true;
            btnEdit.Enabled=true;
            btnSave.Enabled=true;
            btnSkip.Enabled=true;
        }
        private void LoadGirdview_Staff()
        {
            dGVListStaff.DataSource = bUS_NhanVien.DanhSachNhanVien();
            dGVListStaff.Columns[0].HeaderText = "ID";
            dGVListStaff.Columns[1].HeaderText = "Email";
            dGVListStaff.Columns[2].HeaderText = "Name";
            dGVListStaff.Columns[3].HeaderText = "Addresss";
            dGVListStaff.Columns[4].HeaderText = "Role";
            dGVListStaff.Columns[5].HeaderText = "Status";

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGirdview_Staff();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dGVListStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetValues();
            UnLock();
            btnDelete.Enabled=false;
            btnEdit.Enabled=false;
            lblMaNV.Text = string.Empty;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void dGVListStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 || dGVListStaff.SelectedRows.Count>0)
            {
                txtEmail.Enabled=false;
                txtName.Enabled=false;
                txtAddress.Enabled=false;
                rdoActive.Enabled=false;
                rdoDeactive.Enabled=false;
                rdoAdmin.Enabled=false;
                rdoStaff.Enabled=false;
                btnSave.Enabled=false;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnSkip.Enabled = true;
                lblMaNV.Text= dGVListStaff.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtEmail.Text = dGVListStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtName.Text = dGVListStaff.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAddress.Text = dGVListStaff.Rows[e.RowIndex].Cells[3].Value.ToString();
                string kt = dGVListStaff.Rows[e.RowIndex].Cells[4].Value.ToString();
                int role=0;
                if (!string.IsNullOrEmpty(kt))
                {
                    role = int.Parse(kt);
                    if (role == 0)
                    {
                        rdoStaff.Checked = true;
                    }
                    else
                    {
                        rdoAdmin.Checked = true;
                    }
                }
                string kt1 = dGVListStaff.Rows[e.RowIndex].Cells[4].Value.ToString();
                int status= 0;
                if (!string.IsNullOrEmpty(kt1))
                {
                    status = int.Parse(kt);
                    if (status != 0)
                    {
                        rdoActive.Checked = true;
                    }
                    else
                    {
                        rdoDeactive.Checked = true;
                    }
                }     
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text)||string.IsNullOrEmpty(txtName.Text)||
                string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Input Infromation necessary");
            }
            else
            {
                if (!gUI_NhanVien.IsEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email is not valid");
                    txtEmail.Focus();
                }
                else
                {
                    if (!rdoStaff.Checked && !rdoAdmin.Checked)
                    {
                        MessageBox.Show("Please Choose Role");
                    }
                    else
                    {
                        if (!rdoActive.Checked && !rdoDeactive.Checked)
                        {
                            MessageBox.Show("Please Choose Status");
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(lblMaNV.Text))
                            {
                                //Save into Database
                                DTO_NhanVien nv = new DTO_NhanVien();
                                nv.MaNV = bUS_NhanVien.TaoMaNhanVien();
                                nv.Email = txtEmail.Text;
                                nv.TenNV = txtName.Text;
                                nv.DiaChi = txtAddress.Text;
                                if (rdoAdmin.Checked)
                                {
                                    nv.VaiTro = 1;
                                }
                                else
                                {
                                    nv.VaiTro = 0;
                                }
                                if (rdoActive.Checked)
                                {
                                    nv.TinhTrang = 1;
                                }
                                else
                                {
                                    nv.TinhTrang = 0;
                                }
                                StringBuilder builder = new StringBuilder();
                                builder.Append(gUI_NhanVien.RandomString(4, true));
                                builder.Append(gUI_NhanVien.RandomNumber(1000, 9999));
                                builder.Append(gUI_NhanVien.RandomString(2, false));
                                string matKhauMoi = gUI_NhanVien.encrytion(builder.ToString());
                                nv.MatKhau = matKhauMoi;
                                if (bUS_NhanVien.LuuNhanVien(nv))
                                {
                                    MessageBox.Show("Save successfully");
                                    ResetValues();
                                    LoadGirdview_Staff();
                                }
                                else
                                {
                                    MessageBox.Show("Save Failed");
                                }
                            }
                            else
                            {
                                //Update information
                                DTO_NhanVien nv = new DTO_NhanVien();
                                nv.MaNV = lblMaNV.Text;
                                nv.Email = txtEmail.Text;
                                nv.TenNV = txtName.Text;
                                nv.DiaChi = txtAddress.Text;
                                if (rdoAdmin.Checked)
                                {
                                    nv.VaiTro = 1;
                                }
                                else
                                {
                                    nv.VaiTro = 0;
                                }
                                if (rdoActive.Checked)
                                {
                                    nv.TinhTrang = 1;
                                }
                                else
                                {
                                    nv.TinhTrang = 0;
                                }
                                if (bUS_NhanVien.SuaNhanVien(nv))
                                {
                                    MessageBox.Show("Update successfully");
                                    ResetValues();
                                    LoadGirdview_Staff();
                                }
                                else
                                {
                                    MessageBox.Show("Update Failed");
                                }
                            }
                        }
                    }
                
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Do you want to exit","Exit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (bUS_NhanVien.XoaNhanVien(lblMaNV.Text))
                {
                    MessageBox.Show("Delete successfully");
                    LoadGirdview_Staff();
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                    ResetValues();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UnLock();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable ds = bUS_NhanVien.TimKiemNhanVien(txtInput.Text);
            if (ds.Rows.Count > 0)
            {
                dGVListStaff.DataSource= ds;
                dGVListStaff.Columns[0].HeaderText = "ID";
                dGVListStaff.Columns[1].HeaderText = "Email";
                dGVListStaff.Columns[2].HeaderText = "Name";
                dGVListStaff.Columns[3].HeaderText = "Addresss";
                dGVListStaff.Columns[4].HeaderText = "Role";
                dGVListStaff.Columns[5].HeaderText = "Status";
            }
            else
            {
                MessageBox.Show("Can't find staff");
                ResetValues();
            }
           
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            txtInput.Text=string.Empty;
        }
    }
}
