using Orbitality.GameModule.PlanetModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.AIBotModule
{
    public interface IAIBotController
    {
        void Init(IPlanetController planetController);
        void Start();
        void Pause();
        void Play();
    }
}

