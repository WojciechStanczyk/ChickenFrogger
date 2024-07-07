using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 0.25f;
    [SerializeField] float jump = 1f;
    [SerializeField] float rayLength = 1.4f;

    public Rigidbody rb_jump;

    Vector3 targetPosition;
    Vector3 startPosition;

    bool moving;
    bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        rb_jump.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                moving = false;
                return;
            }

            transform.position = transform.position + (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
        {
            if (!Physics.Raycast(transform.position, Vector3.forward, rayLength))
            {
                rb_jump.AddForce(Vector3.up * jump, ForceMode.Impulse);
                targetPosition = transform.position + Vector3.forward;
                startPosition = transform.position;
                moving = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (!Physics.Raycast(transform.position, Vector3.back, rayLength))
            {
                rb_jump.AddForce(Vector3.up * jump, ForceMode.Impulse);
                targetPosition = transform.position + Vector3.back;
                startPosition = transform.position;
                moving = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (!Physics.Raycast(transform.position, Vector3.left, rayLength))
            {
                rb_jump.AddForce(Vector3.up * jump, ForceMode.Impulse);
                targetPosition = transform.position + Vector3.left;
                startPosition = transform.position;
                moving = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow)  || Input.GetKeyDown(KeyCode.D))
        {
            if (!Physics.Raycast(transform.position, Vector3.right, rayLength))
            {
                rb_jump.AddForce(Vector3.up * jump, ForceMode.Impulse);
                targetPosition = transform.position + Vector3.right;
                startPosition = transform.position;
                moving = true;
            }
        }
    }

   

}
