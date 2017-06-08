using System.IO;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using View.ViewModel;

namespace View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Initializes a new instance of the MainWindow class.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			Closing += (s, e) => ViewModelLocator.Cleanup();
		}

		private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			SimulationVM vm = SimpleIoc.Default.GetInstance<SimulationVM>();
			vm.RunSimulation();

		}
	}
}