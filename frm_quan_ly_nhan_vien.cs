using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Asn1.Crmf;

namespace Admin
{
    public partial class frm_quan_ly_nhan_vien : Form
    {
        string constr;
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataAdapter adapter;

        public frm_quan_ly_nhan_vien()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadDataIntoDataGridView();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InitializeDatabaseConnection()
        {
            try
            {
                constr = "Server=127.0.0.1;Database=ql_thu_vien_1;User ID=root;Password=23102003;";
                connection = new MySqlConnection(constr);
                command = new MySqlCommand();
                adapter = new MySqlDataAdapter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing database connection: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string userEmail = txtUserEmail.Text.Trim();
            string adminID = txtAdminID.Text.Trim();
            string phone = txtPhone.Text.Trim();

            try
            {
                connection.Open();
                StringBuilder queryBuilder = new StringBuilder("SELECT * FROM user WHERE ");
                bool conditionAdded = false;

                if (!string.IsNullOrEmpty(userID))
                {
                    queryBuilder.Append($" user_id = '{userID}'");
                    conditionAdded = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(userName))
                    {
                        if (conditionAdded) queryBuilder.Append(" OR");
                        queryBuilder.Append($" user_name LIKE '%{userName}%'");
                        conditionAdded = true;
                    }

                    if (!string.IsNullOrEmpty(userEmail))
                    {
                        if (conditionAdded) queryBuilder.Append(" OR");
                        queryBuilder.Append($" email LIKE '%{userEmail}%'");
                        conditionAdded = true;
                    }

                    if (!string.IsNullOrEmpty(adminID))
                    {
                        if (conditionAdded) queryBuilder.Append(" OR");
                        queryBuilder.Append($" admin_id LIKE '%{adminID}%'");
                        conditionAdded = true;
                    }

                    if (!string.IsNullOrEmpty(phone))
                    {
                        if (conditionAdded) queryBuilder.Append(" OR");
                        queryBuilder.Append($" SDT LIKE '%{phone}%'");
                        conditionAdded = true;
                    }
                }

                MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM user";
                MySqlCommand command = new MySqlCommand(query, connection);
                DataTable dataTable = new DataTable();
                adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
                connection.Close();
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_them_nhan_vien formManageStaff_AddnewStaff = new frm_them_nhan_vien();
            formManageStaff_AddnewStaff.ShowDialog();
            formManageStaff_AddnewStaff.Owner = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Vui lòng nhập ID nhân viên cần xóa");
                return;
            }

            if (!IsUserIDExists(userID))
            {
                MessageBox.Show("ID nhân viên bạn yêu cầu không tồn tại");
                return;
            }

            try
            {
                connection.Open();
                string deleteQuery = "DELETE FROM user WHERE user_id = @user_id";
                MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
                deleteCmd.Parameters.AddWithValue("@user_id", userID);
                deleteCmd.ExecuteNonQuery();
                LoadDataIntoDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private bool IsUserIDExists(string userID)
        {
            try
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM user WHERE user_id = @user_id";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@user_id", userID);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Vui lòng nhập ID nhân viên cần sửa");
                return;
            }

            if (!IsUserIDExists(userID))
            {
                MessageBox.Show("ID nhân viên bạn yêu cầu sửa thông tin không tồn tại");
                return;
            }
            else
            {
                ManageStaff_RepairInfo formManageAdmin_Repair = new ManageStaff_RepairInfo();
                formManageAdmin_Repair.ShowDialog();
            }

            try
            {
                string selectAllQuery = "SELECT * FROM user";
                MySqlCommand selectAllCmd = new MySqlCommand(selectAllQuery, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectAllCmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            finally
            {
                connection.Close();
            }
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

        private void LoadDataIntoKhoiPhuc()
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string query = "SELECT * FROM `user`";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadDataIntoKhoiPhuc();
        }

        // Các hàm trống
        private void label1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void FormManageStaff_Load(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void txtAdminID_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void txtUserID_TextChanged(object sender, EventArgs e) { }
        private void txtUserEmail_TextChanged(object sender, EventArgs e) { }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }
        private void label7_Click(object sender, EventArgs e) { }
    }
}