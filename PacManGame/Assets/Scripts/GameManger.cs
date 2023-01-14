using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pacman.Core;

namespace Pacman
{
    public class GameManger : MonoSingletonGeneric<GameManger>
    {
        [SerializeField] private PacmanService m_PacmanService;
        [SerializeField] private GhostService m_GhostService;
 
        void Start()
        {
            m_PacmanService.StartGame();
        }

    }
}
