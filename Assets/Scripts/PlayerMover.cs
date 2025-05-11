using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float speedSide;
    [SerializeField] private float gravity;
    [SerializeField] private int lineToMove = 1;
    [SerializeField] private float lineDistance;
    private CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 speed = new Vector3(0, gravity, speedMove);
        controller.Move(speed * Time.deltaTime);
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        else if (lineToMove == 2) 
        {
            targetPosition += Vector3.right * lineDistance;
        }

        transform.position = targetPosition;
    }


    public void MovementSlide(bool IsRight)
    {
        if (IsRight && lineToMove < 2)
        {
            lineToMove += 1;
        }
        if (!IsRight && lineToMove > 0)
        {
            lineToMove -= 1;
        }
    }
}
