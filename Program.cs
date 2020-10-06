using System;
using System.Collections.Generic;
using System.Security;
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.Compare;

namespace dacFXProject
{
  class Program
  {
    // var dac = new DacServices("Data Source=mssql;Initial Catalog=TestDb;Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;User Id=sa;Password=SqlPassw0rd;");
    // Extract Dacpac 
    // ------------------
    // dac.Extract("/Users/philiplan/code/github/dacFXProject/TestDb.dacpac", "TestDb", "TestDb", new Version(1, 0));
    // 
    // Deploy Dacpac
    // ------------------
    // DacPackage package = DacPackage.Load("/Users/philiplan/code/github/dacFXProject/TestDb.dacpac");
    // dac.Deploy(package, "TESTDB1");
    static void Main(string[] args)
    {
        var src = new SchemaCompareDacpacEndpoint("./TestDb.dacpac");
        var target = new SchemaCompareDacpacEndpoint("./TestDb.dacpac");

        var schemaComparison = new SchemaComparison(src, target);

        schemaComparison.Options.IgnorePermissions = true;
        schemaComparison.Options.IgnoreRoleMembership = true;
        schemaComparison.Options.ExcludeObjectTypes = new List<ObjectType>(schemaComparison.Options.ExcludeObjectTypes) { 
          ObjectType.Users
        }.ToArray();
        
        var result = schemaComparison.Compare();
        Console.WriteLine($"Result is equal: {result.IsEqual}, is valid: {result.IsValid}");
    }
  }
}
