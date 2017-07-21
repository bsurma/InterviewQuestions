using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.LeetCode
{
    class _7_Reverse_Integer : Question
    {
        public _7_Reverse_Integer()
        {
            inputTypes = new Type[] { typeof(int) };
        }

        public override object RunTest(params object[] inputs)
        {
            return Reverse((int)inputs[0]);
        }

        public override List<TestData> TestCases
        {
            get
            {
                List<TestData> testCases = new List<TestData>()
                {
                    new TestData { InputData = new object[] { 1 }, ExpectedResult = 1 }
                };
                return testCases;
            }
        }
        
        public int Reverse(int x)
        {
            string f = x.ToString();
            char[] charArray = f.ToCharArray();
            char[] rCharArray = new char[charArray.Length];
            int end = 0;
            if (f[0] == '-')
            {
                rCharArray[0] = '-';
                end = 1;
            }
            int j = end;
            for (int i = charArray.Length - 1; i >= end; i--)
            {
                rCharArray[j] = charArray[i];
            }
            int y = 0;
            Int32.TryParse(new String(rCharArray), out y);
            return y;
        }   
    }
}
