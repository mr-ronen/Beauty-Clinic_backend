# Beauty Clinic Website
Description
This website is designed to simplify the management and customer interaction for a beauty clinic. It allows for easy appointment scheduling and features an exclusive shop with high-quality beauty products. The site also provides detailed information about the clinic's services. Users can create accounts to track their appointments and orders. Future updates will enhance the appointment booking feature.

## Installation
The project is split into two repositories:

Backend: Contains the .NET solution with the necessary migrations for the database.
Frontend: A separate repository with the React project.
To set up the project:

Clone both the backend and frontend repositories.
Follow the installation instructions in each repository to get the project running.
Database Seeding
To seed the database with demo data(mostly used for the products in the shop .):

### Prerequisites
Before installing the Beauty Clinic backend, you should have the following tools installed:
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) (includes the .NET Runtime)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express edition is sufficient for local development)
- [EF Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) for database migrations (can be installed globally with `dotnet tool install --global dotnet-ef`)

### Backend Setup
To get the backend up and running, follow these steps:

1. Clone the backend repository:
   git clone <repository-url>
Replace `<repository-url>` with the URL of the backend repository.

2. Navigate to the backend project directory (where the `.csproj` file is located):
cd path/to/backend/project
3. Configure the database connection string in `appsettings.json` 
"ConnectionStrings": {
    "DefaultConnection": "Your SQL Server connection string here"
}

Make sure to replace "Your SQL Server connection string here" with your actual SQL Server connection string.
Database Setup
To initialize the database with the required schema and seed data, execute:
dotnet ef database update
This command runs all migrations and should be executed in the backend project directory.
Running the Backend
With the database set up, start the backend application:

Troubleshooting
If migrations fail, check the connection string and ensure your SQL Server instance is running.
In case of issues not covered here, check the backend repository's Issues tab or consult the .NET Core documentation.
Notes
The backend and frontend of the project are maintained in separate repositories. It is important to clone both and follow the respective installation instructions.
This README provides guidelines for setting up the backend. For frontend setup, refer to its specific README.
## Usage
To get started with the Beauty Clinic website:

Registering: To create a new user account, visit the registration page at [your website URL]/UserRegistration. Fill in the required details to complete the registration process.

Logging In: If you already have an account, you can log in by visiting [your website URL]/logIn. For local testing, this would typically be http://localhost:3000/logIn.

Once logged in, you can explore the exclusive beauty product shop and see the sum up in the cart.
later on it also will be possible to schedule appointments and manage your orderd.

Note: Replace [your website URL] with the actual URL where your website is hosted.

### Deployment
Details on the deployment process will be added.

### License
This project is a private project, not licensed for public use.

