using Orbitality.GameModule.PlanetModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.AIBotModule
{
    public class AIBotController : IAIBotController
    {
        private RocketCharacteristics rocketCharacteristics;
        private IPlanetController planetController;
        private float countdown;

        public void Init(IPlanetController planetController)
        {
            this.planetController = planetController;
            rocketCharacteristics = planetController.GetRocketCharacteristics();
            countdown = rocketCharacteristics.Cooldown;
            planetController.Attack();
        }

        public void Pause()
        {
            throw new System.NotImplementedException();
        }

        public void Play()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}

