using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class GhostController
    {
        private GhostView m_View;
        private GhostModelSO m_Model;

		public GhostController(GhostModelSO ghostModel, Transform spawnPoint)
		{
			m_Model = ghostModel;
			InitiateGhost(spawnPoint);
		}

		private void InitiateGhost(Transform spawnPoint)
		{
			m_View = Object.Instantiate(m_Model.Prefab, spawnPoint);
			m_View.SetController(this);
			m_View.SetColor(m_Model.GetMaterial());
		}
	}
}
