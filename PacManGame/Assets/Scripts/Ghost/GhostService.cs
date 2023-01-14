using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pacman.Core;

namespace Pacman
{
	[System.Serializable]
    struct GhostProperty
	{
        public Transform SpawnPoint;
        public GhostModelSO GhostModel;
	}

    public class GhostService : MonoSingletonGeneric<GhostService>    
    {
        [SerializeField] private GhostProperty[] m_GhostProperties;
        [SerializeField] private Transform m_ReturnPoint;

        private GhostController[] m_Ghosts;
    
        public void StartGame()
		{
            m_Ghosts = new GhostController[m_GhostProperties.Length];
			for (int i = 0; i < m_GhostProperties.Length; i++)
			{
                m_Ghosts[i] = new GhostController(m_GhostProperties[i].GhostModel, m_GhostProperties[i].SpawnPoint);
			}
		}
    }
}
