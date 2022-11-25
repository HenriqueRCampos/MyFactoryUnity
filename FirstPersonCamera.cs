using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    public static RaycastHit hit;
    private bool hitraycast;

    private float rotationY = 0;
    private float rotationX = 0;

    public float sensibilityY = 0.5f;
    public float sensibilityX = 0.5f;

    float minY_angle = -90;
    float maxY_angle = 90;

    public Transform rayCastOrigin;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMouse = Input.GetAxisRaw("Mouse Y") * sensibilityY;
        float horizontalMouse = Input.GetAxisRaw("Mouse X") * sensibilityX;

        rotationX += horizontalMouse;
        rotationY += verticalMouse;

        rotationY = Mathf.Clamp(rotationY, minY_angle, maxY_angle);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
    
    private void OnDrawGizmos()
    {
        float maxDistance = 2.4f;
        hitraycast = Physics.Raycast(rayCastOrigin.position, rayCastOrigin.forward, out hit, maxDistance);
        if (hitraycast)
        {
            //Debug.Log(hit.transform.name);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
 
}
