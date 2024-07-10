
using UnityEngine;

public class UIJoyStick : MonoBehaviour
{
    private Transform stickTransform;

    public float stickRadius = 50f;

    private Vector2 startBackPosition;
    private Vector2 startStickPosition;

    private bool isDragging;

    private void Start()
    {
        stickTransform = transform.GetChild(0).GetComponent<Transform>();

        startBackPosition = transform.position;
        startStickPosition = stickTransform.position;

        isDragging = false;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            Vector2 mousePosition = Input.mousePosition;

            if (mousePosition.x < Screen.width / 2)
            {
                transform.position = Input.mousePosition;
                isDragging = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            ResetPosition();
        }

        if (isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 direction = currentMousePosition - (Vector2)transform.position;
            float distance = Mathf.Clamp(direction.magnitude, 0, stickRadius);
            Vector2 clampedPosition = (Vector2)transform.position + direction.normalized * distance;
            stickTransform.position = clampedPosition;
        }
    }

    private void ResetPosition()
    {
        transform.position = startBackPosition;
        stickTransform.position = startStickPosition;
    }
}
