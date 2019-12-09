using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootJudgement : MonoBehaviour
{
    Camera cameraScript;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        cameraScript = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            //cameraScript.UpdatePlayerPosY();
            canJump = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            //cameraScript.UpdatePlayerPosY();
            canJump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            canJump = false;
        }
    }
    public void SetCanJump(bool canJump)
    {
        this.canJump = canJump;
    }
    public bool CanJump()
    {
        return canJump;
    }
}
