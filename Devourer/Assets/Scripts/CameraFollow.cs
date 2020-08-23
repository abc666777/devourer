﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        followTransform = GameObject.Find("Player").transform;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (followTransform != null)
            this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, -10);
    }
}
