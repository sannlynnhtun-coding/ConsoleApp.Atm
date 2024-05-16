# Mini Atm

## Overview
ConsoleApp.MiniAtm is a C# console application that simulates an Automated Teller Machine (ATM). It allows users to perform basic banking operations such as checking account balance, withdrawing money, and depositing money.

## Features
- **Check Balance**: View the current balance of the account.
- **Withdraw Funds**: Withdraw a specified amount of money from the account, with checks to prevent overdrafts.
- **Deposit Funds**: Deposit a specified amount of money into the account.

## Domain Logic
The core functionalities are implemented through a series of classes and methods designed to handle user inputs and perform the necessary operations on the account.

### Account Class
This class represents a user's bank account and contains the following properties and methods:
- **Properties**:
  - `Balance`: Represents the current balance of the account.
- **Methods**:
  - `CheckBalance()`: Returns the current balance.
  - `Withdraw(amount)`: Deducts the specified amount from the balance if sufficient funds are available.
  - `Deposit(amount)`: Adds the specified amount to the balance.

### ATM Class
The ATM class manages interactions between the user and their account:
- **Methods**:
  - `ShowMenu()`: Displays the menu options to the user.
  - `ProcessTransaction(option)`: Processes the selected menu option (e.g., check balance, withdraw, deposit).

### Example Usage
When the application starts, it presents a menu with options to the user. Based on user input, it performs the corresponding action:
1. User selects "Check Balance" to view the current account balance.
2. User selects "Withdraw Funds" to withdraw money, ensuring that the account has sufficient funds.
3. User selects "Deposit Funds" to add money to their account.
