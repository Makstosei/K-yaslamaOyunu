using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{

    [SerializeField]
    private Text dogruadettext, yanlisadettext, puantext;

    int puanSure = 10;
    bool surebittimi = true;
    int toplamPuan, yazilacakPuan, artisPuaný;


    private void Awake()
    {
        surebittimi = true;
    }

    public void SonuclarýGoster(int dogrular,int yanlislar,int puan)
    {
        dogruadettext.text = dogrular.ToString();
        yanlisadettext.text = yanlislar.ToString();

        toplamPuan = puan;
        artisPuaný = toplamPuan / 10;

        StartCoroutine(puanýyazdir());
    }


    IEnumerator puanýyazdir()
    {

        while (surebittimi)
        {
            yield return new WaitForSeconds(0.1f);
            yazilacakPuan += artisPuaný;

            if (yazilacakPuan > toplamPuan)
            {

                yazilacakPuan = toplamPuan;
            }

            puantext.text = yazilacakPuan.ToString();
        if (puanSure <= 0)
            {

                surebittimi = false;
            }
        
        }
        puanSure--;


    }


    public void Anamenu()
    {
        SceneManager.LoadScene("MenuLevel");
        
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");

    }

}
