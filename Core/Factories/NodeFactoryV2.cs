using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.V2;

namespace Core.Factories
{
	public class NodeFactoryV2
	{
		public Node Create(string key, string type)
		{
			Node node = null;
			switch (type.ToLower())
			{
				case ("not"):
					node = new NotNode(key, type);
					break;
				case ("and"):
					node = new AndNode(key, type);
					break;
				case ("or"):
					node = new OrNode(key, type);
					break;
                case ("nand"):
                    node = new NandNode(key, type);
                    break;
				case ("input_high"):
					node = new InputNode(key, type, 1);
					break;
				case ("input_low"):
					node = new InputNode(key, type, 0);
					break;
				case ("probe"):
					node = new OutputNode(key, type);
					break;
				default:
					break;
			}
			return node;
		}
	}
}
