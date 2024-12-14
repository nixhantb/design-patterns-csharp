
namespace InterfaceSegregationPrinciple{

    public class Document{

    }

    public interface IMachine{
        void Print(Document d);
        void Scan(Document d);
        void Tax(Document d);
    }

    public interface IPrinter{
        void Print(Document d);
    }

    public interface IScanner{
        void Scan(Document d);
    }

    public interface IMultiFunctionMachine : IScanner, IPrinter{

    }

    public class MultiFunctionMachine: IMultiFunctionMachine{

        public void Print(Document d){
            Console.WriteLine("Printing Documents");
        }

        public void Scan(Document d){
            Console.WriteLine("Printing Documents");
        }
    }

    public class Program{
        static void Main(string[] args){
            Document d = new Document();
            IPrinter printer = new MultiFunctionMachine();
            printer.Print(d);
            IScanner scanner = new MultiFunctionMachine();
            scanner.Scan(d);
        }
    }
}