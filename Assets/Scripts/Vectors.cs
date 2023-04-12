using UnityEngine;

public class Vectors : MonoBehaviour
{

    [SerializeField] Transform goA;
    [SerializeField] Transform goB;
    [SerializeField] Vector3 goAvelocity;
    [SerializeField] Vector3 goAacceleration;
    [SerializeField] Vector3 goBvelocity;
    [SerializeField] Vector3 goBacceleration;

    Vector2 vectorA = new Vector2(6, 3);
    Vector2 vectorB = new Vector2(2, -1);

    void Start()
    {
        Debug.Log(vectorA.magnitude);
        float length = Mathf.Sqrt(Mathf.Pow(vectorA.x, 2) + Mathf.Pow(vectorA.y, 2));
        Debug.Log(length);
        Debug.Log(vectorA.sqrMagnitude);
        Debug.Log(vectorA.magnitude < vectorB.magnitude);
        Debug.Log(vectorA.sqrMagnitude < vectorB.sqrMagnitude);

        Debug.Log(vectorA + vectorB);

        Debug.Log("Gameobject A and B");

        goA.position = new Vector3(2, goA.position.y, goA.position.z);

        Debug.Log(goA.position);
        Debug.Log(goB.position);
        Vector3 difference = goB.position - goA.position;
        Debug.Log(difference.magnitude); 
        // (goB.position - goA.position).magnitude 
    

    }

    // Update is called once per frame
    void Update()
    {
        
        goAacceleration = Vector3.ClampMagnitude(goAacceleration,2);
        goAvelocity += Time.deltaTime * goAacceleration;
        goAvelocity = Vector3.ClampMagnitude(goAvelocity,20);
        goA.position += Time.deltaTime * goAvelocity;

        if (Vector3.Distance(goA.position, goB.position) < 3)
        {
            goB.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            goB.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        goBacceleration = (goA.position - goB.position).normalized * 5;

        goBvelocity += Time.deltaTime * goBacceleration;
        goB.position += Time.deltaTime * goBvelocity;

    }
}
