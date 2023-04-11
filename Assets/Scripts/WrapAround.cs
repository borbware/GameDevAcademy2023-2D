using UnityEngine;

public class WrapAround : MonoBehaviour
{
    float halfScreenWidth = 11.2f;
    float halfScreenHeight = 6.3f;
    void Update()
    {
        Vector3 xVec = Vector3.right * halfScreenWidth * 2; // Vector3.right = new Vector3(1,0,0)
        Vector3 yVec = Vector3.up * halfScreenHeight * 2; // Vector3.up = new Vector3(0,1,0)

        if (transform.position.x > halfScreenWidth)
            transform.position -= xVec;
        if (transform.position.x < -halfScreenWidth)
            transform.position += xVec;

        if (transform.position.y > halfScreenHeight)
            transform.position -= yVec;
        if (transform.position.y < -halfScreenHeight)
            transform.position += yVec;
    }
}
