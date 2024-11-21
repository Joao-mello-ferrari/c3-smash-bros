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
