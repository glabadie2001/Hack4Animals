using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SalmonController : MonoBehaviour
{
    public static SalmonController inst;
    public int SalmonCount;
    public TextMeshProUGUI CountText;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        SalmonCount = 0;
        CountText.text = "CAUGHT: " + SalmonCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = "CAUGHT: " + SalmonCount.ToString();
        if (SalmonCount > 9)
        {
            SceneManager.LoadScene("Sandbox", LoadSceneMode.Single);
        }
    }
}
