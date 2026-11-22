# Match3 Game in Unity

> Updated to Unity `6000.3.29f1` LTS

![Match3gif](/DemoFiles/Match3.gif)

Match 3 games are simple puzzle games where the player pairs three or more identical items on a tiled game board.
Popular modern variations include Candy Crush and Bejeweled.
Unity is ideally suited to this kind of game design, and it's a great entry point for game development.

We cover topics like creating a grid-based game board, using inheritance to create different types of game pieces,
adding obstacles and new levels, detecting matches and clearing pieces, and implementing a user interface complete with a score screen.

![Match3](/DemoFiles/match3.png)

![Match3 - Finished Level](/DemoFiles/match3Final.png)

Based on [Kelley Hecker's course](https://www.linkedin.com/learning/building-a-match-3-game-with-unity).

## Input

The project uses Input System 1.20.1 with Active Input Handling set to
**Input System Package (New)**. `Assets/InputSettings.asset` accepts all device
layouts and processes input during dynamic updates. Desktop mouse input is the
primary control scheme; touchscreen bindings are also available.

Press a piece, drag onto an adjacent piece, then release to attempt a swap.
Tapping a piece or releasing outside the board cancels the gesture. Only the
first pointer controls a board gesture; extra fingers cannot replace or release
it. Input is ignored while the board fills and after game over.

Both UI EventSystems use `InputSystemUIInputModule` with the package's default UI
actions for mouse, touch, keyboard, and gamepad navigation. Each gameplay camera
has a `Physics2DRaycaster` to route pointer events to piece colliders.

To check input after changes:

1. Open `LevelSelect` and select each of the three levels.
2. Check a valid swap, an invalid swap, a tap, and release outside the board.
3. Check Replay and Done on the game-over panel and keyboard/gamepad UI navigation.
4. Switch away from the game during a gesture, then return and start a new one.

If mobile support is pursued, repeat the gesture checks on a physical device,
including a second finger and suspend/resume. Android device validation is outside
the current desktop scope.
