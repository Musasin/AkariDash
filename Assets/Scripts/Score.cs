using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float time;
    int score;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        score = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticValues.IsCountDownPause())
        {
            return;
        }

        time += Time.deltaTime;
        float sec = Mathf.Floor(time);
        string secText = sec.ToString().PadLeft(3, '0');
        float fewSec = Mathf.Floor((time - sec) * 1000);
        string fewSecText = fewSec.ToString().PadRight(3, '0');
        text.text = "SCORE: " + score.ToString().PadLeft(7, '0') + "\nTIME: " + secText + '.' + fewSecText;

        Debug.Log("time: " + time);
        Debug.Log("sec: " + sec);
        Debug.Log("fewSec: " + fewSec);
    }

    public void AddScore(int point)
    {
        score += point;
    }
}
