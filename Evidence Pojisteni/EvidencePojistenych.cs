﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_Pojisteni
{
    internal class EvidencePojistenych
    {
        private DatabazePojistencu databazePojistencu = new DatabazePojistencu();
        
        
        private string ZjistiJmeno()
        {
            Console.WriteLine("Zadejte jméno pojištěného:");
            string jmeno;
            while (string.IsNullOrWhiteSpace(jmeno = Console.ReadLine()))
                Console.WriteLine("Zadejte jméno znovu:");
            return jmeno;
        }

        
        private string ZjistiPrijmeni()
        {
            Console.WriteLine("Zadejte příjmení pojištěného:");
            string prijmeni;
            while (string.IsNullOrWhiteSpace(prijmeni = Console.ReadLine()))
                Console.WriteLine("Zadejte příjmení znovu:");
            return prijmeni;
        }

        
        private int ZjistiVek()
        {
            Console.WriteLine("Zadejte věk pojištěného:");
            int vek;

            while (!int.TryParse(Console.ReadLine(), out vek))
            {
                Console.WriteLine("Zadejte věk znovu");
            }

            return vek;
        }

        
        private int ZjistiTelefonniCislo()
        {
            Console.WriteLine("Zadejte telefonní číslo pojištěného:");
            int telCislo;

            while (!int.TryParse(Console.ReadLine(), out telCislo))
            {
                Console.WriteLine("Zadejte telefonní číslo znovu");
            }

            return telCislo;
        }

       
        public void PridatNovehoPojistence()
        {

            string jmeno = ZjistiJmeno();
            string prijmeni = ZjistiPrijmeni();
            int vek = ZjistiVek();
            int telCislo = ZjistiTelefonniCislo();

            databazePojistencu.PridatNovehoPojistence(jmeno, prijmeni, vek, telCislo);

        }

      
        public void VypsatVsechnyPojistene()
        {

            List<Pojistenec> pojistenci = databazePojistencu.SeznamPojistencu();
            foreach (Pojistenec pojisteny in pojistenci)
            {
                Console.WriteLine(pojisteny);
            }
            
        }

       
        public void VyhledatPojisteneho()
        {
            string jmeno = ZjistiJmeno();
            string prijmeni = ZjistiPrijmeni();


            List<Pojistenec> pojistenci = databazePojistencu.VyhledatPojisteneho(jmeno, prijmeni);
            if (pojistenci.Count() > 0)
            {
                Console.WriteLine();
                foreach (Pojistenec pojisteny in pojistenci)
                    Console.WriteLine(pojisteny);
            }
            else
                Console.WriteLine("Nebyly nalezeny žádné záznamy.");
        }

        public void VypisEvidencePojistenych()
        {
            char volba = '0';
            while (volba != '4')
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("Evidence pojištěných");
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.WriteLine("Vyber si akci:");
                Console.WriteLine("1 - Přidat nového pojištěného");
                Console.WriteLine("2 - Vypsat všechny pojištěné");
                Console.WriteLine("3 - Vyhledat pojištěného");
                Console.WriteLine("4 - Ukončit aplikaci");
                volba = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (volba)
                {
                    case '1':
                        PridatNovehoPojistence();
                        Console.WriteLine();
                        Console.WriteLine("Data byla uložena. Pokračujte libovolnou klávesou...");
                        break;
                    case '2':
                        VypsatVsechnyPojistene();
                        Console.WriteLine();
                        Console.WriteLine("Pokračujte libovolnou klávesou...");
                        break;
                    case '3':
                        VyhledatPojisteneho();
                        Console.WriteLine();
                        Console.WriteLine("Pokračujte libovolnou klávesou...");
                        break;
                    case '4':
                        Console.WriteLine();
                        Console.WriteLine("Libovolnou klávesou ukončíte aplikaci...");
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Neplatná volba, stiskněte libovolnou klávesu a opakujte volbu.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
