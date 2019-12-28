using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticValues : MonoBehaviour
{
    public static bool isCountDownPause = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetCountDownPause(bool flag)
    {
        isCountDownPause = flag;
    }
    public static bool IsCountDownPause()
    {
        return isCountDownPause;
    }
}
