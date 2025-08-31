using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Vida_Player : MonoBehaviour
{
    public float currentLife = 100;
    public float LifeTotal = 100;
    public TextMeshProUGUI textLife;
    public Slider slideeLife;
    private string ultimaVidaExibida = "";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slideeLife != null)
        {
            slideeLife.maxValue = LifeTotal;
            slideeLife.value = Mathf.Clamp(currentLife,0,LifeTotal);
        }

        if(textLife != null)
        {
            AtualizarVida();
        }
    }

    public void AtualizarVida()
    {      
        if (textLife != null)
        {
            int vidaTotal = Mathf.FloorToInt(LifeTotal);
            int vidacorrente = Mathf.Clamp(Mathf.FloorToInt(currentLife), 0, vidaTotal);

            string vida = $"{vidaTotal}/{vidacorrente}";
            
            if(vida != ultimaVidaExibida)
            {
                textLife.text = vida;
                ultimaVidaExibida = vida;
            }
        }
    }
}
