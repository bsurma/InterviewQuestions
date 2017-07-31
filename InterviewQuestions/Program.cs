using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using InterviewQuestions.Interface;
using System.IO;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Assembly> assemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                assemblies.Add(Assembly.LoadFile(dll));

            foreach (Assembly assembly in assemblies)
            {
                //Get all questions by finding types which implement IQuestion
                var questions = assembly.GetTypes().Where(t => t.GetInterface("IQuestion") != null);

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
            }

            Console.ReadLine();
        }        
    }
}
