### Beauty Clinic Website
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
To seed the database with demo data:

Install EF Core Tools:

csharp
Copy code
dotnet tool install --global dotnet-ef
Apply Migrations:
In the root directory of the backend project, run:

sql
Copy code
dotnet ef database update
Verify Data:
Check the database to ensure the seed data is present.

## Usage
To get started with the Beauty Clinic website:

Registering: To create a new user account, visit the registration page at [your website URL]/UserRegistration. Fill in the required details to complete the registration process.

Logging In: If you already have an account, you can log in by visiting [your website URL]/logIn. For local testing, this would typically be http://localhost:3001/logIn.

Once logged in, you can explore the exclusive beauty product shop, schedule appointments, and manage your orders and appointments.

Note: Replace [your website URL] with the actual URL where your website is hosted.

# Deployment
Details on the deployment process will be added.

# License
This project is a private project, not licensed for public use.

