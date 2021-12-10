using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frightened : MonoBehaviour
{

    public Material realMat;
    public Material scaredMat;

    public MeshRenderer body;
   
    public Collider coll;

    public bool isFrightened;
    public bool isEaten;


    // Start is called before the first frame update
    void Start()
    {
        body.material = realMat;
        coll = transform.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void frightenedState()
    {
        body.material = scaredMat;
        isFrightened = true;
    }

    public void ResetState()
    {
        body.enabled = true;
        coll.enabled = true;
        body.material = realMat;
        isFrightened = false;
        isEaten = false;
    }

    public void Eaten()
    {
        body.enabled = false;
        coll.enabled = false;
        isFrightened = false;
        isEaten = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && isFrightened)
        {
            Eaten();
        }
        
    }

}
