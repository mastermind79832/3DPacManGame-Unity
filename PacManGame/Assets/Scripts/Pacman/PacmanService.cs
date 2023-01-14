using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pacman.Core;
using System;

namespace Pacman
{
    public class PacmanService : MonoSingletonGeneric<PacmanService>
    {
        [SerializeField] private Transform m_PacmanSpawnPoint;
        [SerializeField] private PacmanModel m_PacmanModel;

		private PacmanController m_PacmanController;

        public void StartGame()
		{
            CreatePacman();
		}

		private void CreatePacman()
		{
			m_PacmanController = new PacmanController(m_PacmanModel, m_PacmanSpawnPoint);
		}
	}
}
