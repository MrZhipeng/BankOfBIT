/*
 * Name: Zhipeng Ding
 * Program: Business Information Technology
 * Course: ADEV-3008 Programming 3
 * Created: 2022-09-07
 * Updated: 2022-09-08
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class FormatName
    {
        public static string FormatDescription(string description, string doNotNeed)
        {
            int endIndex = description.IndexOf(doNotNeed);

            return description.Substring(0, endIndex);
        }
    }
}
