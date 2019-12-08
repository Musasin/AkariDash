using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private FootJudgement footJudgement;
    float velocityX, velocityY;

    const float JUMP_VELOCITY = 15.0f;
    const float WALK_VELOCITY = 7.0f;
    const float JUMP_KEY_MAX_TIME = 0.1f;
    const float DEFAULT_DASH_SPEED = 1.0f;
    const float MAX_DASH_SPEED = 5.0f;
    const float MIN_DASH_SPEED = 0.2f;
    float pressJumpKeyTime;
    float dashSpeed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        footJudgement = GetComponentInChildren<FootJudgement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        dashSpeed = DEFAULT_DASH_SPEED;
        AudioManager.Instance.PlayBGM("bgm_maoudamashii_8bit14", 0.5f, true);
    }

    // Update is called once per frame
    void Update()
    {
        velocityX = rb.velocity.x;
        velocityY = rb.velocity.y;

        UpdateTimes();
        UpdateMove();
        UpdateJump();

        rb.velocity = new Vector2(velocityX, velocityY);
    }


    private void UpdateTimes()
    {
    }

    // 移動処理
    private void UpdateMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dashSpeed = Mathf.Min(dashSpeed + 0.01f, MAX_DASH_SPEED);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dashSpeed = Mathf.Max(dashSpeed - 0.01f, MIN_DASH_SPEED);
        }
        velocityX = WALK_VELOCITY * dashSpeed;
        animator.speed = dashSpeed;

    }

    // ジャンプ処理
    private void UpdateJump()
    {
        if (Input.GetKey(KeyCode.C) && pressJumpKeyTime < JUMP_KEY_MAX_TIME)
        {
            pressJumpKeyTime += Time.deltaTime;
            velocityY = JUMP_VELOCITY;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            pressJumpKeyTime = JUMP_KEY_MAX_TIME;
        }
        if (Input.GetKeyDown(KeyCode.C) && footJudgement.CanJump())
        {
            velocityY = JUMP_VELOCITY;
            pressJumpKeyTime = 0;
            footJudgement.SetCanJump(false);
        }
    }

}
