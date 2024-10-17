using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0f, 1f)]
    public float smoothTime;

    public Vector3 positionOffset;

    [Header("Axis Limitation")]
    public Vector2 xLimit; //X axis limitation
    public Vector2 yLimit; //Y axis limitation

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosittion = target.position + positionOffset;
        targetPosittion = new Vector3(Mathf.Clamp(targetPosittion.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosittion.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosittion, ref velocity, smoothTime);
    }
}
