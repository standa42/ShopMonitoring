# ShopMonitoring
Task made for a job interview   
- REST api providing customer satisfaction in store along with other person features like age, sex,..  
- Includes GET all (with time filtering), GET by id, POST batch of customers
- Uses swagger for documentation
- There is Power BI report for queried table that explores data (can be found in ./powerbi_report/)

## Installation instructions 
- Clone repo
- Insert connection string to db into appsettings.json to CustomerConnectionRemote property (correct string can be reconstructed from supplied assignment - I also sent it in my solution email)
- Project should be ok by now and I tested 2 ways to launch it: 
1) launch iis express
- swagger should automatically open in browser (or its always available at https://localhost:44394/index.html)
Available queries with examples:
- GET all customers => http://localhost:12533/api/customers
- GET all customers filtered by date => http://localhost:12533/api/customers?startDate=2020-09-16T20:35:07&endDate=2020-09-16T20:45:07
- POST one or more new customers => http://localhost:12533/api/customers  
with body like (json in raw text format(tested using postman)): 
``` json
[
    {
        "visitDateTime": "2020-08-16T20:42:07",
        "age": 24,
        "wasSatisfied": false,
        "sex": "M"
    },
    {
        "visitDateTime": "2020-07-16T20:45:07",
        "age": 42,
        "wasSatisfied": true,
        "sex": "F"
    }
]
```

2) 'dotnet run' in package manager console
- swagger is available at https://localhost:5001/index.html
- queries can be made over port 5000

## Power BI report vizualization
![Power BI report - customer satisfaction](/powerbi_report/final_report.png?raw=true "Power BI report - customer satisfaction")
