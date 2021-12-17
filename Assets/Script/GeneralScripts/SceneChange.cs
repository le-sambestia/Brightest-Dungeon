using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public GameObject room;
    public Text text;
    
    public void SwitchScene()
    {
        SceneManager.LoadScene(RoomController.instance.currentWorldName + "Combat", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(RoomController.instance.currentWorldName + "Main"));
        room = GameManager.RoomCont;
        room.SetActive(false);
    }
    public void BossSwitchScene()
    {
        SceneManager.LoadScene(RoomController.instance.currentWorldName + "Boss", LoadSceneMode.Additive);
        room = GameManager.RoomCont;
        room.SetActive(false);
    }
    public void MapSwitchScene()
    {        
        SceneManager.UnloadSceneAsync("Rewards");
        room  = GameManager.RoomCont;
        room.SetActive(true);
    }

    public void LoadNextArea()
    {
        int x = int.Parse(RoomController.instance.currentWorldName);
        x += 1;
        RoomController.instance.currentWorldName = x.ToString();
        SceneManager.LoadScene(RoomController.instance.currentWorldName + "Main");
    }
    public void ResetGame()
    {
        SceneManager.LoadScene("1Main");
        //room = GameManager.RoomCont;
    }
    public void CantLeave()
    {
        text.text = "You can't leave!";
        //room = GameManager.RoomCont;
    }
}