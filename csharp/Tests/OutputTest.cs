using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace csharp.Tests
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class OutputTest
    {
        [Test]
        public void AfterThirtyDays()
        {
            StringBuilder output = new StringBuilder();
            using (StringWriter outputWriter = new StringWriter(output))
            {
                Console.SetOut(outputWriter);

                Program.Main(new string[] { });

                Approvals.Verify(output.ToString());
            }
        }
    }
}
