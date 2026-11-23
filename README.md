# Softwar_Tools_Y3_iFruitVersionControl
VersionControl for the 3rd year  Software Tools - 43876 (SWDV71004)

# iBlendit - smoothie truck app

version control for the 3rd year software tools module - 43876 (SWDV71004)

iBlendit is a windows desktop app for running a smoothie truck. you take orders at the counter, the orders go into a queue for whoever is making them, stock gets taken off automatically when an order goes through, and you can see how much money the truck made on the revenue page.

made by team iFruit:
- Jan Arno Coetzer
- Ryan Lock
- Jack O Mahoney

## what it does

- **menu page** - shows all the smoothies as cards with their category colour, price and ingredients. you click them to build up the current order and it warns you if something is low or out of stock
- **orders page** - open orders show up as tickets, you mark them done when they're made and they move over to completed with the time it took
- **recipe page** - add, edit and delete recipes. you can change the name, category and ingredients. if you add an ingredient that doesn't exist yet it gets created in stock with 0 quantity
- **stock page** - see what's in stock and add or remove stock (it converts units for you e.g. g to kg)
- **revenue page** - takes the completed orders and shows totals, a line chart and which blends sell the most. everything is in euro

## How it's built

it's c# on .net 10 with windows forms. we split it up into layers so the ui isn't doing everything itself:
SmoothieTruckApp/
Front-End/ all the forms, pages and custom controls (cards, rows, charts)
Services/ business logic - stock, queue, revenue, recipes, input checks
Repositories/ reading and writing menu items, orders, recipes and stock
Models/ plain classes like Order, MenuItem, Recipe, StockItem
DataBaseContext/ our own small file based database
DataBase/DB_Tables the actual table files the app loads
SmoothieTruckApp.Tests/ xunit tests

### The database

we wrote our own little database instead of using sql. each table is a text file with a schema line at the top and then one row per line, like this:
item_index PK:INTEGER | name:STRING | price:DECIMAL | categoryname:STRING | categorycolor:STRING
1|Tropical Sunrise|9.50|Fruit|#f5b244

it supports INTEGER, DECIMAL, STRING and BOOLEAN columns and primary keys. the actual file reading and writing goes through `IStorageProvider`, so there's a `FileStorageProvider` for the real app and an `InMemoryStorageProvider` for the tests so they don't touch the real files. writes are done safely so a failed save doesn't wipe a table.

the tables are:
- `item_table` - the menu items
- `recipe_table` - which ingredients go in which smoothie
- `stock_table` - ingredients and how much we have
- `ordered_items_table` - every order and the items in it
- `income_table` - income records

## Running it

you need windows and the .net 10 sdk (or visual studio 2022 / 2026 with the .net desktop workload)
git clone https://github.com/JanArnoCoetzer/Softwar_Tools_Y3_iFruitVersionControl.git
cd Softwar_Tools_Y3_iFruitVersionControl
dotnet build SmoothieTruckApp/SmoothieTruckApp.slnx
dotnet run --project SmoothieTruckApp/SmoothieTruckApp.csproj

or just open `SmoothieTruckApp/SmoothieTruckApp.slnx` in visual studio and hit start.

if you just want to use it, grab the latest zip from the [releases page](https://github.com/JanArnoCoetzer/Softwar_Tools_Y3_iFruitVersionControl/releases), unzip it and run `SmoothieTruckApp.exe`. it's self contained so you don't need .net installed.

## Tests

there's around 110 xunit tests covering the database (schemas, rows, serializers, storage providers, boolean columns, safe saves) and the services (stock, queue, admin, revenue, order totals, order completion).
dotnet test SmoothieTruckApp.Tests/SmoothieTruckApp.Tests.csproj


with coverage:
dotnet test SmoothieTruckApp.Tests/SmoothieTruckApp.Tests.csproj --collect "XPlat Code Coverage" --settings SmoothieTruckApp.Tests/coverage.runsettings


the Front-End folder, `Program.cs` and `Properties` are left out of coverage because they're winforms designer and ui code. the logic that matters lives in Services, Repositories and DataBaseContext so that's what we test.

## pipeline (ci/cd)

everything runs on azure pipelines from `azure-pipelines-1.yml`. it kicks off on every push to main and on every pull request into main.

**Build_And_Test stage**
1. installs .net 10
2. starts the sonarcloud scan
3. builds the solution in release
4. runs the unit tests and collects code coverage
5. publishes the coverage report to azure devops
6. finishes the sonarcloud analysis (code smells, bugs, duplication, coverage)
7. publishes the app as a self contained win-x64 build, copies the db tables in and zips it up as the `iBlendit` artifact

**Deploy stage** (only on main and only if the build passed)
1. publishes the zip to our azure artifacts feed (`iFruitStudio/iblendit-releases`) as version `1.0.<build id>`
2. creates a github release with the zip and a changelog

## How we work (branching)

we use feature branches off main, kind of like github flow:

- `main` is always meant to be working and is what gets released
- every new feature or fix gets its own branch, e.g. `orders-page`, `bugfix`, `tests`, `release-pipeline`, `improve-recipe-editing`
- when it's done you open a pull request into main
- the pipeline has to pass on the pr and someone else on the team has to approve it before it can be merged
- main is protected so nobody can push straight to it

we went with this instead of something like gitflow because there's only 3 of us, the sprints are short and we release from main every time it changes. a separate develop and release branch would just be extra merging for no real gain. feature branches still keep unfinished work away from main, pr reviews mean someone else always looks at the code, and the pipeline check on every pr means stuff that breaks the build or the tests doesn't get in.

## Work items
our tasks and tests are on azure boards.
