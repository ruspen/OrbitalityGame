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


        public void Init(int id, IPlanetController planetController)
        {
            this.ID = id;
            this.planetController = planetController;
            rocketCharacteristics = planetController.GetRocketCharacteristics();
            cooldown = rocketCharacteristics.Cooldown;
            planetController.OnDied += () =>
            {
                OnDied?.Invoke(id);
            };
            planetController.OnHealthChanged += ChangeHealth;
            
            planetController.SimpleUpdate += Update;
        }

        public void Pause()
        {
            throw new System.NotImplementedException();
        }

        public void Play()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
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

