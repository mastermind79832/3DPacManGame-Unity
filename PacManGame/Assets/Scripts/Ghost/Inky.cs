using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inky : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform pacman;

    private float[] posX = {13,-13};
    private float[] posZ = {14,-16};
    private Vector3 pos;
    private float time = 6;
    private Frightened fright;


    // Start is called before the first frame update
    void Start()
    {
        fright = GetComponent<Frightened>();
       pos = (new Vector3(posX[Random.Range(0,posX.Length)],transform.position.y,posZ[Random.Range(0,posZ.Length)]));
       agent.SetDestination(pos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fright.isEaten)
        {
              
                EatenMovement();
            
            return;
        }

        if(fright.isFrightened)
        {   
            if(time > 3)
                FrightMovement();
            time += Time.fixedDeltaTime;
            return;
        }

        NormalMovement();
    }

    private void NormalMovement()
    {
        if( (pacman.position.x > (transform.position.x - 2f) && pacman.position.z > (transform.position.z - 2f)) && (pacman.position.x < (transform.position.x + 2f) && pacman.position.z < (transform.position.z + 2f)) )
        {
            agent.SetDestination(pacman.position);
        }

        if(time > 5)
        {
            pos = (new Vector3(posX[Random.Range(0,2)],transform.position.y,posZ[Random.Range(0,2)]));
            agent.SetDestination(pos);
            time = 0;
        }
        time += Time.fixedDeltaTime;
    
    }

    
    bool isLeft = true;
    private void FrightMovement()
    {
        Vector3 pos;
        if(isLeft)
        {  
            pos = new Vector3(-13,transform.position.y,16);
            isLeft = false;
        }
        else
        {
            pos = new Vector3(-5,transform.position.y,-11);
            isLeft = true;
        }
        agent.SetDestination(pos);
        time = 0;
        
    }

    private void EatenMovement()
    {
        Vector3 pos = new Vector3(0,transform.position.y,0);
        agent.SetDestination(pos);
        if(transform.position.x >= -1 && transform.position.x <= 1 && transform.position.z >= -1 && transform.position.z <= 1)
        {
            fright.ResetState();
        }

    }
}
