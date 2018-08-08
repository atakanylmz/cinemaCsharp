using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class IzleyiciListe : Liste
    {
        public override void DeleteFirst()
        {
            Node yeniBos = new Node();
            yeniBos.next = Head.next;
            Head = yeniBos;
            size--;
        }
        public override void DeletePos(string tel)
        {
            if (Head.telefon == tel)
                DeleteFirst();
            else
            {
                Node yeniBos = new Node();                
                Node gezici = Head;
                Node prev = null;
                while(gezici!=null)
                {
                    prev = gezici;
                    gezici = gezici.next;
                    if (gezici.telefon == tel)
                        break;
                }
                yeniBos.koltukNo = gezici.koltukNo;
                prev.next = yeniBos;
                yeniBos.next = gezici.next;
                gezici = null;
                size--;
            }           
        }
        public override Node GetElement(string tel)
        {
            Node gezici = Head;
            while (gezici != null)
            {
                if ((gezici.telefon) == tel)
                {
                    break;
                }
                gezici = gezici.next;                
            }
            return gezici;
        }
        public override void InsertFirst(Node yeni)
        {
            if (Head == null)
            {
                Head = yeni;
            }
            else
            {
                yeni.next = Head;
                Head = yeni;
            }                       
        }
        public override void InsertPos(string isim, string soyisim, string telno, int koltukno)
        {
            Node yeniNode = new Node();
            yeniNode.ad = isim;
            yeniNode.soyad = soyisim;
            yeniNode.telefon = telno;
            yeniNode.koltukNo = koltukno;
            if (koltukno == 1)
            {
                yeniNode.next = Head.next;
                Head = yeniNode;
            }
            else
            {
                Node gezici = Head;
                Node prev = null;
                    for (int i = 2; i <= koltukno; i++)
                    {
                        prev = gezici;
                        gezici = gezici.next;
                    }
                
                prev.next = yeniNode;
                yeniNode.next = gezici.next;
                gezici = null;
            }
            size++;           
        }
        public override string Karsilastir(int girilenKoltukNo)
        {
            Node gezici = Head;
            while(gezici!=null)
            {
                if (girilenKoltukNo == gezici.koltukNo && gezici.telefon!="")
                    return "dolu";
                gezici = gezici.next;
            }
            return "bos";
        }       
        public override string TelKontrol(string tel)
        {
            Node gezici = Head;
            while (gezici != null)
            {
                if (tel == gezici.telefon)
                    return "var";
                gezici = gezici.next;
            }
            return "yok";
        }
    }
}
