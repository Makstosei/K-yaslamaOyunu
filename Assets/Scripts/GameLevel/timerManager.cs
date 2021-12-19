using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerManager : MonoBehaviour
{


    [SerializeField]
    private Text s�reText;
    int kalansure;
    bool gerisays�nm�;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        gerisays�nm� = true;
        kalansure = 90;

    }

    public void sureyibaslat()
    {
        StartCoroutine(s�reTimerRoutine());

    }



    IEnumerator s�reTimerRoutine()
    {
        while (gerisays�nm�)
        {
            yield return new WaitForSeconds(1f);
            if(kalansure <= 0)
            {
                s�reText.text = "";
                gerisays�nm� = false;
                gameManager.OyunuBitir();

            }
            
            else if (kalansure < 10)
            {
                s�reText.text ="0"+ kalansure.ToString();

            }
            else
            {
                s�reText.text = kalansure.ToString();


            }

            kalansure--;

            
        }

    }

    
}
