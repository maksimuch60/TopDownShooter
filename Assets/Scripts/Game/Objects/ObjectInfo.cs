using System;
using UnityEngine;

namespace TDS.Game.Objects
{
    [Serializable]
    public class ObjectInfo
    {
        [HideInInspector]
        public string name;
        public GameObject GameObject;
        public float Chance;

        public void UpdateName()
        {
            name = GameObject == null ? String.Empty : GameObject.name;
        }
    }
}