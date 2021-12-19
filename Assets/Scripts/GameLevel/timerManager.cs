using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerManager : MonoBehaviour
{


    [SerializeField]
    private Text süreText;
    int kalansure;
    bool gerisaysýnmý;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        gerisaysýnmý = true;
        kalansure = 90;

    }

    public void sureyibaslat()
    {
        StartCoroutine(süreTimerRoutine());

    }



    IEnumerator süreTimerRoutine()
    {
        while (gerisaysýnmý)
        {
            yield return new WaitForSeconds(1f);
            if(kalansure <= 0)
            {
                süreText.text = "";
                gerisaysýnmý = false;
                gameManager.OyunuBitir();

            }
            
            else if (kalansure < 10)
            {
                süreText.text ="0"+ kalansure.ToString();

            }
            else
            {
                süreText.text = kalansure.ToString();


            }

            kalansure--;

            
        }

    }

    
}
