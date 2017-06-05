﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.V2;

namespace Core.Factories
{
    public class NodeFactoryV2
    {
        public NodeV2 Create(string key, string type)
        {
            NodeV2 node = null;
            switch (type.ToLower())
            {
                case ("not"):
                    node = new NotNode(key);
                    break;
                case ("and"):
                    node = new AndNode(key);
                    break;
                case ("or"):
                    node = new OrNode(key);
                    break;
                case ("input_high"):
                    node = new InputNode(key, 1);
                    break;
                case ("input_low"):
                    node = new InputNode(key, 0);
                    break;
                case ("probe"):
                    node = new OutputNode(key);
                    break;
                default:
                    break;
            }
            return node;
        }
    }
}
