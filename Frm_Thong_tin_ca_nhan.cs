using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJECT_CK_20231
{
    public partial class Form_Thongtinnguoidung : Form
    {
        private string ID_User;
        public Form_Thongtinnguoidung(string ID_ND)
        {
            InitializeComponent();
            this.ID_User = ID_ND;
        }

        private string GetRandomImageUrl()
        {
            // Thay đổi kích thước và các thông số khác nếu cần
            int width = 800;
            int height = 600;

            // Tạo URL cho hình ảnh ngẫu nhiên từ Lorem Picsum
            return $"https://picsum.photos/{width}/{height}/?random";
        }

        private MySqlConnection tao_connetion()
        {
            string server = "localhost";
            string database = "ql_thu_vien_1";
            string uid = "root";
            string password = "23102003";

            string constring = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password}";
            MySqlConnection connection = new MySqlConnection(constring);
            return connection;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string query = @"SELECT user.user_name, user.user_address, user.user_sex, user.email, user.SDT, account.account_dob
                             FROM user
                             JOIN account ON user.user_id = account.user_id
                             WHERE user.user_id = @ID_User";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID_User", ID_User);

            //____________________Lấy data___________________//
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataRow row = dataTable.Rows[0];

            tex_Nhaphovaten.Text = row["user_name"].ToString();
            tex_Nhapngaysinh.Text = row["account_dob"].ToString();
            tex_Nhapgioitinh.Text = row["user_sex"].ToString();
            tex_Nhapdiachi.Text = row["user_address"].ToString();
            tex_NhapEmail.Text = row["email"].ToString();
            tex_Nhapdienthoai.Text = row["SDT"].ToString();
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            tab_Thongtin.SelectedIndex = 0;
        }

        private void tab_TTCN_Click(object sender, EventArgs e)
        {

        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            tab_Thongtin.SelectedIndex = 1;
        }

        private void vbButton3_Click(object sender, EventArgs e)
        {
            tab_Thongtin.SelectedIndex = 2;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void vbB_Xacnhan_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string query = "SELECT * FROM account WHERE user_id = @ID_User";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID_User", ID_User);

            //____________________Lấy data___________________//
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataRow row = dataTable.Rows[0];

            string nameuser = tex_NhapTK.Text;
            string oldPassword = tex_NhapMKcu.Text;
            string newPassword = tex_NhapMKmoi.Text;
            string confirmPassword = tex_NLai.Text;

            if (oldPassword == row["password"].ToString())
            {
                string updatePasswordQuery = "UPDATE account SET password = @newPassword WHERE user_id = @ID_User";
                MySqlCommand updatePasswordCmd = new MySqlCommand(updatePasswordQuery, connection);
                updatePasswordCmd.Parameters.AddWithValue("@newPassword", newPassword);
                updatePasswordCmd.Parameters.AddWithValue("@ID_User", ID_User);

                updatePasswordCmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật mật khẩu thành công!!!");
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng. Vui lòng thử lại.");
            }
        }

        private void vbB_doithongtin_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string query = "SELECT * FROM user WHERE user_id = @ID_User";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID_User", ID_User);

            //____________________Lấy data___________________//
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataRow row = dataTable.Rows[0];

            string tenmoi = tex_doiten.Text;
            string ngaysinhmoi = tex_doingaysinh.Text;

            string gioitinhmoi = rad_Male.Text;
            string gioitinhmoi1 = rad_Female.Text;

            string diachimoi = tex_Doidiachi.Text;
            string emailmoi = tex_Doiemail.Text;
            string dienthoaimoi = tex_DoiSDT.Text;

            string updateten = "UPDATE user SET user_name = @tenmoi WHERE user_id = @ID_User";
            MySqlCommand updatetenCmd = new MySqlCommand(updateten, connection);
            updatetenCmd.Parameters.AddWithValue("@tenmoi", tenmoi);
            updatetenCmd.Parameters.AddWithValue("@ID_User", ID_User);
            updatetenCmd.ExecuteNonQuery();

            string updatengaysinh = "UPDATE account SET account_dob = @ngaysinhmoi WHERE user_id = @ID_User";
            MySqlCommand updatengaysinhCmd = new MySqlCommand(updatengaysinh, connection);
            updatengaysinhCmd.Parameters.AddWithValue("@ngaysinhmoi", ngaysinhmoi);
            updatengaysinhCmd.Parameters.AddWithValue("@ID_User", ID_User);
            updatengaysinhCmd.ExecuteNonQuery();

            if (rad_Male.Checked)
            {
                string updategioitinhmoi = "UPDATE user SET user_sex = @gioitinhmoi WHERE user_id = @ID_User";
                MySqlCommand updategioitinhCmd = new MySqlCommand(updategioitinhmoi, connection);
                updategioitinhCmd.Parameters.AddWithValue("@gioitinhmoi", gioitinhmoi);
                updategioitinhCmd.Parameters.AddWithValue("@ID_User", ID_User);
                updategioitinhCmd.ExecuteNonQuery();
            }

            if (rad_Female.Checked)
            {
                string updategioitinhmoi = "UPDATE user SET user_sex = @gioitinhmoi1 WHERE user_id = @ID_User";
                MySqlCommand updategioitinhCmd = new MySqlCommand(updategioitinhmoi, connection);
                updategioitinhCmd.Parameters.AddWithValue("@gioitinhmoi1", gioitinhmoi1);
                updategioitinhCmd.Parameters.AddWithValue("@ID_User", ID_User);
                updategioitinhCmd.ExecuteNonQuery();
            }

            string updatediachimoi = "UPDATE user SET user_address = @diachimoi WHERE user_id = @ID_User";
            MySqlCommand updatediachimoiCmd = new MySqlCommand(updatediachimoi, connection);
            updatediachimoiCmd.Parameters.AddWithValue("@diachimoi", diachimoi);
            updatediachimoiCmd.Parameters.AddWithValue("@ID_User", ID_User);
            updatediachimoiCmd.ExecuteNonQuery();

            string updateemailmoi = "UPDATE user SET email = @emailmoi WHERE user_id = @ID_User";
            MySqlCommand updatedemailmoiCmd = new MySqlCommand(updateemailmoi, connection);
            updatedemailmoiCmd.Parameters.AddWithValue("@emailmoi", emailmoi);
            updatedemailmoiCmd.Parameters.AddWithValue("@ID_User", ID_User);
            updatedemailmoiCmd.ExecuteNonQuery();

            string updatedienthoaimoi = "UPDATE user SET SDT = @dienthoaimoi WHERE user_id = @ID_User";
            MySqlCommand updatedienthoaimoiCmd = new MySqlCommand(updatedienthoaimoi, connection);
            updatedienthoaimoiCmd.Parameters.AddWithValue("@dienthoaimoi", dienthoaimoi);
            updatedienthoaimoiCmd.Parameters.AddWithValue("@ID_User", ID_User);
            updatedienthoaimoiCmd.ExecuteNonQuery();

            MessageBox.Show("Cập nhật thông tin thành công!!!");

            tex_Nhaphovaten.Text = tex_doiten.Text;
            tex_Nhapngaysinh.Text = tex_doingaysinh.Text;
            if (rad_Male.Checked)
            {
                tex_Nhapgioitinh.Text = rad_Male.Text;
            }
            if (rad_Female.Checked)
            {
                tex_Nhapgioitinh.Text = rad_Female.Text;
            }

            tex_Nhapdiachi.Text = tex_Doidiachi.Text;
            tex_NhapEmail.Text = tex_Doiemail.Text;
            tex_Nhapdienthoai.Text = tex_DoiSDT.Text;
        }

        private void rad_Male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rad_Female_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vbB_DoiTT_Click(object sender, EventArgs e)
        {
            tab_Thongtin.SelectedIndex = 2;
        }
    }
}