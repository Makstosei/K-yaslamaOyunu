using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueimage, falseimage;

    private void Awake()
    {
        TrueFalseScaleKapat();
    }


    void Start()
    {
        
    }

    public void TrueFalseScaleAc(bool dogrumu)
    {
        if (dogrumu)
        {
            trueimage.GetComponent<RectTransform>().DOScale(1, 0.2f);
            falseimage.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
        {
            falseimage.GetComponent<RectTransform>().DOScale(1, 0.2f);
            trueimage.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        Invoke("TrueFalseScaleKapat", 0.4f);

    }

    public void TrueFalseScaleKapat()
    {

        falseimage.GetComponent<RectTransform>().localScale = Vector3.zero;
        trueimage.GetComponent<RectTransform>().localScale = Vector3.zero;

    }

}
