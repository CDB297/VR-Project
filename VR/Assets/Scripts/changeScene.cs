using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID) 
    {
        SceneManager.LoadScene(sceneID);
    }
}
