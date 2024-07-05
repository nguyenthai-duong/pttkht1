using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT_CK_20231
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
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

        private void vbB_Xacnhan_Click(object sender, EventArgs e)
        {
            string userName = tex_UserName.Text;
            string userAddress = tex_UserAddress.Text;
            string userSex = radioButtonMale.Checked ? "Male" : radioButtonFemale.Checked ? "Female" : "";
            string email = tex_Email.Text;
            int adminId = 1; // Admin ID mặc định là 1
            int sdt = int.Parse(tex_SDT.Text);
            string matkhau = tex_NhapMK.Text;
            string nhaplai = tex_XacnhanMK.Text;
            DateTime accountDob = new DateTime(2003, 1, 1); // account_dob mặc định là 1/1/2003

            if (userSex == "")
            {
                MessageBox.Show("Vui lòng chọn giới tính!!!");
                return;
            }

            if (matkhau != nhaplai)
            {
                MessageBox.Show("Mật khẩu xác nhận không chính xác!!!");
                return;
            }

            MySqlConnection connection = tao_connetion();
            connection.Open();

            string queryk = "SELECT * FROM `user` WHERE `email` = @Email";
            MySqlCommand cmdk = new MySqlCommand(queryk, connection);
            cmdk.Parameters.AddWithValue("@Email", email);

            //____________________Lấy data___________________//
            MySqlDataAdapter adapterk = new MySqlDataAdapter(cmdk);
            DataTable dataTablek = new DataTable();
            adapterk.Fill(dataTablek);
            int rowCount = dataTablek.Rows.Count;

            if (rowCount != 0)
            {
                MessageBox.Show("Email đã tồn tại!!!");
                return;
            }

            string insertQueryUser = "INSERT INTO `user` (user_address, user_sex, email, user_name, admin_id, SDT) VALUES (@UserAddress, @UserSex, @Email, @UserName, @AdminId, @SDT)";
            MySqlCommand insertQueryUserCmd = new MySqlCommand(insertQueryUser, connection);
            insertQueryUserCmd.Parameters.AddWithValue("@UserAddress", userAddress);
            insertQueryUserCmd.Parameters.AddWithValue("@UserSex", userSex);
            insertQueryUserCmd.Parameters.AddWithValue("@Email", email);
            insertQueryUserCmd.Parameters.AddWithValue("@UserName", userName);
            insertQueryUserCmd.Parameters.AddWithValue("@AdminId", adminId);
            insertQueryUserCmd.Parameters.AddWithValue("@SDT", sdt);
            insertQueryUserCmd.ExecuteNonQuery();

            // Lấy user_id vừa được tạo
            string getUserIdQuery = "SELECT user_id FROM `user` WHERE `email` = @Email";
            MySqlCommand getUserIdCmd = new MySqlCommand(getUserIdQuery, connection);
            getUserIdCmd.Parameters.AddWithValue("@Email", email);
            int userId = Convert.ToInt32(getUserIdCmd.ExecuteScalar());

            string insertQueryAccount = "INSERT INTO `account` (user_id, password, role, account_dob) VALUES (@UserId, @Matkhau, 'User', @AccountDob)";
            MySqlCommand insertQueryAccountCmd = new MySqlCommand(insertQueryAccount, connection);
            insertQueryAccountCmd.Parameters.AddWithValue("@UserId", userId);
            insertQueryAccountCmd.Parameters.AddWithValue("@Matkhau", matkhau);
            insertQueryAccountCmd.Parameters.AddWithValue("@AccountDob", accountDob);
            insertQueryAccountCmd.ExecuteNonQuery();

            MessageBox.Show($"Đăng ký thành công!!! User ID của bạn là: {userId}, hãy nhớ nó để đăng nhập vào hệ thống.");
            MessageBox.Show($"Đăng ký thành công!!! User ID của bạn là: {userId}, hãy nhớ nó để đăng nhập vào hệ thống.");

            connection.Close();
        }
    }
}
