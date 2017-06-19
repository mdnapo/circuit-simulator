using Core.Builders;
using Core.Factories;
using Core.Models.V2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void NodeFactory_ShouldReturnAndNode()
        {
            var factory = new NodeFactoryV2();
            factory.AddNodeType("and", typeof(AndNode));


            var node = factory.Create("bla", "and");

            Assert.IsInstanceOfType(node, typeof(AndNode));
        }

        [TestMethod]
        public void NodeFactory_ShouldReturnXorNode()
        {
            var factory = new NodeFactoryV2();
            factory.AddNodeType("xor", typeof(XorNode));


            var node = factory.Create("bla", "xor");

            Assert.IsInstanceOfType(node, typeof(XorNode));
        }

        [TestMethod]
        public void NodeFactory_ShouldReturnInputNode()
        {
            var factory = new NodeFactoryV2();
            factory.AddNodeType("input_high", typeof(InputNode));

            var node = factory.Create("bla", "input_high");

            Assert.IsInstanceOfType(node, typeof(InputNode));
        }

        [TestMethod]
        public void NodeFactory_ShouldReturnOutputNode()
        {
            var factory = new NodeFactoryV2();
            factory.AddNodeType("probe", typeof(OutputNode));


            var node = factory.Create("bla", "probe");

            Assert.IsInstanceOfType(node, typeof(OutputNode));
        }

        //[TestMethod]
        //public void NodeFactory_InvalidNode_ShouldReturnNull()
        //{
        //    var factory = new NodeFactoryV2();
        //    factory.AddNodeType("nand", typeof(NandNode));

        //    var node = factory.Create("bla", "basdasd");

        //    Assert.AreEqual(null, node);
        //}

        [TestMethod]
        public void NodeFactory_InputLow_ShouldReturnInputNode()
        {
            var factory = new NodeFactoryV2();
            factory.AddNodeType("input_low", typeof(InputNode));

            var node = factory.Create("bla", "input_low");

            Assert.IsInstanceOfType(node, typeof(InputNode));
        }

        [TestMethod]
        public void NodeFactory_ShouldReturnOrNode()
        {
            var factory = new NodeFactoryV2();
            factory.AddNodeType("or", typeof(OrNode));

            var node = factory.Create("bla", "or");

            Assert.IsInstanceOfType(node, typeof(OrNode));
        }

        [TestMethod]
        public void NodeFactory_ShouldReturnNandNode()
        {
            var factory = new NodeFactoryV2();
            factory.AddNodeType("nand", typeof(NandNode));


            var node = factory.Create("bla", "nand");

            Assert.IsInstanceOfType(node, typeof(NandNode));
        }

        [TestMethod]
        public  void CircuitBuilder_addAndOperator_CircuitShouldHaveOperator()
        {
            var builder = new CircuitBuilderV2();

            builder.AddNode("NODE1", "AND");

            var op = builder.GetCircuit().Operators.Where(node => node.Key == "NODE1");

            Assert.AreEqual(1, op.Count());
            Assert.IsInstanceOfType(op.First(), typeof(AndNode));
        }

        [TestMethod]
        public void CircuitBuilder_addOrOperator_CircuitShouldHaveOperator()
        {
            var builder = new CircuitBuilderV2();

            builder.AddNode("NODE1", "OR");

            var op = builder.GetCircuit().Operators.Where(node => node.Key == "NODE1");

            Assert.AreEqual(1, op.Count());
            Assert.IsInstanceOfType(op.First(), typeof(OrNode));
        }

        [TestMethod]
        public void CircuitBuilder_addEdges_NodeShouldHaveEdge()
        {
            var builder = new CircuitBuilderV2();

            builder.AddNode("NODE1", "OR");
            builder.AddNode("NODE2", "AND");
            builder.AddNode("NODE3", "OR");
            builder.AddNode("NODE4", "OR");

            builder.AddEdge("NODE1", new string[]{ "NODE2", "NODE3", "NODE4"} );

            var node = builder.GetCircuit().Operators.Where(n => n.Key == "NODE1").First();

            
            Assert.AreEqual("NODE2", node.Outputs.ElementAt(0).Key);
            Assert.AreEqual("NODE3", node.Outputs.ElementAt(1).Key);
            Assert.AreEqual("NODE4", node.Outputs.ElementAt(2).Key);
        }

        [TestMethod]
        public void CircuitBuilder_addEdge_NodeShouldHaveEdge()
        {
            var builder = new CircuitBuilderV2();

            builder.AddNode("NODE1", "OR");
            builder.AddNode("NODE2", "AND");

            builder.AddEdge("NODE1", new string[] { "NODE2"});

            var node = builder.GetCircuit().Operators.Where(n => n.Key == "NODE1").First();


            Assert.AreEqual("NODE2", node.Outputs.ElementAt(0).Key);
        }
    }
}
