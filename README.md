## Synopsis

This is a small angular application started from angular seed project 1.0.0. 

## Code Example

The Example consists of .Net WebApi Solution Under which a single controller is designed to hold static list of personal data.
The List is initialized with default values and the values are retained in transiant mode and are not persistant. 
Under the UI application there is two views one is used manage the two records initialized via the webapi you can update 
the records from the grid view. Since this is a demo there is no authenitication used by the Webapi application.
Cors is enabled on the .NET Solution.

UI/                    --> all of the source files for the UI application
APP/				   --> .NET solution hosting the WebApi for the Personal Controller


## Installation

Host the WebApi solution on your local IIS or Express IIS , under /UI update global vairable "WebApiHost" to point to uri 
for Personal Controller. 
To Start the UI go to the UI folder and run the following command
   npm install
then 
   npm start


