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
                        Acceleration = 2.2f,
                        Weight = 0.4f,
                        Cooldown = 3,
                        Damage = 25,
                        sprite = Resources.Load<Sprite>(GameData.ROCKET0_SPRITE_PATH)
                    };
                case RocketType.Middle:
                    return new RocketCharacteristics
                    {
                        Acceleration = 2f,
                        Weight = 0.5f,
                        Cooldown = 2,
                        Damage = 40,
                        sprite = Resources.Load<Sprite>(GameData.ROCKET1_SPRITE_PATH)
                    };
                case RocketType.Big:
                    return new RocketCharacteristics
                    {
                        Acceleration = 1.5f,
                        Weight = 0.6f,
                        Cooldown = 1,
                        Damage = 50,
                        sprite = Resources.Load<Sprite>(GameData.ROCKET2_SPRITE_PATH)
                    };
                default:
                    return new RocketCharacteristics
                    {
                        Acceleration = 3,
                        Weight = 1,
                        Cooldown = 3,
                        Damage = 20,
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
        public float Damage;
        public Sprite sprite;

    }

    
}

