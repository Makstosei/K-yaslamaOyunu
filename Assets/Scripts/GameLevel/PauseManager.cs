using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePaneli;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

     private void OnDisable()
    {
        Time.timeScale = 1f;

    }


    public void DevamEt()
    {

        pausePaneli.SetActive(false);
    }

    public void Menuyedon()
    {
        SceneManager.LoadScene("MenuLevel");

    }

    public void Oyundanc�k()
    {

        Application.Quit();

    }
}
