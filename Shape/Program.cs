using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{

    public interface IDrawObject
    {
        void DrawMe();
    }

    public class Blood : IDrawObject
    {
        public virtual void DrawMe()
        {

        }
    }

    // SHAPE CLASS
    public abstract class Shape : IDrawObject
    {
        public const double PI = Math.PI;
        protected double x;
        protected double y;
        private int myInt;

        public virtual double Area()
        {
            return x * y;
        }

        public abstract void DrawMe();

        public Shape()
        {

        }

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    // CIRCLE CLASS INHERITS SHAPE
    public class Circle : Shape
    {
        public int myInt;
        public override double Area()
        {
            return PI * this.x * this.x;
        }

        public override void DrawMe()
        {
            // code that specifically draws a circle
        }

        public Circle(double r) : base(r, 0)
        {

        }
    }

    // SPHERE CLASS INHERITS SHAPE
    public class Sphere : Shape
    {
        public override double Area()
        {
            return 4 * PI * this.x * this.x;
        }

        public override void DrawMe()
        {
            // code that specifically draws a sphere
        }

        public Sphere(double r) : base (r, 0)
        {

        }
    }

    // CYLINDER CLASS INHERITS SHAPE
    public class Cylinder : Shape
    {
        public override double Area()
        {
            return 2 * PI * this.x * this.x + 2 * PI * this.x * this.y;
        }

        public override void DrawMe()
        {
            // code that specifically draws a cylinder
        }

        public Cylinder(double r, double h) : base(r, h)
        {
            
        }
    }

    // RECTANGLE CLASS INHERITS SHAPE
    public class Rectangle : Shape
    {
        public bool IsSquare
        {
            get
            {
                return (this.x == this.y);
            }
        }

        public override void DrawMe()
        {
            // code that specifically draws a rectangle
        }

        public Rectangle(double w, double h) : base (w, h)
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyMethod();

            Circle circle = new Circle(5.5);
            Cylinder cylinder = new Cylinder(3, 6);
            Rectangle rectangle = new Rectangle(1, 2);
            Blood blood = new Blood();

            Circle circle2;
            circle2 = circle;
            circle2.myInt = 1;

            Shape shape;
            shape = rectangle;
            shape.DrawMe();
            shape.Area();
            // shape.IsSquare;

            IDrawObject drawObject;
            drawObject = blood;
            drawObject.DrawMe();

            drawObject = circle;
            drawObject.DrawMe();


            DrawObject(circle);
            DrawObject(cylinder);
            DrawObject(blood);
        }

        static void DrawObject(IDrawObject drawObject)
        {
            drawObject.DrawMe();
        }

        static void PrintAreaOfShape(Shape shape)
        {
            // if (shape.GetType() == typeof(Circle))
            if (shape is Circle)
            {
                Console.WriteLine("Your shape is a circle!");
            }

            if (shape.GetType() == typeof(Rectangle))
            {
                Rectangle r;
                r = (Rectangle)shape;

                if (r.IsSquare)
                {
                    Console.WriteLine("Your shape is a square!");
                }
            }

            if (shape is IDrawObject)
            {
                IDrawObject drawObject = (IDrawObject)shape;
                drawObject.DrawMe();
            }

            Console.WriteLine("The area is: " + shape.Area());
        }

        static void MyMethod()
        {

        }
    }
}
