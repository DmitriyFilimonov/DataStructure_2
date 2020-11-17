using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure_2Lib.DoubleLL
{
    class DoubleNode
    {
        public int Value { get; set; }
        public DoubleNode Next { get; set; }
        public DoubleNode Pre { get; set; }

        public DoubleNode()
        {
            
            Next = null;
            Pre = null;

        }

        public DoubleNode(int value)
        {
            Value = value;
            Next = null;
            Pre = null;
            
        }

        public DoubleNode(DoubleNode doubleNode)
        {
            Next = doubleNode.Next;
            Pre = doubleNode.Pre;

            Value = doubleNode.Value;
        }
    }
}
