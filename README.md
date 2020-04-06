# OrbitalityGame
Mobile game
Decomposition levels:
* 0 OrbitalityGame
* 1 OrbitalityGame.UtilitiesModule
* 1 OrbitalityGame.SceneModules (Has a scene controller that activates all the necessary modules)
* 1 OrbitalityGame.GlobalModule 
* 1 OrbitalityGame.GameModule (access through IGameController)
* 2 OrbitalityGame.GameModule.AIBotModule (access through IAIBotController)
* 2 OrbitalityGame.GameModule.GameUIModule (access through IGameUIController)
* 2 OrbitalityGame.GameModule.PlanetModule (access through IPlanetController)
* 2 OrbitalityGame.GameModule.SunModule

```
Game save

The type of planet, type of rockets, lives for the main character and each bot is saved in the game.
It is json at PlayerPrefs

Modules

Modules communicate with each other only through received events or requested data in initialization.
This is done to enable the replacement of modules without extra time
