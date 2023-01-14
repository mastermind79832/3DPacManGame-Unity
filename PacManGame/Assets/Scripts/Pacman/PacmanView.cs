using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class PacmanView : MonoBehaviour
    {
        private PacmanController m_Controller;

		public void SetController(PacmanController pacmanController)
		{
			m_Controller = pacmanController;
		}
	}
}
