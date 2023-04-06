using UnityEngine;

public class RotateExample : MonoBehaviour
{
    [SerializeField] GameObject pivot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(
            pivot.transform.position, Vector3.forward, 50 * Time.deltaTime
        );
        transform.Rotate(0, 0, 100 * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, 40);
        //transform.eulerAngles = new Vector3(0, 0, 40);
        
        
        transform.Translate(transform.up * 2f * Time.deltaTime);
    }
}
