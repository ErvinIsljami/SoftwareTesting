using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_ConvertorDemo.Test
{
    //Dekorator [TestFixture] koji omogućava da kompajler klasu MassConvertorTest prepoznaje kao testnu klasu
    //Bez njega, svaka metoda u okviru klase MassConvertorTest ne bi bila tumačena kao test
    //Pokretanje testova: Test -> Run -> All Tests
    //Testna klasa treba da ukazuje na klasu iz projekta koju testira (u ovom slučaju to je MassConvertor)
    [TestFixture]
    class MassConvertorTest
    {
        //Dekorator [Test] omogućava da se sama metoda tumači kao test, odnosno da se može pokretati odvojeno od ostatka projekta, kao testna metoda
        //Najjednostavniji tip unit testova. Naziv same testne metode treba da ukaže na semantiku testa, odnosno šta se testom proverava
        [Test]
        public void Convert_Success()
        {
            MassConverter mass = new MassConverter(); //Za testiranje metode Convert iz klase MassConvertor, potreban je objekat te klase s obzirom na to da metoda nije statička
            double result = mass.Convert(10); //Metodi Convert prosleđuje se proizvoljan broj (u ovom primeru će biti broj 10)
            Assert.AreEqual(4.5351473922902494d, result); //Klasa Assert omogućava pozivanje velikog broja statičkih metoda koje služe za testiranje. Metoda AreEqual prima dva parametra: očekivanu vrednost i stvarnu vrednost (dobijenu pozivom funkcije Convert).
        }

        //Test prikazuje jednostavan primer testiranja graničnih slučajeva aplikacije, odnosno kako će se aplikacija ponašati kada se kao input prosledi slovo
        //Semantika naziva metode treba da ukazuje šta očekujemo da test proveri
        [Test]
        public void Convert_ExpectedFormatException()
        {
            MassConverter mass = new MassConverter();
            //Metoda Throws klase Assert, zahteva da se definiše tip Exceptiona koji se očekuje. U slučaju ovog primera, to je System.Format Exception.
            //Throws metoda sastoji se iz dva dela: preambule - koja u ovom primeru predstavlja prazne zagrade pre strelice (=>) i u preambuli se mogu pozivati metode ili setovati promenljive koje će kasnije uticati na samo hvatanje Exceptiona
            //Drugi deo Throws metode (sa desne strane strelice - =>) obuhvata poziv metode koja treba da podigne Exception. U ovom primeru, to je poziv metode Convert i prosleđivanje slova kao inputa metode 
            Assert.Throws<System.FormatException>(() => mass.Convert(double.Parse("s")));
        }

        //Dekorator [TestCase] ukazuje da je reč o parametrizovanom testu. Za razliku od dekoratora [Test], on omogućava da se u okviru njega proslede vrednosti parametra koji će se kasnije koristiti u telu testne metode
        //Dekorator [TestCase] takođe omogućava da se za jednu metodu pokrene više testova, odnosno onoliko testova koliko imamo [TestCase] dekoratora iznad same metode (u ovom primeru biće pokrenuta dva testa nad jednom metodom)
        [TestCase(10, 4.5351473922902494d)]
        [TestCase(0, 0)]
        //Parametri prosleđeni u okviru [TestCase] dekoratora prihvataju se u potpisu same metode
        //U ovom primeru, parametar sa vrednošću 4.5351473922902494d biće smešten u promenljivu expectedValue, dok će parametar sa vrednošću 10 biti smešten u promenljivu input
        //Suština parametrizovanih testova je korišćenje tih parametara u daljem telu testne metode
        //S obzirom na to da ova testna metoda void, ovaj tip parametrizovanih testova je bez povratne vrednosti
        public void Convert_Success_Params(int input, double expectedValue)
        {
            MassConverter mass = new MassConverter();
            double result = mass.Convert(input); //Umesto prosleđenog broja (kao u prvom testu u okviru ove klase), prosleđuje se promenljiva dobijena kroz potpis metode
            Assert.AreEqual(expectedValue, result); //Koriščenje klase Assert i neke od njenih metoda jer je reč o parametrizovanim testovima bez povratne vrednosti
        }

        //S obzirom na dekorator [TestCase], i ovaj test spada u grupu parametrizovanih testova
        //Testna metoda u ovom slučaju ima povratni vrednost, tako da ovaj test spada u grupu parametrizovanih testova sa povratnom vrednošću
        //Testni property ExpectedResult prihvata vrednost sa kojom će se povratna vrednost metode proveravati
        [TestCase(10, ExpectedResult = 4.5351473922902494d)]
        public double Convert_Success_ParamsWithReturnStatement(int input)
        {
            MassConverter mass = new MassConverter();
            return mass.Convert(input); //Povratna vrednost koja mora biti identična vrednosti u okviru property-a ExpectedResult da bi test prošao
        }
    }
}
