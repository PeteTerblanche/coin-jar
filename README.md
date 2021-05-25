# Coin-Jar

Coin Jar implementation in C# exposing its functionality as a RESTful API

###### Coin Jar technical specs

Target framework - netcoreapp3.1
Language version - C# 8.0

###### What is Coin Jar all about?

The coin jar will only accept the latest US coinage and has a volume of 42 fluid ounces. 
Additionally, the jar has a counter to keep track of the total amount of money collected and can reset the count back to $0.00.

The coin jar implemented with a RESTful API that exposes 3 endpoints which allows us to do the following:  

1. Add a coin. 
2. Get the total amount of our coins. 
3. Reset the coins

A singleton is used for data-persistence.

###### How to test Coin Jar?

1. Open and build the Coin-Jar solution.

2. Run Coin-Jar.API which will open a web browser with URL https://localhost:<port>/swagger/index.html

3. You will see the following:
   3.1 POST /api/Coins 

   - This will add the coin. 
   - Leave the selection for application/json.
   - Add copy and paste the below to the input box
     {
       "amount": 0.5
     }
   - Execute and view the Response

   3.2 GET /api/Coins

   - Execute and view the Response

   3.3 DELETE /api/Coins

   - Execute and view the Response

4. The same logic can be applied when testing with Postman.

5. To validate the test cases, right-click the Coin-Jar.Tests project and select "Run Unit Tests".