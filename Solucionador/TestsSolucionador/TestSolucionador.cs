using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solucionador;

namespace TestsSolucionador
{
    [TestClass]
    public class TestSolucionador
    {
        [TestMethod]
        public void TestMethod1()
        {
            string nombreFichero = "Output.txt";
            File.WriteAllText(Util._PATH_ + nombreFichero, "texto en el fichero");
        }
    }
}
