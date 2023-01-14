using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class GhostController
    {
        private GhostView m_View;
        private GhostModelSO m_Model;
		private GhostModelSO ghostModel;
		private Transform spawnPoint;

		public GhostController(GhostView view, GhostModelSO model)
		{
			m_View = view;
			m_Model = model;
		}

		public GhostController(GhostModelSO ghostModel, Transform spawnPoint)
		{
			this.ghostModel = ghostModel;
			this.spawnPoint = spawnPoint;
		}
	}
}
