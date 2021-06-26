# Adapter Implementation

## Description
In this implementation of the adapter design pattern, a list of employees is imported and then a third party tool is used to add a fancy header and footer to the list while printing it. To specify further, let’s say that an internal SAP system returns a list of employees as a string array. The third-party tool () expects a list of strings though. Therefore an adapter is needed to enable the user to use the library with a string array.

## UML
![UML](https://i.imgur.com/fn4UwlS.png)

