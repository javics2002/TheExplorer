using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamekit2D
{
    public class SceneLoader : MonoBehaviour
    {
        public void SceneLoaderWithIndex(int SceneIndex)
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }
}