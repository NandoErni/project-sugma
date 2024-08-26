using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var two = GetComponent<TestTwo>();
        two.IsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
