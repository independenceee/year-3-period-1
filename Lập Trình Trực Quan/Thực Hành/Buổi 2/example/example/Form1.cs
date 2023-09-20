﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void AddComboBox()
        {
            txtThoiGianGui.Items.Add("1");
            txtThoiGianGui.Items.Add("3");
            txtThoiGianGui.Items.Add("6");
            txtThoiGianGui.Items.Add("12");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AddComboBox();
            this.KeyPreview = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtSoTienGui.Text = "";
            txtNgayGui.Text = "";
            txtThoiGianGui.Text = "";
            txtThoiGianGui.SelectedIndex = -1;
            rdoThuong.Checked = false;
            rdoPhatLoc.Checked = false;
        }

        private void btnThemVao_Click(object sender, EventArgs e)
        {
            int kt = 1;
            if(txtMaKH.TextLength < 6)
            {
                MessageBox.Show("Nhập lại vì mã < 6");
                kt = 0;
            }

            if(txtDiaChi.TextLength == 0 || txtKhachHang.TextLength == 0)
            {
                MessageBox.Show("Nhập lại vì tên hoặc địa chỉ rỗng");
                kt = 0;
            }

            double tienlai = 0;

            if(kt == 1)
            {
                if (rdoThuong.Checked == true)
                {
                    if (txtThoiGianGui.SelectedItem == "1")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.06;

                    }
                    if (txtThoiGianGui.SelectedItem == "3")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.07;

                    }
                    if (txtThoiGianGui.SelectedItem == "6")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.08;

                    }
                    if (txtThoiGianGui.SelectedItem == "12")
                    {
                        tienlai = Convert.ToDouble(txtSoTienGui.Text) * 0.09;
                    }
                }
                else if (rdoPhatLoc.Checked == true)
                {
                    if (txtThoiGianGui.SelectedItem == "1")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.07;

                    }
                    if (txtThoiGianGui.SelectedItem == "3")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.08;

                    }
                    if (txtThoiGianGui.SelectedItem == "6")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.09;

                    }
                    if (txtThoiGianGui.SelectedItem == "12")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.1;

                    }
                }
                lbDanhSach.Items.Add(txtMaKH.Text + " | " + txtKhachHang.Text + " | " +
                    txtDiaChi.Text
                    + " | " + txtNgayGui.Text + " | " + txtSoTienGui.Text + " | "
                    + txtThoiGianGui.Text + " tháng | " + tienlai);
                
                /*
                StaticData._Nguoigui.Add(new NguoiGui(Convert.ToInt32(txtMaKH.Text), txtKhachHang.Text, txtDiaChi.Text, Convert.ToInt32(txtSoTienGui.Text),
                    dtpNgayGui.Text, cbThoiGianGui.Text, tienlai
                  ));
                */

            

        }
    }
    }
}
