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
        event Action SimpleUpdate;
        void Init(RocketType rocketType, float currentHealth, bool isMain = false);
        void StartMove(EllipseData ellipseData);
        void Pause();
        void Play();
        void Attack();
        void TakeDamage(float points);
        float GetHeath();
        RocketCharacteristics GetRocketCharacteristics();
        void Delete();

    }
}

