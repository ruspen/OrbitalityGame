using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.PlanetModule
{
    public interface IPlanetController
    {
        void Init();
        void StartMove(Vector3[] way, int startPositionAtWay, float speed);
        void Pause();
        void Play();
    }
}

