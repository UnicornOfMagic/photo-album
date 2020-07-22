![.NET Core](https://github.com/UnicornOfMagic/photo-album/workflows/.NET%20Core/badge.svg?branch=master)

# Photo Album Technical Showcase

## Introduction
Hello! This is my Technical Showcase for the Photo Album project. 

## Installation Instructions
As this is a dotnet core project, there is no executable. Only a DLL. \
The quickest way to install is to download the latest release found in the releases tab and extract the zip archive. \
However, if you want to compile it yourself a simple `dotnet publish -c Release` will suffice.

## Requirements
In order to run the dotnet application, you must have the dotnet cli installed which is included in the dotnet core sdk. \
You can download that [here](https://dotnet.microsoft.com/download). \
**Note: This project requires dotnet core 3.1 at a minimum**

## Usage Instructions
The photo album application is a command line application invoked via the dotnet core cli. The application will run once given a single parameter.

Most common usage will be something along the lines of: \
 ```dotnet ~/Path/To/Dll/photoalbum.dll {albumID}``` \
 
Valid `{albumID}` parameters are integers from 1-100.

e.g. `dotnet ~/Path/To/Dll/photoalbum.dll 50` will return all photos in album 50.
