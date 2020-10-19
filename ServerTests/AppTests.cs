using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Tests
{
    [TestClass()]
    public class AppTests
    {
        [TestMethod()]
        public void CreateInstanceTest()
        {
            //"Testing for thread safety is hard if not impossible in most cases.", - Alexei Levenkov 
            int count = 0;
            
            AppOptions options = new AppOptions();
            
            Parallel.For(1, 15, i =>
             {
                 for (int j = 0; i < 10; j++)
                 {
                     App.CreateInstance(options);

                     Thread.Sleep(i);
                 }
             });

          
        }
    }
}