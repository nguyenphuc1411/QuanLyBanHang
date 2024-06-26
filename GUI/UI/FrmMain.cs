using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class FrmMain : Form
    {
        private string email;
        private string role;
        public FrmMain(string email, string role)
        {
            InitializeComponent();
            this.email = email;
            this.role = role;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            char kitu = email[0];
            lblProfile.Text = kitu.ToString().ToUpper();
            lblHi.Text = "Chào " + email;
            if(role == "NhanVien")
            {
                btnStaff.Enabled = false;
                btnInventory.Enabled = false;
                btnWarehoused.Enabled = false;
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ResetDGV();
            FrmNhanVien frm = new FrmNhanVien();
            frm.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ResetDGV();
            FrmKhachHang frm = new FrmKhachHang(email);
            frm.ShowDialog();
        }

        private void btnUserManual_Click(object sender, EventArgs e)
        {
            try
            {
                string duongDan = Path.GetFullPath("HuongDan.txt");

                // Sử dụng Process.Start để mở tài liệu PDF bằng ứng dụng mặc định
                Process.Start(duongDan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở tài liệu: " + ex.Message);
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ResetDGV();
            FrmHang frm = new FrmHang(email);
            frm.ShowDialog();
        }

        private void btnWarehoused_Click(object sender, EventArgs e)
        {
            BUS_Hang bUS_Hang=new BUS_Hang();
            dgvThongKe.DataSource= bUS_Hang.ThongKeHang();
            dgvThongKe.Columns[0].HeaderText = "ID";
            dgvThongKe.Columns[1].HeaderText = "Name";
            dgvThongKe.Columns[2].HeaderText = "Import Quantity";
            dgvThongKe.Visible = true;
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            BUS_Hang bUS_Hang = new BUS_Hang();
            dgvThongKe.DataSource = bUS_Hang.ThongKeTonKho();
            dgvThongKe.Columns[0].HeaderText = "Name";
            dgvThongKe.Columns[1].HeaderText = "Quantity";
            dgvThongKe.Visible = true;
        }

        private void btnIntroduce_Click(object sender, EventArgs e)
        {
            try
            {
                string duongDan = Path.GetFullPath("HuongDan.txt");

                // Sử dụng Process.Start để mở tài liệu PDF bằng ứng dụng mặc định
                Process.Start(duongDan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở tài liệu: " + ex.Message);
            }
        }
        private void ResetDGV()
        {
            dgvThongKe.Visible=false;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Log Out", "Log Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Hide();
                FrmLogin frm = new FrmLogin();
                frm.ShowDialog();
            }
        }
    }
}
