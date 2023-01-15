using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
	[System.Serializable]
    public class PacmanModel 
    {
        [SerializeField] private PacmanView m_Prefab;
        [SerializeField] private float m_Speed;

        public PacmanView Prefab => m_Prefab;  
        public float Speed => m_Speed; 
    }
}
