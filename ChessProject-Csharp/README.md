# Sprint Report (ChessBoard C# Project)

(Assume I am in a sprint to complete the code test.)

## Sprint Goals
 The project’s long-term goals are to build a fully functional chess game. The targets of the sprint is to 
 * get all unit tests found under the Tests folder passing
 * focus on some basic functionality of the Chessboard and some simple movements of a Pawn
 * refactor the code of the project to an extendable structure
 * fix the bugs found in the initial implementation

## Requirement
All simulations take place on a chess board (class name: `ChessBoard`) that is a grid consisting of length X, and height Y – both of which are integers.  Chess pieces can be placed on the board at a given (x,y) coordinate pair with (0, 0) being in the lower left-hand corner of the board, and (7, 7) being in the top right hand corner of the board, as seen in the following illustration:

![alt text](http://www.chessvariants.org/d.chess/startup.gif)

Pieces are either Black or White.  Black pieces typically start at row x=7 and x=6, whereas white pieces typically start at rows x=0 and x=1.  That said, you can set up a board with many initial configurations to replay famous chess games (that last bit might be a paradox).  

Additionally, Pieces can be given two commands: move and capture (we will ignore capture for this exercise).  Each piece has unique movements, but we are going to focus on commands for pawns.  For our limited implementation, Pawns can only move forward one space (toward their opponents side of the board) and can only capture in a forward and diagonal direction as seen in the next illustration.

![alt text](http://www.chessvariants.org/d.chess/pawnmove.gif)

## Code Enhancement in the Sprint

The following enhancement has been taken during the sprint. 

### Improve code quality
* expendability - add a base Piece class which can be inherited by different types of pieces.
* readability - rename some functions based on their implementations; use meaningful names; add documentations; 
* testability - declare some properties of classes to interface which can be easily mocked. 
* reusability - move the shared validation functions to the coordinate validator which implements an interface. The validator is injected to the its consumer class as a property. 
* clean code - combine the two properties MaxBoardHeight and MaxBoardWidth to a single property MaxBoardLength because chess board is a square. 

### Use patterns
* polymorphism
* factory pattern

### Bug fixes
* fix incorrect defined MaxBoardWidth and MaxBoardHeight
* fix the incorrect tests, such as Limits_The_Number_Of_Pawns in ChessBoard_Tests.cs. 
* remove unused parameters, such as MovementType in ChessBoard.Move. The enum MovementType is not in use for now but might be required in the project in the future therefore it is kept. 

### Test Drive Development
* write unit tests before implementations
* improve the test coverage 

### Add new features for pawn
* add more logic to validate pawn's movements.

## Work still to do
* Although the test coverage was improved in the sprint, more improvement can be done. For example, the calls of the functions should be verified using unit tests.

## Discussions
* MaxBoardWidth and MaxBoardHeight of ChessBoard class are not used outside the class. They can be changed to private. 
* The PieceFactory has not been used and was added from the architecture perspective. If we used pure TDD or Feature Oriented Design point of view, it should not have been added in the current sprint. 
* The work in the sprint was pushed directly to the master branch. It would be a better approch to creat a feature branch and a pull request to be merged to master for code review. 

## Further Fixes
After submitting the code on Sunday, I realised there were couple of bugs and more refactoring could be done. The latest commit fixed the bugs and applied the following refactoring.

### Fix the following bugs:
* After moving a piece on a chess board, the array of the chess board was not updated and the original coordinate was not emptied.
* The dictionary of the chess board containing the numbers of pieces with same colour and type was defined for type only. The previous tests for checking if a limit is exceeded didn’t cover the scenario for adding pieces with different colours.  
### Code refactoring:
* Extend the tests for testing validate if limit exceeded when adding multiple pieces with same type but different colours.
* Implement three operations ‘AddPiece’, ‘RemovePiece’ and ‘SetPiece’ in ChessBoard. 
* Simplify Pawn.Move function by calling ChessBoard.RemovePiece and ChessBoard.AddPiece.
* Remove a duplicate validation function for validating duplicate positioning.
* Remove a duplicate exception class.
* Change the validation for duplicate positioning to private as it is not needed in the Pawn.Move.
* Tidy up the unit tests.

