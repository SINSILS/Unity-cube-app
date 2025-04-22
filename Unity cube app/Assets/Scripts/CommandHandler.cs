using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text consoleOutput;
    public ScrollRect console;

    private bool isOnline { get; set; }


    private void Start()
    {
        inputField.onSubmit.AddListener(HandleInput); // on Submit
        inputField.ActivateInputField();
    }

    void HandleInput(string input)
    {
        //AddLog(">" + input);
        string[] command = input.Split(' ');

        if (isOnline) 
        {
            switch (command[0])
            {
                case "/start":
                    if (command.Length == 1)
                    {
                        AddLog("<color=yellow>>App is already online</color>");
                    }
                    else
                    {
                        AddLog("<color=red>>Invalid command</color>");
                    }
                    break;
                case "/end":
                    if (command.Length == 1)
                    {
                        isOnline = false;
                        AddLog("<color=red>>App is now offline</color>");
                    }
                    else
                    {
                        AddLog("<color=red>>Invalid command</color>");
                    }
                    break;
                case "/rotate":
                    //AddLog(">" + command[0]);
                    string[] args = command[1].Split(",");
                    if(args.Length == 3 && float.TryParse(args[0], out _) && float.TryParse(args[1], out _) && float.TryParse(args[2], out _))
                    {
                        //Sita desim kazkur
                        //Vector3 myVector3 = new Vector3(float.Parse(args[0]), float.Parse(args[1]), float.Parse(args[2]));
                        AddLog(">" + "Zjbs rotatinu xyz");
                    }
                    else
                    {
                        AddLog("<color=red>>Invalid arguments</color>");
                    }
                    break;
                case "/moveX":
                    //AddLog(">" + command[0]);
                    if (command.Length == 2 && float.TryParse(command[1], out _))
                    {
                        AddLog(">" + "Zjbs judinam x");
                        //new Vector3(command[1] * Time.deltaTime, 0, 0);
                    }
                    else 
                    {
                        AddLog("<color=red>>Invalid arguments</color>");
                    }
                    break;
                case "/echo":
                    string textLine = "";
                    for (int i = 1; i < command.Length; i++)
                    {
                        textLine += command[i] + " ";
                    }
                    AddLog(">" + textLine);
                    break;
                default:
                    AddLog("<color=red>>Invalid command</color>");
                    break;
            }
        }
        else if(command[0] == "/start")
        {
            if (command.Length == 1)
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




        //AddLog("<color=green>>App is now online</color>");
        //AddLog("<color=red>>App is now offline</color>");
        //AddLog("<color=yellow>>App is already online</color>");
        //AddLog("<color=red>>App is offline</color>");


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
