﻿// The MIT License (MIT) 
// Copyright (c) 1994-2017 The Sage Group plc or its licensors.  All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of 
// this software and associated documentation files (the "Software"), to deal in 
// the Software without restriction, including without limitation the rights to use, 
// copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the 
// Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.IO;
using EnvDTE;
using EnvDTE80;

namespace Sage.CA.SBS.ERP.Sage300.UpgradeWizard
{
    /// <summary> Entry Point for Upgrade Wizard </summary>
    public class Sage300Upgrade
    {
		/// <summary> Execute the Upgrade Wizard </summary>
        public void Execute(Solution solution)
        {
			var sln = (Solution2)solution;
			var templatePath = sln.GetProjectItemTemplate("UpgradeWebItems.zip", "CSharp");

			using (var form = new Upgrade(DestinationDefault(solution), DestinationWebDefault(solution), templatePath))
            {
                form.ShowDialog();
            }
        }

        /// <summary> Get Destination default </summary>
        /// <param name="solution">Solution</param>
        /// <returns>Destination or Empty String</returns>
        public string DestinationDefault(Solution solution)
        {
            var retVal = string.Empty;

            try
            {
                // Get destination default from project
                retVal = Directory.GetParent(Path.GetFullPath(solution.FileName)).FullName;
            }
            catch
            {
                // Ignore
            }
            return retVal;
        }

        /// <summary> Get Destination Web default </summary>
        /// <param name="solution">Solution</param>
        /// <returns>Destination Web or Empty String</returns>
        public string DestinationWebDefault(Solution solution)
        {
            var retVal = string.Empty;

            try
            {
                // Get destination web default from project
                retVal = Path.Combine(Directory.GetParent(Directory.GetParent(Path.GetFullPath(solution.FileName)).FullName).FullName, "Columbus-Web", "Sage.CA.SBS.ERP.Sage300.Web");
            }
            catch
            {
                // Ignore
            }
            return retVal;

        }

    }
}
