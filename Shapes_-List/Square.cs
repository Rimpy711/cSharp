using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes__List
{
    //[Serializable]
    public class Square : Shape
    {
        public double Size { set; get; }

        public override string Color { get => base.Color; set => base.Color = value; }
        public override double Area => Size * Size;
        public override string Name => GetType().Name;
    }

}
