using Orbitality.GameModule.PlanetModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.AIBotModule
{
    public interface IAIBotController
    {
        int ID { get;}
        event Action<int> OnDied;
        event Action<int, float> OnChangeHealth;
        void Init(int id, IPlanetController planetController);
        void Pause();
        void Play();
    }
}

