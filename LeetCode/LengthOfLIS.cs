using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions.Interface;

namespace InterviewQuestions.LeetCode
{
    class LengthOfLISTest : Question
    {
        public LengthOfLISTest()
        {
            inputTypes = new Type[] { typeof(int[]) };
        }
        
        public override object RunTest(params object[] inputs)
        {
            return LengthOfLIS(inputs[0] as int[]);
        }

        public override List<TestData> TestCases
        {
            get
            {
                List<TestData> testCases = new List<TestData>()
                {
                    new TestData { InputData = new object[] { new int[] { 10, 9, 2, 5, 3, 4 } }, ExpectedResult = 4 }
                };
                return testCases;
            }
        }

        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return 1;
            
            // Start with the longest sequence length
            for (int sequenceLength = nums.Length; sequenceLength > 0; sequenceLength--)
            {
                // For each index create all possible subsequences
                for (int i = 0; i <= nums.Length - sequenceLength; i++)
                {                                 
                    int[] subSequence = new int[sequenceLength];                        
                    for (int j = i; j < sequenceLength; j++)
                    {
                        // Create a subsequence by skipping
                        subSequence[j] = nums[j + i];
                    }
                    bool success = false;
                    for (int j = 0; j < sequenceLength - 2; j++)
                    {
                        if (subSequence[j] > subSequence[j + 1])
                            break;
                    }
                    if (success)
                        return sequenceLength;
                }
            }
            return 1;
        }
    }
}
