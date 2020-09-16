using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T manager;
    public static T Manager
    {
        get
        {
            if (manager == null)
            {
                manager = FindObjectOfType<T>();
            }
            return manager;
        }
    }
}
