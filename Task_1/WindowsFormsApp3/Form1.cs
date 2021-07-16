using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        string fileName = "";
        public Form1()
        {
            InitializeComponent();

            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.
                                    ConnectionStrings["MyConnString"].
                                    ConnectionString;
        }

        private void LoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Graphics File|*.bmp;*.gif;*.jpg; *.png";
            ofd.FileName = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                LoadPicture1();
            }
        }

        private void LoadPicture1()
        {
            try
            {
                byte[] bytes;
                bytes = CreateCopy();
                conn.Open();
                SqlCommand comm = new SqlCommand("insert into Pictures(bookid, name, picture) values(@bookid, @name, @picture);", conn);
                if (textBox1.Text == null ||
                textBox1.Text.Length == 0) return;
                int index = -1;
                int.TryParse(textBox1.Text, out index);
                if (index == -1) return;
                comm.Parameters.Add("@bookid", SqlDbType.Int).Value = index;
                comm.Parameters.Add("@name", SqlDbType.NVarChar, 255).Value = fileName;
                comm.Parameters.Add("@picture", SqlDbType.Image, bytes.Length). Value = bytes;
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private byte[] CreateCopy()
        {
            Image img = Image.FromFile(fileName);
            int maxWidth = 300, maxHeight = 300;
            //размеры выбраны произвольно
            double ratioX = (double)maxWidth /
            img.Width;
            double ratioY = (double)maxHeight /
            img.Height;
            double ratio = Math.Min(ratioX, ratioY);
            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);
            Image mi = new Bitmap(newWidth, newHeight);
            //рисунок в памяти
            Graphics g = Graphics.FromImage(mi);
            g.DrawImage(img, 0, 0, newWidth, newHeight);
            MemoryStream ms = new MemoryStream();
            //поток для ввода|вывода байт из памяти
            mi.Save(ms, ImageFormat.Jpeg);
            ms.Flush();//выносим в поток все данные 
                       //из буфера
            ms.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(ms);
            byte[] buf = br.ReadBytes((int)ms.Length);
            return buf;
        }

        private void ShowOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == null || textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Укажите id книги!");
                    return;
                }
                int index = -1;
                int.TryParse(textBox1.Text, out index);
                if (index == -1)
                {
                    MessageBox.Show("Укажите id книги в правильном формате!");
                    return;
                }
                da = new SqlDataAdapter("select picture from Pictures where id = @id;", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = index;
                ds = new DataSet();
                da.Fill(ds);
                byte[] bytes = (byte[])ds.Tables[0].Rows[0]["picture"];
                MemoryStream ms = new MemoryStream(bytes);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter("select * from Pictures; ", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "picture");
                dataGridView1.DataSource = ds.Tables["picture"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
