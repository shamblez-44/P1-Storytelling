using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfficeCutsceneToStreetCutscene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(35f);
        SceneManager.LoadSceneAsync(1);
    }
}

