# ♟️ Chess Game in C#

A complete chess game developed in C# for terminal/console, implementing all official chess rules, including special moves.

## 🎮 Features

### ✨ Main Features
- ✅ **All pieces with correct movements**: King, Queen, Rook, Bishop, Knight, and Pawn
- ✅ **Complete turn system** with player alternation
- ✅ **Move validation**: Only valid moves are allowed
- ✅ **Piece capture** with counter and visualization
- ✅ **Check detection** with visual warning in red
- ✅ **Checkmate detection** with automatic game ending
- ✅ **King protection**: Cannot make moves that leave your own king in check
- ✅ **Board rotation**: Each player sees their pieces at the bottom

### 🎯 Special Moves
- 🏰 **Castling**: Kingside and queenside
- 👻 **En Passant**: Special pawn capture
- 👑 **Pawn Promotion**: Automatic transformation into Queen

### 🎨 Visual Interface
- 🎨 **Chessboard pattern** with alternating squares (gray/black)
- 🟢 **Green highlights** for possible moves
- 🎨 **Differentiated colors**: White pieces (white) and Black pieces (yellow)
- 📊 **Detailed information**: Turn number, current player, captured pieces
- ⚠️ **Visual alerts** for check and checkmate
- 🎭 **Decorative borders** and professional layout

## 🚀 How to Run

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) or higher

### Installation and Execution

1. **Clone the repository:**
```bash
git clone https://github.com/brunnossanttos/chess-csharp.git
cd chess-csharp
```

2. **Build the project:**
```bash
dotnet build
```

3. **Run the game:**
```bash
dotnet run
```

## 🎲 How to Play

### Board Notation
The board uses standard algebraic chess notation:
- **Columns**: a, b, c, d, e, f, g, h (from left to right)
- **Rows**: 1, 2, 3, 4, 5, 6, 7, 8 (from bottom to top)

### Movement
1. Type the **origin position** (e.g., `e2`)
2. The game shows **possible moves** in green
3. Type the **destination position** (e.g., `e4`)
4. The move is validated and executed

### Example Moves
```
Origin: e2
Destination: e4

Origin: e7
Destination: e5

Origin: g1
Destination: f3
```

### Piece Symbols
- **K** - King
- **Q** - Queen
- **R** - Rook
- **B** - Bishop
- **N** - Knight
- **P** - Pawn

## 🏗️ Project Structure

```
chess-csharp/
├── ChessBoard/              # Board base layer
│   ├── Board.cs             # Board management
│   ├── BoardException.cs    # Board exception handling
│   ├── Piece.cs             # Abstract base class for pieces
│   ├── Position.cs          # Position system
│   └── Color.cs             # Color enumeration
│
├── Chess/                   # Chess game logic
│   ├── ChessMatch.cs        # Game match manager
│   ├── ChessPosition.cs     # Chess position notation
│   ├── King.cs              # King piece implementation
│   ├── Queen.cs             # Queen piece implementation
│   ├── Rook.cs              # Rook piece implementation
│   ├── Bishop.cs            # Bishop piece implementation
│   ├── Knight.cs            # Knight piece implementation
│   └── Pawn.cs              # Pawn piece implementation
│
├── Screen.cs                # Terminal visual interface
├── Program.cs               # Program entry point
└── README.md                # Documentation
```

## 🎓 Programming Concepts Applied

This project was developed for educational purposes, applying fundamental **Object-Oriented Programming (OOP)** concepts:

### OOP Principles

- **Encapsulation**: Private properties with controlled access
- **Inheritance**: All pieces inherit from the `Piece` base class
- **Polymorphism**: `PossibleMoves()` method overridden in each piece
- **Abstraction**: Abstract `Piece` class defines contract for pieces

### SOLID Principles

- **SRP** (Single Responsibility): Each class has a single responsibility
- **OCP** (Open/Closed): Easy to add new pieces without modifying existing code
- **LSP** (Liskov Substitution): Pieces can be substituted by their subclasses
- **ISP** (Interface Segregation): Specific interfaces for each need
- **DIP** (Dependency Inversion): Dependencies on abstractions, not concrete implementations

### Patterns and Best Practices

- **Custom exception handling**
- **User input validation**
- **Separation of concerns** (logic vs presentation)
- **Clean code** and well documented
- **Clear and consistent naming**

## 🐛 Error Handling

The game validates all inputs and moves, displaying clear messages:

- ❌ "There is no piece at the chosen origin position!"
- ❌ "The chosen origin piece is not yours!"
- ❌ "There are no possible moves for the chosen origin piece!"
- ❌ "Invalid destination position!"
- ❌ "You cannot put yourself in check!"

## 📝 Implemented Rules

### Piece Movements

- **King**: 1 square in any direction + Castling
- **Queen**: Any direction, any distance
- **Rook**: Horizontal or vertical, any distance
- **Bishop**: Diagonal, any distance
- **Knight**: "L" movement (2+1 squares)
- **Pawn**: 1 square forward (2 on first move), diagonal capture, En Passant, Promotion

### Victory Conditions

- ✅ **Checkmate**: King in check with no valid moves
- ✅ Impossible to put your own king in check
- ✅ All moves validated before execution

## 🛠️ Technologies Used

- **Language**: C# 12
- **Framework**: .NET 9.0
- **Paradigm**: Object-Oriented Programming
- **Interface**: Console/Terminal
- **Version Control**: Git/GitHub

## 📚 Learning Outcomes

This project demonstrates:

- Complete implementation of complex game rules
- Code structuring in multiple layers
- Advanced use of OOP and SOLID
- Validation and error handling
- Terminal visual interface creation
- Game state management

## 🤝 Contributions

Contributions are welcome! Feel free to:

- Report bugs
- Suggest improvements
- Add new features
- Improve documentation

## 📄 License

This project is open source and available under the MIT License.

## 👨‍💻 Author

**Bruno Santos**

- GitHub: [@brunnossanttos](https://github.com/brunnossanttos)

## 🎯 Project Status

✅ **COMPLETE** - All phases implemented:

1. ✅ Basic match structure
2. ✅ Basic movement
3. ✅ Main game loop
4. ✅ Destination validation
5. ✅ Piece capture
6. ✅ Check detection
7. ✅ Checkmate and game end
8. ✅ Visual improvements
9. ✅ Special moves
10. ✅ Deploy and documentation

---

⭐ If you liked this project, please give it a star!

🎮 **Have fun playing chess!** ♟️
