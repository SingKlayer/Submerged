using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneScr : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI caption;
    [SerializeField] private string Jogo;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private AudioSource audio;

    private int index;
    void Start()
    {
        caption.text = string.Empty;
        StartDialogue();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (caption.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                caption.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            caption.text += c;
            voiceTalk();
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            caption.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadScene(Jogo);
        }
    }

    void voiceTalk()
    {
        audio.pitch = Random.Range(0.5f, 1f);
        audio.Play();
    }
}
