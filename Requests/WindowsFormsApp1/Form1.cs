using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        TabPage tabPage = null;
        ListView listView2 = null;
        
        string cs = "";
        public Form1()
        {
            InitializeComponent();

            conn = new SqlConnection();
            cs = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.ConnectionString = cs;

            viewBox1.SelectedIndexChanged += viewBox1_SelectedIndexChanged;
        }


        private int Number_Of_Requests()
        {
            int number = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                char ch = Convert.ToChar(textBox1.Text[i]);
                if (ch == ';')
                {
                    number++;
                }
            }
            return number;
        }

        private void AddNewTabPages(int number)
        {
            tabPage = new TabPage();
            tabPage.Text = "Tab " + number;
            tabPage.Controls.Add(listView2);
            tabControl1.TabPages.Add(tabPage);
        }

        private void ChangeViewListView()
        {
            if (viewBox1.SelectedItem.ToString().Equals("Details"))
            {
                listView2 = new ListView();
                listView2.View = View.Details;
                listView2.GridLines = true;
                listView2.Width = 440;
                listView2.Height = 230;
            }
            else 
            {
                listView2 = new ListView();
                listView2.View = View.List;
                listView2.Width = 440;
                listView2.Height = 230;
            }
        }

        private void RemoveTabPage()
        {
            if (tabControl1.TabPages != null)
            {
                foreach (TabPage page in tabControl1.TabPages)
                {
                    tabControl1.TabPages.Remove(page);
                }
            }
        }

        private void SelectingDisplayMode()
        {
            int counter = 0;
            int counter1 = 0;

            int numberOfRequests = Number_Of_Requests();

            if (viewBox1.SelectedItem.ToString().Equals("Details"))
            {
                while (counter1 <= numberOfRequests)
                {
                    ChangeViewListView();

                    AddNewTabPages(counter1);

                    foreach (var t in set.Tables[counter1].Columns)
                    {
                        listView2.Columns.Add(t.ToString());
                        counter++;
                    }

                    foreach (DataRow r in set.Tables[counter1].Rows)
                    {
                        ListViewItem listViewItem = new ListViewItem(r[0].ToString());
                        for (int i = 1; i < counter; i++)
                        {
                            listViewItem.SubItems.Add(r[i].ToString());
                        }
                        listView2.Items.Add(listViewItem);
                    }

                    listView2.Items.Add("\n");
                    counter1++;
                    counter = 0;
                }
            }

            if (viewBox1.SelectedItem.ToString().Equals("List"))
            {
                int numberTab = 0;
                foreach (DataTable table in set.Tables)
                {
                    ChangeViewListView();

                    AddNewTabPages(numberTab);

                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn column in table.Columns)
                        {
                            listView2.Items.Add(row[column].ToString());
                        }
                        listView2.Items.Add("\t");
                    }
                    numberTab++;
                }
            }
        }

        private void ToPerform()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);

                set = new DataSet();

                string sql = textBox1.Text;

                da = new SqlDataAdapter(sql, conn);

                da.Fill(set);

                RemoveTabPage();

                SelectingDisplayMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            viewBox1.Items.Add("Details");
            viewBox1.Items.Add("List");
        }
        private void viewBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToPerform();
        }
    }
}
