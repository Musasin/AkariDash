﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ParticleSystem ps;
    SpriteRenderer sr;
    float deadTime;
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        deadTime = 0;
        ps = GetComponentInChildren<ParticleSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            deadTime += Time.deltaTime;
        sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f - deadTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ps.Play();
            isDead = true;
            AudioManager.Instance.PlaySE("Coin", 0.2f);
        }
    }
}