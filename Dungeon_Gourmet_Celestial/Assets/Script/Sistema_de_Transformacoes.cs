using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sistema_de_Transformacoes : MonoBehaviour
{
    public bool SemCabecaAtivado = false;
    public Image HudTransform;
    private SpriteRenderer render;
    public float TempoDeTransformacao = 100f;
    public float TempodeRecuperacao = 15f;

    [SerializeField]private float tempoAtualTransformacao;
    [SerializeField]private float tempoAtualRecuperacao;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        tempoAtualTransformacao = TempoDeTransformacao;
        tempoAtualRecuperacao = TempodeRecuperacao;
    }

    // Update is called once per frame
    void Update()
    {
        ChecarInput();
        AtivandoTransformacao();
    }

    private void ChecarInput()
    {
        if(Input.GetKeyDown(KeyCode.R) && tempoAtualTransformacao > 0)
        {
            SemCabecaAtivado = true;
            Debug.Log("Virando o sem cabeça");
        }
    }

    public void AtivandoTransformacao()
    {
        if(SemCabecaAtivado)
        {
            render.color = Color.blue;
            HudTransform.color = Color.gray;

            tempoAtualTransformacao -= Time.deltaTime;

            if(tempoAtualTransformacao <= 0)
            {
                SemCabecaAtivado = false;
                tempoAtualTransformacao = 0;
                tempoAtualRecuperacao = TempodeRecuperacao;
                Debug.Log("Voltando ao normal");
            }
        }
        else
        {
            render.color = Color.white;
            HudTransform.color = Color.white;

            if(tempoAtualTransformacao < TempoDeTransformacao)
            {
                tempoAtualRecuperacao -= Time.deltaTime;

                if(tempoAtualRecuperacao <= 0)
                {
                    tempoAtualTransformacao = TempoDeTransformacao;
                    tempoAtualRecuperacao = TempodeRecuperacao;
                    Debug.Log("Recuperando e pronto para transformar novamente");
                }
            }
        }
    }

    public void EscolhendoTransformacao()
    {

    }
}
