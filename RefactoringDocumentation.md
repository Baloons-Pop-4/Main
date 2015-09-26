**Refactoring Documentation for Project “Balloons-Pop-4”**
------------------------------------------------------

1. Renamed solution and project.
2. Renamed some of the methods and variables to make them self-documenting.
3. Refactored some methods, so they're shorter and more understandable.
4. Started splitting the logic of the program into `multiple .cs` file
	> "ConsoleUI.cs", "Contracts.cs", "Engine.cs", "GameLogic.cs",  "Highscore.cs", "Program.cs"
5. Added a file for interface declaration `Contracts.cs`.
6. Implemented `Singleton` design pattern for the Engine class.
7. Added basic interface abstraction (`ConsoleUI` and `ILogger`), with the intent of adding an option GUI.
8. Moved the different files into .dll-s
9. The startup project is named `BalloonsPop`
10. Renamed some methods in `ConsoleUI.cs`
	> printHighscore --> PrintHighscore
	> 
	> printField --> PrintField
	> 
	> printMessage --> PrintMessage
11. Removed some unnecessary .cs files.
12. Reordered repository structure.
13. Added `README.md` with information about requirements, contributors.
14. Renamed `ILogger` to `IBalloonsUserInterface`.
15. Added property for the Engine instance of type `IEngine`
	>`private static Engine instance = new Engine();`
16. Added  Initialize method to `IEngine` and implemented in Engine.
	>Assigns an instance of a UI that implements the IBalloonsUserInteface to the engine instance
17. Deleted the commented code in the Engine class.
18. Extracted all messages in const strings.
19. Renamed temp variables with appropriate names
	>temp --> inputAsString
20. `ReadUserInput method` is added to interface and implemented in `ConsoleUI`.
21. Added a `ValidationProvider` with a template for different validators.
22. Refactored an if statement in `Engine.cs`.
23. Added a a missing validation condition in `ValidationProvider.cs`.
24. Fixed a bug in the `UserInputValidator` and refactored default case in Engine.
25. Fixed a bug in Validation and Engine refactoring.
26. Moved the Initializing of the Engine to `MainProgram.cs`.
27. Added a Game class for the Engine to work with
	>It has a field, user moves count and a reset method. Will help to avoid code duplication in Engine.Run
28. Refactored the `PrintField` method in the `ConsoleUI.cs`.
29. Added colors.
30. Extracted methods from the `PrintMatrix()`
	>GetDashedLine(), SetConsoleColor(), SetConsoleColorToDefault()
31. Wrapped the `ConsoleUI` class in a namespace `UserInterfaces`.
32. Extracted class `Game.cs` from `Engine.cs`.
33. Removed the unnecessary loop condition in `Run()`
	>while (command != EXIT) --> while (true)
34. Wrapped the `GameLogic` class in a namespace `GameLogic`.
35. Added public Constructor and a private field of type Random.
36. Made the `GenerateField()` method non-static and renamed the varaibles in side.
37. Added implicit typing in the `GenerateFieldMethod`.
38. Changed the engine class to work with instances of the `GameLogic` class.
39. Extracted some more constants
	>private const int MIN_BALLOON_VALUE = 1;
	>
	>private const int MAX_BALLOON_VALUE = 4;
40. Removed the unused `printMatrix` method from the `GameLogic.cs`.
41. Added a method which pops all balloons of a type in a given direction
	>public void PopInDirection(byte[,] matrix, int row, int col, int xUpdate, int yUpdate)
42. Added a `MatrixValidator` and a `IMatrixValidator` interface. Implemented the `IsInsideMatrix()` method in the `MatrixValidator` class.
43. Added validation for the `PopInDirection` method.
44. Removed the static check methods with non-static ones
	>The new methods are PopInDirection and PopBaloons which use loops
instead of recursion
45. Substituted remove doit method and added two non-static methods in its place.
46. Removed the commented code in `GameIsOver()` method.
47. Extracted the random balloon value generation in another method
	>private byte GetRandomBaloonValue()
