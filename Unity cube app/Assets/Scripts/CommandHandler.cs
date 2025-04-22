using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text consoleOutput;
    public ScrollRect console;

    private void Start()
    {
        inputField.onSubmit.AddListener(HandleInput); // on Submit
        inputField.ActivateInputField();
    }

    void HandleInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return;

        // Conditions
        if (input.ToLower() == "/start")
        {
            AddLog("<color=green>>App is now online!</color>");
        }
        else if (input.ToLower() == "/end")
        {
            AddLog("<color=red>>App is now offline!</color>");
        }
        else
        {
            AddLog("> " + input);
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }

    void AddLog(string message)
    {
        consoleOutput.text += message + "\n";

        // Scrolls to bottom and updates height
        RectTransform contentRect = consoleOutput.rectTransform.parent.GetComponent<RectTransform>();
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, contentRect.sizeDelta.y + 23);
        Canvas.ForceUpdateCanvases();
        console.verticalNormalizedPosition = 0f;
    }
}
