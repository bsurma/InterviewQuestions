using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Interface
{
    public abstract class Question : IQuestion
    {
        protected Type[] inputTypes;

        public abstract List<TestData> TestCases { get; }

        public object Test(params object[] inputs)
        {
            if (inputs.Length != inputTypes.Length)
                throw new ArgumentException("The input type(s) must be " + inputTypes.ToString());
            for (int i = 0; i < inputs.Length; i++)
            {
                object input = inputs[i];
                if (input.GetType() != inputTypes[i])
                    throw new ArgumentException("The input type must be " + inputTypes[i]);
            }

            return RunTest(inputs);
        }

        public abstract object RunTest(params object[] inputs);
    }

    public interface IQuestion
    {
        object Test(object[] inputs);

        List<TestData> TestCases { get; }
    }

    public class TestData
    {
        public object[] InputData { get; set; }
        public object ExpectedResult { get; set; }
    }
}
