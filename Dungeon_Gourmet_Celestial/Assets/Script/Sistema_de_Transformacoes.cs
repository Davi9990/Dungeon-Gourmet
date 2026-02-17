using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sistema_de_Transformacoes : MonoBehaviour
{
    [Header("Referências")]
    public bool SemCabecaAtivado = false;
    public Image HudTransform;
    private SpriteRenderer render;

    [Header("Transformações")]
    public float TempoDeTransformacao = 100f;
    public float TempodeRecuperacao = 15f;

    public bool[] transformavcoesdesbloqueadas;
    public MonoBehaviour[] scriptsTransform;

    [SerializeField]private float tempoAtualTransformacao;
    [SerializeField]private float tempoAtualRecuperacao;
    [SerializeField] private int transformacaoAtual = 0;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();

        tempoAtualTransformacao = TempoDeTransformacao;
        tempoAtualRecuperacao = TempodeRecuperacao;

        transformavcoesdesbloqueadas = new bool[scriptsTransform.Length];

        transformavcoesdesbloqueadas[0] = true;

        EscolhendoTransformacao(0);
    }

    // Update is called once per frame
    void Update()
    {
        ChecarInput();
        AtivandoTransformacao();
    }

    private void ChecarInput()
    {
        int index = 1;

        if(Input.GetKeyDown(KeyCode.R) && tempoAtualTransformacao > 0 
            && transformavcoesdesbloqueadas[index])
        {
            EscolhendoTransformacao(index);
            transformacaoAtual = index;
            Debug.Log("Virando o sem cabeça");
        }
    }

    public void AtivandoTransformacao()
    {
        
        if (transformacaoAtual != 0)
        {
            render.color = Color.blue;
            HudTransform.color = Color.gray;

            tempoAtualTransformacao -= Time.deltaTime;

            if (tempoAtualTransformacao <= 0)
            {
                VoltarAoNormal();
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

    private void VoltarAoNormal()
    {
        EscolhendoTransformacao(0);
        transformacaoAtual = 0;

        tempoAtualTransformacao = 0;
        tempoAtualRecuperacao = TempodeRecuperacao;

        Debug.Log("Voltando ao Normal");
    }

    public void DesbloquearTransformacao(int index)
    {
        if(index >= 0 && index < transformavcoesdesbloqueadas.Length)
        {
            transformavcoesdesbloqueadas[index] = true;
            Debug.Log($"Transformação {index} desbloqueada!");
        }
    }

    public void EscolhendoTransformacao(int index)
    {
        foreach(MonoBehaviour script in scriptsTransform)
        {
            script.enabled = false;
        }

        if(index >= 0 && index < scriptsTransform.Length)
        {
            scriptsTransform[index].enabled = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Dullahan"))
        {
            scriptsTransform[1].enabled = true;
        }
    }
}
