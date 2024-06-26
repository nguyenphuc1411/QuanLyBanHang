using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace GUI.UI
{
    public partial class FrmResetPassword : Form
    {
        BUS_NhanVien bUS_NhanVien =new BUS_NhanVien();
        GUI_NhanVien gUI_NhanVien=new GUI_NhanVien();
        private string email;
        public FrmResetPassword(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void FrmResetPassword_Load(object sender, EventArgs e)
        {
            txtEmail.Text = email;
        }
        //ma xac minh
        StringBuilder builder = new StringBuilder();

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (bUS_NhanVien.XacNhanEmailQuenMatKhau(txtEmail.Text))
            {
                builder.Append(gUI_NhanVien.RandomString(4, true));
                builder.Append(gUI_NhanVien.RandomNumber(1000, 9999));
                builder.Append(gUI_NhanVien.RandomString(2, false));
                string matKhauMoi = gUI_NhanVien.encrytion(builder.ToString());
                bUS_NhanVien.CapNhatMatKhauMoi(txtEmail.Text, matKhauMoi);
                if (gUI_NhanVien.SendMail(txtEmail.Text, builder.ToString()))
                {
                    MessageBox.Show("New Password has been sent to your email");
                }
            }
            else
            {
                MessageBox.Show("Email is not exists");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text)||string.IsNullOrEmpty(txtPass.Text)||string.IsNullOrEmpty(txtReEnter.Text))
            {
                MessageBox.Show("Input the necessary information");
            }
            else
            {
                if(txtCode.Text!=builder.ToString())
                {
                    MessageBox.Show("Wrong code");
                }
                else
                {
                    if (txtPass.Text != txtReEnter.Text)
                    {
                        MessageBox.Show("Passwords are not the same");
                    }
                    else
                    {
                        bUS_NhanVien.CapNhatMatKhauMoi(txtEmail.Text,gUI_NhanVien.encrytion(txtPass.Text));
                        MessageBox.Show("Update password successfully");
                        this.Close();
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
