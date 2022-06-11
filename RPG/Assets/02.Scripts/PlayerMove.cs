using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float gravity = 9.81f;
    private Rigidbody rb;
    private Vector3 _move;

    public void SetMove(float x, float z)
    {
        _move.x = x * moveSpeed;
        _move.z = z * moveSpeed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //_move += Vector3.down * gravity;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        playerAnimator.SetFloat("h", h);
        playerAnimator.SetFloat("v", v);

        SetMove(h, v);
        playerAnimator.SetFloat("RunForwardBlend", 1.0f);
    }

    private void FixedUpdate()
    {
        rb.position += _move * moveSpeed * Time.fixedDeltaTime;
    }
}
