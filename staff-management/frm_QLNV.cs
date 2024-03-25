using System;
using System.Globalization;
using System.Windows.Forms;

namespace staff_management
{
    public partial class frm_QLNV : Form
    {
        public frm_QLNV()
        {
            InitializeComponent();
            LoadTable();
            LoadCbo();
        }

        private void dgv_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_NhanVien.DataSource = LOPDUNGCHUNG.LoadTB("SELECT * FROM NHANVIEN");
        }


        public void LoadCbo()
        {
            cbo_TenPhongBan.DataSource = LOPDUNGCHUNG.LoadTB("SELECT * FROM PHONGBAN");
            cbo_TenPhongBan.ValueMember = "MAPB";
            cbo_TenPhongBan.DisplayMember = "TenPB";
        }

        public void LoadTable()
        {
            dgv_NhanVien.DataSource = LOPDUNGCHUNG.LoadTB("SELECT * FROM NHANVIEN");
        }

        private void btn_Them_Click(object sender, System.EventArgs e)
        {
            string sql = $"INSERT INTO NHANVIEN VALUES ('{txt_MSNV.Text}', N'{txt_HoTen.Text}', N'{cbo_TenPhongBan.SelectedValue}', N'{dtp_NgayVaoLam.Value}', N'{txt_ThamNien.Text}')";
            if (LOPDUNGCHUNG.CUD(sql) >= 1)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
            LoadTable();
        }

        private void frm_QLNV_Load(object sender, System.EventArgs e)
        {

        }

        private void btn_Sua_Click(object sender, System.EventArgs e)
        {
            string sql = $"UPDATE NHANVIEN SET HOTEN = N'{txt_HoTen.Text}', MAPB = N'{cbo_TenPhongBan.SelectedValue}', NGAYVAOLAM = N'{dtp_NgayVaoLam.Value}', THAMNIEN = N'{txt_ThamNien.Text}' WHERE MSNV = '{txt_MSNV.Text}'";
            if (LOPDUNGCHUNG.CUD(sql) >= 1)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
            }
            LoadTable();
        }

        private void dgv_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MSNV.Text = dgv_NhanVien.CurrentRow.Cells["MSNV"].Value.ToString();
            txt_HoTen.Text = dgv_NhanVien.CurrentRow.Cells["HOTEN"].Value.ToString();
            cbo_TenPhongBan.SelectedValue = dgv_NhanVien.CurrentRow.Cells["MAPB"].Value.ToString();

            string dateString = dgv_NhanVien.CurrentRow.Cells["NGAYVAOLAM"].Value.ToString();
            DateTime ngayVaoLam = DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parseDate) ? parseDate : DateTime.Now;
            dtp_NgayVaoLam.Value = ngayVaoLam;

            txt_ThamNien.Text = dgv_NhanVien.CurrentRow.Cells["THAMNIEN"].Value.ToString();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE NHANVIEN WHERE MSNV = '{txt_MSNV.Text}'";
            if (LOPDUNGCHUNG.CUD(sql) >= 1)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
            LoadTable();
        }

        private void btn_Dem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT COUNT(*) FROM NHANVIEN";
            if (LOPDUNGCHUNG.CAL(sql) >= 1)
            {
                txt_Dem.Text = LOPDUNGCHUNG.CAL(sql).ToString();
                MessageBox.Show("Đếm thành công");
            }
            else
            {
                MessageBox.Show("Đếm không thành công");
            }
            LoadTable();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cms_RightClick_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
