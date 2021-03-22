using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FInishLevel : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        FortunePoints.instance.AddPoints(2);
        SceneManager.LoadScene(9);
        CompletedLevels.instance.CompletedLevel();
    }
}
