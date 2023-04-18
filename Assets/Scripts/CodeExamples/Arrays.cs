using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{
    [SerializeField] GameObject solttu;
    [SerializeField] int[] collectionOfIntegers;
    // three ways to achieve the same result:
    string[] names1 = new string[2] {"matti", "teppo"};
    string[] names2 = new string[] {"matti", "teppo"};
    string[] names3 = {"matti", "teppo"};
    [SerializeField] List<string> namesList = new List<string>() {"matti", "teppo"};
    [SerializeField] GameObject[] solttusArray = new GameObject[16];
    [SerializeField] List<GameObject> solttusList = new List<GameObject>();

    void ThrashFunction()
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

        foreach (string name in namesList)
        {
            int i = namesList.IndexOf(name);
            Debug.Log($"{i}: {name}");
        }
        for (int i = 0; i < namesList.Count; i++)
        {
            namesList[i] += " :D";
            string name = namesList[i];
            name += "DDDDD";
            Debug.Log($"{i}: {name}");
            namesList[i] = name;
        }
        // converting array to list
        GameObject[] solttusOnceAgainArray = GameObject.FindGameObjectsWithTag("Solttu");
        List<GameObject> solttusOnceAgainList = new List<GameObject>();
        solttusOnceAgainList.AddRange(solttusOnceAgainArray);
        solttusOnceAgainList.RemoveAt(0);
        solttusOnceAgainList.RemoveAt(0);
        solttusOnceAgainList.RemoveAt(0);
        solttusOnceAgainList.RemoveAt(0);

        foreach (GameObject solttu in solttusOnceAgainList)
        {
            solttu.GetComponent<Renderer>().material.color = Color.black;
        }
    }

    void Start()
    {

        CreateSolttusIfNotEmpty();
        // ThrashFunction();
        RemoveSolttusFromList();

    }

    void CreateSolttusIfNotEmpty()
    {
        for (int x = 0; x < 10; x += 1)
        {
            for (int y = 0; y < 2; y += 1)
            {
                Debug.Log($"x: {x}, y: {y}");
                if (NoSolttusInLocation(x + 0.5f, y + 0.5f))
                {
                    Instantiate(solttu, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity);
                }
            }
        }
    }
    bool NoSolttusInLocation(float x, float y)
    {
        GameObject[] solttus = GameObject.FindGameObjectsWithTag("Solttu");
        foreach (GameObject solttu in solttus)
        {
            if (solttu.transform.position.x == x && solttu.transform.position.y == y)
            {
                return false;
            }
        }
        return true;
    }
    void RemoveSolttusFromList()
    {
        GameObject[] solttusOnceAgainArray = GameObject.FindGameObjectsWithTag("Solttu");
        List<GameObject> solttusOnceAgainList = new List<GameObject>();
        solttusOnceAgainList.AddRange(solttusOnceAgainArray);

        Debug.Log(solttusOnceAgainList.Count);
        for (int i = solttusOnceAgainList.Count - 1; i >= 0 ; i--)
        {
            GameObject solttu = solttusOnceAgainList[i];
            if (solttu.transform.position.y > 1)
            {
                solttusOnceAgainList.Remove(solttu);
            }
        }
        Debug.Log(solttusOnceAgainList.Count);

        List<GameObject> solttusCopy = new List<GameObject>();
        solttusCopy.AddRange(solttusOnceAgainList);

    }

    void Update()
    {
        
    }
}
