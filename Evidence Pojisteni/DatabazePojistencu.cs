using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_Pojisteni
{
    internal class DatabazePojistencu
    {
        private List<Pojistenec> pojistenci = new List<Pojistenec>();

       
        public void PridatNovehoPojistence(string jmeno, string prijmeni, int vek, int telCisl)
        {
            pojistenci.Add(new Pojistenec(jmeno, prijmeni, vek, telCisl));
        }

        
        public List<Pojistenec> VyhledatPojisteneho(string jmeno, string prijmeni)
        {
            List<Pojistenec> nalezeniPojistenci = new List<Pojistenec>();

            foreach (Pojistenec pojisteny in pojistenci)
            {
                if ((pojisteny.PrijmeniPojisteneho.ToLower() == prijmeni.ToLower() && (pojisteny.JmenoPojisteneho.ToLower() == jmeno.ToLower())))
                    nalezeniPojistenci.Add(pojisteny);
            }
            
            return nalezeniPojistenci;
        }
       
        public List<Pojistenec> SeznamPojistencu()
        {
            return pojistenci;
        }


    }
}
