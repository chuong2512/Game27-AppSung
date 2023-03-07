using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("App");
    }
}