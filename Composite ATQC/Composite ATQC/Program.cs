using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_ATQC
{
    abstract class Element
    {
        protected string name;
        public List<Element> nodes = new List<Element>();

        public Element(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public abstract void Print(string indent, bool last);
    }

    class Insertion : Element
    {

        public Insertion(string name) : base(name) {}

        public override void Print(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(name);

            for (int i = 0; i < nodes.Count; i++)
                nodes[i].Print(indent, i == nodes.Count - 1);
        }
    }

    class Program
    {
        public static void Implementation(Element node)
        {
            string newName;
            Console.WriteLine("You`re in {0} node", node.GetName());
            Console.WriteLine("Enter subnodes of current node. To finish enter empty line");
            newName = Console.ReadLine();
            if (newName == "")
            {
                return;
            }

            do
            {    
                node.nodes.Add(new Insertion(newName));
                newName = Console.ReadLine();
            } while (newName != "") ;

            foreach (Element elem in node.nodes)
            {
                Implementation(elem);
            }
        }

        static void Main(string[] args)
        {
            Element root = new Insertion("It Academy");
            Implementation(root);
            root.Print("", true);
            Console.ReadKey();
        }
    }
}
