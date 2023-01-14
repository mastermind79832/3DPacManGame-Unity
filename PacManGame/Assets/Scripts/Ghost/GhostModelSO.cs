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
		[SerializeField] private GhostType m_Type;
		[SerializeField] private float m_MoveSpeed;
		[SerializeField] private Material m_NormalMat;
		[SerializeField] private Material m_FrightenedMat;
	}
}
