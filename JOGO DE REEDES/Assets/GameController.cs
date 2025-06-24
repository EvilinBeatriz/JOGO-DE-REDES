using UnityEngine;
using TMPro;

public class GameControllerTwoPlayers : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI turnText;       // "Vez do Jogador X"
    public TextMeshProUGUI player1Text;    // "Jogador 1: Y"
    public TextMeshProUGUI player2Text;    // "Jogador 2: Z"

    // Estado do jogo
    int player1Score = 0;
    int player2Score = 0;
    int currentPlayer = 1;                // 1 = Jogador 1, 2 = Jogador 2

    void Start()
    {
        AtualizarUI();
    }

    public void Acertou()
    {
        if (currentPlayer == 1) player1Score++;
        else                    player2Score++;
        AlternarTurno();
    }

    public void Errou()
    {
        if (currentPlayer == 1) player1Score--;
        else                    player2Score--;
        AlternarTurno();
    }

    void AlternarTurno()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        AtualizarUI();
    }

    void AtualizarUI()
    {
        player1Text.text = "Jogador 1: " + player1Score;
        player2Text.text = "Jogador 2: " + player2Score;
        turnText.text    = "Vez do Jogador " + currentPlayer;
    }
}
