using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class FrmHang : Form
    {
        private string email;
        private string fileAddress;
        private string fileName;
        private string fileSavePath;
        BUS_Hang bUS_Hang = new BUS_Hang();
        public FrmHang(string email)
        {
            InitializeComponent();
            this.email = email;
        }
        private void ResetValues()
        {
            txtInput.Text = "Input Name Product";
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPurchase.Text = string.Empty;
            txtSelling.Text = string.Empty;
            txtNote.Text = string.Empty;
            pcHinhAnh.Image = null;
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtQuantity.Enabled = false;
            txtPurchase.Enabled = false;
            txtSelling.Enabled = false;
            txtNote.Enabled = false;
            pcHinhAnh.Enabled = false;
            btnOpen.Enabled = false;
            txtName.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSkip.Enabled = false;
            btnClose.Enabled = true;
        }
        public void Lock()
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtQuantity.Enabled = false;
            txtPurchase.Enabled = false;
            txtSelling.Enabled = false;
            txtNote.Enabled = false;
            pcHinhAnh.Enabled = false;
            btnOpen.Enabled = false;
            txtName.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSkip.Enabled = false;
            btnClose.Enabled = true;
        }
        private void UnLock()
        {
            txtName.Enabled = true;
            txtQuantity.Enabled = true;
            txtPurchase.Enabled = true;
            txtSelling.Enabled = true;
            txtNote.Enabled = true;
            btnOpen.Enabled = true;
            pcHinhAnh.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = true;
            btnSkip.Enabled = true;
        }
        private void LoadGirdview_Product()
        {
            dGVProduct.DataSource = bUS_Hang.DanhSachHang();
            dGVProduct.Columns[0].HeaderText = "ID";
            dGVProduct.Columns[1].HeaderText = "Name";
            dGVProduct.Columns[2].HeaderText = "Quantity";
            dGVProduct.Columns[3].HeaderText = "Purchase Price";
            dGVProduct.Columns[4].HeaderText = "Selling Price";
            dGVProduct.Columns[5].HeaderText = "Image";
            dGVProduct.Columns[6].HeaderText = "Note";
            dGVProduct.Columns[7].HeaderText = "MaNV";
        }

        private void FrmHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGirdview_Product();
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
                if (bUS_Hang.XoaHang(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Delete successfully");
                    ResetValues();
                    LoadGirdview_Product();
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
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtQuantity.Text) ||
               string.IsNullOrEmpty(txtPurchase.Text) || string.IsNullOrEmpty(txtSelling.Text))
            {
                MessageBox.Show("Input Infromation necessary");
            }
            else
            {
                DTO_Hang h = new DTO_Hang();
                BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
                h.TenHang = txtName.Text;
                int soLuong;
                float donGiaNhap, donGiaBan;
                if (!int.TryParse(txtQuantity.Text, out soLuong))
                {
                    MessageBox.Show("Quantity is not number");
                    txtQuantity.Focus();
                }
                else
                {
                    h.SoLuong = soLuong;
                    if (!float.TryParse(txtPurchase.Text, out donGiaNhap))
                    {
                        MessageBox.Show("Purchase is not number");
                        txtPurchase.Focus();
                    }
                    else
                    {
                        h.DonGiaNhap= donGiaNhap;
                        if (!float.TryParse(txtSelling.Text, out donGiaBan))
                        {
                            MessageBox.Show("Selling is not number");
                            txtSelling.Focus();
                        }
                        else
                        {
                            h.DonGiaBan= donGiaBan;
                            if (!string.IsNullOrEmpty(fileName))
                            {
                                h.HinhAnh = "\\Image\\" + fileName;
                            }
                            h.GhiChu = txtNote.Text;
                            h.MaNV = bUS_NhanVien.LayMaNhanVien(email);
                            if (string.IsNullOrEmpty(txtID.Text))
                            {
                                if (bUS_Hang.ThemHang(h))
                                {
                                    MessageBox.Show("Save successfully");
                                    ResetValues();
                                    LoadGirdview_Product();
                                }
                                else
                                {
                                    MessageBox.Show("Save Failed");
                                }
                            }
                            else
                            {
                                h.MaHang = int.Parse(txtID.Text);
                                if (bUS_Hang.SuaHang(h))
                                {
                                    MessageBox.Show("Update successfully");
                                    ResetValues();
                                    LoadGirdview_Product();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UnLock();
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Bitmap(*.bmp)|*.bmp|JPG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.Title = "Select a picture for the product";

            //Kiểm tra xem người dùng đã chọn file chưa
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileAddress = openFile.FileName;
                pcHinhAnh.Image=Image.FromFile(fileAddress);
                fileName=Path.GetFileName(openFile.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                fileSavePath = saveDirectory + "\\Image\\" + fileName;
            }
        }

        private void dGVProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string saveDrictory = Application.StartupPath.Substring(0,(Application.StartupPath.Length-10));
            if (e.RowIndex >= 0)
            {
                Lock();
                btnDelete.Enabled=true;
                btnEdit.Enabled=true;
                txtID.Text = dGVProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtQuantity.Text = dGVProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPurchase.Text = dGVProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSelling.Text = dGVProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNote.Text = dGVProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                string hinhAnh=dGVProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (!string.IsNullOrEmpty(hinhAnh))
                {
                    pcHinhAnh.Image = Image.FromFile(saveDrictory + hinhAnh);
                }
            }
        }
    }
}
