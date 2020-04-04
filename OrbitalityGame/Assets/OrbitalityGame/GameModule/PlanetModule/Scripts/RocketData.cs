using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbitality.GameModule.PlanetModule
{
    public class RocketData
    {
        public RocketCharacteristics GetCharacteristics(RocketType rocketType)
        {
            switch (rocketType)
            {
                case RocketType.Small:
                    return new RocketCharacteristics
                    {
                        Acceleration = 3,
                        Weight = 1,
                        Cooldown = 3,
                        sprite = Resources.Load<Sprite>(GameData.ROCKET0_SPRITE_PATH)
                    };
                case RocketType.Middle:
                    return new RocketCharacteristics
                    {
                        Acceleration = 2,
                        Weight = 2,
                        Cooldown = 2,
                        sprite = Resources.Load<Sprite>(GameData.ROCKET1_SPRITE_PATH)
                    };
                case RocketType.Big:
                    return new RocketCharacteristics
                    {
                        Acceleration = 1,
                        Weight = 3,
                        Cooldown = 1,
                        sprite = Resources.Load<Sprite>(GameData.ROCKET2_SPRITE_PATH)
                    };
                default:
                    return new RocketCharacteristics
                    {
                        Acceleration = 3,
                        Weight = 1,
                        Cooldown = 3,
                        sprite = Resources.Load<Sprite>(GameData.ROCKET0_SPRITE_PATH)
                    };
            }
        }
    }

    public enum RocketType
    {
        Small = 0,
        Middle = 1,
        Big = 2
    }

    public struct RocketCharacteristics
    {
        public float Acceleration;
        public float Weight;
        public float Cooldown;
        public Sprite sprite;
    }

    
}

