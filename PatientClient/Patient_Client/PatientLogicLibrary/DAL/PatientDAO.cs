using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace PatientLogicLibrary.DAL
{
    public class PatientDAO : BaseDAO, IPatientDAO
    {
        private const string INSERT_Patient = "INSERT INTO Patient(First_Name, Middle_Name, Surname, Address, Phone_Number, Medical_Card_Number, Diagnosis,Age) VALUES(@first, @middle, @surname, @address, @phone, @medicalCardNumber, @diagnoses, @age)";
        private const string DELETE_Patient = "DELETE FROM Patient WHERE Patient_Id = @id";
        private const string UPDATE_Patient = "UPDATE Patient SET First_Name = @first, Middle_Name = @middle, Surname = @surname, Address = @address, Phone_Number = @phone, Medical_Card_Number = @medicalCardNumber, Diagnosis = @diagnoses, Age = @age WHERE Patient_Id = @id";
        private const string SELECT_Patients = "SELECT * FROM Patient";
        public int Add(Patient patient)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = INSERT_Patient;

            IDbConnection connection = GetConnection();

            command.Connection = (SqlConnection)connection;

            SqlParameter first = new SqlParameter();
            first.ParameterName = "@first";
            first.SqlDbType = System.Data.SqlDbType.NVarChar;
            first.Value = patient.FirstName;

            command.Parameters.Add(first);

            SqlParameter middle = new SqlParameter();
            middle.ParameterName = "@middle";
            middle.SqlDbType = System.Data.SqlDbType.NVarChar;
            middle.Value = patient.MiddleName;

            command.Parameters.Add(middle);

            SqlParameter surname = new SqlParameter();
            surname.ParameterName = "@surname";
            surname.SqlDbType = System.Data.SqlDbType.NVarChar;
            surname.Value = patient.Surname;

            command.Parameters.Add(surname);

            SqlParameter address = new SqlParameter();
            address.ParameterName = "@address";
            address.SqlDbType = System.Data.SqlDbType.NVarChar;
            address.Value = patient.Address;

            command.Parameters.Add(address);

            SqlParameter phone = new SqlParameter();
            phone.ParameterName = "@phone";
            phone.SqlDbType = System.Data.SqlDbType.NVarChar;
            phone.Value = patient.PhoneNumber;

            command.Parameters.Add(phone);

            SqlParameter medical = new SqlParameter();
            medical.ParameterName = "@medicalCardNumber";
            medical.SqlDbType = System.Data.SqlDbType.NVarChar;
            medical.Value = patient.MedicalCardNumber;

            command.Parameters.Add(medical);

            SqlParameter diagnoses = new SqlParameter();
            diagnoses.ParameterName = "@diagnoses";
            diagnoses.SqlDbType = System.Data.SqlDbType.NVarChar;
            diagnoses.Value = patient.Diagnosis;

            command.Parameters.Add(diagnoses);

            SqlParameter age = new SqlParameter();
            age.ParameterName = "@age";
            age.SqlDbType = System.Data.SqlDbType.NVarChar;
            age.Value = patient.Age;

            command.Parameters.Add(age);

            int row = command.ExecuteNonQuery();

            ReleaseConnection(connection);

            return row;
        }

        public List<Patient> GetAll()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = SELECT_Patients;

            IDbConnection connection = GetConnection();

            command.Connection = (SqlConnection)connection;

            SqlDataReader reader = command.ExecuteReader();

            List<Patient> list = new List<Patient>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = (int)reader[0];
                    string first = (string)reader[1] + "";
                    string middle = (string)reader[2] + "";
                    string surname = (string)reader[3] + "";
                    string address = (string)reader[4] + "";
                    string phone = (string)reader[5] + "";
                    int medical = (int)reader[6];
                    string diagnoses = (string)reader[7] + "";
                    int age = (int)reader[8];

                    list.Add(new Patient(id,first,middle,surname,address,phone,medical,diagnoses,age));
                }
            }

            ReleaseConnection(connection);

            return list;
        }

        public DataTable GetTable()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = SELECT_Patients;
            IDbConnection connection = GetConnection();
            command.Connection = (SqlConnection)connection;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);


            ReleaseConnection(connection);
            return table;
        }

        public int Remove(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = DELETE_Patient;

            IDbConnection connection = GetConnection();

            command.Connection = (SqlConnection)connection;

            SqlParameter id_ = new SqlParameter();
            id_.ParameterName = "@id";
            id_.SqlDbType = System.Data.SqlDbType.Int;
            id_.Value = id;

            command.Parameters.Add(id_);

            int raw = command.ExecuteNonQuery();

            ReleaseConnection(connection);

            return raw;
        }

        public int Update(Patient patient)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = UPDATE_Patient;

            IDbConnection connection = GetConnection();

            command.Connection = (SqlConnection)connection;

            SqlParameter first = new SqlParameter();
            first.ParameterName = "@first";
            first.SqlDbType = System.Data.SqlDbType.NVarChar;
            first.Value = patient.FirstName;

            command.Parameters.Add(first);

            SqlParameter middle = new SqlParameter();
            middle.ParameterName = "@middle";
            middle.SqlDbType = System.Data.SqlDbType.NVarChar;
            middle.Value = patient.MiddleName;

            command.Parameters.Add(middle);

            SqlParameter surname = new SqlParameter();
            surname.ParameterName = "@surname";
            surname.SqlDbType = System.Data.SqlDbType.NVarChar;
            surname.Value = patient.Surname;

            command.Parameters.Add(surname);

            SqlParameter address = new SqlParameter();
            address.ParameterName = "@address";
            address.SqlDbType = System.Data.SqlDbType.NVarChar;
            address.Value = patient.Address;

            command.Parameters.Add(address);

            SqlParameter phone = new SqlParameter();
            phone.ParameterName = "@phone";
            phone.SqlDbType = System.Data.SqlDbType.NVarChar;
            phone.Value = patient.PhoneNumber;

            command.Parameters.Add(phone);

            SqlParameter medical = new SqlParameter();
            medical.ParameterName = "@medical";
            medical.SqlDbType = System.Data.SqlDbType.NVarChar;
            medical.Value = patient.MedicalCardNumber;

            command.Parameters.Add(medical);

            SqlParameter diagnoses = new SqlParameter();
            diagnoses.ParameterName = "@diagnoses";
            diagnoses.SqlDbType = System.Data.SqlDbType.NVarChar;
            diagnoses.Value = patient.Diagnosis;

            command.Parameters.Add(diagnoses);

            SqlParameter age = new SqlParameter();
            age.ParameterName = "@age";
            age.SqlDbType = System.Data.SqlDbType.NVarChar;
            age.Value = patient.Age;

            command.Parameters.Add(age);

            SqlParameter id_ = new SqlParameter();
            id_.ParameterName = "@id";
            id_.SqlDbType = System.Data.SqlDbType.Int;
            id_.Value = patient.ID;

            command.Parameters.Add(id_);

            int raw = command.ExecuteNonQuery();

            ReleaseConnection(connection);

            return raw;
        }
    }
}
