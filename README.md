# _Salon Systems_
Joseph Tomlinson

## Descriptions
MVC Web app that allows a Hair Salon Employee to add/remove new hair stylists and add/remove clients to or from that Stylists.

Information is stored in a MySQL database

## Requirements
* #### MySQL Server using [MAMP](https://www.mamp.info/en/) or [MySQL Community](https://dev.mysql.com/downloads/mysql/)
* #### .NET Framework [v1.1](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-osx-x64.1.1.4.pkg)
* #### .NET [runtime](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-osx-x64.1.1.4.pkg)




## Instructions
Clone with git or download as a zip file and extract to a directory on your machine.

##### Sql Setup
In order to load the proper information into a database, some tables must be created.
You can create these tables by entering the following MySQL commands into your Sql
Server

``` Sql
CREATE DATABASE joseph_tomlinson;
USE DATABASE joseph_tomlinson;

CREATE TABLE stylists (stylist_id SERIAL, name NVARCHAR(255));
CREATE TABLE clients (client_id SERIAL, stylist_id INT, name NVARCHAR(255), phone VARCHAR(10), address VARCHAR(255), notes TEXT);
```

If you wish to perform your own tests, use the following:
``` Sql
CREATE DATABASE joseph_tomlinson_tests;
USE DATABASE joseph_tomlinson_tests;

CREATE TABLE stylists (stylist_id SERIAL, name NVARCHAR(255));
CREATE TABLE clients (client_id SERIAL, stylist_id INT, name NVARCHAR(255), phone VARCHAR(10), address VARCHAR(255), notes TEXT);
```
###### (Pretty much the same thing, except with a database called "test")

## Specifications


________
| Specification                                                                                  | Example Input                                                                              | Example Result                                                                                                                 |
|------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| A list of Stylists will be Visible with a button at the bottom labeled "Add New Stylist"       | User clicks Add new Stylist                                                                | A page will open that allows the  user to enter and submit the stylist's information.                                          |
| Each Stylist will have their own page with information and a list of clients assigned to them. | User will click a on the Stylist's name in the list of stylists.                           | The Stylists's information panel will open                                                                                     |
| Each Stylists page will allow for the addition of new "Clients" to be assigned to them.        | User will click a "Add Client" button at the bottom of Stylist' page                       | A form will open where the user can enter the new client's information.                                                        |
| Clients information such as address, phone number and name must all be viewable by the user    | User clicks on the client's name                                                           | a page displaying all client info will open.                                                                                   |
| All client information can be updated from the client's information page                       | User clicks on an "Update Client" button                                                   | All the displays for user information will swap to forms and reveal an "update" submit button which applies these changes.     |
| User can cancel client changes submission.                                                     | User clicks a "cancel submission" button                                                   | The page will reload, refreshing the information from the Database of that client.                                             |
| Clients will be able to be "removed" from the system                                           | User clicks a "Remove" button from the Stylist's list of clients, or the Client info page. | A popup asking for confirmation will open, confirming the removal will load the Client list with the targetted client removed. |
________

##### This app makes use of the following frameworks/libraries:
* Boostrap
* Dotnet
* Jquery
