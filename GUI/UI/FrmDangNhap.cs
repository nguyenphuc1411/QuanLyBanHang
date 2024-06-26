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
    public partial class FrmLogin : Form
    {
        GUI_NhanVien gUI_NhanVien=new GUI_NhanVien();
        BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text.Length==0 ||txtPassword.Text.Length==0)
            {
                MessageBox.Show("Please input Email or Password");
            }
            else
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.Email = txtEmail.Text;
                nv.MatKhau = gUI_NhanVien.encrytion(txtPassword.Text);
                if (bUS_NhanVien.NhanVienDangNhap(nv))
                {
                    if (bUS_NhanVien.TrangThaiHoatDong(txtEmail.Text))
                    {
                        if (chckRemember.Checked)
                        {
                            bUS_NhanVien.GhiNhoMatKhau(txtEmail.Text, txtPassword.Text);
                        }
                        MessageBox.Show("Login successfully");
                        FrmMain frm = new FrmMain(nv.Email, bUS_NhanVien.VaiTroNV(nv.Email));
                        frm.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Email is not active");
                        txtEmail.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Incorect Email or Password");
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
        }

        private void btnForget_Click(object sender, EventArgs e)
        {
            FrmResetPassword frm= new FrmResetPassword(txtEmail.Text);
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
            txtEmail.Text = bUS_NhanVien.EmailDaNho();
            txtPassword.Text=bUS_NhanVien.MatKhauDaNho();
        }
    }
}
