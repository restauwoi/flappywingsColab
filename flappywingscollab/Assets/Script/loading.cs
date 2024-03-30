using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public Image Fill;

    void Start(){
        StartCoroutine(Loading());
    }

    IEnumerator Loading(){
        AsyncOperation loading = SceneManager.LoadSceneAsync("Menu");

        while(!loading.isDone){
            Fill.fillAmount = loading.progress/0.9f;
            yield return null;
        }
    }
}
