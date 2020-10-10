# mopd_programming_exercise
An exercise in ASP.NET and SQL Server to implement a simple library book rental system.  
> *exercise designed by Clint Ramoutar.*

# Instructions
## SQL Server Steps
1.	Open SQL Server Management Studio
2.	Create new database
3.	Create three tables in the new database
4.	In each of the tables create 5 fields including a primary key
5.	Link each of the table with a foreign key for example class id is a foreign key in student table
6.	Populate the three tables with dummy data, at least 5-10 rows

## Visual Studio Steps
1.	Create new project
2.	Select C# then select “web” (You can select an online template however I recommend you use an empty template at first to properly understand all the features)
3.	Select a name for your project then click create
4.	Look for the name of your project in solution explorer, right click and add new item “web forms master page”
5.	Create the structure of the pages on your web application on this master page
6.	Download and install Ajax Control Toolkit by following the steps on this website: https://www.c-sharpcorner.com/UploadFile/1e050f/how-to-add-ajax-control-toolkit-in-visual-studio/
7.	Create a drop down menu on the master page
8.	Add some links to the following pages:  Help page, About Us, Database Insert Exercise, Database Update Exercise, Database Delete Exercise, and Database Search Exercise
9.	Create a new page and name the page “default”, when adding this new page ensure you select “web form with master page” then select the page master page you created in step 4
10.	This default page would be your homepage, create authentication in this page utilising active directory authentication
11.	Ensure all pages created from now are secured redirects unauthorised users to a access denied page or message
12.	Create a new page that has a data entry form to populate the three database tables you created before, take the data entered and insert into the SQL Server database you created earlier
13.	Create a form to allow users to view and update existing information 
14.	Create the functionality to select any record to delete
15.	Create a search feature to allow users to search the database and view the information
16.	Create a table to allow users to view multiple records and select any record to update or delete

# Tutorials, Guides Resources
- [Chris' Master Programming Languages Resources, Tips, Notes](https://docs.google.com/document/d/1trN6ODL9dQdxBqlKaaaTeJQ1jzbqR5sgyy0SE3Vngi0/edit?usp=sharing)

# Environment Setup
## Use Internet Explorer Only!

## Visual Studio Setup
Microsoft Visual Studio Professional 2015
Version 14.0.25431.01 Update 3
Microsoft .NET Framework
Version 4.7.03190

Installed Version: Professional

Visual Basic 2015   00322-40000-00000-AA861
Microsoft Visual Basic 2015

Visual C# 2015   00322-40000-00000-AA861
Microsoft Visual C# 2015

Visual C++ 2015   00322-40000-00000-AA861
Microsoft Visual C++ 2015

Application Insights Tools for Visual Studio Package   7.0.20622.1
Application Insights Tools for Visual Studio

ASP.NET AJAX Control Toolkit   1.0
ASP.NET AJAX Control Toolkit Visual Studio integration package

ASP.NET and Web Tools 2015.1 (Beta8)   14.1.11107.0
ASP.NET and Web Tools 2015.1 (Beta8)

ASP.NET Web Frameworks and Tools 2012.2   4.1.41102.0
For additional information, visit http://go.microsoft.com/fwlink/?LinkID=309563

ASP.NET Web Frameworks and Tools 2013   5.2.40314.0
For additional information, visit http://www.asp.net/

Common Azure Tools   1.8
Provides common services for use by Azure Mobile Services and Microsoft Azure Tools.

JavaScript Language Service   2.0
JavaScript Language Service

JavaScript Project System   2.0
JavaScript Project System

Microsoft Azure Mobile Services Tools   1.4
Microsoft Azure Mobile Services Tools

NuGet Package Manager   3.4.4
NuGet Package Manager in Visual Studio. For more information about NuGet, visit http://docs.nuget.org/.

PreEmptive Analytics Visualizer   1.2
Microsoft Visual Studio extension to visualize aggregated summaries from the PreEmptive Analytics product.

SQL Server Data Tools   14.0.60519.0
Microsoft SQL Server Data Tools

TypeScript   1.8.36.0
TypeScript tools for Visual Studio

## Microsoft SQL Server 2014 Management Studio Setup
| Feature | Version|  
|---------|--------|
| Microsoft SQL Server Management Studio | 12.0.5223.6  |
| Microsoft Analysis Services Client Tools | 2.0.5223.6  |
| Microsoft Data Access Components (MDAC) | 10.0.17763.1 |
| Microsoft MSXML |3.0 6.0 |
| Microsoft Internet Explorer | 9.11.17763.0  |
| Microsoft .NET Framework | 4.0.30319.42000  |
| Operating System | 6.3.17763  |
