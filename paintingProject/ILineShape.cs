using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paintingProject
{
    public interface ILineShape
    {
        void changeShape();

    }

    public class Line : ILineShape
    {
        public void changeShape()
        {
            Console.WriteLine(Shape.Line);
        }
    }

    public class Horizontal : ILineShape
    {
        public void changeShape()
        {
            Console.WriteLine(Shape.Horizontal);
        }
    }

    public class Vertical : ILineShape
    {
        public void changeShape()
        {
            Console.WriteLine(Shape.Vertical);
        }
    }
}