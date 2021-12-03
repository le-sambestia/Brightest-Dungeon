using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject room;

    
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
}