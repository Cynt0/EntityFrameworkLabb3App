# EntityFrameworkLabb3App

För att komma åt databasen så ska Lab2BookStores.bak importeras till SSMS där du får tillgång till all dess data och tabeller när den importerats.

Detta gör genom att

1.Högerklicka på "Databases" mappen i SSMS och klickar på "Restore Database"
2. Klicka sedan på Device och sen på "..." knappen.
3.Tryck sedan på Add och leta sedan upp filen i den mappen du har sparat den i.
4. Klicka sedan på OK och sedan OK igen
5. Sedan ska databasen finnas i SQL Server Object Explorer i Visual studio.

För att sedan få tillgång till den i VS så måste du
1.Klicka på din SQL server i SQL Server explorer
2.Klicka på "Lab2BookStores"
3.Högerklicka och sedan properties
4.Leta upp "Connection String" och kopiera den genom "CTRL + C"
5.Lokalisera in i Data > Lab2BookStoresContext och gå till rad 40 och klista in connection strängen.

Sedan är det bara att tuta och köra! 😎
