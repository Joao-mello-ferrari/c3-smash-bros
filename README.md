## Version control description
> SmashBrosV0.unitypackage
1. Arena with rigid body
2. Player prefabs with base phisics, coliision trigger detection and hit capabilities
3. Multiplayer control with [Unity Netcode](by name: com.unity.netcode.gameobjects)
4. Hit count of own player using Canva and LegacyText component
5. Character animation, with Walking and Standing states
6. Need [ParralenSync](by git URL: https://github.com/VeriorPies/ParrelSync.git?path=/ParrelSync) to test multiplayer game

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
> How to run ? <br>- Click play button<br> - Go to Hierarchy > DontDestroyOnLoad > NetworkManager > Start Host


## Used docs
* Configure VsCode to be Unity default editor: [link](https://learn.microsoft.com/en-us/visualstudio/gamedev/unity/get-started/getting-started-with-visual-studio-tools-for-unity?pivots=macos)
* Helper video to understand Unity Multiplayer with Unity Netcode: [link](https://www.youtube.com/watch?v=stJ4SESQwJQ&t=505s)
* Animations: [link 1](https://www.youtube.com/watch?v=_FFv8dkfF1g) & [link 2](https://www.youtube.com/watch?v=msTvOG4w80I)
