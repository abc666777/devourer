using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform leftBounds;
    public Transform rightBounds;
    public Transform upBounds;
    public Transform downBounds;

    private float smoothDampTime = 0.15f;
    private Vector3 smoothDampVelocity = Vector3.zero;
    private float camWidth, camHeight, levelMinX, levelMaxX, levelMinY, levelMaxY;

    // Start is called before the first frame update

    void Start()
    {
        target = GameObject.Find(GlobalReferences.player).transform;
        camHeight = Camera.main.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;

        float leftBoundWidth = leftBounds.GetComponent<Collider2D>().bounds.size.x / 2;
        float rightBoundWidth = rightBounds.GetComponent<Collider2D>().bounds.size.x / 2;

        float upBoundHeight = upBounds.GetComponent<Collider2D>().bounds.size.y / 2;
        float downBoundHeight = downBounds.GetComponent<Collider2D>().bounds.size.y / 2;

        levelMinX = leftBounds.position.x + leftBoundWidth + (camWidth / 2);
        levelMaxX = rightBounds.position.x - rightBoundWidth - (camWidth / 2);

        levelMaxY = upBounds.position.y - upBoundHeight - (camHeight / 2);
        levelMinY = downBounds.position.y + downBoundHeight + (camHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            float targetX = Mathf.Max(levelMinX, Mathf.Min(levelMaxX, target.position.x));
            float targetY = Mathf.Max(levelMinY, Mathf.Min(levelMaxY, target.position.y));
            float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smoothDampTime);
            float y = Mathf.SmoothDamp(transform.position.y, targetY, ref smoothDampVelocity.y, smoothDampTime);

            transform.position = new Vector3(x, y, -10);
        }
    }
}
