using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Blinky : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform pacman;
    public Rigidbody rb;

   private Frightened fright;

    float time = 3;

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
          EatenMovement();return;
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
        agent.SetDestination(pacman.position);
    }

    bool isLeft = true;
    private void FrightMovement()
    {
        Vector3 pos;
        if(isLeft)
        {  
            pos = new Vector3(13,transform.position.y,-16);
            isLeft = false;
        }
        else
        {
            pos = new Vector3(5,transform.position.y,-11);
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
