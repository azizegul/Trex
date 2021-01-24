# Trex

This project was created as a demo project for Mert Yazilim.

## Installation

Before running, a sql database named TrexLog should be created and run with the script in docs/sql/CreateLogTable.sql
Please remember to change the connection string in Data/Logger/LoggerDal.
 ```csharp
SqlConnection connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=TrexLog; Trusted_Connection=true");
```
