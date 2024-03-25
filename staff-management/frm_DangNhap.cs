using System;
using System.Windows.Forms;

namespace staff_management
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {

        }
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (LOPDUNGCHUNG.CAL($"SELECT COUNT(*) FROM TAIKHOAN WHERE TENDANGNHAP = '{txt_TenDangNhap.Text}' AND MATKHAU = '{txt_MatKhau.Text}'") >= 1)
            {
                frm_QLNV frm_QLNV = new frm_QLNV();
                frm_QLNV.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập và mật khẩu");
            }
        }

    }
}
