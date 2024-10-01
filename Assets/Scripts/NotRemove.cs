using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotRemove : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
