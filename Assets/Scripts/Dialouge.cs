using UnityEngine;
using TMPro;
using System.Collections;



public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    
    public float textSpeed;
    private int index;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textcomponent.text = string.Empty;
        StartDialouge();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textcomponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textcomponent.text = lines[index];

            }

        }
    }

    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
