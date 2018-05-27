using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeLoading : MonoBehaviour {

    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject Btn;
    public Animator cactus;

    private void Start()
    {
        Btn.SetActive(true);
    }

    public void ClicktoLoad()
    {
        Btn.SetActive(false);
        StartCoroutine(img1Time());
    }

    IEnumerator img1Time()
    {
        yield return new WaitForSeconds(1f);
        img1.SetActive(true);
        StartCoroutine(img2Time());
    }
    IEnumerator img2Time()
    {
        yield return new WaitForSeconds(1f);
        img1.SetActive(false);
        img2.SetActive(true);
        StartCoroutine(img3Time());
    }
    IEnumerator img3Time()
    {
        yield return new WaitForSeconds(1f);
        img2.SetActive(false);
        img3.SetActive(true);
        StopCoroutine(img3Time());
        SceneManager.LoadSceneAsync("Scene2");
    }

    public void AnimateCac()
    {
        cactus.SetTrigger("boom");
    }
}
