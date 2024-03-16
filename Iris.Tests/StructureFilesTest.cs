using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Iris.Runtime.Model.BaseObjects;
using Iris.Designer.VisualObjects;
using Iris.Runtime.Core;

namespace Iris.Tests
{
  [TestFixture]
  public class StructureFilesTest
  {
    private Structure LoadStructure(string fileName)
    {
      string filePath = @"D:\Projetos\IRIS 2.0\Iris.Tests\TestFiles\";
      fileName = filePath + fileName;
      PersistenceStructure vStructure = PersistenceManager<PersistenceStructure>.LoadFromFile(fileName);
      return vStructure.Structure;
    }

    [Test]
    public void Load2XEval()
    {
      LoadStructure("2XEval.Iris");
    }

    [Test]
    public void Run2XEval()
    {
      LoadStructure("2XEval.Iris").Execute(false);
    }

    [Test]
    public void LoadXEval()
    {
      LoadStructure("XEval.Iris");
    }

    [Test]
    public void RunXEval()
    {
      LoadStructure("XEval.Iris").Execute(false);
    }

    [Test]
    public void LoadCCode2()
    {
      LoadStructure("C# Code2.Iris");
    }

    [Test]
    public void RunCCode2()
    {
      LoadStructure("C# Code2.Iris").Execute(false);
    }

    [Test]
    public void LoadCCode()
    {
      LoadStructure("C# Code.Iris");
    }

    [Test]
    public void RunCCode()
    {
      LoadStructure("C# Code.Iris").Execute(false);
    }

    [Test]
    public void LoadDatasetCommand()
    {
      LoadStructure("DatasetCommand.Iris");
    }

    [Test]
    public void RunDatasetCommand()
    {
      LoadStructure("DatasetCommand.Iris").Execute(false);
    }

    [Test]
    public void LoadDepositoLapa()
    {
      LoadStructure("DepositoLapa.Iris");
    }

    [Test]
    public void LoadDiallogger()
    {
      LoadStructure("Diallogger.Iris");
    }

    [Test]
    public void RunDiallogger()
    {
      LoadStructure("Diallogger.Iris").Execute(false);
    }

    [Test]
    public void LoadFullTest1()
    {
      LoadStructure("FullTest1.Iris");
    }

    [Test]
    public void RunFullTest1()
    {
      LoadStructure("FullTest1.Iris").Execute(false);
    }

    [Test]
    public void LoadFullTest()
    {
      LoadStructure("FullTest.Iris");
    }

    [Test]
    public void RunFullTest()
    {
      LoadStructure("FullTest.Iris").Execute(false);
    }

    [Test]
    public void LoadLookup1()
    {
      LoadStructure("Lookup1.Iris");
    }

    [Test]
    public void RunLookup1()
    {
      LoadStructure("Lookup1.Iris").Execute(false);
    }

    [Test]
    public void LoadLookup2()
    {
      LoadStructure("Lookup2.Iris");
    }

    [Test]
    public void RunLookup2()
    {
      LoadStructure("Lookup2.Iris").Execute(false);
    }

    [Test]
    public void LoadLookup()
    {
      LoadStructure("Lookup.Iris");
    }

    [Test]
    public void RunLookup()
    {
      LoadStructure("Lookup.Iris").Execute(false);
    }

    [Test]
    public void LoadSubString()
    {
      LoadStructure("SubString.Iris");
    }

    [Test]
    public void RunSubString()
    {
      LoadStructure("SubString.Iris").Execute(false);
    }

    [Test]
    public void LoadT1()
    {
      LoadStructure("T1.Iris");
    }

    [Test]
    public void RunT1()
    {
      LoadStructure("T1.Iris").Execute(false);
    }

    [Test]
    public void LoadTesRSr()
    {
      LoadStructure("TesRSr.Iris");
    }

    [Test]
    public void RunTesRSr()
    {
      LoadStructure("TesRSr.Iris").Execute(false);
    }

    [Test]
    public void LoadTestCommand()
    {
      LoadStructure("TestCommand.Iris");
    }

    [Test]
    public void RunTestCommand()
    {
      LoadStructure("TestCommand.Iris").Execute(false);
    }

    [Test]
    public void LoadTestePersistenciaTabelas()
    {
      LoadStructure("TestePersistenciaTabelas.Iris");
    }

    [Test]
    public void RunTestePersistenciaTabelas()
    {
      LoadStructure("TestePersistenciaTabelas.Iris").Execute(false);
    }

    [Test]
    public void LoadTestInMemoryRS()
    {
      LoadStructure("TestInMemoryRS.Iris");
    }

    [Test]
    public void RunTestInMemoryRS()
    {
      LoadStructure("TestInMemoryRS.Iris").Execute(false);
    }

    [Test]
    public void LoadTestScalar()
    {
      LoadStructure("TestScalar.Iris");
    }

    [Test]
    public void RunTestScalar()
    {
      LoadStructure("TestScalar.Iris").Execute(false);
    }


    [Test]
    public void LoadTestUpdate()
    {
      LoadStructure("TestUpdate.Iris");
    }

    [Test]
    public void RunTestUpdate()
    {
      LoadStructure("TestUpdate.Iris").Execute(false);
    }

    [Test]
    public void LoadTecFerV2()
    {
      LoadStructure("v2-TecFer.Iris");
    }

    [Test]
    public void LoadTecFerV3()
    {
      LoadStructure("v3-TecFer.Iris");
    }


    [Test]
    public void LoadTecFerV4()
    {
      LoadStructure("v4-TecFer.Iris");
    }


  }
}
