using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MartenController : MonoBehaviour
{
    public Image black;
    public GameObject footprint;

    private void Awake()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        footprint.GetComponent<SpriteRenderer>().enabled = false;

        float elapsedTime = 0.0f;
        float totalTime = 2.5f;

        Color initialColor = black.color;
        Color targetColor = Color.black;
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            black.color = Color.Lerp(initialColor, targetColor, elapsedTime / totalTime);
            yield return null;
        }

        elapsedTime = 0f;
        footprint.GetComponent<SpriteRenderer>().enabled = true;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            black.color = Color.Lerp(targetColor, initialColor, elapsedTime / totalTime);
            yield return null;
        }

        elapsedTime = 0;

        while (elapsedTime < 3)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        PersistenceManager.inst.flags["baited"] = true;
        SceneManager.LoadScene("Sandbox", LoadSceneMode.Single);
    }
}
