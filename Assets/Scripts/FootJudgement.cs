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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        cameraScript.UpdatePlayerPosY();
        canJump = true;
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