48. Removed a case that is handled by the `Engine` class.
49. Added test for `GameLogic`. `PopInDirection()` method is now private.
50. The `IBaloonsUserInterface` is splitted into 2 interfaces - `IBaloonsPrinter`, `IBaloonsUserInterface`.
51. Color picking works with an array instead of dictionary.
52. Extracted some more constants from method `PrintField()`.
53. Improved project structure and removed StyleCop warnings.
54. Renamed `IBaloonsPrinter` to `IPrinter`, because the context is obvious.
55. Renamed `IBaloonsUserInterface` to `IUserInterface`, because the context is obvious.
56. Split the interfaces from the old `Contracts` folder into separate files.
57. Split `ValidatorProvider` into `MatrixValidator` and `UserInputValidator` as two separate files (and consequently removed some redundant static getter, could be discussed further on how to increase the abstraction).
58. Fixed some StyleCop warnings, the very few left now are the constant ones but I haven't touched them as we haven't decided on team conventions yet.
59. Added `Command` class hierarchy.
60. Added interfaces for the commands and a field in Engine.
61. Implemented command usage in the Run switch.
62. Starting implementing `PopBalloon` command.
63. Added interfaces for `Game` and `GameLogic` classes.
64. Added build badge to README.
65. Inverted most of the remaining engine dependencies via interfaces.
66. Refactored object creating in `Main`.
67. Added `Command` class for printing the highscore.
68. Added `Factory method` for `PrintHighscoreCommand`.Implemented `PopBaloonCommand`.
69. Factory now supports creation of `PopBaloonCommand`-s.
70. Added a method `GetCommandList()`. This method will replace the switch in the `Engine.Run()` method.
71. Fixed problems with commands in `GameLogic`.
72. Replaced the switch in method `Engine.Run()` with command list.
73. Removed unnecessary code in `Engine.cs`.
74. Removed commented code and the useless method `EndGame()`.
75. Fixed a test in `GameLogic` tests.
76. Added `tests` for class `Game`.
77. Added `tests` for class `MatrixValidator`.
78. Added `tests` for class `Game`.
79. Added `tests` for class `UserInputValidator`.
80. Moved all interfaces to `Contracts` in `Common` project.
81. Added quite basic version of a `WPF UI` with some `XAML`.
82. Added a sample highscore printing.
83. Added `Initialize()` method for the Balloon display.
84. Added a prompt window for reading usernames. The `ReadUserInput` method now returns the result.
85. `Memento` pattern added as Undo Command. New `SaveCommand.cs` added too.
86. Updated tests for the upcoming changes.
87. Undo implemented + decoupled `GameModel` from `GameLogic`.
88. `Command factory` provides a single method. Commands now have execution context.
89. `ConsoleUI` now extends engine in its own project. Removed the Console-specific methods from the Engine class.
90. Added fluent switch implementation.
91. Implemented fluent switch usage in Engine.
92. Added `ICloneableObject` interface.
93. `Memento` now works with prototype. Revamped private methods of `Memento`.
93. Rewrote `GameLogic` methods using `LINQ`.
94. Added 3 Command factory tests.
95. Added highscore table interface and class.
96. Improved and moved the `PlayerScore` struct.
97. Integrated `HighscoreTable` into the engine.
98. Mocking for command testing.
99. Balloons implemented, all projects now work with the new type.
100. Added tests for the `Memento` class.
101. Added new `Memento` and `Strategy` design patterns. Added more tests.
102. Fixed numerous bugs. Made the `AddPlayer()` method a lot simpler.
103. Fixed conflicts.
104. Updates to tests for the new memento implementation.
105. Added the highscore table as dependency.
106. Removed a test for the old interface.
107. Renamed `GraphicEngine` to `EventEngine`.
108. Split initialization methods into smaller private methods.
109. Refactored `InitializeBalloonField()` method.
110. Renamed the `Engine` project to `Core` and renamed all components accordingly.
111. Removed the old and added the renamed project.
112. Removed singleton from `validators`.
113. Implemented an `XML` and binary highscore saving strategies.
114. `Ninject` integrated.
115. Moved validations to a new library, added ninject binding for it.
116. Removed useless `LogicProvider` class.
117. Moved saving strategies and fixed XML saving.
118. Integrated highscore saving into the project.
119. 