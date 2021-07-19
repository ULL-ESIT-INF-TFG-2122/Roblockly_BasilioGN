using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    private static List<GameObject> findAbleObjects = new List<GameObject>();

    public static Finder finderInstance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (Finder.finderInstance == null)
        {
            Finder.finderInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool CheckContains(string tagToCheck)
    {
        for (int i = 0; i < findAbleObjects.Count; i++)
        {
            Debug.Log("current tag: " + tagToCheck);
            if (findAbleObjects[i].tag == tagToCheck)
            {
                Debug.Log("Ha entrado en el if");
                return true;
            }   
        }
        return false;
    }

    public static void AddObject(GameObject objectToAdd)
    {
        findAbleObjects.Add(objectToAdd);
    }

    public static void RemoveElementByTag(string objectTag)
    {
        for (int i = 0; i < findAbleObjects.Count; i++)
        {
            if (findAbleObjects[i].tag == objectTag)
            {
                findAbleObjects.RemoveAt(i);
            }
        }
    }
}
