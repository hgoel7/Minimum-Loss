using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Minimum_Loss
{
    class Program
    {
        static int minimumLoss(long[] price) {

            int length = price.Count();
            Dictionary<int, Dictionary<int, int>> dictTrackRecord = new Dictionary<int, Dictionary<int, int>>();
            for(int i = 0; i< length - 1; i ++)
            {
                Dictionary<int, int> temp = new Dictionary<int, int>();
                for(int j = i + 1; j < length; j++ )
                {
                    int diff = Convert.ToInt32(price[i] - price[j]);
                    if( diff >= 0)
                        temp.Add(j, diff);                
                }
                dictTrackRecord.Add(i, temp);
            }

            return  dictTrackRecord.Values.Where( y => y.Count > 0 ).Select( x => x.Values.Min()).Min();
        }

        static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@".\Test_File.txt", true);

            int n = Convert.ToInt32(Console.ReadLine());

            long[] price = Array.ConvertAll(Console.ReadLine().Split(' '), priceTemp => Convert.ToInt64(priceTemp));
 
            int result = minimumLoss(price);
            Console.WriteLine("Result : " + result);

            // textWriter.WriteLine(result);

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}

