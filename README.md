# projectSamples

This is a collection of some of my projects

Order of creation: 

## Flooring Mastery 
(Jan, 2021)
This is a flooring ordering console app, allowing adding, editing, deleting and cost estimating of orders.
- Adopted N-tier architecture pattern to organize the responsibilities of the program, dividing the application into clear, modular layers: UI, BLL, Data, Models, and Tests
- Implemented Dependency Injection to switch between text file data and a mock repository during testing via app settings key
- Conducted unit testing using NUnit to test correct results for valid and invalid user input
- Technologies used: **C#, LINQ, NUnit**

## Hotel 
(May, 2021)
For this project, I was tasked with creating a SQL database to model relationships between raw data about hotel room reservations. The data set included tables of information about rooms, guests, and reservations.
To accurately model the relationships, I standardized the data into second normal form, addressing issues of redundant data and inter-column dependencies within table rows.
I then engineered an ERD using Draw.io to model the relationships between the data.
From this ERD, I was able to create a functional SQL database that was able to effectively store and retrieve the data needed. The querying functionality provides insights and information that were not possible before when it was presented as raw table data.
The most challenging part of this project was modeling many-to-many relationships, such as the relationship between guests and reservations. To solve this, I utilized bridge tables to effectively represent these relationships.
This project helped me understand the use and power of bridge tables in effectively modeling less straightforward relationships.
- Technologies used: **T-SQL**

## Vending Machine 
(Jul, 2021)
The is a single-page web application that simulates a vending machine. The user can interact with the application by feeding in coins or bills at the top of the webpage, selecting a product, and making a purchase. If the transaction is successful, the user will be notified with a message and receive the correct amount of change in return, and the remaining quantity of items is updated.
The products available in the vending machine and their respective information are retrieved through calls to a third-party Web API provided by The Software Guild. The project uses JavaScript, jQuery 3.5.1 and AJAX to handle user inputs and interact with the API, making asynchronous requests and dynamically updating the page with JSON data received.
The project's interface features styling from BootStrap v4.5.0 framework.
:grey_exclamation: *psst, there may be a money exploit*
- Technologies used: **HTML, JavaScript, 3rd-Party Web API, BootStrap v4.5.0**

## DVD Library 
(Oct, 2021)
This project is supplied in three parts. A SQL database, web API, and a separate HTML view for a DVD library application.
-Engineered SQL database to store inventory, and stored procedures for CRUD functions
-Built a first-party ASP.NET Web API on the .NET Framework to provide web services and data access to the front-end
-Designed a separate web interface, styled with Bootstrap v4.5.0. Users are allowed to create, read, update, and delete DVD listings, as well as query by title, release year, director name, and rating
-Implemented stored procedures with ADO.NET SQL parameters to secure data from SQL injection attacks
-Utilized Dependency Injection to manage and control dependencies of the web application, in order to switch between a live ADO.NET database connection and a mock repository with sample data to test features
- Technologies used: **.NET Framework, ASP.NET Web API, C#, AJAX, ADO.NET, LINQ, T-SQL**

## GuildCarMastery 
(Jan, 2022)
This is a web app for a vehicle dealership's retail inventory system.
- Drafted and designed a database schema and an SQL database to store inventory, user information, and form data
- Built an ASP.NET MVC server back-end to handle server-side logic, including database interactions and data validation, and a first-party Web API to provide inventory data access to the front-end
- Created a web interface allowing customers to browse vehicle inventory by querying price range or keyword, view vehicle detail pages, and send requests for more information, and for employees to submit purchase forms and view sales reports
- Conducted extensive unit testing using NUnit to verify accuracy of database queries and business logic of the application throughout development
- Implemented stored procedures with ADO.NET SQL parameters to secure data from SQL injection attacks
The hardest challenge of this project was implementing dynamic dropdown options for car models based on the selected car make. To do this, I used jQuery, AJAX, and Razor syntax to make an HTTP request and retrieve the relevent data from the database. Through this process, I gained a better understanding of HTML dropdown implementation with Razor.
- Technologies used: **.NET Framework, ASP.NET MVC, ASP.NET Web API, C# and Razor syntax, ADO.NET, LINQ, T-SQL, Nunit**