using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pinky : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform pacman;
    private Frightened fright;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        fright = GetComponent<Frightened>();
        
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
        else
        {
            float posRange = Random.Range(- 3, 3);
            Vector3 pos = new Vector3(posRange,0,posRange) + pacman.position;
            agent.SetDestination(pos);
        }
    }

  
    bool isLeft = true;
    private void FrightMovement()
    {
        Vector3 pos;
        if(isLeft)
        {  
            pos = new Vector3(-13f,transform.position.y,14f);
            isLeft = false;
        }
        else
        {
            pos = new Vector3(-1.5f,transform.position.y,-10f);
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
