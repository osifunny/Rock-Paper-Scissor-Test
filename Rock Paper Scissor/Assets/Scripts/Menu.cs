using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void CallSettings(){
        Debug.Log("Open Settings");
    }
    public void CallMenu(){
        Debug.Log("Back to Menu");
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit Game Success");
    }
    List<int> widths = new List<int>(){1080,900,720};
    List<int> heights = new List<int>(){1920,1600,1280};
    public void ScreenSize(int index){
        Screen.SetResolution(widths[index],heights[index],Screen.fullScreen);
        Debug.Log("Resolution has changed to " + widths[index] + "x" + heights[index]);
    }
}