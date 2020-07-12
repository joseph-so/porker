#Poker Hand Sorter

This is a program about the Poker game.

The program is developed in the .NET Core 3.1 in Visual Studio 2019

## How to run
### Run with the Visual Stdio
- Open the solution in Visual Studio
- Check  Debug>Poker Debug Properity, the Application arguement with the correct file path to the input file
### Run with the published code
- Open your terminal and go to the folder of the checkout code.  
- Go to Poker\publish folder
- poker poker-hands.txt (Windows CMD) or  .\Poker.exe .\poker-hands.txt for Powershell

## Note related to this project
- XUnit Test is developed for PlayerHand class only
    - It covered the major test case only. 
- Only Directory Not Found and File Not Found Error handling is implemented.
- No other error handling is implemented. It assume that input is always correct
    - It did not check if the input file is in a valid format 
    - It did not check if the card input is correct, e.g. card can is existed in the both player
    - It did not check if the card is valid a card (2-9, T, J, Q, K, A) and the Suit
- For those error, you will expect to see an exception which is not catched.
