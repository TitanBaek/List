using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230424
{
    internal class Er
    {
        public static void Input_Patient()
        {
            List<string> patient = new List<string>();
            DataStructure.PriorityQueue<string> myQueue = new DataStructure.PriorityQueue<string>();

            Insert_Patient(ref patient);
            Insert_Patient_Queue(ref patient,ref myQueue);

            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
        }
        
        public static void Insert_Patient(ref List<string> patient)
        {
            string str;
            string answer;

            while (true)
            {
                Console.Clear();

                Console.Write("환자명을 입력하세요 : ");
                str = Console.ReadLine();
                Console.Clear();
                Console.Write("환자의 골든타임(우선도)을 입력하세요 : ");
                str += $"/{Console.ReadLine()}";
                Console.Clear();

                patient.Add(str);

                Console.Write("더 입력할 환자가 있나요? Y/N : ");
                answer = Console.ReadLine();

                if (answer != "Y" && answer != "y")
                {
                    break;
                }
            }
        }

        public static void Insert_Patient_Queue(ref List<string> patient, ref DataStructure.PriorityQueue<string> myQueue)
        {
            foreach (string value in patient)
            {
                // 슬래시를 기준으로 문자열을 나눠서 PriorityQueue 에 데이터와 우선순위를 삽입
                string[] patientInfo;
                patientInfo = value.Split('/');
                myQueue.Enqueue(patientInfo[0], Int32.Parse(patientInfo[1]));
            }

        }
    }
}
