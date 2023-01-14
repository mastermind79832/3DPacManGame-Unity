using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class PacmanController
    { 
        private PacmanView m_View;
        private PacmanModel m_Model;

        public PacmanController(PacmanModel model, Transform spawn)
		{
			m_Model = model;
            m_View = Object.Instantiate(model.GetPrefab(), spawn);
            m_View.SetController(this);
		}
	}
}
