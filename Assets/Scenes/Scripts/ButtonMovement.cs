using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMovement : MonoBehaviour
{
    public float gridSize = 1f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpHeight = 200f;

    private float raylength = 1.4f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    // References to the UI buttons
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    public Button exitButton;   

    void Start()
    {
        targetPosition = transform.position;

        // Assign button click events
        upButton.onClick.AddListener(OnUpButton);
        downButton.onClick.AddListener(OnDownButton);
        leftButton.onClick.AddListener(OnLeftButton);
        rightButton.onClick.AddListener(OnRightButton);
        exitButton.onClick.AddListener(onExitButton);
    }

    void Update()
    {
       
    }

    public void OnUpButton()
    {
        if (!isMoving)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = targetRotation;
            if (!Physics.Raycast(transform.position, Vector3.forward, raylength))
            {
                targetPosition += new Vector3(0, 0, gridSize);
                StartCoroutine(MoveToPosition());
            }
        }
    }

    public void OnDownButton()
    {
        if (!isMoving)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = targetRotation;
            if (!Physics.Raycast(transform.position, Vector3.back, raylength))
            {
                targetPosition += new Vector3(0, 0, -gridSize);
                StartCoroutine(MoveToPosition());
            }
        }
    }

    public void OnLeftButton()
    {
        if (!isMoving)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 270, 0);
            transform.rotation = targetRotation;
            if (!Physics.Raycast(transform.position, Vector3.left, raylength))
            {
                targetPosition += new Vector3(-gridSize, 0, 0);
                StartCoroutine(MoveToPosition());
            }
        }
    }

    public void OnRightButton()
    {
        if (!isMoving)
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

    public void onExitButton()
    {
        //SceneManager.LoadScene("Menu");
        Application.Quit();
    }


    private IEnumerator MoveToPosition()
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

                //  smooth jump sin
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