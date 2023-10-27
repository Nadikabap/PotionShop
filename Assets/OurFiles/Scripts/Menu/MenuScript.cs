using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

namespace Menu
{
    public class MenuScript : MonoBehaviour
    {


        // Стартует игру(переходит на сцену игры по счелчку на соответствующую кнопку)
        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // Закрывает игру
        public void QuitGame()
        {
            Application.Quit();
        }

        public void ToMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void LevelSelect(int level)
        {
            SceneManager.LoadScene(level);
        }

    }
}