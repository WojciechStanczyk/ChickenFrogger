using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement2 : MonoBehaviour
{
    public float gridSize = 1f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpHeight = 200f;

    private float raylength = 1.4f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    
    }

    void Update()
    {

        if (!isMoving)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = targetRotation;
                if (!Physics.Raycast(transform.position, Vector3.forward, raylength))
                {
                    targetPosition += new Vector3(0, 0, gridSize);
                    StartCoroutine(MoveToPosition());
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = targetRotation;
                if (!Physics.Raycast(transform.position, Vector3.back, raylength))
                {
                    targetPosition += new Vector3(0, 0, -gridSize);
                    StartCoroutine(MoveToPosition());
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Quaternion targetRotation = Quaternion.Euler(0, 270, 0);
                transform.rotation = targetRotation;
                if (!Physics.Raycast(transform.position, Vector3.left, raylength))
                {
                    targetPosition += new Vector3(-gridSize, 0, 0);
                    StartCoroutine(MoveToPosition());
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                transform.rotation = targetRotation;
                if (!Physics.Raycast(transform.position, Vector3.right, raylength))
                {
                    targetPosition += new Vector3(gridSize, 0, 0);
                    StartCoroutine(MoveToPosition());
                }
            }
        }
    }


    private System.Collections.IEnumerator MoveToPosition()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = targetPosition;
        float elapsedTime = 0f;

        while ((transform.position - targetPosition).sqrMagnitude > Mathf.Epsilon)
        {
            while (elapsedTime < 1f / moveSpeed)
            {
                elapsedTime += Time.deltaTime * moveSpeed;
                float t = Mathf.Clamp01(elapsedTime * moveSpeed);

                // Calculate the jump height using a sine wave for a smooth jump arc
                float height = Mathf.Sin(Mathf.PI * t) * jumpHeight;

                transform.position = Vector3.Lerp(startPosition, endPosition, t) + new Vector3(0, height, 0);
                yield return null;
            }

            // Ensure the object ends exactly at the target position
            transform.position = targetPosition;

            isMoving = false;
        }
    }
}

