using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public abstract class Liste
    {
        public Node Head;
        public int size = 0;
        public abstract void DeleteFirst();
        public abstract void InsertFirst(Node yeniNode);
        public abstract void InsertPos(string isim, string soyisim, string telno, int koltukno);
        public abstract void DeletePos(string tel);
        public abstract Node GetElement(string tel);
        public abstract string Karsilastir(int girilenKoltukNo);
        public abstract string TelKontrol(string tel);
    }
}
