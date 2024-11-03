using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 velocity = Vector3.zero;

    [Range(0.1f, 1f)]
    public float smoothTime = 0.3f;

    public Vector3 positionOffset;
    //[Header("Axis Limitation")]
    //public Vector2 xLimit;
    //public Vector2 yLimit;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found in the scene.");
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;  

        Vector3 targetPosition = target.position + positionOffset;
        //targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y),Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y),-10);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
