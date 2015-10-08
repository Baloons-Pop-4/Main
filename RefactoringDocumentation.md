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
49. Added `Unit Tests` for `GameLogic`. `PopInDirection()` method is now private.
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
76. Added `Unit Tests` for class `Game`.
77. Added `Unit Tests` for class `MatrixValidator`.
78. Added `Unit Tests` for class `Game`.
79. Added `Unit Tests` for class `UserInputValidator`.
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
94. Added 3 Command factory `Unit Tests`.
95. Added highscore table interface and class.
96. Improved and moved the `PlayerScore` struct.
97. Integrated `HighscoreTable` into the engine.
98. Mocking for command testing.
99. Balloons implemented, all projects now work with the new type.
100. Added `Unit Tests` for the `Memento` class.
101. Added new `Memento` and `Strategy` design patterns. Added more tests.
102. Fixed numerous bugs. Made the `AddPlayer()` method a lot simpler.
103. Fixed conflicts.
104. Updates to tests for the new memento implementation.
105. Added the highscore table as dependency.
106. Removed a `Unit test` for the old interface.
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
119. Removed random dependency by a new interface `IRandomNumberGenerator`
120. Added new dependencies to core constructor, fixed tests.
121. Added bundling and binding for types.
122. Added singleton scopes via ninject for the UI.
123. Renamed cloning strategy namespaces correctly.
124. Added `log4net`.2.0.3.nupkg. Added interface `ILogger` and implemented `Log4NetWrapper`.
125. Fixed all StyleCop warnings in `BalloonsPop.Common/Contracts/`.
126. Introduced extendable factory for commands.
127. Fixed a bug in validations and refactored them.
128. Deleted old validation files and changes all using to the updates library.
129. Added `xml` documentation for `BalloonsPop.Validation`.
130. Added `Unit Tests` for `DotNetCloningStrategy` and `SerializationStrategy`.
131. Added `Unit Tests` for `switch gadget`.
132. Added `Unit Tests` for `IsMatch` method of `ReflectionCloning` class.
133. Fixed 300+ `StyleCop` warnings.
134. Fixed abstractions for highscore manipulation.
135. Implemented `Bridge pattern` for `LogicProvider` class.
136. Removed unused method from `BalloonPopper` and added `xml` documentation.
137. Added `xml` documentation for `FieldGenerator` class.
138. Deleted the old saving strategies and `HighscoreHandler`.
139. Highscore handling fixed once and for all.
140. Added `Unit Tests` for `HighscoreTable` class.
141. Fixed `Stylecop` warning, added protected properties to Core.
142. Started controller for `MainWindow.xaml`.
143. Introduced `WpfResourceProvider`.
144. Fixed game over delay bug by introducing a new command.
145. Wpf GUI now uses the controller, the provider and the manipulator.
146. Extracted `WpfManipulator` logic in extension methods.
147. Replaced `ResourceProvider` with extensions + better interface.
148. Undo button event is added.
149. Added `Exit` command in WPF.
150. Deleted unused prompt window and some extension methods.
151. Renamed `ClickEventArgs` to `UserCommandArgs` and added `xml` documentation for it.
152. Added abstracted button event attaching.
153. MainWindow now contains event handle. Controller for MainWindow delegates the event addition/removal to `MainWindow.RaiseCommand`.
154. Extracted static readonly members from Controller in another class.
155. Added exception throwing for null cases in `StringExtensions.cs`.
156. Added `Unit Tests` for extensions + added more exception throwing.
157. Added `Unit Tests` for `UserCommandsArgs`.
158. Added `Unit Tests` for `StringExtension.cs` and `IEnumerableExtensionTests.cs`.
159. Added `Unit Tests` for `Resources.cs`.
160. Added `xml` documentation in `Resources.cs`.
161. Added `xml` documentation for the `XAML/Wpf` project.
162. Fixed all `Stylecop` warning for `XAML/Wpf` project.
163. Added sounds and new interfaces.
164. Fixed image paths.
165. Refactored and renamed the `GenerateField()` method.
166. Refactored `LogicProvider`.
167. Added `xml` documentation for all classes in `BalloonsPop.Logic`.
168. Abstracted field randomization to core.
169. Added `xml` documentation for all `BalloonsPop.Bundling` classes.
170. Inverted `memento` dependency from core. Planning on moving memento to a separate project.
171. `Memento` implementation moved to `BalloonsPop.Saver`.
172. Added `SaverModule` for Saver loading.
173. Refactored all engine's constructors.
174. Removed a bunch of unused properties from `ICoreBundle`.
175. Started introducing `Composite` commands.
176. Constructed `composite` commands for: *restart*, *game over handling*, *exit*, *undo*