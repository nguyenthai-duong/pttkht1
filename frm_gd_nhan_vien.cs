using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace PROJECT_CK_20231
{
    public partial class Frm_qlsach : Form
    {
        public Frm_qlsach()
        {
            InitializeComponent();
            LoadDataIntoDgvQuanLySach();
            LoadDataIntoDgvQuanLyTheDoc();
            LoadDataIntoDgvQuanLyNhapSach();
            LoadDataIntoDgvQuanLyMuonSach();
            LoadDataIntoDgvDanhGia();

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



        private void LoadDataIntoDgvQuanLySach()
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string query = "SELECT * FROM book";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dGV_qlsach.DataSource = dataTable;
            connection.Close();
        }

        private void LoadDataIntoDgvDanhGia()
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string query = "SELECT * FROM evaluate";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dGV_Danhgia.DataSource = dataTable;
            connection.Close();
        }

        private void LoadDataIntoDgvQuanLyTheDoc()
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string query = "SELECT * FROM cardreader";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dGV_qlthedoc.DataSource = dataTable;
            connection.Close();
        }

        private void LoadDataIntoDgvQuanLyNhapSach()
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string query = "SELECT * FROM receipt";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dGV_qlnhapsach.DataSource = dataTable;
            connection.Close();
        }


        private void LoadDataIntoDgvQuanLyMuonSach()
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string query = "SELECT * FROM borrowing_receipt";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dGV_qlmuonsach.DataSource = dataTable;
            connection.Close();
        }


















        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void dGV_qlsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void vbButton6_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string madocgia = tex_madocgia1.Text;

            string queryp = "SELECT * FROM cardreader WHERE user_id = @madocgia";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@madocgia", madocgia);
            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);

            dGV_qlthedoc.DataSource = dataTablep;
            connection.Close();
        }

        private void vbButton4_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string masach = tex_masach1.Text;
            string queryp = "SELECT * FROM book WHERE book_id = @masach";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@masach", masach);
            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount = dataTablep.Rows.Count;
            if (rowCount > 0)
            {
                Quanlysach.SelectedIndex = 6;
            }
            if (rowCount == 0)
            {
                MessageBox.Show("Không tồn tại mã sách");
            }
            connection.Close();
        }

        private void Quanlysach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void vbButton8_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            DateTime selectedDateTime = date_ngaysinh.Value;
            string ngaysinh = selectedDateTime.ToString("yyyy-MM-dd");
            string madocgia = tex_madocgia1.Text;

            // Kiểm tra xem user_id có tồn tại trong bảng user hay không
            string checkUserQuery = "SELECT COUNT(*) FROM user WHERE user_id = @madocgia";
            MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, connection);
            checkUserCmd.Parameters.AddWithValue("@madocgia", madocgia);
            int userExists = Convert.ToInt32(checkUserCmd.ExecuteScalar());

            if (userExists == 0)
            {
                // Nếu user_id không tồn tại, từ chối thêm vào bảng cardreader và thông báo lỗi
                MessageBox.Show("Mã độc giả không tồn tại trong hệ thống! Vui lòng kiểm tra lại.");
            }
            else
            {
                // Kiểm tra xem user_id có tồn tại trong bảng cardreader hay không
                string queryp = "SELECT COUNT(*) FROM cardreader WHERE user_id = @madocgia";
                MySqlCommand cmdp = new MySqlCommand(queryp, connection);
                cmdp.Parameters.AddWithValue("@madocgia", madocgia);
                int cardReaderExists = Convert.ToInt32(cmdp.ExecuteScalar());

                if (cardReaderExists == 0)
                {
                    // Tính toán ngày hết hạn là một năm sau ngày sinh
                    DateTime expiryDate = selectedDateTime.AddYears(1);
                    string expiry = expiryDate.ToString("yyyy-MM-dd");

                    string insertQuery = "INSERT INTO cardreader (user_id, cardreader_dob, expiry) VALUES (@madocgia, @ngaysinh, @expiry)";
                    MySqlCommand insertQuerycmd = new MySqlCommand(insertQuery, connection);
                    insertQuerycmd.Parameters.AddWithValue("@madocgia", madocgia);
                    insertQuerycmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    insertQuerycmd.Parameters.AddWithValue("@expiry", expiry);
                    insertQuerycmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thẻ đọc thành công");
                }
                else
                {
                    MessageBox.Show("Người dùng đã có thẻ bạn đọc! Vui lòng kiểm tra lại!");
                }
            }

            LoadDataIntoDgvQuanLyTheDoc();
            connection.Close();
        }

        private void vbButton7_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string madocgia = tex_madocgia1.Text;
            string queryp = "SELECT * FROM cardreader WHERE user_id = @madocgia";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@madocgia", madocgia);

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount = dataTablep.Rows.Count;

            if (rowCount > 0)
            {
                string deletequery = "DELETE FROM cardreader WHERE user_id = @madocgia";
                MySqlCommand cmdd = new MySqlCommand(deletequery, connection);
                cmdd.Parameters.AddWithValue("@madocgia", madocgia);
                cmdd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa thẻ đọc");
            }
            else
            {
                MessageBox.Show("Mã thẻ không tồn tại! Không thể xóa");
            }
            LoadDataIntoDgvQuanLyTheDoc();
            connection.Close();
        }

        private void vbButton5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dGV_qlthedoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void qlsach_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string masach = tex_masach1.Text;
            string theloai = tex_theloai1.Text;
            string tacgia = tex_tacgia1.Text;
            string tensach = tex_tensach1.Text;

            string queryp = "SELECT * FROM book WHERE book_id = @masach";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@masach", masach);

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount = dataTablep.Rows.Count;

            if (rowCount == 0)
            {
                string insertQuery = "INSERT INTO book (book_id, book_category, publisher, book_name) VALUES (@masach, @theloai, @tacgia, @tensach)";
                MySqlCommand insertQuerycmd = new MySqlCommand(insertQuery, connection);
                insertQuerycmd.Parameters.AddWithValue("@masach", masach);
                insertQuerycmd.Parameters.AddWithValue("@theloai", theloai);
                insertQuerycmd.Parameters.AddWithValue("@tacgia", tacgia);
                insertQuerycmd.Parameters.AddWithValue("@tensach", tensach);
                insertQuerycmd.ExecuteNonQuery();
                MessageBox.Show("Thêm sách thành công");
            }
            else
            {
                MessageBox.Show("Mã sách đã tồn tại! Vui lòng kiểm tra lại!");
            }
            LoadDataIntoDgvQuanLySach();
            connection.Close();
        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string masach = tex_masach1.Text;
            string queryp = "SELECT * FROM book WHERE book_id = @masach";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@masach", masach);

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount = dataTablep.Rows.Count;

            if (rowCount > 0)
            {
                string deletequery = "DELETE FROM book WHERE book_id = @masach";
                MySqlCommand cmdd = new MySqlCommand(deletequery, connection);
                cmdd.Parameters.AddWithValue("@masach", masach);
                cmdd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa sách");
            }
            else
            {
                MessageBox.Show("Mã sách không tồn tại! Không thể xóa");
            }
            LoadDataIntoDgvQuanLySach();
            connection.Close();
        }

        private void vbButton3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string tensach = tex_tensach1.Text;
            string theloai = tex_theloai1.Text;
            string tacgia = tex_tacgia1.Text;

            string queryp = "SELECT * FROM book WHERE book_name = @tensach";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@tensach", tensach);
            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);

            string query1 = "SELECT * FROM book WHERE book_category = @theloai";
            MySqlCommand cmd1 = new MySqlCommand(query1, connection);
            cmd1.Parameters.AddWithValue("@theloai", theloai);
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            DataTable dataTable1 = new DataTable();
            adapter1.Fill(dataTable1);

            string query2 = "SELECT * FROM book WHERE publisher = @tacgia";
            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
            cmd2.Parameters.AddWithValue("@tacgia", tacgia);
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);

            if (!string.IsNullOrEmpty(tensach))
            {
                dGV_qlsach.DataSource = dataTablep;
            }
            if (!string.IsNullOrEmpty(theloai))
            {
                dGV_qlsach.DataSource = dataTable1;
            }
            if (!string.IsNullOrEmpty(tacgia))
            {
                dGV_qlsach.DataSource = dataTable2;
            }
            connection.Close();
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void vbButton12_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            DateTime currentTime = DateTime.Now;
            string ngaynhap = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            string manhap = tex_manhap.Text;
            string masach = tex_masach.Text;
            string manhanvien = tex_manhanvien.Text;
            string manhacungcap = tex_manhacungcap.Text;
            int quantity = int.Parse(tex_soluong.Text);
            int price = int.Parse(tex_gia.Text);

            // Kiểm tra xem mã nhập đã tồn tại hay chưa
            string queryp = "SELECT COUNT(*) FROM receipt WHERE receipt_id = @manhap";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@manhap", manhap);
            int receiptExists = Convert.ToInt32(cmdp.ExecuteScalar());

            if (receiptExists == 0)
            {
                // Thêm mới vào bảng receipt
                string insertReceiptQuery = "INSERT INTO receipt (receipt_id, supplier_id, receipt_dob, staff_id) VALUES (@manhap, @manhacungcap, @ngaynhap, @manhanvien)";
                MySqlCommand insertReceiptCmd = new MySqlCommand(insertReceiptQuery, connection);
                insertReceiptCmd.Parameters.AddWithValue("@manhap", manhap);
                insertReceiptCmd.Parameters.AddWithValue("@manhacungcap", manhacungcap);
                insertReceiptCmd.Parameters.AddWithValue("@ngaynhap", ngaynhap);
                insertReceiptCmd.Parameters.AddWithValue("@manhanvien", manhanvien);
                insertReceiptCmd.ExecuteNonQuery();

                // Thêm chi tiết vào bảng receipt_details
                string insertReceiptDetailsQuery = "INSERT INTO receipt_details (receipt_id, book_id, quantity, price) VALUES (@manhap, @masach, @quantity, @price)";
                MySqlCommand insertReceiptDetailsCmd = new MySqlCommand(insertReceiptDetailsQuery, connection);
                insertReceiptDetailsCmd.Parameters.AddWithValue("@manhap", manhap);
                insertReceiptDetailsCmd.Parameters.AddWithValue("@masach", masach);
                insertReceiptDetailsCmd.Parameters.AddWithValue("@quantity", quantity);
                insertReceiptDetailsCmd.Parameters.AddWithValue("@price", price);
                insertReceiptDetailsCmd.ExecuteNonQuery();

                MessageBox.Show("Thêm sách thành công");
            }
            else
            {
                MessageBox.Show("Mã nhập đã tồn tại! Vui lòng kiểm tra lại!");
            }

            // Cập nhật lại DataGridView
            LoadDataIntoDgvQuanLyNhapSach();
            connection.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void vbButton11_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string manhapsach = tex_manhap.Text;

            // Kiểm tra xem mã nhập có tồn tại hay không
            string queryp = "SELECT COUNT(*) FROM receipt WHERE receipt_id = @manhapsach";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@manhapsach", manhapsach);
            int receiptExists = Convert.ToInt32(cmdp.ExecuteScalar());

            if (receiptExists > 0)
            {
                // Xóa các chi tiết hóa đơn trong bảng receipt_details trước
                string deleteDetailsQuery = "DELETE FROM receipt_details WHERE receipt_id = @manhapsach";
                MySqlCommand deleteDetailsCmd = new MySqlCommand(deleteDetailsQuery, connection);
                deleteDetailsCmd.Parameters.AddWithValue("@manhapsach", manhapsach);
                deleteDetailsCmd.ExecuteNonQuery();

                // Xóa bản ghi trong bảng receipt
                string deleteReceiptQuery = "DELETE FROM receipt WHERE receipt_id = @manhapsach";
                MySqlCommand deleteReceiptCmd = new MySqlCommand(deleteReceiptQuery, connection);
                deleteReceiptCmd.Parameters.AddWithValue("@manhapsach", manhapsach);
                deleteReceiptCmd.ExecuteNonQuery();

                MessageBox.Show("Đã xóa hóa đơn nhập sách");
            }
            else
            {
                MessageBox.Show("Mã nhập không tồn tại trong kho nhập! Không thể xóa");
            }

            // Cập nhật lại DataGridView
            LoadDataIntoDgvQuanLyNhapSach();
            connection.Close();
        }

        private void vbButton10_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string manhapsach = tex_manhap.Text;
            string masach = tex_masach.Text;
            string manhanvien = tex_manhanvien.Text;
            string queryp = "SELECT * FROM receipt";

            List<string> conditions = new List<string>();
            if (!string.IsNullOrEmpty(manhapsach))
            {
                conditions.Add("receipt_id = @manhapsach");
            }
            if (!string.IsNullOrEmpty(masach))
            {
                conditions.Add("receipt_id IN (SELECT receipt_id FROM receipt_details WHERE book_id = @masach)");
            }
            if (!string.IsNullOrEmpty(manhanvien))
            {
                conditions.Add("staff_id = @manhanvien");
            }

            if (conditions.Count > 0)
            {
                queryp += " WHERE " + string.Join(" AND ", conditions);
            }

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);

            if (!string.IsNullOrEmpty(manhapsach))
            {
                cmdp.Parameters.AddWithValue("@manhapsach", manhapsach);
            }
            if (!string.IsNullOrEmpty(masach))
            {
                cmdp.Parameters.AddWithValue("@masach", masach);
            }
            if (!string.IsNullOrEmpty(manhanvien))
            {
                cmdp.Parameters.AddWithValue("@manhanvien", manhanvien);
            }

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            dGV_qlnhapsach.DataSource = dataTablep;

            connection.Close();
        }

        private void vbButton9_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string manhapsach = tex_manhap.Text;

            string queryp = "SELECT * FROM receipt WHERE receipt_id = @manhapsach";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@manhapsach", manhapsach);

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount = dataTablep.Rows.Count;

            if (rowCount > 0)
            {
                Quanlysach.SelectedIndex = 4; // Chuyển sang tab chứa thông tin hóa đơn nhập sách
                dGV_qlnhapsach.DataSource = dataTablep; // Hiển thị thông tin hóa đơn nhập sách trong DataGridView
            }
            else
            {
                MessageBox.Show("Không tồn tại mã nhập sách");
            }

            connection.Close();
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void vbButton11_Click_1(object sender, EventArgs e)
        {

            MySqlConnection connection = tao_connetion();
            connection.Open();
            string manhapsach = tex_manhap.Text;
            string masachmoi = tex_doisachnhap.Text;
            string doimanhanvien = tex_doimanv.Text;

            string updatenhapsach = "UPDATE `bill nhập` SET `Mã sách` = @masachmoi WHERE `Mã nhập` = @manhapsach;";
            MySqlCommand updategioCmd = new MySqlCommand(updatenhapsach, connection);
            updategioCmd.Parameters.AddWithValue("@masachmoi", masachmoi);
            updategioCmd.Parameters.AddWithValue("@manhapsach", manhapsach); // Thay 'ten_nguoidung' bằng tên người dùng
            updategioCmd.ExecuteNonQuery();

            string updatenhapsach1 = "UPDATE `bill nhập` SET `Mã nhân viên` = @doimanhanvien WHERE `Mã nhập` = @manhapsach;";
            MySqlCommand updategioCmd1 = new MySqlCommand(updatenhapsach1, connection);
            updategioCmd1.Parameters.AddWithValue("@doimanhanvien", doimanhanvien);
            updategioCmd1.Parameters.AddWithValue("@manhapsach", manhapsach); // Thay 'ten_nguoidung' bằng tên người dùng
            updategioCmd1.ExecuteNonQuery();
            LoadDataIntoDgvQuanLyNhapSach();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void vbButton16_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            DateTime currentTime = DateTime.Now;
            string ngaymuon = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            string mamuon = text_mamuon.Text;
            string madocgia = tex_madocgia.Text;
            string manhanvien = tex_manhanvien.Text;

            // Kiểm tra xem mã mượn đã tồn tại hay chưa
            string queryp = "SELECT COUNT(*) FROM borrowing_receipt WHERE borrowing_receipt_id = @mamuon";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@mamuon", mamuon);
            int borrowingExists = Convert.ToInt32(cmdp.ExecuteScalar());

            if (borrowingExists == 0)
            {
                // Thêm mới vào bảng borrowing_receipt
                string insertBorrowingReceiptQuery = "INSERT INTO borrowing_receipt (borrowing_receipt_id, reader_id, staff_id, borrowing_receipt_dob) VALUES (@mamuon, @madocgia, @manhanvien, @ngaymuon)";
                MySqlCommand insertBorrowingReceiptCmd = new MySqlCommand(insertBorrowingReceiptQuery, connection);
                insertBorrowingReceiptCmd.Parameters.AddWithValue("@mamuon", mamuon);
                insertBorrowingReceiptCmd.Parameters.AddWithValue("@madocgia", madocgia);
                insertBorrowingReceiptCmd.Parameters.AddWithValue("@manhanvien", manhanvien);
                insertBorrowingReceiptCmd.Parameters.AddWithValue("@ngaymuon", ngaymuon);
                insertBorrowingReceiptCmd.ExecuteNonQuery();

                // Thêm chi tiết mượn vào bảng borrowing_receipt_details
                foreach (DataGridViewRow row in dGV_qlmuonsach.Rows)
                {
                    if (row.Cells["book_id"].Value != null && row.Cells["quantity"].Value != null)
                    {
                        string masach = row.Cells["book_id"].Value.ToString();
                        int soluong = int.Parse(row.Cells["quantity"].Value.ToString());

                        string insertBorrowingDetailsQuery = "INSERT INTO borrowing_receipt_details (borrowing_receipt_id, book_id, quantity) VALUES (@mamuon, @masach, @soluong)";
                        MySqlCommand insertBorrowingDetailsCmd = new MySqlCommand(insertBorrowingDetailsQuery, connection);
                        insertBorrowingDetailsCmd.Parameters.AddWithValue("@mamuon", mamuon);
                        insertBorrowingDetailsCmd.Parameters.AddWithValue("@masach", masach);
                        insertBorrowingDetailsCmd.Parameters.AddWithValue("@soluong", soluong);
                        insertBorrowingDetailsCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm đơn mượn thành công");
            }
            else
            {
                MessageBox.Show("Mã mượn đã tồn tại! Vui lòng kiểm tra lại!");
            }

            // Cập nhật lại DataGridView
            LoadDataIntoDgvQuanLyMuonSach();
            connection.Close();
        }

        private void vbButton15_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string mamuon = text_mamuon.Text;

            // Kiểm tra xem mã mượn có tồn tại hay không
            string queryp = "SELECT COUNT(*) FROM borrowing_receipt WHERE borrowing_receipt_id = @mamuon";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@mamuon", mamuon);
            int borrowingExists = Convert.ToInt32(cmdp.ExecuteScalar());

            if (borrowingExists > 0)
            {
                // Xóa các chi tiết hóa đơn mượn sách trong bảng borrowing_receipt_details trước
                string deleteDetailsQuery = "DELETE FROM borrowing_receipt_details WHERE borrowing_receipt_id = @mamuon";
                MySqlCommand deleteDetailsCmd = new MySqlCommand(deleteDetailsQuery, connection);
                deleteDetailsCmd.Parameters.AddWithValue("@mamuon", mamuon);
                deleteDetailsCmd.ExecuteNonQuery();

                // Xóa bản ghi trong bảng borrowing_receipt
                string deleteBorrowingQuery = "DELETE FROM borrowing_receipt WHERE borrowing_receipt_id = @mamuon";
                MySqlCommand deleteBorrowingCmd = new MySqlCommand(deleteBorrowingQuery, connection);
                deleteBorrowingCmd.Parameters.AddWithValue("@mamuon", mamuon);
                deleteBorrowingCmd.ExecuteNonQuery();

                MessageBox.Show("Đã xóa hóa đơn mượn sách");
            }
            else
            {
                MessageBox.Show("Mã mượn không tồn tại trong kho mượn! Không thể xóa");
            }

            // Cập nhật lại DataGridView
            LoadDataIntoDgvQuanLyMuonSach();
            connection.Close();
        }


        private void vbButton14_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string mamuonsach = text_mamuon.Text;
            string masach = tex_idsach.Text;
            string madocgia = tex_madocgia.Text;
            string queryp = "SELECT * FROM borrowing_receipt";

            List<string> conditions = new List<string>();
            if (!string.IsNullOrEmpty(mamuonsach))
            {
                conditions.Add("borrowing_receipt_id = @mamuonsach");
            }
            if (!string.IsNullOrEmpty(masach))
            {
                conditions.Add("borrowing_receipt_id IN (SELECT borrowing_receipt_id FROM borrowing_receipt_details WHERE book_id = @masach)");
            }
            if (!string.IsNullOrEmpty(madocgia))
            {
                conditions.Add("reader_id = @madocgia");
            }

            if (conditions.Count > 0)
            {
                queryp += " WHERE " + string.Join(" AND ", conditions);
            }

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);

            if (!string.IsNullOrEmpty(mamuonsach))
            {
                cmdp.Parameters.AddWithValue("@mamuonsach", mamuonsach);
            }
            if (!string.IsNullOrEmpty(masach))
            {
                cmdp.Parameters.AddWithValue("@masach", masach);
            }
            if (!string.IsNullOrEmpty(madocgia))
            {
                cmdp.Parameters.AddWithValue("@madocgia", madocgia);
            }

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            dGV_qlmuonsach.DataSource = dataTablep;

            connection.Close();
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void vbButton13_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string mamuon = text_mamuon.Text;

            string queryp = "SELECT * FROM borrowing_receipt WHERE borrowing_receipt_id = @mamuon";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@mamuon", mamuon);

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount = dataTablep.Rows.Count;

            if (rowCount > 0)
            {
                Quanlysach.SelectedIndex = 5; // Chuyển sang tab chứa thông tin hóa đơn mượn sách
                dGV_qlmuonsach.DataSource = dataTablep; // Hiển thị thông tin hóa đơn mượn sách trong DataGridView
            }
            else
            {
                MessageBox.Show("Không tồn tại mã nhập sách");
            }

            connection.Close();
        }


        private void vbB_caphatmuon_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string mamuon = text_mamuon.Text;
            string masachmoi = tex_masachmuon.Text;
            string madocgiamoi = tex_iddocgia.Text;

            string updatenhapsach = "UPDATE `bill mượn` SET `Mã sách` = @masachmoi WHERE `Mã mượn` = @mamuon;";
            MySqlCommand updategioCmd = new MySqlCommand(updatenhapsach, connection);
            updategioCmd.Parameters.AddWithValue("@masachmoi", masachmoi);
            updategioCmd.Parameters.AddWithValue("@mamuon", mamuon); // Thay 'ten_nguoidung' bằng tên người dùng
            updategioCmd.ExecuteNonQuery();

            string updatenhapsach1 = "UPDATE `bill mượn` SET `Mã độc giả` = @madocgiamoi WHERE `Mã mượn` = @mamuon;";
            MySqlCommand updategioCmd1 = new MySqlCommand(updatenhapsach1, connection);
            updategioCmd1.Parameters.AddWithValue("@madocgiamoi", madocgiamoi);
            updategioCmd1.Parameters.AddWithValue("@mamuon", mamuon); // Thay 'ten_nguoidung' bằng tên người dùng
            updategioCmd1.ExecuteNonQuery();
            LoadDataIntoDgvQuanLyMuonSach();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void vbButton12_Click_1(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string masach = tex_masach1.Text;
            string tensachmoi = tex_suatensach.Text;
            string tacgiamoi = tex_suatacgia.Text;
            string theloaimoi = tex_suatheloai.Text;

            string updatenhapsach = "UPDATE `table books` SET `Tên sách` = @tensachmoi WHERE `Mã sách` = @masach;";
            MySqlCommand updategioCmd = new MySqlCommand(updatenhapsach, connection);
            updategioCmd.Parameters.AddWithValue("@tensachmoi", tensachmoi);
            updategioCmd.Parameters.AddWithValue("@masach", masach); // Thay 'ten_nguoidung' bằng tên người dùng
            updategioCmd.ExecuteNonQuery();

            string updatenhapsach1 = "UPDATE `table books` SET `Tên tác giả` = @tacgiamoi WHERE `Mã sách` = @masach;";
            MySqlCommand updategioCmd1 = new MySqlCommand(updatenhapsach1, connection);
            updategioCmd1.Parameters.AddWithValue("@masach", masach);
            updategioCmd1.Parameters.AddWithValue("@tacgiamoi", tacgiamoi); // Thay 'ten_nguoidung' bằng tên người dùng
            updategioCmd1.ExecuteNonQuery();

            string updatenhapsach2 = "UPDATE `table books` SET `Thể loại` = @theloaimoi WHERE `Mã sách` = @masach;";
            MySqlCommand updategioCmd2 = new MySqlCommand(updatenhapsach2, connection);
            updategioCmd2.Parameters.AddWithValue("@masach", masach);
            updategioCmd2.Parameters.AddWithValue("@theloaimoi", theloaimoi); // Thay 'ten_nguoidung' bằng tên người dùng
            updategioCmd2.ExecuteNonQuery();

            LoadDataIntoDgvQuanLySach();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void vbButton5_Click_1(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string queryp = "SELECT * FROM cardreader";

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdp);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Thong_ke_the_ban_doc.pdf";
                sfd.Title = "Thống kê thẻ bạn đọc";
                sfd.InitialDirectory = @"C:\File_pdf_oop";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Tạo bảng với số cột tương ứng với số cột trong DataTable
                    Table table = new Table(dataTable.Columns.Count);

                    // Thêm header cho bảng
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Thêm dữ liệu từ DataTable vào bảng
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (object value in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(value.ToString())));
                        }
                    }

                    // Thêm bảng vào tài liệu PDF
                    document.Add(table);
                    document.Close();
                    writer.Close();

                    MessageBox.Show("Đã xuất file báo cáo thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.");
            }
        }


        private void vbButton16_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = "Danh sách lọc sách.pdf";
            sfd.Title = "Danh sách các sách theo" + tex_theloai1.Text + " " + tex_tacgia1.Text + " " + tex_tensach1.Text;
            sfd.InitialDirectory = @"C:\File_pdf_oop";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PdfWriter writer = new PdfWriter(sfd.FileName);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                //dGV_qlsach.AutoResizeColumns();
                // Tạo bảng iTextSharp
                Table table = new Table(dGV_qlsach.Columns.Count);

                // Thêm header cho bảng từ DataGridView
                foreach (DataGridViewColumn column in dGV_qlsach.Columns)
                {
                    table.AddHeaderCell(new Cell().Add(new Paragraph(column.HeaderText)));
                }

                // Thêm dữ liệu từ DataGridView vào bảng
                foreach (DataGridViewRow row in dGV_qlsach.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || cell.Value == DBNull.Value)
                        {
                            cell.Value = "Unknown";
                        }
                        else
                        {
                            table.AddCell(new Cell().Add(new Paragraph(cell.Value.ToString())));
                        }
                    }
                }


                document.Add(table); // Thêm bảng vào tài liệu PDF

                document.Close();
                writer.Close();

                MessageBox.Show("File PDF đã được xuất thành công!");
            }
        }

        private void vbButton17_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            // Tạo truy vấn để chọn các thẻ bạn đọc có ngày sinh sau ngày 24/11/2003
            string queryp = "SELECT * FROM cardreader WHERE cardreader_dob > '2003-11-24'";

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdp);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "the_ban_doc_duoi_18_tuoi.pdf";
                sfd.Title = "Thẻ bạn đọc dưới 18 tuổi";
                sfd.InitialDirectory = @"C:\File_pdf_oop";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Tạo bảng với số cột tương ứng với số cột trong DataTable
                    Table table = new Table(dataTable.Columns.Count);

                    // Thêm header cho bảng
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Thêm dữ liệu từ DataTable vào bảng
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (object value in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(value.ToString())));
                        }
                    }

                    // Thêm bảng vào tài liệu PDF
                    document.Add(table);
                    document.Close();
                    writer.Close();

                    MessageBox.Show("Đã xuất file báo cáo thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.");
            }

            connection.Close();
        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void vbButton18_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string nam = tex_nam.Text;
            string queryp = "SELECT * FROM borrowing_receipt WHERE YEAR(borrowing_receipt_dob) > @nam";

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@nam", nam);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdp);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            connection.Close();

            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "don_muon_sach.pdf";
                sfd.Title = "Đơn mượn sách";
                sfd.InitialDirectory = @"C:\File_pdf_oop";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Tạo bảng với số cột tương ứng với số cột trong DataTable
                    Table table = new Table(dataTable.Columns.Count);

                    // Thêm header cho bảng
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Thêm dữ liệu từ DataTable vào bảng
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (object value in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(value.ToString())));
                        }
                    }

                    // Thêm bảng vào tài liệu PDF
                    document.Add(table);
                    document.Close();
                    writer.Close();

                    MessageBox.Show("Đã xuất file báo cáo thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.");
            }
        }


        private void text_mamuon_TextChanged(object sender, EventArgs e)
        {

        }

        private void vbButton19_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string nam = tex_nam1.Text;
            string queryp = "SELECT * FROM receipt WHERE YEAR(receipt_dob) > @nam";

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@nam", nam);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdp);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            connection.Close();

            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "thong_ke_nhap_sach.pdf";
                sfd.Title = "Thống kê nhập sách";
                sfd.InitialDirectory = @"C:\File_pdf_oop";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Tạo bảng với số cột tương ứng với số cột trong DataTable
                    Table table = new Table(dataTable.Columns.Count);

                    // Thêm header cho bảng
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Thêm dữ liệu từ DataTable vào bảng
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (object value in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(value.ToString())));
                        }
                    }

                    // Thêm bảng vào tài liệu PDF
                    document.Add(table);
                    document.Close();
                    writer.Close();

                    MessageBox.Show("Đã xuất file báo cáo thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.");
            }
        }


        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void vbButton20_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string diemlon = tex_diemlon.Text;
            string queryp = "SELECT * FROM evaluate WHERE evaluate_score > @diemlon";

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@diemlon", diemlon);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdp);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            connection.Close();

            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "thong_ke_danh_gia_diem_lon_hon.pdf";
                sfd.Title = "Thống kê đánh giá điểm lớn hơn";
                sfd.InitialDirectory = @"C:\File_pdf_oop";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Tạo bảng với số cột tương ứng với số cột trong DataTable
                    Table table = new Table(dataTable.Columns.Count);

                    // Thêm header cho bảng
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Thêm dữ liệu từ DataTable vào bảng
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (object value in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(value.ToString())));
                        }
                    }

                    // Thêm bảng vào tài liệu PDF
                    document.Add(table);
                    document.Close();
                    writer.Close();

                    MessageBox.Show("Đã xuất file báo cáo thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.");
            }
        }


        private void vbButton21_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string diembang = tex_diembang.Text;
            string queryp = "SELECT * FROM evaluate WHERE evaluate_dob = @diembang";

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@diembang", diembang);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdp);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            connection.Close();

            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "thong_ke_danh_gia_diem_bang.pdf";
                sfd.Title = "Thống kê đánh giá điểm bằng";
                sfd.InitialDirectory = @"C:\File_pdf_oop";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Tạo bảng với số cột tương ứng với số cột trong DataTable
                    Table table = new Table(dataTable.Columns.Count);

                    // Thêm header cho bảng
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Thêm dữ liệu từ DataTable vào bảng
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (object value in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(value.ToString())));
                        }
                    }

                    // Thêm bảng vào tài liệu PDF
                    document.Add(table);
                    document.Close();
                    writer.Close();

                    MessageBox.Show("Đã xuất file báo cáo thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Quanlysach.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Quanlysach.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Quanlysach.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Quanlysach.SelectedIndex = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Quanlysach.SelectedIndex = 7;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tex_diembang_TextChanged(object sender, EventArgs e)
        {

        }

        private void vbB_loaddiembang_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string diembang = tex_diembang.Text;

            if (!string.IsNullOrEmpty(diembang))
            {
                string queryp = "SELECT * FROM evaluate WHERE rating = @diembang";
                MySqlCommand cmdp = new MySqlCommand(queryp, connection);
                cmdp.Parameters.AddWithValue("@diembang", diembang);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdp);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dGV_Danhgia.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập điểm đánh giá để tìm kiếm.");
            }

            connection.Close();
        }


        private void vbB_loaddiemlon_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string diemlon = tex_diemlon.Text;
            string queryp = "SELECT * FROM evaluate WHERE evaluate_dob > @diemlon";

            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@diemlon", diemlon);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdp);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            connection.Close();

            if (dataTable.Rows.Count > 0)
            {
                dGV_Danhgia.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
        }


        private void vbButton22_Click(object sender, EventArgs e)
        {
            LoadDataIntoDgvQuanLySach();
        }
    }
}
