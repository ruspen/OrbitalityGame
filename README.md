# OrbitalityGame
Mobile game
Decomposition levels:
* 0 OrbitalityGame
* 1 OrbitalityGame.UtilitiesModule
* 1 OrbitalityGame.SceneModules (Has a scene controller that activates all the necessary modules)
* 1 OrbitalityGame.GlobalModule 
* 1 OrbitalityGame.GameModule (assess through IGameController)
* 2 OrbitalityGame.GameModule.AIBotModule (assess through IAIBotController)
* 2 OrbitalityGame.GameModule.GameUIModule (assess through IGameUIController)
* 2 OrbitalityGame.GameModule.PlanetModule (assess through IPlanetController)
* 2 OrbitalityGame.GameModule.SunModule
