using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManeger : MonoBehaviour
{
    public Image[] skillsImagens;
    public float escale;

    // Update is called once per frame
    void Update()
    {
        SelecionandoSkills();
    }

    public void SelecionandoSkills()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            skillsImagens[0].rectTransform.localScale = new Vector3(escale,escale,1f);
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
            skillsImagens[0].rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            skillsImagens[1].rectTransform.localScale = new Vector3(escale, escale, 1f);
        }
        else if (Input.GetKeyUp(KeyCode.F2))
        {
            skillsImagens[1].rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            skillsImagens[2].rectTransform.localScale = new Vector3(escale, escale, 1f);
        }
        else if (Input.GetKeyUp(KeyCode.F3))
        {
            skillsImagens[2].rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            skillsImagens[3].rectTransform.localScale = new Vector3(escale, escale, 1f);
        }
        else if (Input.GetKeyUp(KeyCode.F4))
        {
            skillsImagens[3].rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            skillsImagens[4].rectTransform.localScale = new Vector3(escale, escale, 1f);
        }
        else if (Input.GetKeyUp(KeyCode.F5))
        {
            skillsImagens[4].rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
