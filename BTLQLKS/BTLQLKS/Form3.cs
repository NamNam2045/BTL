using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTLQLKS
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=NAMNAM\ADMIN;Initial Catalog=QLCSDLKS;Integrated Security=True;trustserverCertificate=True");

        private void openCon()
        {
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
          
        }

        private void closeCon()
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private Boolean Exe(string cmd)
        {
            openCon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, conn);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception ex) 
            {
            check = false;
            }
            closeCon();
            return check;
        }
        private DataTable Red(string cmd)
        {
            openCon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, conn);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);

            }
            catch (Exception)
            { 
                dt = null;
                throw;
            
            }
            conn.Close();
            return dt;   
        }


        private void load()
        {
            DataTable dt = Red("SELECT * FROM NhanVien");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exe("INSERT INTO NhanVien(MaNV ,TenNV ,MatKhau ,ChucVu) VALUES (N'" + tbMNV.Text + "','" + tbTenDN.Text + "','" + tbMK.Text + "','"+tbVT.Text+"')");
            load();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbTenDN.ResetText();
            tbMNV.ResetText();
            tbMK.ResetText();
            tbVT.ResetText();

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Exe("UPDATE NhanVien SET TenNV = N'" + tbTenDN.Text + "',MatKhau = N'" + tbMK.Text + "',ChucVu = N'" + tbVT.Text + "' WHERE MaNV = '" + tbMNV.Text + "'");
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMNV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbTenDN.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbMK.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbVT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            {
                Exe("DELETE FROM NhanVien WHERE MaNV = '" + tbMNV.Text + "'");
                load();
            }
        }

        private void btTK_Click(object sender, EventArgs e)
        {
            DataTable dt = Red("SELECT * FROM NhanVien WHERE MaNV = '"+tbMNV.Text+"'");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}



