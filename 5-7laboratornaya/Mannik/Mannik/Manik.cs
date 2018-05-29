using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannik
{
    public class Manik
    {
        public string Name { get; set; }
        public double PhoneNumber { get; set; }
        public string Date { get; set; }
        public TypesManicure ServiceManicure { get; set; }
        public StyleManicure Manicure { get; set; }
        public List<string> addService { get; set; }
        static void Main(string[] args)
        {
        }
    }
    public class Service
    {
        public TypesManicure ServiceManicure { get; set; }
    }
    public enum TypesManicure
    {
        Manicure,
        Covering,
        Cut
    }
    public class Manicure
    {
        public StyleManicure ManicureStyle { get; set; }
    }
    public enum StyleManicure
    {
        однотипно,
        френч,
        градиент
    }
}
