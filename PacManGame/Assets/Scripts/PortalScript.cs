using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform portal;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(portal.position.x,other.transform.position.y,portal.position.z);
    }
}
