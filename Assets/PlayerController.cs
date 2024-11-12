using UnityEngine;
using TMPro; // Adiciona o namespace para usar TextMeshPro

public class PlayerController : MonoBehaviour
{
    // Refer�ncia para o componente de texto da UI usando TextMeshProUGUI
    public TextMeshProUGUI playerWeightText;

    // Peso inicial do jogador, definido como 80kg
    public int weight = 80;

    // Vari�vel que indica se o jogador j� possui uma pedra no invent�rio
    private bool hasStone = false;

    // Refer�ncia ao objeto da pedra que o jogador pegou
    private GameObject stone;

    private void Start()
    {
        // Atualiza o texto de peso na interface no in�cio do jogo
        UpdateWeightText();
    }

    private void Update()
    {
        // Verifica se a tecla "Q" foi pressionada e o jogador tem uma pedra
        if (Input.GetKeyDown(KeyCode.Q) && hasStone)
        {
            // Se sim, chama o m�todo para largar a pedra
            DropStone();
        }
    }

    // M�todo chamado para adicionar a pedra ao invent�rio
    public void PickStone(GameObject stoneObject, int stoneWeight)
    {
        // Verifica se o jogador ainda n�o possui uma pedra
        if (!hasStone)
        {
            // Aumenta o peso do jogador pelo peso da pedra
            weight += stoneWeight;

            // Marca que o jogador agora possui uma pedra
            hasStone = true;

            // Guarda uma refer�ncia para o objeto da pedra
            stone = stoneObject;

            // Esconde o objeto pedra da cena
            stone.SetActive(false);

            // Atualiza o texto de peso na interface
            UpdateWeightText();
        }
    }

    // M�todo chamado para largar a pedra e reduzir o peso do jogador
    private void DropStone()
    {
        // Verifica se o jogador tem uma pedra
        if (hasStone)
        {
            // Reduz o peso do jogador pelo peso da pedra (40 kg)
            weight -= 40;

            // Marca que o jogador n�o possui mais a pedra
            hasStone = false;

            // Mostra a pedra novamente na cena
            stone.SetActive(true);

            // Reposiciona a pedra para a posi��o inicial (ajuste opcional)
            stone.transform.position = new Vector3(0, 0.5f, 0);

            // Atualiza o texto de peso na interface
            UpdateWeightText();
        }
    }

    // Atualiza o texto de peso na interface com o peso atual do jogador
    private void UpdateWeightText()
    {
        playerWeightText.text = $"Peso do Jogador: {weight} kg";
    }
}
