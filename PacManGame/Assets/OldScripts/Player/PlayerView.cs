using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public float MovementSpeed;
    public Rigidbody rb;

    public GameManager gameManager;

    private PlayerController playerController;

  

    

    // Start is called before the first frame update
    void Start()
    {
        playerController = new PlayerController(MovementSpeed ,this,rb);

        
    }

    // Update is called once per frame
    void Update()
    {
        

        GetInput();
    }

    private void FixedUpdate()
    {
        playerController.MoveForward();
        
    }

    private void GetInput()
    {
        

        if(Input.GetKeyDown(KeyCode.W))
        {

            playerController.ChangeDirection(Vector3.forward);
            //Debug.Log(IsPathClear(Vector3.forward));
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            playerController.ChangeDirection(Vector3.back);
            //Debug.Log(IsPathClear(Vector3.back));
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            playerController.ChangeDirection(Vector3.left);
            //Debug.Log(IsPathClear(Vector3.left));
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            playerController.ChangeDirection(Vector3.right);
            //Debug.Log(IsPathClear(Vector3.right));
        }
    }

    // private bool IsPathClear(Vector3 direction)
    // {
    //     Quaternion rotation = Quaternion.Euler(0,transform.rotation.y,0);
    //     Vector3 pos = new Vector3(transform.position.x, 1 , transform.position.z);
    //     bool hit = Physics.BoxCast(pos,Vector3.one * 0.1f,direction,rotation,0.5f,6);
    //     // DrawBoxCastOnHit(pos,Vector3.one * 0.1f,direction,rotation,0.5f,6);
    //     Debug.DrawRay(pos,direction,Color.red,0.5f);

    //     extDe
        


    //     return hit;
    // }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pelet")
        {
            Destroy(other.gameObject);
            gameManager.IncreaseScore(10);
        }
        if(other.tag == "PowerUp")
        {
            gameManager.PowerUpActivated();
            Destroy(other.gameObject);
            gameManager.IncreaseScore(30);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ghost")
        {
            Frightened fright;
            fright = other.gameObject.GetComponent<Frightened>();
            if(!fright.isFrightened && !fright.isEaten)
            {
                gameManager.GameOver();
                return;
            }

            if(fright.isFrightened)
            {
                gameManager.IncreaseScore(50);
            }
        }
        
    }

}
