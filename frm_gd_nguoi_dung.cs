using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace PROJECT_CK_20231
{
    public partial class Form_gduser : Form
    {
        private string ID_Account;
        private float previousWidth;
        private float previousHeight;

        public Form_gduser(string ID_user)
        {
            InitializeComponent();
            this.AcceptButton = but_Timkiemsach;
            previousWidth = this.Width;
            previousHeight = this.Height;
            this.SizeChanged += Form_gduser_SizeChanged;
            this.ID_Account = ID_user;
        }

        private void Form_gduser_SizeChanged(object sender, EventArgs e)
        {
            float widthChangeRatio = (float)this.Width / previousWidth;
            float heightChangeRatio = (float)this.Height / previousHeight;
            ScaleControls(widthChangeRatio, heightChangeRatio);
            previousWidth = this.Width;
            previousHeight = this.Height;
        }

        private void ScaleControls(float widthChangeRatio, float heightChangeRatio)
        {
            foreach (Control control in this.Controls)
            {
                control.Left = (int)(control.Left * widthChangeRatio);
                control.Top = (int)(control.Top * heightChangeRatio);
                control.Width = (int)(control.Width * widthChangeRatio);
                control.Height = (int)(control.Height * heightChangeRatio);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tab_Trangchu.SelectedIndex = 2;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hàm rỗng
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void Themsach(System.Windows.Forms.PictureBox picBox2, System.Windows.Forms.TextBox textbox5, System.Windows.Forms.TextBox textbox6, System.Windows.Forms.TextBox textbox9)
        {
            picBox2.Image = pictureBoxBiaSach.Image;
            textbox5.Text = textBoxTenSach.Text;
            textbox6.Text = "Tác giả: " + textBoxTacGia.Text;
            textbox9.Text = tex_UID.Text;
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            if (textBoxTenSach.Text != "Tên sách")
            {
                MySqlConnection connection = tao_connetion();
                connection.Open();

                string queryp = "SELECT * FROM cart WHERE reader_id = @ID_Account";
                MySqlCommand cmdp = new MySqlCommand(queryp, connection);
                cmdp.Parameters.AddWithValue("@ID_Account", ID_Account);

                MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
                DataTable dataTablep = new DataTable();
                adapterp.Fill(dataTablep);
                int rowCount1 = dataTablep.Rows.Count;

                if (rowCount1 > 7)
                {
                    MessageBox.Show("Giỏ sách đã đầy!!!");
                }
                if (rowCount1 == 0)
                {
                    Themsach(pic_1, tex_Ten1, tex_T1, UID1);
                    MessageBox.Show("Đã thêm vào giỏ sách!!!");
                }
                if (rowCount1 == 1)
                {
                    Themsach(pic_2, tex_Ten2, tex_T2, UID2);
                    MessageBox.Show("Đã thêm vào giỏ sách!!!");
                }
                if (rowCount1 == 2)
                {
                    Themsach(pic_3, tex_Ten3, tex_T3, UID3);
                    MessageBox.Show("Đã thêm vào giỏ sách!!!");
                }
                if (rowCount1 == 3)
                {
                    Themsach(pic_4, tex_Ten4, tex_T4, UID4);
                    MessageBox.Show("Đã thêm vào giỏ sách!!!");
                }
                if (rowCount1 == 4)
                {
                    Themsach(pic_5, tex_Ten5, tex_T5, UID5);
                    MessageBox.Show("Đã thêm vào giỏ sách!!!");
                }
                if (rowCount1 == 5)
                {
                    Themsach(pic_6, tex_Ten6, tex_T6, UID6);
                    MessageBox.Show("Đã thêm vào giỏ sách!!!");
                }
                if (rowCount1 == 6)
                {
                    Themsach(pic_7, tex_Ten7, tex_T7, UID7);
                    MessageBox.Show("Đã thêm vào giỏ sách!!!");
                }
                if (rowCount1 == 7)
                {
                    Themsach(pic_8, tex_Ten8, tex_T8, UID8);
                    MessageBox.Show("Đã thêm vào giỏ sách!!!");
                }

                string UID = textBoxBookId.Text;

                string insertQuery = "INSERT INTO cart (reader_id, book_id) VALUES (@ID_Account, @UID)";
                MySqlCommand insertQuerycmd = new MySqlCommand(insertQuery, connection);
                insertQuerycmd.Parameters.AddWithValue("@ID_Account", ID_Account);
                insertQuerycmd.Parameters.AddWithValue("@UID", UID);
                insertQuerycmd.ExecuteNonQuery();
            }
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Hàm rỗng
        }

        private void but_Trangchu_Click(object sender, EventArgs e)
        {
            tab_Trangchu.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tab_Trangchu.SelectedIndex = 1;
        }

        private void lienhe_Click(object sender, EventArgs e)
        {
            tab_Trangchu.SelectedIndex = 0;
        }

        private void but_Lienhe_Click(object sender, EventArgs e)
        {
            tab_Trangchu.SelectedIndex = 3;
        }

        private void but_Muonsach_Click(object sender, EventArgs e)
        {
            tab_Danhmuc.SelectedIndex = 0;
        }

        private void but_Tusach_Click(object sender, EventArgs e)
        {
            tab_Danhmuc.SelectedIndex = 1;
        }

        private void but_Lichsu_Click(object sender, EventArgs e)
        {
            tab_Danhmuc.SelectedIndex = 2;
        }

        private void but_Thebandoc_Click(object sender, EventArgs e)
        {
            tab_Danhmuc.SelectedIndex = 3;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void button_Name_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void vbButton4_Click(object sender, EventArgs e)
        {
            Form_Thongtinnguoidung Thongtin = new Form_Thongtinnguoidung(ID_Account);
            Thongtin.ShowDialog();
        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            Form_Thongtinnguoidung Thongtin = new Form_Thongtinnguoidung(ID_Account);
            Thongtin.ShowDialog();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_Timkiemsach_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_Thongtinsach1_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private string GetRandomImageUrl()
        {
            int width = 800;
            int height = 600;
            return $"https://picsum.photos/{width}/{height}/?random";
        }

        private void but_Timkiemsach_Click(object sender, EventArgs e)
        {
            tex_Thongtinsach1.Text = "";
            tex_Thongtinsach2.Text = "";
            tex_Thongtinsach3.Text = "";
            tex_Thongtinsach4.Text = "";

            string searchText = tex_Timkiemsach.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                MySqlConnection connection = tao_connetion();
                connection.Open();

                string query = "SELECT * FROM book WHERE book_name LIKE @searchText";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                int rowCount = dataTable.Rows.Count;
                if (rowCount > 3)
                {
                    DataRow row1 = dataTable.Rows[0];
                    DataRow row2 = dataTable.Rows[1];
                    DataRow row3 = dataTable.Rows[2];
                    DataRow row4 = dataTable.Rows[3];
                    tex_Thongtinsach1.Text = row1["book_name"].ToString();
                    tex_Thongtinsach1.AppendText(Environment.NewLine + row1["book_category"] + " - " + row1["publish_year"]);
                    tex_Thongtinsach2.Text = row2["book_name"].ToString();
                    tex_Thongtinsach2.AppendText(Environment.NewLine + row2["book_category"] + " - " + row2["publish_year"]);
                    tex_Thongtinsach3.Text = row3["book_name"].ToString();
                    tex_Thongtinsach3.AppendText(Environment.NewLine + row3["book_category"] + " - " + row3["publish_year"]);
                    tex_Thongtinsach4.Text = row4["book_name"].ToString();
                    tex_Thongtinsach4.AppendText(Environment.NewLine + row4["book_category"] + " - " + row4["publish_year"]);
                }
                if (rowCount == 3)
                {
                    DataRow row1 = dataTable.Rows[0];
                    DataRow row2 = dataTable.Rows[1];
                    DataRow row3 = dataTable.Rows[2];
                    tex_Thongtinsach1.Text = row1["book_name"].ToString();
                    tex_Thongtinsach1.AppendText(Environment.NewLine + row1["book_category"] + " - " + row1["publish_year"]);
                    tex_Thongtinsach2.Text = row2["book_name"].ToString();
                    tex_Thongtinsach2.AppendText(Environment.NewLine + row2["book_category"] + " - " + row2["publish_year"]);
                    tex_Thongtinsach3.Text = row3["book_name"].ToString();
                    tex_Thongtinsach3.AppendText(Environment.NewLine + row3["book_category"] + " - " + row3["publish_year"]);
                }
                if (rowCount == 2)
                {
                    DataRow row1 = dataTable.Rows[0];
                    DataRow row2 = dataTable.Rows[1];
                    tex_Thongtinsach1.Text = row1["book_name"].ToString();
                    tex_Thongtinsach1.AppendText(Environment.NewLine + row1["book_category"] + " - " + row1["publish_year"]);
                    tex_Thongtinsach2.Text = row2["book_name"].ToString();
                    tex_Thongtinsach2.AppendText(Environment.NewLine + row2["book_category"] + " - " + row2["publish_year"]);
                }
                if (rowCount == 1)
                {
                    DataRow row1 = dataTable.Rows[0];
                    tex_Thongtinsach1.Text = row1["book_name"].ToString();
                    tex_Thongtinsach1.AppendText(Environment.NewLine + row1["book_category"] + " - " + row1["publish_year"]);
                }

                tex_KQ_Timkiemsach2.Text = tex_Timkiemsach.Text;
            }
        }

        private void tex_Thongtinsach1_Click(object sender, EventArgs e)
        {
            but_Chitietsach1.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string searchText = tex_Timkiemsach.Text.Trim(); // Lấy dữ liệu từ TextBox tìm kiếm
            if (!string.IsNullOrEmpty(searchText))
            {
                MySqlConnection connection = tao_connetion();
                connection.Open();

                string query = "SELECT * FROM book WHERE book_name LIKE @searchText";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0]; // Lấy dòng đầu tiên của kết quả tìm kiếm

                    // Cập nhật các TextBox trong panel pan_Chitietsach
                    textBoxBookId.Text = row["book_id"].ToString();
                    textBoxTenSach.Text = row["book_name"].ToString();
                    textBoxTacGia.Text = row["publisher"].ToString();
                    textBoxTheLoai.Text = row["book_category"].ToString();
                    textBoxNamXuatBan.Text = row["publish_year"].ToString();
                    textBoxNoiDungChinh.Text = "Tác giả có phong cách viết riêng, cách sử dụng ngôn từ tinh tế và sáng tạo. Lối hành văn cần phải lưu loát, dễ hiểu nhưng vẫn đầy chất văn học. Ngoài ra quyển sách còn cung cấp những tri thức mới, góc nhìn mới hoặc những bài học quý giá giúp người đọc mở mang trí tuệ và tư duy. Nó sẽ làm cho người đọc suy ngẫm và thậm chí đặt ra những câu hỏi về chính mình và thế giới xung quanh."; // Thêm thông tin nếu cần

                    // Hiển thị hình ảnh trong PictureBox
                    try
                    {
                        string imageUrl = row["link_url"].ToString();
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            WebClient webClient = new WebClient();
                            byte[] imageData = webClient.DownloadData(imageUrl);
                            using (MemoryStream stream = new MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(stream);
                                pictureBoxBiaSach.Image = image;
                                pictureBoxBiaSach.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo hình ảnh được hiển thị đầy đủ
                            }
                        }
                        else
                        {
                            MessageBox.Show("URL hình ảnh không tồn tại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách nào với tên đã nhập.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên sách để tìm kiếm.");
            }
        }

        private void AssignValues(System.Windows.Forms.PictureBox picBox, System.Windows.Forms.TextBox textbox1, System.Windows.Forms.TextBox textbox2, System.Windows.Forms.TextBox textbox3, int n)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string imageURL = GetRandomImageUrl();
            WebClient webClient = new WebClient();
            byte[] data = webClient.DownloadData(imageURL);

            using (var stream = new System.IO.MemoryStream(data))
            {
                Image image_book = Image.FromStream(stream);
                picBox.Image = image_book;
            }

            string query1 = "SELECT * FROM borrowing_receipt_details WHERE borrowing_receipt_id = (SELECT borrowing_receipt_id FROM borrowing_receipt WHERE reader_id = @ID_Account) LIMIT @n, 1";
            MySqlCommand cmd1 = new MySqlCommand(query1, connection);
            cmd1.Parameters.AddWithValue("@ID_Account", ID_Account);
            cmd1.Parameters.AddWithValue("@n", n);

            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            DataTable dataTable1 = new DataTable();
            adapter1.Fill(dataTable1);
            DataRow row = dataTable1.Rows[0];

            textbox3.Text = "Mã mượn sách: " + row["borrowing_receipt_id"].ToString();
            textbox3.AppendText(Environment.NewLine + "ID: sách: " + row["book_id"].ToString());
            textbox3.AppendText(Environment.NewLine + "Số lượng: " + row["quantity"].ToString());

            string str_bookid = row["book_id"].ToString();

            string query2 = "SELECT * FROM book WHERE book_id = @str_bookid";
            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
            cmd2.Parameters.AddWithValue("@str_bookid", str_bookid);

            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);
            DataRow row2 = dataTable2.Rows[0];

            textbox1.Text = row2["book_name"].ToString();
            textbox2.Text = "Tác giả: " + row2["publisher"].ToString();
        }

        private void AssignValuesgiohang(System.Windows.Forms.PictureBox picBox1, System.Windows.Forms.TextBox textbox3, System.Windows.Forms.TextBox textbox4, System.Windows.Forms.TextBox textbox5, int k)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();
            string imageURL = GetRandomImageUrl();
            WebClient webClient = new WebClient();
            byte[] data = webClient.DownloadData(imageURL);

            using (var stream = new System.IO.MemoryStream(data))
            {
                Image image_book = Image.FromStream(stream);
                picBox1.Image = image_book;
            }

            string queryq = "SELECT * FROM cart WHERE reader_id = @ID_Account LIMIT @k, 1";
            MySqlCommand cmdq = new MySqlCommand(queryq, connection);
            cmdq.Parameters.AddWithValue("@ID_Account", ID_Account);
            cmdq.Parameters.AddWithValue("@k", k);

            MySqlDataAdapter adapterq = new MySqlDataAdapter(cmdq);
            DataTable dataTableq = new DataTable();
            adapterq.Fill(dataTableq);
            DataRow row3 = dataTableq.Rows[0];
            string str_bookid1 = row3["book_id"].ToString();

            string query3 = "SELECT * FROM book WHERE book_id = @str_bookid1";
            MySqlCommand cmd3 = new MySqlCommand(query3, connection);
            cmd3.Parameters.AddWithValue("@str_bookid1", str_bookid1);

            MySqlDataAdapter adapter3 = new MySqlDataAdapter(cmd3);
            DataTable dataTable4 = new DataTable();
            adapter3.Fill(dataTable4);
            DataRow row4 = dataTable4.Rows[0];

            textbox3.Text = row4["book_name"].ToString();
            textbox4.Text = "Tác giả: " + row4["publisher"].ToString();
            textbox5.Text = row4["book_id"].ToString();
        }

        private void pic_Sachtimkiem_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private string str1;
        private string str2;
        private void Form_gduser_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string query = "SELECT * FROM user WHERE user_id = @ID_Account";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID_Account", ID_Account);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataRow row = dataTable.Rows[0];

            vbB_NameUser.Text = row["user_name"].ToString();

            string queryCard = "SELECT * FROM cardreader WHERE user_id = @ID_Account";
            MySqlCommand cmdCard = new MySqlCommand(queryCard, connection);
            cmdCard.Parameters.AddWithValue("@ID_Account", ID_Account);

            MySqlDataAdapter adapterCard = new MySqlDataAdapter(cmdCard);
            DataTable dataTableCard = new DataTable();
            adapterCard.Fill(dataTableCard);
            if (dataTableCard.Rows.Count > 0)
            {
                DataRow cardRow = dataTableCard.Rows[0];
                tex_Tenthe.AppendText(" " + row["user_name"].ToString());
                tex_Ngaysinhthe.AppendText(" " + cardRow["cardreader_dob"].ToString());
                tex_Gioitinhthe.AppendText(" " + row["user_sex"].ToString());
                tex_Diachithe.AppendText(" " + row["user_address"].ToString());
                tex_Mathe.AppendText(" " + row["user_id"].ToString());
            }
            else
            {
                tex_Chuacothe.Text = "Bạn chưa có thẻ bạn đọc. Vui lòng đăng kí!!!";
            }

            string queryk = "SELECT * FROM borrowing_receipt_details WHERE borrowing_receipt_id IN (SELECT borrowing_receipt_id FROM borrowing_receipt WHERE reader_id = @ID_Account)";
            MySqlCommand cmdk = new MySqlCommand(queryk, connection);
            cmdk.Parameters.AddWithValue("@ID_Account", ID_Account);

            MySqlDataAdapter adapterk = new MySqlDataAdapter(cmdk);
            DataTable dataTablek = new DataTable();
            adapterk.Fill(dataTablek);
            int rowCount = dataTablek.Rows.Count;

            if (rowCount == 0)
            {
                tex_DL1.Text = "Bạn đọc chưa mượn sách ở thư viện";
            }
            if (rowCount == 1)
            {
                AssignValues(pic_ls1, tex_Tenls1, tex_TG1, tex_DL1, 0);
            }
            if (rowCount == 2)
            {
                AssignValues(pic_ls1, tex_Tenls1, tex_TG1, tex_DL1, 0);
                AssignValues(pic_ls2, tex_Tenls2, tex_TG2, tex_DL2, 1);
            }
            if (rowCount >= 3)
            {
                AssignValues(pic_ls1, tex_Tenls1, tex_TG1, tex_DL1, 0);
                AssignValues(pic_ls2, tex_Tenls2, tex_TG2, tex_DL2, 1);
                AssignValues(pic_ls3, tex_Tenls3, tex_TG3, tex_DL3, 2);
            }

            string queryp = "SELECT * FROM cart WHERE reader_id = @ID_Account";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@ID_Account", ID_Account);

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount1 = dataTablep.Rows.Count;

            if (rowCount1 == 0)
            {
                tex_TB.Text = "Không có quyển sách nào trong giỏ hàng!!!";
            }
            if (rowCount1 == 1)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
            }
            if (rowCount1 == 2)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
            }
            if (rowCount1 == 3)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
            }
            if (rowCount1 == 4)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
            }
            if (rowCount1 == 5)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
            }
            if (rowCount1 == 6)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
            }
            if (rowCount1 == 7)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
                AssignValuesgiohang(pic_7, tex_Ten7, tex_T7, UID7, 6);
            }
            if (rowCount1 == 8)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
                AssignValuesgiohang(pic_7, tex_Ten7, tex_T7, UID7, 6);
                AssignValuesgiohang(pic_8, tex_Ten8, tex_T8, UID8, 7);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void pan_Chitietsach_Paint(object sender, PaintEventArgs e)
        {
            // Hàm rỗng
        }

        private void pic_Muonsach_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void but_Chitietsach3_Click(object sender, EventArgs e)
        {
            string searchText = tex_Timkiemsach.Text.Trim(); // Lấy dữ liệu từ TextBox tìm kiếm
            if (!string.IsNullOrEmpty(searchText))
            {
                MySqlConnection connection = tao_connetion();
                connection.Open();

                string query = "SELECT * FROM book WHERE book_name LIKE @searchText";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0]; // Lấy dòng đầu tiên của kết quả tìm kiếm

                    // Cập nhật các TextBox trong panel pan_Chitietsach
                    textBoxBookId.Text = row["book_id"].ToString();
                    textBoxTenSach.Text = row["book_name"].ToString();
                    textBoxTacGia.Text = row["publisher"].ToString();
                    textBoxTheLoai.Text = row["book_category"].ToString();
                    textBoxNamXuatBan.Text = row["publish_year"].ToString();
                    textBoxNoiDungChinh.Text = "Tác giả có phong cách viết riêng, cách sử dụng ngôn từ tinh tế và sáng tạo. Lối hành văn cần phải lưu loát, dễ hiểu nhưng vẫn đầy chất văn học. Ngoài ra quyển sách còn cung cấp những tri thức mới, góc nhìn mới hoặc những bài học quý giá giúp người đọc mở mang trí tuệ và tư duy. Nó sẽ làm cho người đọc suy ngẫm và thậm chí đặt ra những câu hỏi về chính mình và thế giới xung quanh."; // Thêm thông tin nếu cần

                    // Hiển thị hình ảnh trong PictureBox
                    try
                    {
                        string imageUrl = row["link_url"].ToString();
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            WebClient webClient = new WebClient();
                            byte[] imageData = webClient.DownloadData(imageUrl);
                            using (MemoryStream stream = new MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(stream);
                                pictureBoxBiaSach.Image = image;
                                pictureBoxBiaSach.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo hình ảnh được hiển thị đầy đủ
                            }
                        }
                        else
                        {
                            MessageBox.Show("URL hình ảnh không tồn tại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách nào với tên đã nhập.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên sách để tìm kiếm.");
            }
        }

        private void but_Chitietsach2_Click(object sender, EventArgs e)
        {
            string searchText = tex_Timkiemsach.Text.Trim(); // Lấy dữ liệu từ TextBox tìm kiếm
            if (!string.IsNullOrEmpty(searchText))
            {
                MySqlConnection connection = tao_connetion();
                connection.Open();

                string query = "SELECT * FROM book WHERE book_name LIKE @searchText";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0]; // Lấy dòng đầu tiên của kết quả tìm kiếm

                    // Cập nhật các TextBox trong panel pan_Chitietsach
                    textBoxBookId.Text = row["book_id"].ToString();
                    textBoxTenSach.Text = row["book_name"].ToString();
                    textBoxTacGia.Text = row["publisher"].ToString();
                    textBoxTheLoai.Text = row["book_category"].ToString();
                    textBoxNamXuatBan.Text = row["publish_year"].ToString();
                    textBoxNoiDungChinh.Text = "Tác giả có phong cách viết riêng, cách sử dụng ngôn từ tinh tế và sáng tạo. Lối hành văn cần phải lưu loát, dễ hiểu nhưng vẫn đầy chất văn học. Ngoài ra quyển sách còn cung cấp những tri thức mới, góc nhìn mới hoặc những bài học quý giá giúp người đọc mở mang trí tuệ và tư duy. Nó sẽ làm cho người đọc suy ngẫm và thậm chí đặt ra những câu hỏi về chính mình và thế giới xung quanh."; // Thêm thông tin nếu cần

                    // Hiển thị hình ảnh trong PictureBox
                    try
                    {
                        string imageUrl = row["link_url"].ToString();
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            WebClient webClient = new WebClient();
                            byte[] imageData = webClient.DownloadData(imageUrl);
                            using (MemoryStream stream = new MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(stream);
                                pictureBoxBiaSach.Image = image;
                                pictureBoxBiaSach.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo hình ảnh được hiển thị đầy đủ
                            }
                        }
                        else
                        {
                            MessageBox.Show("URL hình ảnh không tồn tại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách nào với tên đã nhập.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên sách để tìm kiếm.");
            }
        }
        private void but_Chitietsach4_Click(object sender, EventArgs e)
        {
            string searchText = tex_Timkiemsach.Text.Trim(); // Lấy dữ liệu từ TextBox tìm kiếm
            if (!string.IsNullOrEmpty(searchText))
            {
                MySqlConnection connection = tao_connetion();
                connection.Open();

                string query = "SELECT * FROM book WHERE book_name LIKE @searchText";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0]; // Lấy dòng đầu tiên của kết quả tìm kiếm

                    // Cập nhật các TextBox trong panel pan_Chitietsach
                    textBoxBookId.Text = row["book_id"].ToString();
                    textBoxTenSach.Text = row["book_name"].ToString();
                    textBoxTacGia.Text = row["publisher"].ToString();
                    textBoxTheLoai.Text = row["book_category"].ToString();
                    textBoxNamXuatBan.Text = row["publish_year"].ToString();
                    textBoxNoiDungChinh.Text = "Tác giả có phong cách viết riêng, cách sử dụng ngôn từ tinh tế và sáng tạo. Lối hành văn cần phải lưu loát, dễ hiểu nhưng vẫn đầy chất văn học. Ngoài ra quyển sách còn cung cấp những tri thức mới, góc nhìn mới hoặc những bài học quý giá giúp người đọc mở mang trí tuệ và tư duy. Nó sẽ làm cho người đọc suy ngẫm và thậm chí đặt ra những câu hỏi về chính mình và thế giới xung quanh."; // Thêm thông tin nếu cần

                    // Giả sử bạn có một cột chứa URL hình ảnh trong cơ sở dữ liệu
                    string imageUrl = row["link_url"].ToString();
                    WebClient webClient = new WebClient();
                    byte[] imageData = webClient.DownloadData(imageUrl);
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        pictureBoxBiaSach.Image = image;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách nào với tên đã nhập.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên sách để tìm kiếm.");
            }
        }

        private void tex_Diachithe_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void pan_Tieude_Paint(object sender, PaintEventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_Mathe_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_DL1_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_Tenthe_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void pic_1_Click(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_Ten1_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_Ten5_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void tex_Ten2_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            // Hàm rỗng
        }

        private void xoagiatri(System.Windows.Forms.PictureBox picBox3, System.Windows.Forms.TextBox textbox7, System.Windows.Forms.TextBox textbox8, System.Windows.Forms.TextBox textbox9)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string ID = textbox9.Text;
            string deletequery = "DELETE FROM cart WHERE book_id = @ID";
            MySqlCommand cmdp = new MySqlCommand(deletequery, connection);
            cmdp.Parameters.AddWithValue("@ID", ID);
            cmdp.ExecuteNonQuery();

            picBox3.Image = null;
            textbox7.Text = "";
            textbox8.Text = "";
        }

        private void xoa(System.Windows.Forms.PictureBox picBox0, System.Windows.Forms.TextBox textbox0, System.Windows.Forms.TextBox textbox1, System.Windows.Forms.TextBox textbox2)
        {
            picBox0.Image = null;
            textbox0.Text = "";
            textbox1.Text = "";
            textbox2.Text = "";
        }

        private void vbButton4_Click_1(object sender, EventArgs e)
        {
            if (check_1.Checked)
            {
                xoagiatri(pic_1, tex_Ten1, tex_T1, UID1);
                check_1.Checked = false;
            }
            if (check_2.Checked)
            {
                xoagiatri(pic_2, tex_Ten2, tex_T2, UID2);
                check_2.Checked = false;
            }
            if (check_3.Checked)
            {
                xoagiatri(pic_3, tex_Ten3, tex_T3, UID3);
                check_3.Checked = false;
            }
            if (check_4.Checked)
            {
                xoagiatri(pic_4, tex_Ten4, tex_T4, UID4);
                check_4.Checked = false;
            }
            if (check_5.Checked)
            {
                xoagiatri(pic_5, tex_Ten5, tex_T5, UID5);
                check_5.Checked = false;
            }
            if (check_6.Checked)
            {
                xoagiatri(pic_6, tex_Ten6, tex_T6, UID6);
                check_6.Checked = false;
            }
            if (check_7.Checked)
            {
                xoagiatri(pic_7, tex_Ten7, tex_T7, UID7);
                check_7.Checked = false;
            }
            if (check_8.Checked)
            {
                xoagiatri(pic_8, tex_Ten8, tex_T8, UID8);
                check_8.Checked = false;
            }

            xoa(pic_1, tex_Ten1, tex_T1, UID1);
            xoa(pic_2, tex_Ten2, tex_T2, UID2);
            xoa(pic_3, tex_Ten3, tex_T3, UID3);
            xoa(pic_4, tex_Ten4, tex_T4, UID4);
            xoa(pic_5, tex_Ten5, tex_T5, UID5);
            xoa(pic_6, tex_Ten6, tex_T6, UID6);
            xoa(pic_7, tex_Ten7, tex_T7, UID7);
            xoa(pic_8, tex_Ten8, tex_T8, UID8);

            MySqlConnection connection = tao_connetion();
            connection.Open();

            string queryp = "SELECT * FROM cart WHERE reader_id = @ID_Account";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@ID_Account", ID_Account);

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount1 = dataTablep.Rows.Count;

            if (rowCount1 == 0)
            {
                tex_TB.Text = "Không có quyển sách nào trong giỏ hàng!!!";
            }
            if (rowCount1 == 1)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
            }
            if (rowCount1 == 2)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
            }
            if (rowCount1 == 3)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
            }
            if (rowCount1 == 4)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
            }
            if (rowCount1 == 5)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
            }
            if (rowCount1 == 6)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
            }
            if (rowCount1 == 7)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
                AssignValuesgiohang(pic_7, tex_Ten7, tex_T7, UID7, 6);
            }
            if (rowCount1 == 8)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
                AssignValuesgiohang(pic_7, tex_Ten7, tex_T7, UID7, 6);
                AssignValuesgiohang(pic_8, tex_Ten8, tex_T8, UID8, 7);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Hàm rỗng
        }

        private void updateBill(string UID_book)
        {
            MySqlConnection connection = tao_connetion();
            connection.Open();

            // Kiểm tra xem có phiếu mượn nào chưa hoàn tất cho người dùng hiện tại
            string checkReceiptQuery = "SELECT borrowing_receipt_id FROM borrowing_receipt WHERE reader_id = @ID_Account AND staff_id IS NULL ORDER BY borrowing_receipt_dob DESC LIMIT 1";
            MySqlCommand checkReceiptCmd = new MySqlCommand(checkReceiptQuery, connection);
            checkReceiptCmd.Parameters.AddWithValue("@ID_Account", ID_Account);
            object receiptIdObj = checkReceiptCmd.ExecuteScalar();

            int receiptId;
            if (receiptIdObj != null)
            {
                receiptId = Convert.ToInt32(receiptIdObj);
            }
            else
            {
                // Nếu không có phiếu mượn nào, tạo phiếu mượn mới với ID ngẫu nhiên
                Random rnd = new Random();
                receiptId = rnd.Next(100000, 999999); // Tạo ID ngẫu nhiên từ 100000 đến 999999

                string insertReceiptQuery = "INSERT INTO borrowing_receipt (borrowing_receipt_id, reader_id, borrowing_receipt_dob) VALUES (@receiptId, @ID_Account, @currentTime)";
                MySqlCommand insertReceiptCmd = new MySqlCommand(insertReceiptQuery, connection);
                insertReceiptCmd.Parameters.AddWithValue("@receiptId", receiptId);
                insertReceiptCmd.Parameters.AddWithValue("@ID_Account", ID_Account);
                insertReceiptCmd.Parameters.AddWithValue("@currentTime", DateTime.Now);
                insertReceiptCmd.ExecuteNonQuery();
            }

            // Kiểm tra và chuyển đổi UID_book thành số nguyên
            int bookId;
            if (int.TryParse(UID_book, out bookId))
            {
                // Thêm chi tiết sách vào phiếu mượn
                string insertDetailQuery = "INSERT INTO borrowing_receipt_details (borrowing_receipt_id, book_id, quantity) VALUES (@receiptId, @bookId, 1)";
                MySqlCommand insertDetailCmd = new MySqlCommand(insertDetailQuery, connection);
                insertDetailCmd.Parameters.AddWithValue("@receiptId", receiptId);
                insertDetailCmd.Parameters.AddWithValue("@bookId", bookId);
                insertDetailCmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Error: book_id is not a valid integer.");
            }

            connection.Close();
        }

        private void vbB_Dat_Click(object sender, EventArgs e)
        {
            Form4 users4 = new Form4();
            users4.ShowDialog();

            if (check_1.Checked)
            {
                updateBill(UID1.Text);
                xoagiatri(pic_1, tex_Ten1, tex_T1, UID1);
                check_1.Checked = false;
            }
            if (check_2.Checked)
            {
                updateBill(UID2.Text);
                xoagiatri(pic_2, tex_Ten2, tex_T2, UID2);
                check_2.Checked = false;
            }
            if (check_3.Checked)
            {
                updateBill(UID3.Text);
                xoagiatri(pic_3, tex_Ten3, tex_T3, UID3);
                check_3.Checked = false;
            }
            if (check_4.Checked)
            {
                updateBill(UID4.Text);
                xoagiatri(pic_4, tex_Ten4, tex_T4, UID4);
                check_4.Checked = false;
            }
            if (check_5.Checked)
            {
                updateBill(UID5.Text);
                xoagiatri(pic_5, tex_Ten5, tex_T5, UID5);
                check_5.Checked = false;
            }
            if (check_6.Checked)
            {
                updateBill(UID6.Text);
                xoagiatri(pic_6, tex_Ten6, tex_T6, UID6);
                check_6.Checked = false;
            }
            if (check_7.Checked)
            {
                updateBill(UID7.Text);
                xoagiatri(pic_7, tex_Ten7, tex_T7, UID7);
                check_7.Checked = false;
            }
            if (check_8.Checked)
            {
                updateBill(UID8.Text);
                xoagiatri(pic_8, tex_Ten8, tex_T8, UID8);
                check_8.Checked = false;
            }

            // Làm sạch giỏ hàng
            xoa(pic_1, tex_Ten1, tex_T1, UID1);
            xoa(pic_2, tex_Ten2, tex_T2, UID2);
            xoa(pic_3, tex_Ten3, tex_T3, UID3);
            xoa(pic_4, tex_Ten4, tex_T4, UID4);
            xoa(pic_5, tex_Ten5, tex_T5, UID5);
            xoa(pic_6, tex_Ten6, tex_T6, UID6);
            xoa(pic_7, tex_Ten7, tex_T7, UID7);
            xoa(pic_8, tex_Ten8, tex_T8, UID8);

            // Cập nhật lại giỏ hàng
            MySqlConnection connection = tao_connetion();
            connection.Open();

            string queryp = "SELECT * FROM cart WHERE reader_id = @ID_Account";
            MySqlCommand cmdp = new MySqlCommand(queryp, connection);
            cmdp.Parameters.AddWithValue("@ID_Account", ID_Account);

            MySqlDataAdapter adapterp = new MySqlDataAdapter(cmdp);
            DataTable dataTablep = new DataTable();
            adapterp.Fill(dataTablep);
            int rowCount1 = dataTablep.Rows.Count;

            if (rowCount1 == 0)
            {
                tex_TB.Text = "Không có quyển sách nào trong giỏ hàng!!!";
            }
            if (rowCount1 == 1)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
            }
            if (rowCount1 == 2)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
            }
            if (rowCount1 == 3)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
            }
            if (rowCount1 == 4)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
            }
            if (rowCount1 == 5)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
            }
            if (rowCount1 == 6)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
            }
            if (rowCount1 == 7)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
                AssignValuesgiohang(pic_7, tex_Ten7, tex_T7, UID7, 6);
            }
            if (rowCount1 == 8)
            {
                AssignValuesgiohang(pic_1, tex_Ten1, tex_T1, UID1, 0);
                AssignValuesgiohang(pic_2, tex_Ten2, tex_T2, UID2, 1);
                AssignValuesgiohang(pic_3, tex_Ten3, tex_T3, UID3, 2);
                AssignValuesgiohang(pic_4, tex_Ten4, tex_T4, UID4, 3);
                AssignValuesgiohang(pic_5, tex_Ten5, tex_T5, UID5, 4);
                AssignValuesgiohang(pic_6, tex_Ten6, tex_T6, UID6, 5);
                AssignValuesgiohang(pic_7, tex_Ten7, tex_T7, UID7, 6);
                AssignValuesgiohang(pic_8, tex_Ten8, tex_T8, UID8, 7);
            }
        }


        private void tex_Tensach_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tex_LNTP_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}