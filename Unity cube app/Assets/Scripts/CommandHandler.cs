using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text consoleOutput;
    public ScrollRect console;
    public Main main;

    private bool isOnline { get; set; }

    private void Start()
    {
        inputField.onSubmit.AddListener(HandleInput); // on Submit
        inputField.ActivateInputField();
    }

    void HandleInput(string input)
    {
        string[] text = input.Split(' ');

        if (isOnline) 
        {
            switch (text[0])
            {
                case "/start":
                    if (text.Length == 1)
                    {
                        AddLog("<color=yellow>>App is already online</color>");
                    }
                    else
                    {
                        AddLog("<color=red>>Invalid text</color>");
                    }
                    break;
                case "/end":
                    if (text.Length == 1)
                    {
                        isOnline = false;
                        AddLog("<color=red>>App is now offline</color>");
                    }
                    else
                    {
                        AddLog("<color=red>>Invalid text</color>");
                    }
                    break;
                case "/rotate":
                    string[] args = text[1].Split(",");
                    if (args.Length == 3 && float.TryParse(args[0], out _) && float.TryParse(args[1], out _) && float.TryParse(args[2], out _))
                    {
                        main.HandleCommand("rotate", args);
                        AddLog(">" + "Rotating cube");
                    }
                    else
                    {
                        AddLog("<color=red>>Invalid arguments</color>");
                    }
                    break;
                case "/moveX":
                    if (text.Length == 2 && float.TryParse(text[1], out _))
                    {
                        main.HandleCommand("moveX", new string[] { text[1] });
                        AddLog(">" + "Moving cube");
                    }
                    else
                    {
                        AddLog("<color=red>>Invalid arguments</color>");
                    }
                    break;
                case "/echo":
                    string textLine = "";
                    for (int i = 1; i < text.Length; i++)
                    {
                        textLine += text[i] + " ";
                    }
                    AddLog(">" + textLine);
                    break;
                default:
                    AddLog("<color=red>>Invalid command</color>");
                    break;
            }
        }
        else if(text[0] == "/start")
        {
            if (text.Length == 1)
            {
                isOnline = true;
                AddLog("<color=green>>App is now online</color>");
            }
            else
            {
                AddLog("<color=red>>Invalid command</color>");
            }
        }
        else
        {
            AddLog("<color=red>>App is offline</color>");
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }

    void AddLog(string message)
    {
        consoleOutput.text += message + "\n";
        Canvas.ForceUpdateCanvases();
        float preferredHeight = consoleOutput.preferredHeight -25f;

        // adjusts height of RectTransform
        RectTransform contentRect = consoleOutput.rectTransform.parent.GetComponent<RectTransform>();
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, preferredHeight);

        // scrolls to bottom
        Canvas.ForceUpdateCanvases();
        console.verticalNormalizedPosition = 0f;
    }
}
