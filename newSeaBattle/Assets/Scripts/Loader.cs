using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Loader : MonoBehaviour
{
    public void ButtonRussianLanguage()
    {
        YandexGame.savesData.saveLanguage = "ru";

        if (YandexGame.savesData.sceneForLoad == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (YandexGame.savesData.sceneForLoad > 0)
        {
            SceneManager.LoadScene(YandexGame.savesData.sceneForLoad);
        }
    }

    public void ButtonEnglishLanguage()
    {
        YandexGame.savesData.saveLanguage = "en";

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
