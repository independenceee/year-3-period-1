using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_2
{
    public partial class Form1 : Form
    {

        private double tongTien;

        private void AddComboBox()
        {
            cbDoUong.Items.Add("Coca cola");
            cbDoUong.Items.Add("Pepsi");
            cbDoUong.Items.Add("Seven Up");
            for(int index = 1; index<= 10; index ++)
            {
                cbSoLuong.Items.Add(index);
            }
        }

        
        public Form1()
        {
            InitializeComponent();
            AddComboBox();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtGiaDuThuyen.Text = "";
            rdoCaNgay.Checked = false;
            rdoNuaNgay.Checked = false;
            cbDoUong.Text = "";
            cbDoUong.SelectedIndex = -1;
            cbSoLuong.Text = "";
            cbSoLuong.SelectedIndex = -1;
            txtTien.Text= "";
            txtHoTen.Focus();
        }

        private void SoTien()
        {
            switch(cbDoUong.Text)
            {
                case "Coca cola":
                    tongTien = 0.5 * int.Parse(cbSoLuong.Text);
                    txtTien.Text = (0.5 * int.Parse(cbSoLuong.Text)).ToString();
                    break;

                case "Pepsi":
                    tongTien = 0.8 * int.Parse(cbSoLuong.Text);
                    txtTien.Text = (0.8 * int.Parse(cbSoLuong.Text)).ToString();
                    break;
                default:
                    tongTien = 1 * int.Parse(cbSoLuong.Text);
                    txtTien.Text = (1.0 * int.Parse(cbSoLuong.Text)).ToString();
                    break;
            }
        }

        private void cbSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoTien();
        }

        private void rdoCaNgay_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaDuThuyen.Text = "200";

        }

        private void rdoNuaNgay_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaDuThuyen.Text = "100";
        }

        private void btnThemVaoDanhSach_Click(object sender, EventArgs e)
        {
            
            if(txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Nhập lại vì mã < 6");
                
            }

            string item = txtHoTen.Text+ "|";
            if(rdoCaNgay.Checked == true)
            {
                item = item + "cả ngày";
            }

            if(rdoNuaNgay.Checked == true)
            {
                item = item + "nửa ngày";
            }

            item = item + "Đồ uống" + cbDoUong.Text;
            item = (item + cbSoLuong.Text).ToString();
            item = item + "Tiền" + (int.Parse(txtGiaDuThuyen.Text) + tongTien).ToString();
            
            lstKhachHang.Items.Add(item);
        }
    }
}
