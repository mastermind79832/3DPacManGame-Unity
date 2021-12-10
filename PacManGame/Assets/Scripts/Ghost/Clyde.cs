using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Clyde : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform pacman;

    Vector3 pos = Vector3.zero;
    float PosResetTime = 6;

    // private float dis = 2;
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
     // if( ((pacman.position.x - dis )> transform.position.x || ( pacman.position.x +dis ) < transform.position.x) && ((pacman.position.z - dis) > transform.position.z || (pacman.position.z + dis) < transform.position.z) )
        // {
        //     agent.SetDestination(pacman.position);
        //     PosResetTime = 0;
        // }
        if( (pacman.position.x > (transform.position.x - 2f) && pacman.position.z > (transform.position.z - 2f)) && (pacman.position.x < (transform.position.x + 2f) && pacman.position.z < (transform.position.z + 2f)) )
        {
            agent.SetDestination(pacman.position);
        }

        if(PosResetTime > 5)
        {
            
            pos = new Vector3(Random.Range(-13, 13),transform.position.y,Random.Range(-16,14));
            agent.SetDestination(pos);
            PosResetTime = 0;
        }
    
        PosResetTime += Time.fixedDeltaTime;

        
        
    }

   
    bool isLeft = true;
    private void FrightMovement()
    {
        Vector3 pos;
        if(isLeft)
        {  
            pos = new Vector3(13,transform.position.y,14);
            isLeft = false;
        }
        else
        {
            pos = new Vector3(2,transform.position.y,10);
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
