using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blagajna
{
    public class Stavka
    {
        public String naziv { get; set; }
        public String proizvodjac { get; set; }
        public double cijena { get; set; }
        public String zadanaKolicina { get; set; }
        public double kupljenaKolicina { get; set; }
        public double zaPlatiti { get; set; }

        public Stavka()
        {

        }

        public Stavka(String naziv, String proizvodjac, String zadanaKolicina, double cijenaSPorezom, double kupljenaKolicina, double zaPlatiti) {
            this.naziv = naziv;
            this.proizvodjac = proizvodjac;
            this.cijena = cijenaSPorezom;
            this.zadanaKolicina = zadanaKolicina;
            this.kupljenaKolicina = kupljenaKolicina;
            this.zaPlatiti = zaPlatiti;
        }

        public string ToDelimitedString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(String.Format("{0} {1} {2} | {3} x {4}   {5}\n", this.naziv, this.proizvodjac, this.zadanaKolicina, this.cijena, this.kupljenaKolicina, this.zaPlatiti));
            return result.ToString();
        }

    }
}
