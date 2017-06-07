using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Output;

namespace Core.Models.V2
{
	public class OutputNode : Node, INotifyPropertyChanged
	{
		private int _value;
		public new int Value
		{
			get { return _value; }
			set
			{
				_value = SetValue(value);
				OnPropertyChanged("Value");
			}
		}

		public OutputNode(string key, string type) : base(key, type)
		{
		}

		public override void Process()
		{
			base.Process();
			Value = Inputs.First().Value;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
