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
    public partial class EditForm : Form
    {
        private Patient patient1;
        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(Patient patient) : this()
        {

            this.patient1 = patient;

            button1.Text = "Update";

            textBox1.Text = patient.FirstName;
            textBox2.Text = patient.MiddleName;
            textBox3.Text = patient.Surname;
            textBox4.Text = patient.Address;
            textBox5.Text = patient.PhoneNumber;
            textBox6.Text = patient.MedicalCardNumber + "";
            textBox7.Text = patient.Diagnosis;
            textBox8.Text = patient.Age + "";

            button1.Click -= button1_Click;
            button1.Click += button1_Click_Update;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string first = textBox1.Text;
            string middle = textBox2.Text;
            string surname = textBox3.Text;
            string addres = textBox4.Text;
            string phone = textBox5.Text;
            int medical = Convert.ToInt32(textBox6.Text);
            string diagnosis = textBox7.Text;
            int age = Convert.ToInt32(textBox8.Text);

            Patient patient = new Patient(patient1.ID, first, middle, surname, addres, phone, medical, diagnosis, age);

            int raw = Form1.dao.Add(patient);

            Close();
        }

        private void button1_Click_Update(object sender, EventArgs e)
        {
            string first = textBox1.Text;
            string middle = textBox2.Text;
            string surname = textBox3.Text;
            string addres = textBox4.Text;
            string phone = textBox5.Text;
            int medical = Convert.ToInt32(textBox6.Text);
            string diagnosis = textBox7.Text;
            int age = Convert.ToInt32(textBox8.Text);

            Patient patient = new Patient(patient1.ID, first, middle, surname, addres, phone, medical, diagnosis, age);

            Form1.dao.Add(patient); 

            Close();
        }
    }
}
