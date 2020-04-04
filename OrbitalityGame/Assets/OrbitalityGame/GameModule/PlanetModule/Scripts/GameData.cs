using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.PlanetModule
{
    public class GameData
    {
        public static List<string> PLANETS_PREFAB_PATH = new List<string>
        {
            "Planet/Planet1",
            "Planet/Planet2",
            "Planet/Planet3",
            "Planet/Planet4"
        };

        public static string ROCKET_PREFAB_PATH = "Rocket/Rocket";
        public static string ROCKET0_SPRITE_PATH = "Rocket/RocketImageType0";
        public static string ROCKET1_SPRITE_PATH = "Rocket/RocketImageType1";
        public static string ROCKET2_SPRITE_PATH = "Rocket/RocketImageType2";
    }
}

