

namespace LiscovSubstitutionPrinciple
{

    public class Rectangle
    {

        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public Rectangle()
        {

        }
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {

        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    public class Program
    {

        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has Area {Area(rc)}");

            Rectangle sq = new Square();

            sq.Height = 5;

            Console.WriteLine($"{sq} has Area {Area(sq)}");

        }
    }
}