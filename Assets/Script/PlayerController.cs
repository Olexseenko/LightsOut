using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum State
    {
        Normal,
        UI,
    }

    private Rigidbody rigidbody;
    private Vector3 direction;
    private Vector3 pointToLook;
    
    private Camera mainCamera;
    public float moveSpeed = 6f;
    
    bool isMove = true;
    
    public State state;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        state = State.Normal;
    }

    
    void Update()
    {
        switch(state)
        {
            case State.Normal:
                direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
                if (Input.GetMouseButton(1))
                {
                    isMove = false;
                }
                else isMove = true;
                
                break;

            case State.UI:
                break;
        }

    }
    private void FixedUpdate()
    {
        switch(state)
        {
            case State.Normal:
                if (direction.magnitude >= 0.1f)
                {
                    SmoothRotate();
                }

                if (isMove)
                {
                    rigidbody.velocity = direction * moveSpeed;
                }
                

                break;

            case State.UI:
                break;
        }
        

    }

    
    void SmoothRotate()
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, targetAngle, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, angle, 0.2f);
    }

   
    void LookAtMousePosition()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
            
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

        }
    }
}
