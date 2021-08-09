# Entity Framework Core Performance Testng

This project was created to test the performance of EF Core.
### Database used: AdventureWorks2019

- First query was created by using EF Core. Average time to do EF Core query is 1800ms.
- Second query was mapped from SQL View and the average time to complete it was 500ms.
- Thirs query was mapper from SQL Procedure and the average time to complete it was 400ms.

- The second time, when running the queries, EF Core querie time was almost matched with View and Procedure

![Performance Results](https://i.ibb.co/ctLGxCT/232687282-840678979904780-5977563033922820592-n.png)
