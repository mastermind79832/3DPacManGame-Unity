using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman.Core
{
    public class MonoSingletonGeneric<T> : MonoBehaviour where T: MonoSingletonGeneric<T> 
    {
        private T instance;
        public T Instance { get { return instance; } }

		protected virtual void Awake()
		{
			if (instance == null)
				instance = (T)this;
			else
				Destroy(Instance.gameObject);
		}
	}
}
