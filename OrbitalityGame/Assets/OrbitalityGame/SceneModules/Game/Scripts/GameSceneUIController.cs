using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Orbitality.SceneModules.Game
{
    public class GameSceneUIController : MonoBehaviour
    {
        public event Action OnPauseClick;
        public event Action OnPlayClick;
        public event Action OnBackClick;


        [SerializeField]
        private Image pausePlayButtonImage;
        [SerializeField]
        private Sprite pauseSprite;
        [SerializeField]
        private Sprite playSprite;
        [Header("Inform Panel")]
        [SerializeField]
        private GameObject informPanel;
        [SerializeField]
        private GameObject winOgject;
        [SerializeField]
        private GameObject loseObject;

        private bool isPause = false;


        public void OnPausePlayButtonClick()
        {
            if (isPause)
            {
                isPause = false;
                OnPlayClick?.Invoke();
                pausePlayButtonImage.sprite = pauseSprite;
            }
            else
            {
                isPause = true;
                OnPauseClick?.Invoke();
                pausePlayButtonImage.sprite = playSprite;
            }
            
        }

        public void OnBackButtonClick()
        {
            OnBackClick?.Invoke();
        }

        public void ShowWin()
        {
            informPanel.SetActive(true);
            winOgject.SetActive(true);
        }
        public void ShowLose()
        {
            informPanel.SetActive(true);
            loseObject.SetActive(true);
        }

        void Start()
        {
            pausePlayButtonImage.sprite = pauseSprite;
        }
        

    }
}

