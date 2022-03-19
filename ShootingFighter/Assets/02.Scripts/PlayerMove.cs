using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Ű���� ȭ��ǥ ����Ű ����, ������ ����Ű�� X ������ ������
    // Ű���� ȭ��ǥ ����Ű ����, �Ʒ��� ����Ű�� Z ������ ������
    Transform tr;
    Vector3 move;
    public float speed = 1f;
    private void Awake()
    {
        tr = GetComponent<Transform>();   
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        move = new Vector3(h, 0, y);
    }
    private void FixedUpdate()
    {
        tr.Translate(move * speed * Time.fixedDeltaTime);
    }
}
