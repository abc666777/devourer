using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3;

    private const float speedPenalty = 0.5f;
    private const float speedBonus = 1.5f;

    private float movingPenalty = 1;

    public bool isSlow = false;
    public bool isFast = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetSpeed();
        Debug.Log("Current:" + transform.position);
        Debug.Log("Target:" + Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, Input.mousePosition, speed * Time.deltaTime * movingPenalty);
    }

    void SetSpeed()
    {
        if (isSlow && isFast) movingPenalty = (speedPenalty - speedBonus);
        else if (isSlow) movingPenalty = (speedPenalty);
        else if (isFast) movingPenalty = (speedBonus);
        else movingPenalty = 1;
    }
}