using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenButton(GameObject panel){
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseButton(GameObject panel){
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit(){
        Application.Quit();
    }
}
