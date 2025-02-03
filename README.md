# zealightlabs_assessment
This is a .NET 8-based application for managing products, categories, 
and other related functionalities. It includes features like adding, 
updating, deleting products, as well as filtering by category and price.

1. Prerequisites
Before you begin, ensure you have the following installed:

.NET 8 SDK 
A supported IDE such as Visual Studio, Visual Studio Code, or Rider
SQL Server or PostgreSQL (depending on your database configuration)
Any other dependencies based on your setup

2. Clone the Repository

Clone the repository to your local machine using the following command:

    git clone https://github.com/apostleyemi/zealight_ass.git
    cd zealight_ass


    Install Dependencies


3. If you are using Visual Studio, the dependencies should be restored 
automatically when opening the solution. Alternatively, run this command to restore dependencies manually:

dotnet restore

4. Update your appsettings.json file with the correct connection string to your database. Example for SQL Server:

{
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
    }
}

5. Apply Migrations

To create the database schema, run the migrations with the following command:
dotnet ef migrations add InitialMigration

After creating the migration, apply it to your database by running:

dotnet ef database update
This will create the necessary tables, seed the db with preset data and apply any pending migrations to your database.


6. **Build the Project**

After applying the migrations and seeding the database, you can build the application using:

bash :

    dotnet build

7. Run the Application

You can now run the application locally by using the following command:
  dotnet run

This will start the application on the default port (e.g., https://localhost:5001).
