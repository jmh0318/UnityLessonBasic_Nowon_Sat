using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isDetected
    {
        get
        {
            return detectedGround != null ? true : false;
        }
    }
    public Collider2D detectedGround;
    public Collider2D lastGround;
    public Collider2D ignoringGround;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private Vector2 size;
    private Vector2 center;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        size.x = col.size.x / 2;
        size.y = 0.005f;
    }

    private void Update()
    {
        center.x = rb.position.x + col.offset.x;
        center.y = rb.position.y + col.offset.y - col.size.y / 2 - size.y;
        detectedGround = Physics2D.OverlapBox(center, size, 0, groundLayer);
        if (detectedGround != null)
            lastGround = detectedGround;
    }

    public void IgnoreGroundUntilPassedIt()
    {
        ignoringGround = lastGround;
        if (ignoringGround != null)
        StartCoroutine(E_IgnoreGroundUntilPassedIt(lastGround));
    }

    IEnumerator E_IgnoreGroundUntilPassedIt(Collider2D groundCol)
    {
        Physics2D.IgnoreCollision(col, groundCol, true);
        float passingGroundColCenter = groundCol.transform.position.y + groundCol.offset.y;

        // �÷��̾ �ش� �׶��带 �������� �����ϴ��� üũ
        yield return new WaitUntil(() =>
        {
            return rb.position.y + col.offset.y - col.size.y / 2 < passingGroundColCenter;
        }
        );

        // �÷��̾ �ش� �׶��带 ������ ���������� üũ
        yield return new WaitUntil(() =>
        {
            bool isPassed = false;

            if (groundCol != null)
            {
                // ������ �̵��ҽø� ����ؼ� ��ġ ��� ������
                passingGroundColCenter = groundCol.transform.position.y + groundCol.offset.y;

                // �÷��̾ ������ ����ߴ��� üũ
                // 1. �÷��̾ �������鼭 �������
                // 2. �÷��̾ �ö󰡸鼭 �������
                if ((rb.position.y + col.offset.y + col.size.y / 2 < passingGroundColCenter - size.y) ||
                   (rb.position.y + col.offset.y + col.size.y / 2 > passingGroundColCenter + size.y))
                {
                    isPassed = true;
                }
            }
            // ������ ������� ���
            else
                isPassed = true;

            return isPassed;
        });

        Physics.IgnoreCollision(col, groundCol, false);
    }

    private void OnDrawGizmos()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        size.x = col.size.x / 2;
        size.y = 0.005f;
        center.x = rb.position.x + col.offset.x;
    }
}