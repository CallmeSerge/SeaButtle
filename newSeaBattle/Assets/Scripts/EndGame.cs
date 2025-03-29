using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _buttonReturnToFirstLevel;
    [SerializeField] private GameObject _textWinRussian;
    [SerializeField] private GameObject _textWinEnglish;

    private void Start()
    {
        if (YandexGame.savesData.saveLanguage == "ru")
        {
            _textWinRussian.SetActive(true);
        }
        else
        {
            _textWinEnglish.SetActive(true);
        }

        Invoke("ButtonReturnToFirstLevelAwake", 2);
    }

    private void ButtonReturnToFirstLevelAwake()
    {
        _buttonReturnToFirstLevel.SetActive(true);
    }

    public void ButtonReturnToFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
