using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isTouching = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isTouching = true;
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    if (isTouching)
                    {
                        touchEndPos = touch.position;
                        Vector2 delta = touchEndPos - touchStartPos;

                        float horizontalRotation = delta.x * rotationSpeed;
                        float verticalRotation = -delta.y * rotationSpeed;

                        transform.Rotate(Vector3.up, horizontalRotation, Space.World);
                        transform.Rotate(Vector3.right, verticalRotation, Space.World);

                        touchStartPos = touchEndPos;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isTouching = false;
                    break;
            }
        }
    }
}
