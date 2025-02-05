using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int speed;
    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); 
    }
    // Update is called once per frame
    void Update()
    {
        //Movement
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");
        body.linearVelocity = new Vector2(HorizontalMovement * (2.75f*speed), VerticalMovement * (2.75f*speed));
        //FastMovement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            body.linearVelocity = new Vector2(HorizontalMovement * 3.5f, VerticalMovement * 3.5f) * speed *2;
        }

        if (HorizontalMovement > 0.01f)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
        else if (HorizontalMovement < -0.01f)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}