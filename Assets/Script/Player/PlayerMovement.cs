using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector3 PlayerPosition { get; private set; }
    public Animator animator;
    public enum State
    {
        normal,
        UI,
        hide,
        
    }

    public static Vector3 playerPosition;
    private Rigidbody rigidbodyPlayer;
    private Vector3 direction;
    private Vector3 pointToLook;
    
    private Camera mainCamera;
    private Resurrection resurrection;
    public float moveSpeed = 6f;
    
    bool isMove = true;
    
    public State state;

    void Awake()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        resurrection = FindObjectOfType<Resurrection>();
        state = State.normal;
    }

    
    void Update()
    {
        PlayerPosition = transform.position;

        switch (state)
        {
            case State.normal:
                if (Input.GetMouseButton(1))
                {
                    isMove = false;
                }
                else isMove = true;
                if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
                {
                    animator.SetBool("IsMove", false);
                }
                
                playerPosition = GetComponent<Transform>().position;
                direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
                
                
                break;

            case State.UI:
                break;

            case State.hide:
            animator.SetBool("IsMove", false);
                break;
        }

    }
    private void FixedUpdate()
    {
        switch(state)
        {
            case State.normal:
                if (direction.magnitude >= 0.1f)
                {
                    SmoothRotate();
                }

                if (isMove)
                {
                    animator.SetBool("IsMove", true);
                    
                    rigidbodyPlayer.velocity = direction * moveSpeed;
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

    public void AttackRecevied()
    {
        state = State.hide;
        resurrection.PlayerDied();
    }
}
