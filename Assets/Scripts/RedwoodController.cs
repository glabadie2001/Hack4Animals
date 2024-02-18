using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedwoodController : MonoBehaviour
{
    public Sprite[] SpriteArray = new Sprite[5];
    public int SpriteIndex = 0;
    public SpriteRenderer Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //update sprite here
        if (Input.GetMouseButtonDown(0) && SpriteIndex < 5)
        {
            SpriteIndex++;
            Renderer.sprite = SpriteArray[SpriteIndex];
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
        if (SpriteIndex == 5)
        {
            SceneManager.LoadScene("Sandbox", LoadSceneMode.Single);
        }
    }
}
