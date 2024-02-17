using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainScreen : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Start()
    {
        StartCoroutine(backtoMainScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator backtoMainScreen()
    {
        yield return new WaitForSeconds(69);
        SceneManager.LoadScene("Main Screen");
    }
}
