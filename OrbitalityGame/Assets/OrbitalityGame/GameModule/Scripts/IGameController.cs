using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule
{
    public interface IGameController
    {
        event Action OnWin;
        event Action OnLose;

        void Init();
        void StartGame();
        void SaveGame();

    }
}

