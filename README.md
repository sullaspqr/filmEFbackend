# Projekt alapok:
Egyszerű Entity Framework, ami a dotnet 8.0.2-es verziót használja.

# Nuget Package Manager:

A package-ok közül a legfontosabb a Pomelo.EntityFrameworkCore.MySql 8.0.2,
valamint a Microsoft.EntityFrameworkCore és Microsoft.EntityFrameworkCore.Tools
szintén 8.0.2-es változattal fut!
Szükséges még a működő változathoz a Swashbuckle.AspNetCore, valamint az ehhez
tartozó csomagok: Swashbuckle.AspNetCore.Swagger, Swashbuckle.AspNetCore.SwaggerGen és
Swashbuckle.AspNetCore.SwaggerUI, mindháromból a "legfrissebb" 7.1.0 
(a jövőben a Swashbuckle-t nem támogatja a 9.0 dotnet, ezért a projektekbe nem teszi be
automatikusan, helyette jön a Scalar, ami hasonló tool, mint a Swagger)

# Adatbázis import + Scaffold:

Importálva az adatbázist filmapp db, film táblájába, le tudjuk scaffold-olni utána
a következő kóddal:
dotnet ef dbcontext scaffold "Server=localhost;Database=filmapp;User=root;Password=;"
Pomelo.EntityFrameworkCore.MySql --output-dir Models --context-dir Data 
--context FilmContext --force

feltételezve, hogy üres root-al használjuk az adatbázist! 
Production esetén ügyeljünk az adatbázis hozzáférés connection string-ként való ki-
exportálására, amit ne publikáljunk az Interneten, különben bárki hozzáfér az
adatainkhoz és esetleg drop-olhatja az egész adatbázist!
