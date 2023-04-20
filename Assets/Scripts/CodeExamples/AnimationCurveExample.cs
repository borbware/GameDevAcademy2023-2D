using UnityEngine;

public class AnimationCurveExample : MonoBehaviour
{

    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;
    [SerializeField] float time;
    [SerializeField] AnimationCurve anim;
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.LerpUnclamped(startPos, endPos, anim.Evaluate(Time.time - 2));

        // transform.position = new Vector3(
        //     Mathf.LerpUnclamped(-4, 4, anim.Evaluate(Time.time - 2)),
        //     3,
        //     0
        // );
    }
}
