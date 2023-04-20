using UnityEngine;

public class Lerps : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;

    [SerializeField] float time;
    void Start()
    {
        
    }

    void Update()
    {

        transform.position = Vector3.Lerp(startPos, endPos, Time.time - 2);

        // transform.position = new Vector3(
        //     Mathf.Lerp(-4, 4, Time.time - 2),
        //     0,
        //     0
        // );  
    }
}
