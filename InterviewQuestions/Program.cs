using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            var questions = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface("IQuestion") != null);

            foreach (var question in questions)
            {
                if (question.IsAbstract)
                    continue;

                var q = Activator.CreateInstance(question) as IQuestion;
                Console.WriteLine("Execution question: " + question.Name + ", containing " + q.TestCases.Count.ToString() + " test cases.");

                bool success = true;
                foreach (var test in q.TestCases)
                {
                    var result = q.Test(test.InputData);

                    if (!result.Equals(test.ExpectedResult))
                    {
                        success = false;
                        Console.WriteLine(" - Error: " + result.ToString() + " does not match " + test.ExpectedResult.ToString());
                    }
                }
                if (success)
                {
                    Console.WriteLine("### Success!");
                }
            }

            Console.ReadLine();
        }        
    }
}
