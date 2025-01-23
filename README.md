## Demo
https://github.com/user-attachments/assets/605b6349-ad95-4481-8f5c-32c596a6caee


## Project Setup
- Go to window > Package Manager > Hit `+` icon on Top left > Add package bit git URL
  - `com.unity.netcode.gameobjects` Used to add host/client connections
  - `https://github.com/VeriorPies/ParrelSync.git?path=/ParrelSync` Used to create clone app to test multiplayer
  - `com.unity.services.multiplayer` Used to allow Lobby and connect to unity Lobby System Manager

- Go to Assets/Scenes > For each scene (currently 3)
  - Double click the scene
  - Hit the play button to start the game
  - Click `yes` to import the scene to build scenes

- If there are compilation errors like below: Go to Edit > Project Settings > Burst AOT Settings > uncheck Enable Burst Compilation.
```
Failed to find entry-points:
  Mono.Cecil.AssemblyResolutionException:
  Failed to resolve assembly: 'Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' --->
  System.Exception: Failed to resolve assembly 'Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' in directories ...
```


## Version control description
> SmashBrosV0.unitypackage
1. Arena with rigid body
2. Player prefabs with base phisics, coliision trigger detection and hit capabilities
3. Multiplayer control with Unity Netcode
4. Hit count of own player using Canva and LegacyText component
5. Character animation, with Walking and Standing states

<br>

> SmashBrosV1.unitypackage
1. Control panel to start/stop host & client
2. Code sanitization

<br>

> SmashBrosV2.unitypackage
1. Render hits taken on displayController
2. Increase damage taken according to current hitpoint (damage)
3. Implement spawn count (lifes) & gameover when exiting arena more than n (current 3) times

<br>

> SmashBrosV3.unitypackage
1. Set up Unity Lobby (https://docs.unity.com/ugs/manual/lobby/manual/get-started)
2. Lobby scene
3. Lobby management
4. Synchronized game start

<br>

> SmashBrosV4.unitypackage
- It's missing because some bugs were fixed in V5 before uploading V4

<br>

> SmashBrosV5.unitypackage
1. Create multiple prefabs, on for each character
2. Character selection (scene + communicating the character of each player for all clients)
3. Customize prefab instantiation and spawn instead of defining player prefab in the Network Manager

<br>

> SmashBrosV6.unitypackage
1. Improved characters sprites state machine
2. Connected Unity Lobby + Relay + Netcode: Now players from different LAN can play together
3. Lobbies are listed automatically
4. Project structure refactor, removing unused code

<br>

> SmashBrosV7.unitypackage
1. Fixed lobby exceptions
2. Added base bot spawn, with BotMovement script
3. Bots are not allowed to hit, only take hits. They are still dumb

<br>

> SmashBrosV8.unitypackage
1. Create "Welcome" scene, before starting the game (only enabling "Start game" button for the host)
2. Develop a separate script to manage player instantiation and spawning, independent of the DisplayController
3. Display damage progress bar for every player
4. Display hearts to represent the remaining lives of each player

<br>

> SmashBrosV9.unitypackage
1. Improve layout on Lobby & CharacterSelecion scenes

<br>

> SmashBrosV10.unitypackage
1. GameOver screen
2. Toasts manager to give user feedback on lobby & selection character
3. Game restart from same lobby (bugs for rendering stocks on client)
4. Improved join Lobby flow

<br>

> SmashBrosV11.unitypackage
1. Randomly choose bot characters avoiding repetition
2. Create unique names for each player
3. Remove unecessary buttons from lobby scene
4. Fix despawn after game over
5. Unable/Despawn players when going back to lobby after game over
6. Inherit CharacterMovement class in BotMovement script
7. Implement retries in join/create lobby until the operation is successful

<br>

> SmashBrosV12.unitypackage
1. Add all characters prefab to game
2. Implement jump, idle & attack animations (using sprites from [@Kauã](https://github.com/KauaOrtiz))
3. Create Victory & EndGame scenes
4. Improved navigation between scenes when game session ended<br>
  4.1. Hosts can navigate back to CharacterSelecion<br>
  4.2. Clients can navigate back to Lobby
5. Improved Lobby UI
6. Add max attempts to join/create lobby

<br>

> SmashBrosV13.unitypackage
1. Add Furg & CC scenarios
2. Final layout fixes

<br>

<br>

> SmashBrosV14.unitypackage
1. Add bot movements
2. Some variables changes

<br>

> [!NOTE]  
> How to run ?
> - Double click SampleScene on Assets/Scenes
> - Click play button
> - Click _create lobby_ button
> - In other editor (use _ParalellSync_) click _list lobbies_ and click the lobby that appears in the list to join
> - Choose you character
> - Click _start game_ in the editor that created the lobby
> - Click _start game_ in the arena scene


## Used docs
* Configure VsCode to be Unity default editor: [link](https://learn.microsoft.com/en-us/visualstudio/gamedev/unity/get-started/getting-started-with-visual-studio-tools-for-unity?pivots=macos)
* Helper video to understand Unity Multiplayer with Unity Netcode: [link](https://www.youtube.com/watch?v=stJ4SESQwJQ&t=505s)
* Animations: [link 1](https://www.youtube.com/watch?v=_FFv8dkfF1g) & [link 2](https://www.youtube.com/watch?v=msTvOG4w80I)
