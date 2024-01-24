# Poker

## Introduction ⛳
This project is a part of a course at AGH University of Science. Utilizing [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0), [WinForms](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/) and [ML.NET](https://dotnet.microsoft.com/en-us/apps/machinelearning-ai/ml-dotnet), application allows users to play a simplified Texas Hold'em variant, with a built-in AI that estimates the outcome of the game and plays accordingly.

## On project structure 📁
The project is divided into two main parts:
1. **Backend**, hidden within a folder with an appropriate name, it contains utility classes and those responsible for creating the bot.
2. **Frontend**, implemented in Form.cs, it includes both UI descriptions in markdown and UI logic.

![image](https://github.com/DawidSerek/Poker/assets/38727547/6a6d1580-2ff3-4769-a0f4-6146acfae0a7)

## Backend ⚙️
> [!NOTE]
> To utilize ML.NET in bot creation, training data needed to be generated before training. The creation of the bot is divided into the following parts:
> 1. Creating enivorment that allows to represent game as data
> 2. Implementing an evaluation algorithm to calculate game outcomes.
> 3. Generating data using the aforementioned points
> 4. Training on generated data

### Game representation 🃏
1. Models
   * [Card](Backend/Card.cs)
   * [Deck](Backend/Deck.cs)
   * [Outcome](Backend/Outcome.cs) - Represents the outcome of the poker game. Due to the nuanced nature of poker hands, outcomes are divided into primary and secondary evaluations (firstEval and secondEval). Additionally, the model captures the contribution of the player's cards in creating the best hand configuration.
2. Utilities
   * [Dealer](Backend/Dealer.cs) - Manages the general game flow, providing methods for adding players, shuffling the deck, and evaluating cards.

### Data Generation 📊
After representing the game, data can be generated for model training. To achieve this, the [MLDataGenerator](Backend/MLDataGenerator.cs) class was created. Said class provides utilities to:
1. Emulating and neatly presenting games within the terminal (primarily for debugging).
2. Preparing datasets for ML and exporting them to CSV files.
> Comment: The generated data, where n = 100,000 * 3 for this model, can be found [here](Backend/output.csv). The data structure includes accordingly: the hand's value, the utilization of cards within the player's hand, and the game outcome represented as -1, 0, or 1 for defeat, draw, and win, respectively. This presentation aims to help the model identify patterns, such as a strong combination with both cards contributing leading to an expected win.

### Model Training 🧠
With properly generated data, ML.NET tools are used to configure and implement the model. Using [mbconfig](MLModel.mbconfig), the model is configured for data classification (predicting loss, draw, or win). The generated data is then used to train the model, producing an object that can estimate the likelihood of a player winning based on the current evaluation and hand strength.

## Frontend 🧿
The User Interface is created using Windows Forms, enabling the player to engage in multiple games consecutively against a bot while keeping track of their funds. All text content has been written in Polish.

### Notable rules include: 📋
* A player cannot place a bid that the other player cannot equalize.
* Bids should be positive integers.
* If a player runs out of funds, the game ends as if both players had checked.
* The starting bid is set at 10, and the new game will not be started if any player has less than this amount.
  
### Images 🖼️
[The background image](https://pl.freepik.com/darmowe-zdjecie/zielony-material-w-jasne-kropki_40730407.htm#query=poker%20table%20background&position=15&from_view=search&track=ais&uuid=1d2893c7-b7b3-4a31-beb8-65b3dcec3ec8) is created by Sketchepedia from Freepik.\
[The card images](https://pl.freepik.com/darmowe-wektory/poker-karty-ikony-kolekcji_1045019.htm#query=playing%20cards&position=40&from_view=search&track=ais&uuid=4774aa00-fefc-4b09-adc2-a462866d0d4d) are created by macrovector from Freepik.

