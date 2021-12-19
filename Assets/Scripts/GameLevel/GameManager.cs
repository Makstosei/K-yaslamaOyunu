using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject sureskorpanel;
    [SerializeField]
    private GameObject pausePanel,sonucPaneli;

    [SerializeField]
    private GameObject puankapimage, buyukSayýyýSecImage;
    [SerializeField]
    private Transform ustkare;
    [SerializeField]
    private Transform altkare;
    [SerializeField]
    private Text ustText,altText,puanText;
    [SerializeField]
    private AudioClip baslangicses,bitisses,dogruses,yanlisses;
    

    DairelerManager dairelerManager;
    timerManager timerManager;
    TrueFalseManager trueFalseManager;
    SonucManager sonucManager;

    private AudioSource audioSource;
    int OyunSayac, kacinciOyun;
    int ustDeger, altDeger, buyukDeger;
    int butonDegeri,toplamPuan,artisPuaný,dogruAdeti,yanlisAdedi;

    private void Awake()
    {
        dogruAdeti = 0;
        yanlisAdedi = 0;
        toplamPuan = 0;
        puanText.text = "0";
        kacinciOyun = 0;
        OyunSayac = 0;
        timerManager = Object.FindObjectOfType<timerManager>();
        dairelerManager = Object.FindObjectOfType<DairelerManager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        EkranýGüncelle();
        ustText.text = "";
        altText.text = "";
    }

    void EkranýGüncelle()
    {
        sureskorpanel.GetComponent<CanvasGroup>().DOFade(1, 3f);
        puankapimage.GetComponent<CanvasGroup>().DOFade(1, 3f);
        ustkare.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        altkare.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
    }


    public void Oyunabasla()
    {
        audioSource.PlayOneShot(baslangicses);
        puankapimage.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
        buyukSayýyýSecImage.GetComponent<CanvasGroup>().DOFade(1, 3f);
        KacinciOyun();
        timerManager.sureyibaslat();
    }

    void KacinciOyun()
    {
        if (OyunSayac < 5)
        {
            kacinciOyun = 1;
            artisPuaný = 10;
        }
        else if (OyunSayac >= 5 && OyunSayac < 10)
        {
            kacinciOyun = 2;
            artisPuaný = 20;
        }
        else if (OyunSayac >= 10 && OyunSayac < 15)
        {
            kacinciOyun = 3;
            artisPuaný = 30;
        }
        else if (OyunSayac >= 15 && OyunSayac < 20)
        {
            kacinciOyun = 4;
            artisPuaný = 40;
        }
        else if (OyunSayac >= 20 && OyunSayac < 25)
        {
            kacinciOyun = 5;
            artisPuaný = 50;
        }
        else
        {
            kacinciOyun = Random.Range(2, 6);
            artisPuaný = 60;
        }



        switch (kacinciOyun)
        {
            case 1:
                BirinciFonksiyon();
                break;

            case 2:
                IkinciFonksiyon();
                break;
            case 3:
                UcuncuFonksiyon();
                break;

            case 4:
                DorduncuFonksiyon();
                break;
            case 5:
                BesinciFonksiyon();
                break;
        }
    }

    void BirinciFonksiyon()
    {
        int rastgeleDeger = Random.Range(1, 50);

        if (rastgeleDeger < 25)
        {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 15);

        }
        else
        {
            ustDeger = Random.Range(2, 50);
            altDeger = Mathf.Abs(ustDeger - Random.Range(1, 15));

        }

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;

        }
        else if (ustDeger<altDeger)
        {
            buyukDeger = altDeger;
        }
        else
        {
            BirinciFonksiyon();
            return;

        }

        ustText.text = ustDeger.ToString();
        altText.text = altDeger.ToString();



    }


    void IkinciFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 20);
        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi + ikinciSayi;
        altDeger = ucuncuSayi + dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;

        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }
        else
        {
            IkinciFonksiyon();
            return;
        }


        ustText.text = birinciSayi + "+" + ikinciSayi;
        altText.text = ucuncuSayi + "+" + dorduncuSayi;

    }


    void UcuncuFonksiyon()
    {
        int birinciSayi = Random.Range(20, 50);
        int ikinciSayi = Random.Range(1, 20);
        int ucuncuSayi = Random.Range(20, 50);
        int dorduncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi - ikinciSayi;
        altDeger = ucuncuSayi - dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;

        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }
        else
        {
            UcuncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + "-" + ikinciSayi;
        altText.text = ucuncuSayi + "-" + dorduncuSayi;


    }

    void DorduncuFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 10);
        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 10);

        ustDeger = birinciSayi * ikinciSayi;
        altDeger = ucuncuSayi * dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;

        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }
        else
        {
            DorduncuFonksiyon();
            return;
        }


        ustText.text = birinciSayi + "*" + ikinciSayi;
        altText.text = ucuncuSayi + "*" + dorduncuSayi;
    }

    void BesinciFonksiyon()
    {
        int bolen1 = Random.Range(2, 10);
        ustDeger = Random.Range(2, 10);
        int bolunen1 = bolen1 * ustDeger;

        int bolen2 = Random.Range(2, 10);
        altDeger = Random.Range(2, 10);
        int bolunen2 = bolen2 * altDeger;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;

        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }
        else
        {
            BesinciFonksiyon();
            return;
        }

        ustText.text = bolunen1 + "/" + bolen1;
        altText.text = bolunen2 + "/" + bolen2;

    }

    public void ButonDegeriBelirle(string butonAdi)
    {
        if (butonAdi == "ustButon")
        {

            butonDegeri = ustDeger;
        }
        else if (butonAdi == "altButon")
        {
            butonDegeri = altDeger;
        }

        if (butonDegeri == buyukDeger)
        {
            trueFalseManager.TrueFalseScaleAc(true);
            dairelerManager.DaireScaleAc(OyunSayac % 5);
            OyunSayac++;
            dogruAdeti++;
            KacinciOyun();
            toplamPuan += artisPuaný;
            puanText.text = toplamPuan.ToString();
            audioSource.PlayOneShot(dogruses);
        }
        else
        {
            trueFalseManager.TrueFalseScaleAc(false);
            HatayagoreSayacýAzalt();
            KacinciOyun();
            yanlisAdedi++;
            audioSource.PlayOneShot(yanlisses);
        }

    }

    void HatayagoreSayacýAzalt()
    {
        OyunSayac -= (OyunSayac % 5 + 5);

        if (OyunSayac < 0)
        {
            OyunSayac = 0;
        }
        dairelerManager.DairelerScaleKapatma();

    }
    public void PausePaneliAc()
    {

        pausePanel.SetActive(true);

    }

    public void OyunuBitir()
    {
        audioSource.PlayOneShot(bitisses);
        sonucPaneli.SetActive(true);
        sonucManager = Object.FindObjectOfType<SonucManager>();
        sonucManager.SonuclarýGoster(dogruAdeti, yanlisAdedi, toplamPuan);
    }
  


}

