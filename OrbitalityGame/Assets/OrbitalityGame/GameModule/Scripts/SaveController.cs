using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule
{
    public class SaveController
    {
        public void SaveGame(SaveDataJson saveData)
        {
            string json = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString(GlobalModule.GameData.PPKEY_SAVE, json);
        }

        public SaveDataJson GetLastSave()
        {
            SaveDataJson saveData = null;
            if (PlayerPrefs.HasKey(GlobalModule.GameData.PPKEY_SAVE))
            {
                string json = PlayerPrefs.GetString(GlobalModule.GameData.PPKEY_SAVE);
                saveData = JsonUtility.FromJson<SaveDataJson>(json);
            }
            return saveData;

        }
    }

    [Serializable]
    public struct CharacterParameters
    {
        public int PlanetID;
        public int RocketID;
        public float Health;
    }

    [Serializable]
    public class SaveDataJson
    {
        public CharacterParameters[] Bots;
        public CharacterParameters Main;
    }
}

