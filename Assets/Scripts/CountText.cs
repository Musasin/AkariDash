using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StaticValues.SetCountDownPause(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayThree()
    {
        text.text = "3";
        AudioManager.Instance.PlaySE("count_en5-03");
    }
    public void PlayTwo()
    {
        text.text = "2";
        AudioManager.Instance.PlaySE("count_en5-02");
    }
    public void PlayOne()
    {
        text.text = "1";
        AudioManager.Instance.PlaySE("count_en5-01");
    }
    public void PlayGo()
    {
        text.text = "GO!";
        AudioManager.Instance.PlaySE("go!01");
        StaticValues.SetCountDownPause(false);
    }
}
