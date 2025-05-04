using UnityEngine;

public class Main : MonoBehaviour
{
    public Cube cube;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    public void HandleCommand(string command, string[] args)
    {
        switch (command)
        {
            case "rotate":
                if (args.Length == 3 &&
                    float.TryParse(args[0], out float rx) &&
                    float.TryParse(args[1], out float ry) &&
                    float.TryParse(args[2], out float rz))
                {
                    cube.Rotate(new Vector3(rx, ry, rz));
                }
                break;
            case "moveX":
                if (args.Length == 1 && float.TryParse(args[0], out float mx))
                {
                    cube.MoveX(mx);
                }
                break;
        }
    }
}
