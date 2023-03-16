using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowTo : MonoBehaviour
{
    public GameObject[] UiElement;
    public GameObject[] UiBT;
    public int pageNum = 1;
    private string previousSceneName;
    /*public GameObject select_gamemode;
    public GameObject Credit;*/

    /*public void Play_Buttom()
    {
        select_gamemode.SetActive(true);
    }*/
    public void Play_cutScene_Buttom()
    {
        SceneManager.LoadScene("CutScene");
    }
   /* public void Play_Story_Buttom()
    {
        SceneManager.LoadScene("Play_ok");
    }
    public void How_to_Buttom()
    {
        SceneManager.LoadScene("How_to_Play");
    }
    public void Credit_Buttom()
    {
        Credit.SetActive(true);
    }
    public void MenuGame()
    {
        select_gamemode.SetActive(false);
        Credit.SetActive(false);
    }*/

    public void ActiveElement(int indexElement)
    {
        UiElement[indexElement].SetActive(true);
        foreach (var item in UiElement)
        {
            if(item != UiElement[indexElement]) // check if item is not the same as UiElement[indexElement]`
            item.SetActive(false); // deactivate item
        }
    }

    public void Nextpage()
    {
        UiElement[pageNum].SetActive(true);
        if (pageNum == 2)
        {
            UiBT[0].SetActive(false);
            UiBT[1].SetActive(true);
        }
        
        foreach (var item in UiElement)
        {
            if (item != UiElement[pageNum]) // check if item is not the same as UiElement[indexElement]`
                item.SetActive(false); // deactivate item
        }
        ++pageNum;
    }

    public void Backpage()
    {
        --pageNum;
        if (pageNum < 0)
        {
            pageNum = 0;
        }

        UiElement[pageNum].SetActive(true);
        if (pageNum < 2)
        {
            UiBT[0].SetActive(true);
            UiBT[1].SetActive(false);
        }

        foreach (var item in UiElement)
        {
            if (item != UiElement[pageNum]) // check if item is not the same as UiElement[indexElement]`
                item.SetActive(false); // deactivate item
        }
    }

    public void GotoScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void GoBack()
    {
        string previousSceneName = PlayerPrefs.GetString("PreviousSceneName");
        if (previousSceneName == "Play_ok")
        {
            SceneManager.LoadScene("Play_ok");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Close Game.exe");
        Application.Quit(); // จะทำงานได้ต่อเมื่อเป็น .exe
    }

    private void Start()
    {
        Time.timeScale = 1;
        previousSceneName = PlayerPrefs.GetString("PreviousSceneName");
    }

    private void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.Escape))
         {
             ResumeGame();
         }*/
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Backpage();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Nextpage();
        }
    }

    public void ResumeGame()
    {
        if (Time.timeScale == 0)//หยุดอยู่
        {
            /*pauseUI.SetActive(false);*/
            ActiveElement(0);
            Time.timeScale = 1;
        }
        else if (Time.timeScale > 0)//เดินอยู่
        {
            /*pauseUI.SetActive(true);*/
            ActiveElement(2);
            Time.timeScale = 0;
        }
    }

    /*    void Start()
        {
            select_gamemode.SetActive(false);
            Credit.SetActive(false);
        }*/
}
