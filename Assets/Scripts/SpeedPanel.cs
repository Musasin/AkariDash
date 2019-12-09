using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPanel : MonoBehaviour
{
    RectTransform rt;
    float percent;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        percent = 0.1f;
        rt = this.GetComponent<RectTransform>();
        rt.localScale = new Vector2(0.0f, 1.0f);
        img = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime;
        rt.localScale = Vector2.MoveTowards(rt.localScale, new Vector2(percent, 1.0f), step);
        img.color = new Color(1.0f, 1.0f - percent, 0.5f - percent / 2);
    }

    public void SetSpeedPercent(float p)
    {
        percent = p;
        Debug.Log(percent);
        Debug.Log(p);
    }
}
