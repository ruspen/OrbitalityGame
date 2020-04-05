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
            //if (Time.timeScale == 1)
            //{
            //    Time.timeScale = 0;
            //}
            //else
            //{
            //    Time.timeScale = 1;
            //}
            
        }

        public void OnBackButtonClick()
        {
            OnBackClick?.Invoke();
        }

        void Start()
        {
            pausePlayButtonImage.sprite = pauseSprite;
        }

        // Update is called once per frame
        void Update()
        {

        }
        

    }
}

