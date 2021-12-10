
using UnityEngine;

public class PlayerModel 
{
    PlayerController playerController;

    private float MoveSpeed;


    public PlayerModel(float speed, PlayerController controller)
    {
        MoveSpeed = speed;
        playerController = controller;
    }

    public float GetSpeed()
    {
        return MoveSpeed;
    }
}
