using Orbitality.GameModule.PlanetModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.GameUIModule
{
    public interface IGameUIController
    {
        event Action onClickRocketButton;
        void Init(float maxHealth, RocketType rocketType);
        void ChangeHealth(float currentHealth);
        void AddBotHealth(int botID, float maxValue);
        void ChangeBotHealth(int botID, float currentHealth);

    }
}

