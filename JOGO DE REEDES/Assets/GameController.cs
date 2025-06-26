using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerTwoPlayers : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI turnText;
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    [Header("Configuração de Rodadas")]
    public int maxRodadas = 20;
    private int rodadaAtual = 0;

    [Header("Painel de Fim")]
    public GameObject painelFim;
    public TextMeshProUGUI textoResultado;

    private int player1Score = 0;
    private int player2Score = 0;
    private int currentPlayer = 1;

    void Start()
    {
        if (painelFim == null)
        {
            Debug.LogError("PainelFim não foi atribuído no Inspector!");
        }
        else
        {
            painelFim.SetActive(false);
            Debug.Log("PainelFim iniciado como inativo.");
        }
        AtualizarUI();
    }

    public void Acertou()
    {
        Debug.Log($"Acertou() chamado - Player {currentPlayer}");
        if (currentPlayer == 1) player1Score++;
        else                     player2Score++;
        AlternarTurno();
    }

    public void Errou()
    {
        Debug.Log($"Errou() chamado - Player {currentPlayer}");
        if (currentPlayer == 1) player1Score--;
        else                     player2Score--;
        AlternarTurno();
    }

    void AlternarTurno()
    {
        rodadaAtual++;
        Debug.Log($"Rodada atual: {rodadaAtual}/{maxRodadas}");
        if (rodadaAtual >= maxRodadas)
        {
            Debug.Log("Máximo de rodadas atingido. Chamando FimDeJogo().");
            FimDeJogo();
            return;
        }

        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        AtualizarUI();
    }

    void AtualizarUI()
    {
        player1Text.text = "Jogador 1: " + player1Score;
        player2Text.text = "Jogador 2: " + player2Score;
        turnText.text    = "Vez do Jogador " + currentPlayer;
    }

    void FimDeJogo()
    {
        Debug.Log("Executando FimDeJogo()");

        // Desativa todos os botões da cena
        var botoes = FindObjectsOfType<Button>();
        foreach (var btn in botoes)
            btn.interactable = false;

        // Exibe painel de fim de jogo
        if (painelFim != null)
        {
            painelFim.SetActive(true);
            Debug.Log("PainelFim ativado.");
        }

        // Determina vencedor
        string vencedor;
        if (player1Score > player2Score)      vencedor = "Jogador 1";
        else if (player2Score > player1Score) vencedor = "Jogador 2";
        else                                   vencedor = "Empate";

        if (textoResultado != null)
        {
            textoResultado.text = vencedor + " venceu!";
        }
        else
        {
            Debug.LogError("TextoResultado não foi atribuído no Inspector!");
        }
    }

    // Método para o botão "Jogar Novamente"
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

