using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraAction : MonoBehaviour
{
    [Header("����ٴ� Ÿ��")]
    public GameObject target;

    [Header("��")]
    public GameObject mapTarget;

    [Header("ī�޶� ��ǥ")]
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float offsetZ = -0.5f;

    [Header("ī�޶� �̵� �ӵ�")]
    public float speed = 5.0f;

    [Header("ī�޶� ���� ���� ����")]
    public float padding = 1.8f;

    private Vector3 targetPos;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        SpriteRenderer spriteRenderer = mapTarget.GetComponent<SpriteRenderer>();
        float spriteHalfWidth = spriteRenderer.bounds.extents.x;
        float spriteHalfHeight = spriteRenderer.bounds.extents.y;

        minX = mapTarget.transform.position.x - spriteHalfWidth + (padding * padding);
        maxX = mapTarget.transform.position.x + spriteHalfWidth - (padding * padding);
        minY = mapTarget.transform.position.y - spriteHalfHeight + padding;
        maxY = mapTarget.transform.position.y + spriteHalfHeight - padding;
    }

    void FixedUpdate()
    {
        float clampedX = Mathf.Clamp(target.transform.position.x + offsetX, minX, maxX);
        float clampedY = Mathf.Clamp(target.transform.position.y + offsetY, minY, maxY);

        targetPos = new Vector3(clampedX, clampedY, target.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
    }
}
