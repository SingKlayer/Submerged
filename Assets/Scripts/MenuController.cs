using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string levelDoJogo;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] GameObject fadePanel;
    private Animator fadeAnimator;

    private void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fadeAnimator = fadePanel.GetComponent<Animator>();
    }

    public void Jogar()
    {
        fadeAnimator.SetBool("Play", true);
        StartCoroutine(waitAnimationEnd());
        
    }

    public void AbrirOpcoes()
    {
        painelMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenu.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void Sair()
    {
        Debug.Log("saiu");
        Application.Quit();
    }

    IEnumerator waitAnimationEnd()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(levelDoJogo);
    }
}
