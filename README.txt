This program implements simple name sorting on a list of names stored in a text file.

TO RUN:

Set the command line arguments in the Project Properties to be 'name-sorter ./unsorted-names-list.txt'

Set the working directory so that your unsorted names file is in the local working directory

(I achieved this through modifying the Project Propteries of DyeNamesTest in the Debug section)


Run the program in Visual Studio (or through a built version)

Sorted names will be output to a text file called 'sorted-names-list' in your working directory

NOTES:

The program has been set up so that it rejects non-alphanumeric characters or specifially allowed characters that occur in names (such as ' ' or '-'). 

Please use a list of names that only have alphanumeric characters and/or these special characters.

A Travis CI Pipeline has been implemented for this Repo