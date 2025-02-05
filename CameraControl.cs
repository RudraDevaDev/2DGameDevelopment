using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Player follow camera
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {

        //Follow player
        float x = player.position.x;
        float y = player.position.y;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
