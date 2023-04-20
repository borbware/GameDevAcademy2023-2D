using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float screenHeight;
    [SerializeField] float screenWidth;
    [SerializeField] float transitionTime;
    [SerializeField] string cameraState = "static";

    Vector3 startPoint;
    Vector3 endPoint;
    float lerpTime;

    void Start()
    {
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight * Camera.main.aspect;
    }
    void StartMoving()
    {
        Time.timeScale = 0;
        cameraState = "moving";
        startPoint = transform.position;
        lerpTime = 0;        
    }
    void StopMoving()
    {
        cameraState = "static";
        Time.timeScale = 1;
    }
    void Update()
    {
        if (cameraState == "static")
        {
            Vector3 distanceToPlayer = player.transform.position - transform.position;
            if (Mathf.Abs(distanceToPlayer.x) > screenWidth / 2)
            {
                StartMoving();
                float direction = Mathf.Sign(distanceToPlayer.x);
                endPoint = transform.position + Vector3.right * screenWidth * direction;
            }
            else if (Mathf.Abs(distanceToPlayer.y) > screenHeight / 2)
            {
                StartMoving();
                float direction = Mathf.Sign(distanceToPlayer.y);
                endPoint = transform.position + Vector3.up * screenHeight * direction;
            }
        }
        else if (cameraState == "moving")
        {
            transform.position = Vector3.Lerp(startPoint, endPoint, lerpTime / transitionTime);
            lerpTime += Time.unscaledDeltaTime;
            if (transform.position == endPoint)
            {
                StopMoving();
            }
        }
    }
}
