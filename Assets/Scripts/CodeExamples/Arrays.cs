using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{

    [SerializeField] int[] collectionOfIntegers;
    // three ways to achieve the same result:
    string[] names1 = new string[2] {"matti", "teppo"};
    string[] names2 = new string[] {"matti", "teppo"};
    string[] names3 = {"matti", "teppo"};
    [SerializeField] List<string> namesList = new List<string>() {"matti", "teppo"};
    [SerializeField] GameObject[] solttusArray = new GameObject[16];
    [SerializeField] List<GameObject> solttusList = new List<GameObject>();

    void Start()
    {

        collectionOfIntegers = new int[5] {1, 1, 1, 1, 1};

        collectionOfIntegers[0] = 10;
        collectionOfIntegers[1] = 20;
        if (collectionOfIntegers.Length > 2)
        {
            collectionOfIntegers[2] = 30;
            Debug.Log(collectionOfIntegers[2]);
        }

        int lastIndex = collectionOfIntegers.Length - 1;
        Debug.Log(collectionOfIntegers[lastIndex]);

        for (int i = 0; i < solttusArray.Length; i++)
        {
            if (solttusArray[i] != null)
            {
                solttusArray[i].transform.Rotate(0, 0, 180);
            }
        }

        GameObject[] solttus2 = GameObject.FindGameObjectsWithTag("Solttu");

        for (int i = 0; i < solttus2.Length; i++)
        {
            solttus2[i].transform.Rotate(0, 0, 90);
        }

        solttusList.Add(solttus2[1]);
        solttusList.Add(solttus2[2]);
        solttusList.Remove(solttus2[1]);

        for (int i = 0; i < solttusList.Count; i++)
        {
            solttusList[i].transform.Translate(0.5f, 0.5f, 0f);
        }

        if (namesList.Contains("matti"))
        {
            namesList.Add("seppo");
        }

    }

    void Update()
    {
        
    }
}
