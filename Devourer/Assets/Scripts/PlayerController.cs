using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30f;
    private const float speedPenalty = 0.5f;
    private const float speedBonus = 1.5f;
    private float movingPenalty = 1;
    public bool isSlow = false;
    public bool isFast = false;
    Rigidbody2D rb;
    public int level = 1;

    public float progress = 33;

    public const float maxProgress = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetSpeed();
        Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPosition = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y,0), destination, Time.fixedDeltaTime * speed * movingPenalty);
        rb.MovePosition(newPosition);
    }

    void SetSpeed()
    {
        if (isSlow && isFast) movingPenalty = (speedBonus - speedPenalty);
        else if (isSlow) movingPenalty = (speedPenalty);
        else if (isFast) movingPenalty = (speedBonus);
        else movingPenalty = 1;
    }

    public void LevelUp()
    {
        if (progress >= 33 && progress < 66)
        {
            transform.localScale = new Vector3(2, 2, 0);
            level = 2;
        }
        else if (progress >= 66)
        {
            transform.localScale = new Vector3(3, 3, 0);
            level = 3;
        }
    }
}