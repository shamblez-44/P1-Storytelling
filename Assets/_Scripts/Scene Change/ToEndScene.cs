using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEndScene : MonoBehaviour
{
    public void Death()
    {
        SceneManager.LoadSceneAsync(6);
    }
}
