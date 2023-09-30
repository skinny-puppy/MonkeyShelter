//using AutoMapper;
//using Castle.Core.Logging;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MonkeyShelter.Controllers;
//using MonkeyShelter.Entities;
//using MonkeyShelter.Services;
//using Moq;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//namespace MonkeyShelterTest
//{
//    [TestClass]
//    public class Tests
//    {

//        private MonkeysController controller;
//        private Mock<IMonkeyShelterRepository> monkeyShelterRepositoryMock;
//        private Mock<IFluctuationStateRepository> fluctuationStateRepositoryMock;
//        private Mock<ILogger> loggerMock;
//        private Mock<IMapper> mapperMock;


//        [TestMethod]
//        public void GetReturnsOk()

//        {
//            IList<Monkey> monkeys = new List<Monkey>
//            {
//                new Monkey
//                {
//                    Id  = "602f88160114589f2298cd5b",
//                    Name = "Kelsey",
//                    Age = 23,
//                    Weight = 300,
//                    EyeColor = "brown",
//                    Species = "White-coated titi",
//                    Registered = "Sat Jan 10 2015 09:42:40",
//                    FavoriteFruit = "banana"
//                },
//                new Monkey
//                {
//                    Id  = "602f8816013638da2c913212",
//                    Name = "Bridgett",
//                    Age = 23,
//                    Weight = 300,
//                    EyeColor = "brown",
//                    Species = "White-coated titi",
//                    Registered = "Sat Jan 10 2015 09:42:40",
//                    FavoriteFruit = "banana"
//                },
//                new Monkey
//                {
//                    Id  = "602f881601aa70c673db3257",
//                    Name = "Finch",
//                    Age = 23,
//                    Weight = 300,
//                    EyeColor = "brown",
//                    Species = "White-coated titi",
//                    Registered = "Sat Jan 10 2015 09:42:40",
//                    FavoriteFruit = "banana"
//                }
//            };
               

//            monkeyShelterRepositoryMock.Setup(p => p.GetMonkeysAsync()).ReturnsAsync(monkeys);
//            mapperMock.Setup(m => m.Map<Foo, Bar>(It.IsAny<Foo>())).Returns((Foo src) => new Bar() { Value = src.Value });

//            monkeyShelterRepositoryMock = new Mock<IMonkeyShelterRepository>();
//            fluctuationStateRepositoryMock = new Mock<IFluctuationStateRepository>();
//            mapperMock = new Mock<IMapper>();
//            loggerMock = new Mock<ILogger>();

//            var controller = new MonkeysController(monkeyShelterRepositoryMock.Object, fluctuationStateRepositoryMock.Object, loggerMock.Object, mapperMock.Object);
//        }
//    }
//}
