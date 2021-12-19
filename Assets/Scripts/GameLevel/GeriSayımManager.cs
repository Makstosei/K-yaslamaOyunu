using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GeriSayımManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gerisayımobje;
    [SerializeField]
    private Text gerisayımtext;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        StartCoroutine(geriSayımRoutine());
    }


    IEnumerator geriSayımRoutine()
    {
        gerisayımtext.text = "3";
        

        gerisayımobje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);

        gerisayımobje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);

        gerisayımtext.text = "2";
       

        gerisayımobje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);

        gerisayımobje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);

        gerisayımtext.text = "1";


        gerisayımobje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);

        gerisayımobje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);

        StopAllCoroutines();


        gameManager.Oyunabasla();
    }


}
