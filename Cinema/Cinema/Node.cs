using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
     public class Node
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon { get; set; }
        public int koltukNo { get; set; }
        public Node next;
    }
}
