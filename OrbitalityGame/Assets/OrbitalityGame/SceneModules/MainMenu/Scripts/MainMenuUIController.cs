using System;
using UnityEngine;
using UnityEngine.UI;

namespace Orbitality.SceneModules.MainMenu
{
    public class MainMenuUIController : MonoBehaviour
    {
        public event Action OnStartGameButtonClick;
        public event Action OnLoadGameButtonClick;

        [SerializeField]
        private Button loadGameButton;

        public void ChangeLoadInteractable(bool interactable)
        {
            loadGameButton.interactable = interactable;
        }

        public void StartGameButtonClick()
        {
            OnStartGameButtonClick?.Invoke();
        }

        public void LoadGameButtonClick()
        {
            OnLoadGameButtonClick?.Invoke();
        }
    }
}

