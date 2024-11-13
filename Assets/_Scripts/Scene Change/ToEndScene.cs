using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEndScene : MonoBehaviour
{
    public int gangsters = 5;

    public void LostGangster()
    {
        gangsters--;
        if (gangsters <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        SceneManager.LoadSceneAsync(6);
    }
}
