using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1
{
    
    public partial class Form1 : Form
    {
        public class Diem
        {
            int tongTinChi;
            double tongDiem;
            double diemTrungBinh;

            public Diem(int tongTinChi)
            {
                
            }
        }

        List<Diem> diem = new List<Diem>();

        public Form1()
        {
            InitializeComponent();
        }


        private void AddComboBox()
        {
            cbTenMonHoc.Items.Add("Tin học đại cương");
            cbTenMonHoc.Items.Add("Giải tích F1");
            cbTenMonHoc.Items.Add("Tiếng Anh A0");
            cbTenMonHoc.Items.Add("Triết học Mác - Lênim");
            cbTenMonHoc.Items.Add("Vật lý F1");
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            AddComboBox();
            
        }


        private void HandleChangeTenMonHoc()
        {
            switch(cbTenMonHoc.Text)
            {
                case "Tin học đại cương":
                    txtSoTinChi.Text = "3";
                    break;
                case "Giải tích F1":
                    txtSoTinChi.Text = "3";
                    break;
                case "Tiếng Anh A0":
                    txtSoTinChi.Text = "3";
                    break;
                case "Triết học Mác - Lênim":
                    txtSoTinChi.Text = "2";
                    break;
                default:
                    txtSoTinChi.Text = "3";
                    break;

            }
        }
        private void cbTenMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleChangeTenMonHoc();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThemVaoDanhSach_Click(object sender, EventArgs e)
        {
            if(txtDiem.Text.Trim() == "")
            {

            }

            listBox1.Items.Add(cbTenMonHoc.Text + txtSoTinChi.Text + txtDiem.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tongTinChi = tongTinChi + int.Parse(txtSoTinChi.Text);
            tongTin.Text = tongTinChi.ToString();
            tongDiem = tongDiem + double.Parse(txtDiem.Text);
            textBox2.Text = tongDiem.ToString();
            diemTrungBinh = diemTrungBinh + (tongDiem / tongTinChi);
            textBox3.Text = diemTrungBinh.ToString();
        }
    }
}
