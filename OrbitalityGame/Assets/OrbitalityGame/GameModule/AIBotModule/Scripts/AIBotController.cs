using Orbitality.GameModule.PlanetModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.AIBotModule
{
    public class AIBotController : IAIBotController
    {
        public event Action<int> OnDied;
        public event Action<int, float> OnChangeHealth;
        public int ID { get; private set; }

        private RocketCharacteristics rocketCharacteristics;
        private IPlanetController planetController;
        private float cooldown;
        private float time = 0;
        private int planetID;
        private int rocketID;


        public void Init(int id, IPlanetController planetController, int planetID, int rocketID)
        {
            this.ID = id;
            this.planetID = planetID;
            this.rocketID = rocketID;
            this.planetController = planetController;
            rocketCharacteristics = planetController.GetRocketCharacteristics();
            cooldown = rocketCharacteristics.Cooldown;
            planetController.OnDied += () =>
            {
                OnDied?.Invoke(id);
            };
            planetController.OnHealthChanged += ChangeHealth;
            
            planetController.SimpleUpdate += Update;
            //planetController.TakeDamage(0);
        }

        public CharacterParameters GetCharacterParameters()
        {
            CharacterParameters charParam = new CharacterParameters();
            charParam.Health = planetController.GetHeath();
            charParam.PlanetID = planetID;
            charParam.RocketID = rocketID;
            return charParam;
        }

        private void ChangeHealth(float currentHealth)
        {
            OnChangeHealth?.Invoke(ID, currentHealth);
        }

        private void Update()
        {
            if (time >= cooldown +1)
            {
                planetController.Attack();
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }
}

