using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionsAndIQueryable.Tests.Task_2
{
    [TestClass]
    public class MapperTests
    {
        private IMapper<Source, Destination> _mapper;

        [TestInitialize]
        public void Initialize()
        {
            var mapGenerator = new MappingGenerator();
            _mapper = mapGenerator.Generate<Source, Destination>();
        }

        #region BaseTests
        
        [TestMethod]
        public void Mapper_ShouldReturnCorrectNewDestinationInstance_Test()
        {
            var result = _mapper.Map(new Source());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Destination));
        }

        [TestMethod]
        public void Mapper_ShouldMapPropertiesWithTheSameName_Test()
        {
            var source = new Source { A = "one" };
            var result = _mapper.Map(source);
            Assert.IsNotNull(result?.A);
            Assert.AreEqual(source.A, result.A);
        }

        [TestMethod]
        public void Mapper_ShouldMapPropertiesWithTheDifferentName_Test()
        {
            var source = new Source { A = "one", B = "two", C = "three" };
            var result = _mapper.Map(source);
            Assert.AreEqual(source.A, result.A);
            Assert.AreEqual(source.B, result.B);
            Assert.IsNull(result.D);
            Assert.IsNotNull(source.C);
        }

        [TestMethod]
        public void Mapper_ShouldMapPropertiesWithTheComplexTypes_Test()
        {
            var source = new Source { Transfer = new Transfer() };
            var result = _mapper.Map(source);
            Assert.IsNotNull(result.Transfer);
            Assert.AreEqual(result.Transfer.Info, source.Transfer.Info);
        }

        [TestMethod]
        public void Mapper_ShouldMapFieldsWithTheSameName_Test()
        {
            var source = new Source { E = "one" };
            var result = _mapper.Map(source);
            Assert.IsNotNull(result.E);
            Assert.AreEqual(source.E, result.E);
        }

        [TestMethod]
        public void Mapper_ShouldMapFieldsWithDifferentName_Test()
        {
            var source = new Source { E = "one", F = "two", G = "three" };
            var result = _mapper.Map(source);
            Assert.AreEqual(source.E, result.E);
            Assert.AreEqual(source.F, result.F);
            Assert.IsNull(result.H);
            Assert.IsNotNull(source.G);
        }
        #endregion

    }

    #region Infrastructure
    public class Source
    {
        public string A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public Transfer Transfer { get; set; }

        public string E;

        public string F;

        public string G;
    }

    public class Destination
    {
        public string A { get; set; }

        public string B { get; set; }

        public string D { get; set; }

        public Transfer Transfer { get; set; }

        public string E;

        public string F;

        public string H;
    }

    public class Transfer
    {
        public string Info { get; set; }
        public Transfer()
        {
            Info = "Info";
        }
    }
    #endregion

}
