using EntityFrameworkLabb3.Data;
using EntityFrameworkLabb3.Models;
using Microsoft.EntityFrameworkCore;

bool menu = true;
    while (true)
    {
        Console.WriteLine("1: Se Lagersaldo"); //Check
        Console.WriteLine("2: Ändra Lagersaldo"); //Check
        Console.WriteLine("3: Lägg till ny bok"); //Check
        Console.WriteLine("4: Lägg till författare"); //Check
        Console.WriteLine("5: Visa tabeller");
        Console.WriteLine("Q: Exit");
        switch (Console.ReadLine().ToLower())
        {
            case "1":
            using (var context = new Lab2BookStoresContext())
            {
                var db = from b in context.Böcker
                         from c in context.Lagersaldo
                         from d in context.Butiker
                             where b.Isbn == c.BöckerIsbn
                             where c.ButikerId == d.Id
                             select new
                             {
                                 bok = b.Titel,
                                 saldo = c.Antal,
                                 butik = c.Butiker.Namn,
                             };

                    Console.WriteLine("Lagersaldo:");
                    foreach (var b in db)
                    {
                        Console.WriteLine("Butik: {0}", b.butik);
                        Console.WriteLine("Titel:{0}", b.bok);
                        Console.WriteLine("Antal: {0}", b.saldo);
                    }
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    Console.Clear();
            }
                    break;

        case "2":
            using (var context = new Lab2BookStoresContext())
            {
               
                foreach (var b in context.Böcker)
                {
                    Console.WriteLine("(" + b.Isbn + ")" + b.Titel);
                }
                Console.WriteLine("Ange BokISBN: ");
                string bokISBN = Console.ReadLine();
                foreach (var g in context.Butiker)
                {
                    Console.WriteLine("(" + g.Id + ")" + " " + g.Namn);
                }
                Console.WriteLine("Ange en butiksID: ");
                    int butikID = int.Parse(Console.ReadLine());
                Console.WriteLine("Vill du lägga till(1) eller ta bort (2)?");
                    int? choice = int.Parse(Console.ReadLine());
                    int saldoChange;
                if (choice == 1)
                {
                    Console.WriteLine("Lägg till Lagersaldo: ");
                        saldoChange = int.Parse(Console.ReadLine());
                    var searcher = context.Lagersaldo.Where(x => x.BöckerIsbn == bokISBN && x.ButikerId == butikID).FirstOrDefault();
                    if (searcher != null)
                    {
                        searcher.Antal += saldoChange;
                        context.SaveChanges();
                    }
                    else
                    {
                        var newBook = new Lagersaldo
                        {
                            BöckerIsbn = bokISBN,
                            ButikerId = butikID,
                            Antal = saldoChange
                        };
                        context.Add(newBook);
                        context.SaveChanges();
                    }
                    
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Ta bort Lagersaldo: ");
                    saldoChange = int.Parse(Console.ReadLine());
                    var removeBooks = context.Lagersaldo.Where(x => x.BöckerIsbn == bokISBN && x.ButikerId == butikID).FirstOrDefault();
                    removeBooks.Antal -= saldoChange;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
                
               
            break;
        case "3":
            using (var context = new Lab2BookStoresContext())
            {
                Console.WriteLine("Ange en Titel: ");
                string? title = Console.ReadLine();
                Console.WriteLine("Ange Språk: ");
                string? language = Console.ReadLine();
                Console.WriteLine("Ange pris på bok: ");
                decimal? price = Decimal.Parse(Console.ReadLine());
                Console.WriteLine("Välj befintlig författare(Siffror): ");
                foreach (var a in context.Författare)
                {
                    Console.WriteLine("(" +  a.Id + ")" + " " + a.Förnamn + " " + a.Efternamn);
                }
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine("Ange ett ISBN (XXXXXXXXX-X): ");
                string? isbnNr = Console.ReadLine();
                if (isbnNr.Length == 11 && isbnNr.Contains('-'))
                {
                    AddBöcker(title, language, price, input, isbnNr);
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                    continue;
                }
            }
            break;

            case "4":
            Console.WriteLine("Förnamn: ");
                string? firstName = Console.ReadLine();
            Console.WriteLine("Efternamn: ");
                string? lastName = Console.ReadLine();
            AddAuthor(firstName, lastName);
            Console.WriteLine("{0} {1} Added!",firstName,lastName );
            Console.ReadKey();
            Console.Clear();

            break;

        case "5":
            VisaTabeller();
            break;
        case "q": 
                Environment.Exit(0);
                break;
        }
    }

void VisaTabeller()
{
    using (var context = new Lab2BookStoresContext())
    {
        var showAllAuthors = context.Författare.Select(x => x.Förnamn + " " + x.Efternamn)
            .ToList();
        Console.WriteLine("Författare: ");
        foreach (var f in context.Författare)
        {
            Console.WriteLine(f.Förnamn + " " + f.Efternamn);
        }
        var showAllBooks = context.Böcker.Select(z => z.Titel)
            .ToList();
        Console.WriteLine("Böcker: ");
        foreach (var b in context.Böcker)
        {
            Console.WriteLine(b.Titel);
        }
        Console.WriteLine("Press any key to Continue...");
        Console.ReadKey();
        Console.Clear();
    }
}
void AddAuthor(string? firstName, string? lastName)
{
    using (var context = new Lab2BookStoresContext())
    {
        var newAuthor = new Författare
        {
            Förnamn = firstName,
            Efternamn = lastName,
            Födelsedatum = DateTime.Now
        };
        context.Författare.Add(newAuthor);
        context.SaveChanges();
       
    }
}
void AddBöcker(string? title, string? language, decimal? price, int input, string? isbnNr)
{
    using (var context = new Lab2BookStoresContext())
    {
        var newBook = new Böcker
        {
            Isbn = isbnNr,
            FörfattareId = input,
            Titel = title,
            Språk = language,
            Pris = price,
            Utgivningsdatum = DateTime.Now
        };
        context.Böcker.Add(newBook);
        context.SaveChanges();
    }
}



