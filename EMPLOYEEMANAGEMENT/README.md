# Employee Management System Backend

This project is a backend application for managing employee data efficiently. It provides CRUD (Create, Read, Update, Delete) functionality to handle employee records and is built using .NET Core with Entity Framework Core. The database connection relies on MS SQL Server, and scripts are included for setting up the necessary tables and data.

## Features

- **Display Employee Grid:** Retrieve and display a grid containing details of all employees.
- **Get Employee by ID:** Fetch detailed information for a specific employee by their unique ID.
- **Create Employee:** Add new employee records to the database.
- **Update Employee:** Modify details of existing employee records.
- **Delete Employee:** Remove employee records from the system.

## Project Structure

- **API:** Contains the backend logic for handling requests, data processing, and database interactions.
- **Dbscripts Folder:** Includes MS SQL Server scripts to set up the database schema and initial data. These scripts must be executed before running the application.

## Setup Instructions

1. **Database Setup:**
   - Navigate to the `Dbscripts` folder.
   - Execute the provided MS SQL Server scripts to create the database and required tables.

2. **Configure Database Connection:**
   - Open the API project in your IDE.
   - Update the database connection string in the `appsettings.json` file to match your SQL Server configuration.

3. **Run the API:**
   - Use the `.NET CLI` or your IDE to build and run the project.
   - The API will be accessible at the configured URL.

## Technologies Used

- **Backend Framework:** .NET Core
- **ORM:** Entity Framework Core
- **Database:** MS SQL Server
- **Frontend (optional for integration):** Angular (not included in this repository)

## Future Enhancements

This project is a foundational backend system. Possible future enhancements include:
- Role-based authentication and authorization.
- Integration with an Angular frontend.
- Advanced features like employee search, pagination, and reporting.
