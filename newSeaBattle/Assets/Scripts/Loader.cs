using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Loader : MonoBehaviour
{
    private void Start()
    {
        if (YandexGame.savesData.sceneForLoad == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (YandexGame.savesData.sceneForLoad > 0)
        {
            SceneManager.LoadScene(YandexGame.savesData.sceneForLoad);
        }
    }

}
