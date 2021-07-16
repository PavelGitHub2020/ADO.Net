using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientLogicLibrary
{
    public class Manager
    {
        private Manager()
        {

        }

        public static double CalculateAvgAge(List<Patient> list)
        {
            double total = 0;

            foreach (Patient patient in list)
            {
                total += patient.Age;
            }

            return total / list.Count;
        }

        private static int FindMaxAge(List<Patient> list)
        {
            int max = list[0].Age;

            foreach (Patient patient in list)
            {
                if (patient.Age > max)
                {
                    max = patient.Age;
                }
            }

            return max;
        }

        public static List<Patient> FindOldestPatient(List<Patient> list)
        {
            int max = FindMaxAge(list);

            List<Patient> oldest = new List<Patient>();

            foreach (Patient patient in list)
            {
                if (patient.Age == max)
                {
                    oldest.Add(patient);
                }
            }

            return oldest;
        }

        private static int FindMinAge(List<Patient> list)
        {
            int min = list[0].Age;

            foreach (Patient patient in list)
            {
                if (patient.Age < min)
                {
                    min = patient.Age;
                }
            }
            
            return min;
        }

        public static List<Patient> FindYongestPatient(List<Patient> list)
        {
            int min = FindMinAge(list);

            List<Patient> yongest = new List<Patient>();

            foreach (Patient patient in list)
            {
                if (patient.Age == min)
                {
                    yongest.Add(patient);
                }
            }

            return yongest;
        }
    }
}
