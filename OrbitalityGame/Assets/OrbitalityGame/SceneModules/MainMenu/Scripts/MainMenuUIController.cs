using System;
using UnityEngine;

namespace Orbitality.SceneModules.MainMenu
{
    public class MainMenuUIController : MonoBehaviour
    {
        public event Action OnStartGameButtonClick;
        public event Action OnLoadGameButtonClick;

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

