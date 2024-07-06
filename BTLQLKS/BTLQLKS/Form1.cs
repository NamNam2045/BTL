using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLQLKS
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection(@"Data Source=NAMNAM\ADMIN;Initial Catalog=QLCSDLKS;Integrated Security=True;trustserverCertificate=True");
                try {


                    conn.Open();
                    string sql = "SELECT * FROM NhanVien WHERE TenNV  = '" + txtTK.Text + "' AND MatKhau = '" + txtMK.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Thong tin khong chinh xac");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi khong the ket noi");
                }
             }   
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
