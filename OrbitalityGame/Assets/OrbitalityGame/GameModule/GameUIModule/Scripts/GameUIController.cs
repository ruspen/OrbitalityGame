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
        private Button rocketButton;
        [SerializeField]
        private Image rocketImageButton;
        [SerializeField]
        private Transform botsPanel;
        [SerializeField]
        private Slider botHealthBarPfefab;

        private float countdown;
        private event Action update;
        private Dictionary<int, Slider> botsHealth = new Dictionary<int, Slider>();


        public void Init(float maxHealth, RocketType rocketType)
        {
            RocketData rocketData = new RocketData();
            RocketCharacteristics rocketCharacteristics = rocketData.GetCharacteristics(rocketType);
            countdown = rocketCharacteristics.Cooldown;
            rocketImageButton.sprite = rocketCharacteristics.sprite;
            rocketButton.onClick.AddListener(ClickRocketButton);
            healthBarSlider.maxValue = maxHealth;
            healthBarSlider.value = maxHealth;
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
            rocketImageButton.fillAmount = 0;
            rocketButton.interactable = false;
            update += Countdown;
        }

        private void Countdown()
        {
            if (rocketImageButton.fillAmount < 1)
            {
                rocketImageButton.fillAmount += Time.deltaTime / countdown;
            }
            else
            {
                update -= Countdown;
                rocketButton.interactable = true;
                rocketImageButton.fillAmount = 1;

            }
        }

        public void AddBotHealth(int botID,float maxValue)
        {
            Slider slider = Instantiate(botHealthBarPfefab, botsPanel) as Slider;
            slider.maxValue = maxValue;
            slider.value = maxValue;
            botsHealth.Add(botID, slider);
        }

        public void ChangeBotHealth(int botID, float currentHealth)
        {
            if (botsHealth.ContainsKey(botID))
            {
                botsHealth[botID].value = currentHealth;
            }
        }
    }
}

