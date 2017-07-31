using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions.Interface;

namespace InterviewQuestions.LeetCode
{
    class _65_Valid_Number : Question
    {
        public _65_Valid_Number()
        {
            inputTypes = new Type[] { typeof(string) };
        }

        public override object RunTest(params object[] inputs)
        {
            return IsNumber(inputs[0] as string);
        }

        public override List<TestData> TestCases
        {
            get
            {
                List<TestData> testCases = new List<TestData>()
                {
                    new TestData { InputData = new object[] { ".8+" }, ExpectedResult = true }
                };
                return testCases;
            }
        }
        
        public bool IsNumber(string s)
        {
            double D;
            
            bool isDbl = Double.TryParse(s, out D);
        
            return isDbl;
        }
        
    }
}
