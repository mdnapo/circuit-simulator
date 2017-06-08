using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Models.V2;

namespace UnitTest
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod()]
        public void AndNode_WithInputs1and1_ShouldReturn1()
        {
            Node andNode = new AndNode("ab", "and");
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });

            andNode.Process();
            var outputValue = andNode.Value;

            Assert.AreEqual(1, outputValue);
        }

        [TestMethod]
        public void AndNode_WithInputs1and0_ShouldReturn0()
        {
            Node andNode = new AndNode("ab", "and");
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });

            andNode.Process();
            var outputValue = andNode.Value;

            Assert.AreEqual(0, outputValue);
        }

        [TestMethod]
        public void AndNode_WithInputs0and0_ShouldReturn0()
        {
            Node andNode = new AndNode("ab", "and");
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });

            andNode.Process();
            var outputValue = andNode.Value;

            Assert.AreEqual(0, outputValue);
        }

        [TestMethod]
        public void AndNode_WithInputs0and0and0_ShouldReturn0()
        {
            Node andNode = new AndNode("ab", "and");
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });

            andNode.Process();
            var outputValue = andNode.Value;

            Assert.AreEqual(0, outputValue);
        }

        [TestMethod]
        public void AndNode_WithInputs1and1and1and1and1_ShouldReturn1()
        {
            Node andNode = new AndNode("ab", "and");
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });

            andNode.Process();
            var outputValue = andNode.Value;

            Assert.AreEqual(1, outputValue);
        }

        [TestMethod]
        public void AndNode_WithInputs1and0and1and1and1_ShouldReturn0()
        {
            Node andNode = new AndNode("ab", "and");
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });

            andNode.Process();
            var outputValue = andNode.Value;

            Assert.AreEqual(0, outputValue);
        }

        [TestMethod]
        public void AndNode_WithInputs1and1and1and0and0_ShouldReturn0()
        {
            Node andNode = new AndNode("ab", "and");
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 1 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });
            andNode.AddInputNode(new AndNode("ab", "and") { Value = 0 });

            andNode.Process();
            var outputValue = andNode.Value;

            Assert.AreEqual(0, outputValue);
        }

        [TestMethod]
        public void NotNode_WithInput1_ShouldReturn0()
        {
            Node notNode = new NotNode("ab", "and");
            notNode.AddInputNode(new NotNode("ab", "and") { Value = 1 });

            notNode.Process();
            var outputValue = notNode.Value;

            Assert.AreEqual(0, outputValue);
        }

        [TestMethod]
        public void NotNode_WithInput0_ShouldReturn1()
        {
            Node notNode = new NotNode("ab", "and");
            notNode.AddInputNode(new NotNode("ab", "and") { Value = 0 });

            notNode.Process();
            var outputValue = notNode.Value;

            Assert.AreEqual(1, outputValue);
        }

        [TestMethod]
        public void OrNode_WithInputs0and0_ShouldReturn0()
        {
            Node notNode = new OrNode("ab", "and");
            notNode.AddInputNode(new OrNode("ab", "and") { Value = 0 });
            notNode.AddInputNode(new OrNode("ab", "and") { Value = 0 });

            notNode.Process();
            var outputValue = notNode.Value;

            Assert.AreEqual(0, outputValue);
        }

        [TestMethod]
        public void OrNode_WithInputs0and1_ShouldReturn1()
        {
            Node notNode = new OrNode("ab", "and");
            notNode.AddInputNode(new OrNode("ab", "and") { Value = 0 });
            notNode.AddInputNode(new OrNode("ab", "and") { Value = 1 });

            notNode.Process();
            var outputValue = notNode.Value;

            Assert.AreEqual(1, outputValue);
        }

        [TestMethod]
        public void OrNode_WithInputs1and1_ShouldReturn1()
        {
            Node notNode = new OrNode("ab", "and");
            notNode.AddInputNode(new OrNode("ab", "and") { Value = 1 });
            notNode.AddInputNode(new OrNode("ab", "and") { Value = 1 });

            notNode.Process();
            var outputValue = notNode.Value;

            Assert.AreEqual(1, outputValue);
        }

        [TestMethod]
        public void NandNode_WithInputs0and0_ShouldReturn1()
        {
            Node nandNode = new NandNode("ab", "and");
            nandNode.AddInputNode(new NandNode("ab", "and") { Value = 0 });
            nandNode.AddInputNode(new NandNode("ab", "and") { Value = 0 });

            nandNode.Process();
            var outputValue = nandNode.Value;

            Assert.AreEqual(1, outputValue);
        }

        [TestMethod]
        public void NandNode_WithInputs1and0_ShouldReturn1()
        {
            Node nandNode = new NandNode("ab", "and");
            nandNode.AddInputNode(new NandNode("ab", "and") { Value = 1 });
            nandNode.AddInputNode(new NandNode("ab", "and") { Value = 0 });

            nandNode.Process();
            var outputValue = nandNode.Value;

            Assert.AreEqual(1, outputValue);
        }

        [TestMethod]
        public void NandNode_WithInputs1and1_ShouldReturn0()
        {
            Node nandNode = new NandNode("ab", "and");
            nandNode.AddInputNode(new NandNode("ab", "and") { Value = 1 });
            nandNode.AddInputNode(new NandNode("ab", "and") { Value = 1 });

            nandNode.Process();
            var outputValue = nandNode.Value;

            Assert.AreEqual(0, outputValue);
        }
    }
}
