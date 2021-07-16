using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientLogicLibrary.DAL;
using PatientLogicLibrary;

namespace Patient_Client
{
    public partial class Form1 : Form
    {
        public static readonly IPatientDAO dao;
        static Form1()
        {
            dao = new PatientDAO();
        }
        public Form1()
        {
            InitializeComponent();
        }

       

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void UpdateForm()
        {
            dataGridView1.DataSource = dao.GetTable();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm();

            editForm.ShowDialog();

            UpdateForm();
        }

        private void getAvgAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double avg = Manager.CalculateAvgAge(dao.GetAll());
            MessageBox.Show($"Average age = {avg}");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            int raw = dao.Remove(id);
            MessageBox.Show($"{raw} raw deleted");
            UpdateForm();
        }

        private void getYongestPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Patient> list = Manager.FindYongestPatient(dao.GetAll());

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Patient list \n");

            foreach (Patient patient in list)
            {
                stringBuilder.Append(patient).Append("\n");

            }

            MessageBox.Show(stringBuilder.ToString());
        }

        private void getOldestPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Patient> list = Manager.FindOldestPatient(dao.GetAll());

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Patient list \n");

            foreach (Patient patient in list)
            {
                stringBuilder.Append(patient).Append("\n");

            }

            MessageBox.Show(stringBuilder.ToString());
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            string first = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
            string middle = (string)dataGridView1.SelectedRows[0].Cells[2].Value;
            string surname = (string)dataGridView1.SelectedRows[0].Cells[3].Value;
            string address = (string)dataGridView1.SelectedRows[0].Cells[4].Value;
            string phone = (string)dataGridView1.SelectedRows[0].Cells[5].Value;
            int medical = (int)dataGridView1.SelectedRows[0].Cells[6].Value;
            string diagnosis = (string)dataGridView1.SelectedRows[0].Cells[7].Value;
            int age = (int)dataGridView1.SelectedRows[0].Cells[8].Value;

            Patient patient = new Patient(id, first, middle, surname, address, phone, medical, diagnosis, age);

            EditForm editForm = new EditForm(patient);

            editForm.ShowDialog();

            UpdateForm();
        }
    }
}
