# projectSamples

This is a culmination of all of my final projects while studying in The Software Guild's C#/.NET bootcamp.

Order of creation: 

## Noun-manager 
(Oct, 2020)
- My first basic CRUD console application.
- The assignment was to make an application that keeps track of any noun (hence the name), mine keeps tracks of books.
- Books are saved to temporary in-memory storage

## Flooring Mastery 
(Jan, 2021)
- Console application for a flooring ordering system, which allows for adding, editing, and deleting orders. 
- Utilitzes dependency injection to switch production (read/write to text files, stored in ~/FlooringMastery.UI/bin/ ) and test (in-memory hard-coded data) data.
- Unit tested, and n-tier architecture

## Hotel 
(May, 2021)
- Yay, databases!
- For this assignment, I was given a bunch of data for a hotel with the task of creating a database to store all the information.
- Included is an ERD image file (created in draw.io) for the data, and then there are SQL files to create the database, insert the data, and some querying statements I was tasked to make.

## Vending Machine 
(Jul, 2021)
- This was my first go-round with webpage development
- This simulates a vending machine, inventory is retrieved and updated to from an API provided by The Software Guild, utilizing AJAX.
- Utilizes Bootstrap for pretty-ifying the page.

:grey_exclamation: *psst, there's an Easter Egg if you input the Konami Code ;)*

## DVD Library 
(Oct, 2021)
- This is code for a web service, SQL queries to create and populate a database, and a seperate HTML/javascript project as an interface for a DVD library application.
- Functionality for adding, deleting, editing, and viewing a list DVDs.
- This builds on all practices of previous projects, including layered architecture, dependency injection, AJAX, Bootstrap, and utilizes ADO.NET
- All API calls were tested using Postman

## GuildCarMastery 
(Jan, 2022)
- This is the culmination of all my study at the Software Guild.
- Building upon previous projects, this is a full web application for a car dealership, with views for customers, sales roles, and admin users.
- Wireframes were supplied, I created an ERD, built the database, test data, and stored procedures, and then a unit-tested ASP.NET web application.

```diff
- I am currently working on fixing ASP.NET Identity integration as well as beautifying the UI. 
- As for ASP.NET Identity, something went wrong and currently, authentication is handled by 
- feeding in an authenticated user ID for every view.
```
