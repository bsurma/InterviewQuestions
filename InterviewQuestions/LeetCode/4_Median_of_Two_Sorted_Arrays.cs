using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.LeetCode
{
    class _4_Median_of_Two_Sorted_Arrays : Question
    {
        public _4_Median_of_Two_Sorted_Arrays()
        {
            inputTypes = new Type[] { typeof(int[]), typeof(int[]) };
        }        

        public override object RunTest(params object[] inputs)
        {
            return FindMedianSortedArrays(inputs[0] as int[], inputs[1] as int[]);
        }

        public override List<TestData> TestCases
        {
            get
            {
                List<TestData> testCases = new List<TestData>()
                {
                    new TestData { InputData = new object[] { new int[] { 1 }, new int[] { 0 } }, ExpectedResult = (double)0.5 }
                };
                return testCases;
            }
        }
        
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int length = nums1.Length + nums2.Length;
            int median = (length % 2 == 0 ? length / 2 : (int)(length / 2)) + 1;
            int[] nums = new int[median];
            int i1 = 0;
            int i2 = 0;
            for (int i = 0; i < median; i++)
            {
                if ((nums1.Length > 0) && (i1 < nums1.Length) && (i2 >= nums2.Length || nums1[i1] < nums2[i2]))
                {
                    nums[i] = nums1[i1];
                        i1++;
                }
                else
                {
                    nums[i] = nums2[i2];
                        i2++;
                }
            }
            if (length % 2 == 0)
            {
                int num1 = nums[median - 1];
                int num2 = nums[median - 2];
                return (double)(num1 + num2) / 2;
            }
            else
                return nums[median - 1];
        }
    }
}
