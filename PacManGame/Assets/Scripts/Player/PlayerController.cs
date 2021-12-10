
using UnityEngine;

public class PlayerController 
{
    private PlayerModel playerModel;
    private PlayerView playerView;
    private Rigidbody rigidbody;

    private GameObject camera;

    private Vector3 direction = Vector3.right;


    public PlayerController(float speed , PlayerView view, Rigidbody rb)
    {
        playerModel = new PlayerModel(speed, this);
        playerView = view;
        rigidbody = rb;

    }


    public void MoveForward()
    {
        
        rigidbody.velocity = direction * playerModel.GetSpeed();
        float angle = Mathf.Atan2(direction.x,direction.z);
        rigidbody.rotation = Quaternion.AngleAxis((angle * Mathf.Rad2Deg) + 180, Vector3.up);

    }

    public void ChangeDirection( Vector3 curDir)
    {
       
        Quaternion deltaRotation = Quaternion.Euler(curDir);
        direction = curDir;

      
    }

       
        
 
}