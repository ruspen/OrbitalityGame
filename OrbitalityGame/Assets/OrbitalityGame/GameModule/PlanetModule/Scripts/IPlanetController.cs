using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.UtilitiesModule;
using System;

namespace Orbitality.GameModule.PlanetModule
{
    public interface IPlanetController
    {
        event Action<float> OnHealthChanged;
        event Action OnDied;
        void Init(RocketType rocketType);
        void StartMove(EllipseData ellipseData);
        void Pause();
        void Play();
        void Attack();
        void TakeDamage(float points);
        float GetHeath();
        RocketCharacteristics GetRocketCharacteristics();

    }
}

