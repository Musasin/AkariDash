using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Title : MonoBehaviour
{
    Image fadePanelImage;
    enum FadeType { None = 0, FadeIn = 1, FadeOut = 2, }
    FadeType fadeType;
    bool isFadeIn;
    bool isFadeOut;
    bool isBlackOut;
    bool isOpenManual;
    float fadeTime;
    string nextScene;

    float red;
    float green;
    float blue;

    void Awake()
    {
        fadePanelImage = GameObject.Find("FadePanel2").GetComponent<Image>();
        fadeType = FadeType.None;
        isFadeIn = false;
        isFadeOut = false;
        isBlackOut = false;
        isOpenManual = false;
        fadeTime = 0;
        nextScene = "";
        red = fadePanelImage.color.r;
        green = fadePanelImage.color.g;
        blue = fadePanelImage.color.b;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fadeTime += Time.deltaTime;

        if (fadeType == FadeType.FadeOut)
        {
            fadePanelImage.color = new Color(red, green, blue, fadeTime);
        }
        else if (fadeType == FadeType.FadeIn)
        {
            fadePanelImage.color = new Color(red, green, blue, 1.0f - fadeTime);
        }

        if (fadeTime > 1.0f && nextScene != "")
        {
            isBlackOut = false;
            SceneManager.LoadScene(nextScene);
        }

        if (Input.GetKeyDown(KeyCode.Return) && !isOpenManual)
        {
            FadeOut("SampleScene");
        }
    }

    public void FadeIn()
    {
        isBlackOut = false;
        fadeType = FadeType.FadeIn;
        fadeTime = 0;
        this.nextScene = "";
    }

    public void FadeOut(string nextScene = "")
    {
        if (!isBlackOut)
        {
            fadeType = FadeType.FadeOut;
            fadeTime = 0;
        }
        this.nextScene = nextScene;
    }

    public void BlackOut(string nextScene = "")
    {
        isBlackOut = true;
        fadeType = FadeType.FadeOut;
        fadeTime = 1.0f;
        this.nextScene = nextScene;
    }

    public bool IsFading()
    {
        return fadeTime < 1.0f;
    }


    public void PlayTitleCall()
    {
        AudioManager.Instance.PlaySE("titlecall");
    }
    public void OpenManual()
    {
        isOpenManual = true;
        AudioManager.Instance.PlaySE("decision3");
    }
    public void CloseManual()
    {
        isOpenManual = false;
        AudioManager.Instance.PlaySE("decision3");
    }
}
