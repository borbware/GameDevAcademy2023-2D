using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    GameObject player;
    [SerializeField] float screenHeight;
    [SerializeField] float screenWidth;
    [SerializeField] float transitionTime;
    [SerializeField] CameraState cameraState = CameraState.Static;

    enum CameraState {
        Static,
        Moving
    };

    Vector3 startPoint;
    Vector3 endPoint;
    float lerpTime;

    void Start()
    {
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight * Camera.main.aspect;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void StartMoving()
    {
        Time.timeScale = 0;
        cameraState = CameraState.Moving;
        startPoint = transform.position;
        lerpTime = 0;        
    }
    void StopMoving()
    {
        cameraState = CameraState.Static;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (cameraState == CameraState.Static)
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
        else if (cameraState == CameraState.Moving)
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
