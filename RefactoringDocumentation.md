**Refactoring Documentation for Project “Balloons-Pop-4”**
------------------------------------------------------

1. Renamed solution and project
2. Renamed some of the methods and variables to make them self-documenting
3. Refactored some methods, so they're shorter and more understandable
4. Started splitting the logic of the program into multiple .cs file
> "ConsoleUI.cs", "Contracts.cs", "Engine.cs", "GameLogic.cs",  "Highscore.cs", "Program.cs"

5. Added a file for interface declaration (Contracts.cs)
6. Implemented Singleton design pattern for the Engine class
7. Added basic interface abstraction (ConsoleUI and ILogger), with the intent of addingan option GUI
8. Moved the different files into .dll-s
> The startup project is named BalloonsPop
9. Renamed some methods in ConsoleUI.cs
>printHighscore --> PrintHighscore
>printField --> PrintField
>printMessage --> PrintMessage

10. Removed some unnecessary .cs files
11. Reordered repository structure.
12. Added README.md with information about requirements, contributors
13. Renamed ILogger to IBalloonsUserInterface
14. Added property for the Engine instance of type IEngine
>private static Engine instance = new Engine();

15. Added Initialize method to IEngine and implemented in Engine. 
>Assigns an instance of a UI that implements the IBalloonsUserInteface to the engine instance

16. Deleted the commented code in the Engine class
17. Extracted all messages in const strings
18. Renamed temp variables with appropriate names 
> temp --> inputAsString

19. ReadUserInput method is added to interface and implemented in ConsoleUI
20. Added a ValidationProvider with a template for different validators
21. Refactored an if statement in Engine.cs
22. Added a a missing validation condition in ValidationProvider.cs
23. Fixed a bug in the UserInputValidator and refactored default case in Engine
24. Fixed a bug in Validation and Engine refactoring
25. Moved the Initializing of the Engine to MainProgram.cs
26. Added a Game class for the Engine to work with
>It has a field, user moves count and a reset method. Will help to avoid
code duplication in Engine.Run

27. Refactored the PrintField method in the ConsoleUI.cs
28. Added colors
29. Extracted methods from the PrintMatrix method
>GetDashedLine(), SetConsoleColor(), SetConsoleColorToDefault()

30. Wrapped the ConsoleUI class in a namespace UserInterfaces
31. Extracted class Game.cs from Engine.cs
32. Removed the unnecessary loop condition in Run()
 >while (command != EXIT) --> while (true)

33. Wrapped the GameLogic class in a namespace GameLogic
34. Added public Constructor and a private field of type Random
35. Made the GenerateField method non-static and renamed the varaibles in side
36. Added implicit typing in the GenerateFieldMethod
37. Changed the engine class to work with instances of the GameLogic class
38. Extracted some more constants
>private const int MIN_BALLOON_VALUE = 1;
private const int MAX_BALLOON_VALUE = 4;

39. Removed the unused printMatrix method from the GameLogic.cs
40. Added a method which pops all baloons of a type in a given direction
>public void PopInDirection(byte[,] matrix, int row, int col, int xUpdate, int yUpdate)

41. Added a MatrixValidator and a IMatrixValidator interface. Implemented the IsInsideMatrix method in the MatrixValidator class
42. Added validation for the PopInDirection method
43. Removed the static check methods with non-static ones
>The new methods are PopInDirection and PopBaloons which use loops
instead of recursion

44. Substituted remove doit method and added two non-static methods in its place
45. Removed the commented code in GameIsOver method
46. Extracted the random baloon value generation in another method
> private byte GetRandomBaloonValue()

47. Removed a case that is handled by the Engine class
48. Added test for GameLogic. PopInDirection method is now private
49. The IBaloonsUserInterface is splitted into 2 interfaces - IBaloonsPrinter, IBaloonsUserInterface
50. Color picking works with an array instead of dictionary
51. Extracted some more constants from method PrintField()
52. Improved project structure and removed StyleCop warnings
53.  Renamed IBaloonsPrinter to IPrinter, because the context is obvious
54. Renamed IBaloonsUserInterface to IUserInterface, because the context is obvious
55. Split the interfaces from the old Contracts folder into separate files
56. Split ValidatorProvider into MatrixValidator and UserInputValidator as two separate files (and consequently removed some redunant static getter, could be discussed further on how to increase the abstraction)
57. Fixed some StyleCop warnings, the very few left now are the constant ones but I haven't touched them as we haven't decided on team conventions yet
58. Added Command class hierarchy
59. Added interfaces for the commands and a field in Engine
60. Implemented command usage in the Run switch
61. Starting implementing PopBaloon command
62. Added interfaces for Game and GameLogic classes
63. Added build badge to README
64. Inverted most of the remaining engine dependencies via interfaces
65. Refactored object creating in Main
66. Added Command class for printing highscore
67. Added factory method for PrintHighscoreCommand
68. Implemented PopBaloonCommand
69. Factory now supports creation of PopBaloonCommand-s
70. Added a method GetCommandList. This method will replace the switch in the Engine.Run method
71. Fixed problems with commands in GameLogic
72. Replaced the switch in method Engine.Run() with command list
73. Removed unnecessary code in Engine.cs
74.  Removed commented code and the useless method EndGame()
75. Fixed a test in GameLogic tests
>TestIfGenerateFieldReturnsFieldThatAreSignificantlyDifferentFromEachOther()

76. Added tests for class Game
77. Added tests for class MatrixValidator
78. Added tests for class Game
79. Added tests for class UserInputValidator
80. Moved all interfaces to Contracts in Common project
81. Added quite basic version of a WPF UI with some XAML
82. Added a sample highscore printing
83. Added Initialize method for the Baloon display