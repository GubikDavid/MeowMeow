using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float speed = 10;
    //private readonly float speedModifier = 45f;
    private readonly float speedModifier = 30000f;
    private Rigidbody rb;
    private Vector3 newPosition;
    //private float move;
    private Vector3 pastPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (GameManager.startGame)
        {
            /*if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        newPosition = Vector3.right * (touch.deltaPosition.x * speedModifier * Time.deltaTime);
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Stationary:
                        newPosition.x = 0;
                        break;
                }
                rb.velocity = Vector3.ClampMagnitude(new Vector3(newPosition.x, rb.velocity.y, rb.velocity.z), 60f);
            }*/
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        Vector2 dragDistance = new Vector2(touch.deltaPosition.x / Screen.width, touch.deltaPosition.y / Screen.height);
                        newPosition = speedModifier * Time.deltaTime * dragDistance * Vector3.right;
                        break;
                    case TouchPhase.Stationary:
                    case TouchPhase.Ended:
                        newPosition.x = 0;
                        break;
                }

                /*switch (touch.phase)
                {
                    Touch touch = Input.GetTouch(0);
                    case TouchPhase.Began:
                        pastPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                        break;
                    case TouchPhase.Moved:
                        newPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                        move = (newPosition.x - pastPosition.x) * speedModifier * Time.deltaTime;
                        pastPosition = newPosition;
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Stationary:
                    case TouchPhase.Canceled:
                        move = 0;
                        //rb.angularVelocity = Vector3.zero;
                        break;
                }*/
                rb.velocity = Vector3.ClampMagnitude(new Vector3(newPosition.x, rb.velocity.y, rb.velocity.z), 60f);
            }
            MoveForward();
        }
    }
    private void MoveForward()
    {
        rb.AddForce(Vector3.forward * 15000 * Time.deltaTime);
        if (rb.velocity.z > speed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }
}
