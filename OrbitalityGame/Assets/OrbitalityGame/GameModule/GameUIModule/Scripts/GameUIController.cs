using Orbitality.GameModule.PlanetModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Orbitality.GameModule.GameUIModule
{
    public class GameUIController : MonoBehaviour, IGameUIController
    {
        public event Action onClickRocketButton;

        [SerializeField]
        private Slider healthBarSlider;
        [SerializeField]
        private Button RocketButton;
        [SerializeField]
        private Image RocketImageButton;

        private float countdown;
        private event Action update;

        public void Init(float maxHealth, RocketType rocketType)
        {
            RocketData rocketData = new RocketData();
            RocketCharacteristics rocketCharacteristics = rocketData.GetCharacteristics(rocketType);
            countdown = rocketCharacteristics.Cooldown;
            RocketImageButton.sprite = rocketCharacteristics.sprite;
            RocketButton.onClick.AddListener(ClickRocketButton);
            healthBarSlider.maxValue = maxHealth;
        }

        public void ChangeHealth(float currentHealth)
        {
            healthBarSlider.value = currentHealth;
        }


        private void Update()
        {
            update?.Invoke();
        }


        private void ClickRocketButton()
        {
            onClickRocketButton?.Invoke();
            RocketImageButton.fillAmount = 0;
            RocketButton.interactable = false;
            update += Countdown;
        }

        private void Countdown()
        {
            if (RocketImageButton.fillAmount < 1)
            {
                RocketImageButton.fillAmount += Time.deltaTime / countdown;
            }
            else
            {
                update -= Countdown;

            }
            RocketButton.interactable = true;
            RocketImageButton.fillAmount = 1;
        }
    }
}

