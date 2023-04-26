using UnityEngine;

public static class Cameraf
{
    public static bool IsOnScreen(Transform transform)
    {
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;
        Vector3 difference = Camera.main.transform.position - transform.position;
        return (
            Mathf.Abs(difference.x) < cameraHalfWidth 
            && Mathf.Abs(difference.y) < cameraHalfHeight
        );
    }
}
