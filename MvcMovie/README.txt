﻿2025-01-22
0900
Added a View HelloWorld
Test and Run
successfull

2025-01-22
0930
Visual apgraded NuGet Packages
Added MoviesController.cs
Attempting to compile the application in memory with the added DbContext.
Attempting to figure out the EntityFramework metadata for the model and DbContext: 'Movie'
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'Price' on entity type 'Movie'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
Using database provider 'Microsoft.EntityFrameworkCore.SqlServer'!
Added DbContext : '\Data\MvcMovieContext.cs'
Added Controller : '\Controllers\MoviesController.cs'.
Added View : \Views\Movies\Create.cshtml
Added View : \Views\Movies\Edit.cshtml

2025-01-22
updated package manager
lot of stuff happening?
Visual took care of everything
(N'20250122145919_InitialCreate', N'8.0.11')
C:\Users\k_cha\source\repos\MvcMovie\MvcMovie\Migrations\20250122145919_InitialCreate.cs

https://localhost:7094/Movies/Edit/5

2025-01-25
2211
Add search by genre
created a class file named MovieGenreViewModel.cs in the Models folder
Replaced the Index method in MoviesController.cs with new code
to use LINQ to get list of genres

2025-01-25
2224
Add search by genre to the Index view
replaced Model with Model.Movies
When the lambda expression is evaluated (for example, @Html.DisplayFor(modelItem => item.Title)), the model's property values are evaluated.
The ! after model.Movies is the null-forgiving operator, which is used to declare that Movies isn't null.
Tested App
https://localhost:7094/Movies?MovieGenre=&SearchString=2

2025-01-25
2259
Add a Rating property to Models/Movie.cs
by adding this command at the end of the file Movie.cs
public string? Rating { get; set; }
Because we added a new field to the Movie class we need to rebuild the app
Tutoriol instructed to press Ctrl Shift B but didn't work
Had to use drop down menu Build MvcMovie

In MoviesController.cs, added Rating to the [Bind] attribute for both the Create and Edit action methods

20250125
2311
added to Views/Movies/Index.cshtml
@Html.DisplayNameFor(model => model.Movies![0].Rating)
updated SeedData
updated Views/Movies/Create.cshtml
Run App
Error
An unhandled exception occurred while processing the request.
SqlException: Invalid column name 'Rating'.
Microsoft.Data.SqlClient.SqlCommand+<>c.<ExecuteDbDataReaderAsync>b__211_0(Task<SqlDataReader> result)

Had to get NuPackages
Ran these commands in the command prompt
Add-Migration Rating
Update-Database
  VALUES (N'20250129122131_Rating', N'8.0.11')
Ran app
successful

Update validation
the Movie class to take advantage of the built-in validation attributes Required, 
StringLength,
 RegularExpression,
 Range 
and the DataType formatting attribute.

Test attributes: or validation

https://localhost:7094/Movies/Create

Tested using Create function
Validation worked
The controller and views automatically picked up the validation rules specified by using validation attributes on the properties of the Movie model class

Tested using Edit function
model crashed?

Clean started at 10:15 AM.
Clean started: Project: MvcMovie, Configuration: Debug Any CPU 
Clean: 1 succeeded, 0 failed, 0 skipped 
Clean completed at 10:35 AM and took 01.865 seconds

20250126
1000
Added a Rating field to the Movie model.
Updated Models/Movie.cs with public int Rating { get; set; }.
Created a new migration using Add-Migration AddRatingField.

20250129124626_AddRatingFields

Executed Update-Database to apply the migration.
Verified the Movies table in SQL Server Management Studio (SSMS) to confirm the column addition.

1054

I stucked Rating Field, 

1113 

That's it today

20250127
0230
Encountered SqlException: Invalid column name 'Rating'.
Checked the Movies table; Rating column was missing.
Re-ran Update-Database, but no changes occurred.
Used Remove-Migration and recreated it with Add-Migration FixRatingColumn.
Executed Update-Database again; confirmed the column addition.
Tested database schema and executed test queries successfully.

20250128
0645
Updated views to include Rating field.
Modified /Views/Movies/Create.cshtml:

<div class="form-group">
    <label asp-for="Rating" class="control-label"></label>
    <input asp-for="Rating" class="form-control" />
    <span asp-validation-for="Rating" class="text-danger"></span>
</div>

0730

Updated /Views/Movies/Edit.cshtml and /Views/Movies/Details.cshtml.
Ran and tested Create and Edit functionalities.
Validated changes in the HTML source and verified data flow in the application.

0900

I added Rating Colum in edit file.
Then test it, it works..

1030

This log provides a detailed record of challenges faced while implementing the Rating field in the project, along with the steps taken to troubleshoot and resolve each issue.
Lastly I tested again, it works now.

20250129
0845

i update it

Successfully implemented and tested the Rating field across all views.
Confirmed functionality and data persistence.


2025002
1000

Added validation to the Movie model using DataAnnotations.
Used attributes like Required, StringLength, Range, and RegularExpression for better input control.
Validation works both on the client-side (with jQuery) and server-side.
Followed the DRY principle by placing all validation rules in the model, keeping the app clean and easy to maintain.
The Create form now automatically displays validation errors without needing changes to the controller.
Ensured that form data isn’t sent if there are validation errors (both client and server-side checks).

1022
Client-side validation doesn’t work for decimal fields in some locales.
Solved: Added support for locales using decimal commas by globalizing the app to handle regional formats correctly.
1030
Date validation errors when using the Range attribute with DateTime.
Solved: Disabled jQuery date validation to properly use Range with DateTime without issues.
1045
Validation messages weren’t appearing automatically.
Solved: Ensured that the asp-validation-for and asp-validation-summary tags are correctly placed in the form to display errors.

1100
tested, it worked


20250205
0829
Clean started at 8:31 AM...
1>------ Clean started: Project: MvcMovie, Configuration: Debug Any CPU ------
========== Clean: 1 succeeded, 0 failed, 0 skipped ==========
========== Clean completed at 8:31 AM and took 01.095 seconds ==========

Clean started at 8:33 AM...
1>------ Clean started: Project: MvcMovie, Configuration: Debug Any CPU ------
========== Clean: 1 succeeded, 0 failed, 0 skipped ==========
========== Clean completed at 8:33 AM and took 00.312 seconds ==========

Now test time!

Build started at 8:33 AM...
1>------ Build started: Project: MvcMovie, Configuration: Debug Any CPU ------
Restored C:\Users\Can\source\repos\MvcMovie\MvcMovie\MvcMovie.csproj (in 1.08 sec).
1>MvcMovie -> C:\Users\Can\source\repos\MvcMovie\MvcMovie\bin\Debug\net8.0\MvcMovie.dll
========== Build: 1 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========
========== Build completed at 8:33 AM and took 04.498 seconds ==========

0849
I think I have done.