using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public static LevelChanger instance;

    public Animator animator;
    public AudioSource bgMusic;
    public float transitionTime = 1f;

    private int levelToLoad;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        // StartCoroutine(AudioFader.FadeIn(bgMusic, 0.5f));
    }

    public void nextLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        animator.SetTrigger("Start");
        StartCoroutine(AudioFader.FadeOut(bgMusic, 0.8f));
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
        StartCoroutine(CloseGame());
        
    }

    IEnumerator CloseGame()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
        Debug.Log("Quit Game!");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadActName(string actName)
    {
        //SceneManager.LoadScene(actName);
        StartCoroutine(LoadSceneName(actName));
    }

    IEnumerator LoadSceneName(string actName)
    {
        animator.SetTrigger("Start");
        StartCoroutine(AudioFader.FadeOut(bgMusic, 0.8f));
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(actName);
    }

    public void ActFade(GameObject currentAct, GameObject nextAct)
    {
        StartCoroutine(ActFadeHandler(currentAct, nextAct));
    }

    IEnumerator ActFadeHandler(GameObject currentAct, GameObject nextAct)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        animator.SetTrigger("End");
        currentAct.SetActive(false);
        nextAct.SetActive(true);
    }
}
