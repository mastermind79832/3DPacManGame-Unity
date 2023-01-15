using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public enum GhostType
	{
		Blinky,
		Pinky,
		Inky,
		Clyde
	}

	[CreateAssetMenu(fileName = "New Ghost", menuName = "New Ghost")]
    public class GhostModelSO : ScriptableObject
    {
		[SerializeField] private GhostView m_Prefab;
		[SerializeField] private GhostType m_Type;
		[SerializeField] private float m_MoveSpeed;
		[SerializeField] private Material m_NormalMat;
		[SerializeField] private Material m_FrightenedMat;

		public GhostView Prefab => m_Prefab;
		public Material GetMaterial(bool isFrightened = false) => isFrightened ? m_FrightenedMat : m_NormalMat;
	}
}
