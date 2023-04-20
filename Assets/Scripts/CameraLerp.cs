using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float screenHeight;
    [SerializeField] float screenWidth;
    [SerializeField] float transitionTime;
    [SerializeField] string cameraState = "static";

    float startX;
    float endX;
    float lerpTime;

    void Start()
    {
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    void Update()
    {
        if (cameraState == "static")
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) > screenWidth / 2)
            {
                cameraState = "moving";
                startX = transform.position.x;
                float direction = Mathf.Sign(player.transform.position.x - transform.position.x);
                endX = transform.position.x + screenWidth * direction;
                lerpTime = 0;
            }
        }
        else if (cameraState == "moving")
        {
            transform.position = new Vector3(
                Mathf.Lerp(startX, endX, lerpTime / transitionTime),
                0,
                -10
            );
            lerpTime += Time.deltaTime;
            if (transform.position.x == endX)
            {
                cameraState = "static";
            }
        }
    }
}
