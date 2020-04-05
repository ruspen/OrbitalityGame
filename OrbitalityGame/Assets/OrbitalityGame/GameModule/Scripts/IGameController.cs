using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule
{
    public interface IGameController
    {
        void Init();
        void StartGame();
        void Pause();
        void Play();
        void SaveGame();
        void EndGame();

    }
}

