using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.UtilitiesModule;

namespace Orbitality.GameModule.PlanetModule
{
    public interface IPlanetController
    {
        void Init(RocketType rocketType);
        void StartMove(EllipseData ellipseData);
        void Pause();
        void Play();
        void Attack();
    }
}

