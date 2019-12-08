using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayObject : MonoBehaviour
{
    bool isIgnore;

    // Start is called before the first frame update
    void Start()
    {
        isIgnore = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isIgnore = true;
        Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), isIgnore);
        Debug.Log(collision);
        Debug.Log("ignore");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isIgnore = false;
        Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), isIgnore);
        Debug.Log(collision);
        Debug.Log("not ignore");
    }

    public bool GetIsIgnore()
    {
        return isIgnore;
    }
}