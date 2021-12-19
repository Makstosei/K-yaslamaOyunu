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
    int toplamPuan, yazilacakPuan, artisPuan�;


    private void Awake()
    {
        surebittimi = true;
    }

    public void Sonuclar�Goster(int dogrular,int yanlislar,int puan)
    {
        dogruadettext.text = dogrular.ToString();
        yanlisadettext.text = yanlislar.ToString();

        toplamPuan = puan;
        artisPuan� = toplamPuan / 10;

        StartCoroutine(puan�yazdir());
    }


    IEnumerator puan�yazdir()
    {

        while (surebittimi)
        {
            yield return new WaitForSeconds(0.1f);
            yazilacakPuan += artisPuan�;

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
