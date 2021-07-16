using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientLogicLibrary
{
    public class Patient
    {
        public int ID { get; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MedicalCardNumber { get; set; }
        public string Diagnosis { get; set; }

        public int Age { get; set; }

        public Patient() { }

        public Patient(int id, string firstName, string middleName, string surname, string address,
                       string phoneNumber, int medicalCardNumber, string diadnosis, int age)
        {
            ID = id;
            FirstName = firstName;
            MiddleName = middleName;
            Surname = surname;
            Address = address;
            PhoneNumber = phoneNumber;
            MedicalCardNumber = medicalCardNumber;
            Diagnosis = diadnosis;
            Age = age;
        }

        public override string ToString()
        {
            return $"{ID}) {FirstName} {MiddleName} {Surname}, address = {Address}, phone mumber = {PhoneNumber}, " +
                   $"medical card number = {MedicalCardNumber}, diagnosis = {Diagnosis}, age = {Age}";
        }

    }
}
