using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Admin;

namespace PROJECT_CK_20231
{
    public partial class Form_Dangnhap : Form
    {
        public Form_Dangnhap()
        {
            InitializeComponent();
        }

        private MySqlConnection tao_connetion()
        {
            string server = "127.0.0.1";
            string database = "ql_thu_vien_1";
            string uid = "root";
            string password = "23102003";

            string constring = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password}";
            MySqlConnection connection = new MySqlConnection(constring);
            return connection;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                string inputText_Taikhoan = tex_Taikhoan.Text; // Lấy dữ liệu từ TextBox
                string inputText_Matkhau = tex_Matkhau.Text;
                string query = "SELECT u.user_id, a.role FROM account a JOIN user u ON a.user_id = u.user_id WHERE u.user_id = @InputText_Taikhoan AND a.password = @InputText_Matkhau";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@InputText_Taikhoan", inputText_Taikhoan);
                command.Parameters.AddWithValue("@InputText_Matkhau", inputText_Matkhau);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string role = reader["role"].ToString();
                        string userId = reader["user_id"].ToString();

                        if (rad_Docgia.Checked && role == "User")
                        {
                            Form_gduser users = new Form_gduser(userId);
                            users.ShowDialog();
                        }
                        else if (rad_Nhanvien.Checked && role == "staff")
                        {
                            Frm_qlsach users = new Frm_qlsach();
                            users.ShowDialog();
                        }
                        else if (rad_Nguoiquanly.Checked && role == "Admin")
                        {
                            Admin_HomePage frm_homepage = new Admin_HomePage(userId);
                            frm_homepage.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Vai trò không hợp lệ.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thông tin đăng nhập chưa chính xác");
                    }
                }
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Hàm rỗng
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_Taikhoan_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void Form_Dangnhap_Load(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void but_dki_Click(object sender, EventArgs e)
        {
            Form5 users5 = new Form5();
            users5.ShowDialog();
        }

        private void rad_Nhanvien_CheckedChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void rad_Docgia_CheckedChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }
    }
}