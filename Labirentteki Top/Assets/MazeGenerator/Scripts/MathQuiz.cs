using UnityEngine;
using UnityEngine.UI;

public class MathQuiz : MonoBehaviour
{
    public Text questionText;
    public InputField answerInput;
    public Button submitButton;
    public Text resultText;
    public Rigidbody ballRigidbody; // Topun Rigidbody bileşeni

    private float correctAnswer;

    void Start()
    {
        GenerateRandomMathOperation();
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void GenerateRandomMathOperation()
    {
        int num1 = Random.Range(1, 101); // 1 ile 100 arasında bir sayı
        int num2 = Random.Range(1, 101); // 1 ile 100 arasında bir sayı
        int operation = Random.Range(0, 4); // 0: Toplama, 1: Çıkarma, 2: Çarpma, 3: Bölme

        string operationSymbol = "";
        switch (operation)
        {
            case 0:
                operationSymbol = "+";
                correctAnswer = num1 + num2;
                break;
            case 1:
                operationSymbol = "-";
                correctAnswer = num1 - num2;
                break;
            case 2:
                operationSymbol = "*";
                correctAnswer = num1 * num2;
                break;
            case 3:
                operationSymbol = "/";
                correctAnswer = (float)num1 / num2;
                break;
        }

        questionText.text = $"{num1} {operationSymbol} {num2} = ?";
    }

    void CheckAnswer()
    {
        float playerAnswer;
        bool isNumeric = float.TryParse(answerInput.text, out playerAnswer);

        if (isNumeric)
        {
            if (Mathf.Approximately(playerAnswer, correctAnswer))
            {
                resultText.text = "Doğru!";
                MoveBall();
            }
            else
            {
                resultText.text = "Yanlış! Doğru cevap: " + correctAnswer;
                StopBall();
            }
        }
        else
        {
            resultText.text = "Lütfen geçerli bir sayı girin.";
        }

        GenerateRandomMathOperation();
        answerInput.text = "";
    }

    void MoveBall()
    {
        // Topun hareket etmesini sağlayan kod
        ballRigidbody.velocity = new Vector3(0, 0, 5); // Topu ileri doğru hareket ettir
    }

    void StopBall()
    {
        // Topu durduran kod
        ballRigidbody.velocity = Vector3.zero; // Topu durdur
    }
}