using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sistema_de_Transformacoes : MonoBehaviour
{
    public bool SemCabecaAtivado = true;
    public Image HudTransform;
    private SpriteRenderer render;
    public float TempoDeTransformacao = 100f;
    private float TempodeRecuperacao = 15f;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TempoDeTransformacao -= Time.deltaTime;

            AtivandoTransformacao();
        }
    }

    public void AtivandoTransformacao()
    {
        if(TempoDeTransformacao >= 100)
        {
            SemCabecaAtivado = true;
            render.color = Color.blue;
            HudTransform.color = Color.gray;
            Debug.Log("Virando o sem cabeça");
        }
        
    }

    public void TempoTransformado()
    {
        if (SemCabecaAtivado)
        {
            TempoDeTransformacao -= Time.deltaTime;
            TempodeRecuperacao = 15f;
        }
        else if(TempoDeTransformacao <= 0)
        {
            SemCabecaAtivado = false;
            TempoDeTransformacao = 100f;
            TempodeRecuperacao -= Time.deltaTime;
        }
    }

    public void EscolhendoTransformacao()
    {

    }
}
