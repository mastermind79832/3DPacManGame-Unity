using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class GhostView : MonoBehaviour
    {
		[SerializeField] private MeshRenderer m_BodyMesh;
		[SerializeField] private Light m_PointLight;

        private GhostController m_Controller;

		public void SetController(GhostController ghostController)
		{
			m_Controller = ghostController;
		}

		public void SetColor(Material material)
		{
			m_BodyMesh.material = material;
			m_PointLight.color = material.color;
		}
	}
}
