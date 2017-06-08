using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Core.Builders;
using Core.Factories;
using Core.Models.V2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace UnitTest
{
    [TestClass]
    public class SimulatorTests
    {
        [TestMethod]
        public void Simulator_validCircuit_hasOutputs1and1()
        {
            var sim = new Simulator();
            var builder = new CircuitBuilderV2();

            builder.AddNode("input", "INPUT_HIGH");
            builder.AddNode("inputt", "INPUT_HIGH");
            builder.AddNode("NODE1", "OR");
            builder.AddNode("NODE2", "OR");
            builder.AddNode("NODE3", "NOT");
            builder.AddNode("output", "PROBE");
            builder.AddNode("outputt", "PROBE");

            builder.AddEdge("input", new string[] { "NODE1", "NODE2" });
            builder.AddEdge("inputt", new string[] { "NODE3" });
            builder.AddEdge("NODE3", new string[] { "NODE2" });
            builder.AddEdge("NODE2", new string[] { "output", "NODE1" });
            builder.AddEdge("NODE1", new string[] { "outputt" });

            var circuit = builder.GetCircuit();
            sim.Circuit = circuit;
            sim.Run();

            Assert.AreEqual(1, sim.Circuit.Outputs.First().Value);
            Assert.AreEqual(1, sim.Circuit.Outputs.Last().Value);
        }

        [TestMethod]
        public void Simulator_validCircuit_hasOutputs0and0()
        {
            var sim = new Simulator();
            var builder = new CircuitBuilderV2();

            builder.AddNode("input", "INPUT_HIGH");
            builder.AddNode("inputt", "INPUT_HIGH");
            builder.AddNode("NODE1", "AND");
            builder.AddNode("NODE2", "AND");
            builder.AddNode("NODE3", "NOT");
            builder.AddNode("output", "PROBE");
            builder.AddNode("outputt", "PROBE");

            builder.AddEdge("input", new string[] { "NODE1", "NODE2" });
            builder.AddEdge("inputt", new string[] { "NODE3" });
            builder.AddEdge("NODE3", new string[] { "NODE2" });
            builder.AddEdge("NODE2", new string[] { "output", "NODE1" });
            builder.AddEdge("NODE1", new string[] { "outputt" });

            var circuit = builder.GetCircuit();
            sim.Circuit = circuit;
            sim.Run();

            Assert.AreEqual(0, sim.Circuit.Outputs.First().Value);
            Assert.AreEqual(0, sim.Circuit.Outputs.Last().Value);
        }

        [TestMethod]
        public void Simulator_validCircuit_returnsValid()
        {
            var sim = new Simulator();
            var builder = new CircuitBuilderV2();

            builder.AddNode("input", "INPUT_HIGH");
            builder.AddNode("inputt", "INPUT_HIGH");
            builder.AddNode("NODE1", "AND");
            builder.AddNode("NODE2", "AND");
            builder.AddNode("NODE3", "NOT");
            builder.AddNode("output", "PROBE");
            builder.AddNode("outputt", "PROBE");

            builder.AddEdge("input", new string[] { "NODE1", "NODE2" });
            builder.AddEdge("inputt", new string[] { "NODE3" });
            builder.AddEdge("NODE3", new string[] { "NODE2" });
            builder.AddEdge("NODE2", new string[] { "output", "NODE1" });
            builder.AddEdge("NODE1", new string[] { "outputt" });

            var circuit = builder.GetCircuit();
            sim.Circuit = circuit;
            sim.Run();

            var not = sim.IsCircuitValid();

            Assert.AreEqual("", not);
        }

        [TestMethod]
        public void Simulator_InvalidCircuitMissingLinks_returnsInValid()
        {
            var sim = new Simulator();
            var builder = new CircuitBuilderV2();

            builder.AddNode("input", "INPUT_HIGH");
            builder.AddNode("inputt", "INPUT_HIGH");
            builder.AddNode("NODE1", "AND");
            builder.AddNode("NODE2", "AND");
            builder.AddNode("NODE3", "NOT");
            builder.AddNode("output", "PROBE");
            builder.AddNode("outputt", "PROBE");

            builder.AddEdge("input", new string[] { "NODE1", "NODE2" });
            builder.AddEdge("inputt", new string[] { "NODE3" });
            builder.AddEdge("NODE3", new string[] { "NODE2" });
            builder.AddEdge("NODE2", new string[] { "output", "NODE1" });
            //builder.AddEdge("NODE1", new string[] { "outputt" });

            var circuit = builder.GetCircuit();
            sim.Circuit = circuit;
            sim.Run();

            var not = sim.IsCircuitValid();

            Assert.AreNotEqual("", not);
        }

        [TestMethod]
        public void Simulator_InvalidCircuitInfiniteLoop_returnsInValid()
        {
            var sim = new Simulator();
            var builder = new CircuitBuilderV2();

            builder.AddNode("input", "INPUT_HIGH");
            builder.AddNode("inputt", "INPUT_HIGH");
            builder.AddNode("NODE1", "AND");
            builder.AddNode("NODE2", "AND");
            builder.AddNode("NODE3", "NOT");
            builder.AddNode("output", "PROBE");
            builder.AddNode("outputt", "PROBE");

            builder.AddEdge("input", new string[] { "NODE1", "NODE2" });
            builder.AddEdge("inputt", new string[] { "NODE3" });
            builder.AddEdge("NODE3", new string[] { "NODE2" });
            builder.AddEdge("NODE2", new string[] { "output", "NODE1" });
            builder.AddEdge("NODE1", new string[] { "outputt", "NODE3" });

            var circuit = builder.GetCircuit();
            sim.Circuit = circuit;
            sim.Run();

            var not = sim.IsCircuitValid();

            Assert.AreNotEqual("", not);
        }
    }
}
