using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Core;
using Core.Builders;
using Core.Models.V2;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using Parser;

namespace View.ViewModel
{
	public class SimulationVM : ViewModelBase
	{
		public Simulator Simulator { get; set; }
		public ICommand SelectCircuit { get; set; }
		public ICommand RunSimulation { get; set; }
		public string Notification { get; set; }

		private FileParser parser;
		private CircuitBuilderV2 builder;


		public SimulationVM()
		{
			parser = new FileParser();
			builder = new CircuitBuilderV2();
			Simulator = new Simulator();
			SelectCircuit = new RelayCommand(SelectCircuitExecute);
			RunSimulation = new RelayCommand(RunSimulationExecute);
			Notification = "Select a circuit and click Run simulation.";
		}

		private void SelectCircuitExecute()
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == true)
			{
				ICircuitDescription description = parser.Parse(dialog.FileName);
				Simulator.Circuit = builder.GetCircuit(description);
				Notification = $"{FormatFileName(dialog.FileName)} selected.";
				RaisePropertyChanged("Notification");
                //Simulator.Run();
                //RaisePropertyChanged("Simulator");
            }
		}

		private void RunSimulationExecute()
		{
			Simulator.Run();
            var errorNotification = Simulator.IsCircuitValid();
            if (errorNotification.Length == 0)
            {
                RaisePropertyChanged("Simulator");
            }
            else
            {
                Notification = errorNotification;
                RaisePropertyChanged("Notification");
            }
		}

		private string FormatFileName(string fileName)
		{
			string[] parts = fileName.Split('\\');
			return parts[parts.Length - 1];
		}
	}
}
