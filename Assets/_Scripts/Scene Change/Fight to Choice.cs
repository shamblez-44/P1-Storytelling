using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FighttoChoice : MonoBehaviour
{
    public void Death()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
