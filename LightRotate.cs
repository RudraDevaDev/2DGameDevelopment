using UnityEngine;
using UnityEngine.InputSystem;

public class LightRotate : MonoBehaviour
{
    private Camera m_Camera;
    private Vector3 m_Position;
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

    }
}

