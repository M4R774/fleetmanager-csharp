# Building and running
Same as the original. 

# Requirements
Visual Studio 2017
SQLite xxxx

# Usage
- GET
- POST
...

# Design decisions
- I chose SQLite for database because it was efficient enough for this purpose, lightweight and really simple to deploy. If more powerful database is needed, the data can be migrated quite easily to more powerful database. One of the drawbacks of the SQLite package is that it does not support asynchronous database operations. This is why my implementation is 100 % synchronous. However the implementation is efficient enough for this task. 