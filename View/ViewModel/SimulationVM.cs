﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Builders;
using Core.Models.V2;
using Parser;

namespace View.ViewModel
{
	public class SimulationVM
	{
		public ObservableCollection<InputNode> Inputs { get; set; }
		public ObservableCollection<InputNode> Outputs { get; set; }
		public string[] TestProp { get; set; }

		private FileParser parser;
		private CircuitBuilderV2 builder;
		private Simulator simulator;

		public SimulationVM()
		{
			parser = new FileParser();
			builder = new CircuitBuilderV2();
			simulator = new Simulator();
		}
	}
}
