using System;
using System.Security;
using Microsoft.SqlServer.Dac.Compare;

namespace dacFXProject
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      var pass = new SecureString();
      var test = new SchemaCompareDatabaseEndpoint("Test", pass);
    }
  }
}
