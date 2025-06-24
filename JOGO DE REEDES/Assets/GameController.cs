using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    public void Acertou()
    {
        score += 1;
        AtualizarTexto();
    }

    public void Errou()
    {
        score -= 1;
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        scoreText.text = "Pontuação: " + score.ToString();
    }
}