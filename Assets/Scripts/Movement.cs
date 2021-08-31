using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer trail;
    public static float speed = 10;
    private readonly float speedModifier = 45000f;
    private Rigidbody rb;
    private Vector3 newPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (GameManager.startGame)
        {
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
                rb.velocity = Vector3.ClampMagnitude(new Vector3(newPosition.x, rb.velocity.y, rb.velocity.z), 60f);
            }
            MoveForward();
        }
    }
    private void MoveForward()
    {
        trail.transform.position = new Vector3(trail.transform.position.x, 0.5f, trail.transform.position.z);
        rb.AddForce(Vector3.forward * 15000 * Time.deltaTime);
        if (rb.velocity.z > speed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }
}
