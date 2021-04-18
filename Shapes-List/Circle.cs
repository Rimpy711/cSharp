using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes_List
{

    [Serializable]
    public class Circle : Shape
    {
        public double Radius { set; get; }

        public override string Color { get => base.Color; set => base.Color = value; }
        public override double Area => Math.PI * (Radius * Radius);
        public override string Name => GetType().Name;
    }

}
