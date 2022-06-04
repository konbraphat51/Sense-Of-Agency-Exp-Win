using System.Collections.Generic;
using UnityEngine;

public class MovementQueue
{
    private float invokeTime;
    public Vector3 movement;

    public MovementQueue(float invokeTime, Vector3 movement)
    {
        this.invokeTime = invokeTime;
        this.movement = movement;
    }

    public bool ShouldMove(float currentTime)
    {
        if (this.invokeTime - currentTime <= 0.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float basicSpeed = 5.0f;
    [SerializeField] private float delayTime = 1.0f;

    [SerializeField] private GameObject rightBorderObj;
    [SerializeField] private GameObject leftBorderObj;
    [SerializeField] private GameObject topBorderObj;
    [SerializeField] private GameObject bottomBorderObj;

    private float rightBorder;
    private float leftBorder;
    private float topBorder;
    private float bottomBorder;

    private bool isDelaying = true;
    private List<MovementQueue> movementQueue = new List<MovementQueue>();

    private void Start()
    {
        //Set border
        rightBorder = rightBorderObj.transform.position.x;
        leftBorder = leftBorderObj.transform.position.x;
        topBorder = topBorderObj.transform.position.y;
        bottomBorder = bottomBorderObj.transform.position.y;
    }

    private void Update()
    {
        Vector3 inputMovement = InputMovement();

        switch (isDelaying)
        {
            case true:
                DelayedMovement(inputMovement);
                break;
            case false:
                NormalMovement(inputMovement);
                break;
        }
    }

    public void Delay(bool shouldDelay)
    {
        isDelaying = shouldDelay;
    }

    private Vector3 InputMovement()
    {
        float currentSpeed = basicSpeed;
        Vector3 output = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            output += new Vector3(0, currentSpeed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            output += new Vector3(0, -currentSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            output += new Vector3(currentSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            output += new Vector3(-currentSpeed, 0, 0);
        }

        return output;
    }

    private void DelayedMovement(Vector3 inputMovement)
    {
        float currentTime = Time.time;
        Vector3 outputMovement = new Vector3(0, 0, 0);

        //Register
        MovementQueue q = new MovementQueue(currentTime + delayTime, inputMovement);
        movementQueue.Add(q);

        //Invoking queue
        while (movementQueue[0].ShouldMove(currentTime))
        {
            outputMovement += movementQueue[0].movement;
            movementQueue.RemoveAt(0);
        }

        //Actual move
        Move(outputMovement);
    }

    private void NormalMovement(Vector3 movement)
    {
        Move(movement);
    }

    private void Move(Vector3 movement)
    {
        float x = Mathf.Clamp(transform.position.x + movement.x, leftBorder, rightBorder);
        float y = Mathf.Clamp(transform.position.y + movement.y, bottomBorder, topBorder);

        transform.position = new Vector3(x,y, 0);
    }
}
