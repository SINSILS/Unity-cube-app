using UnityEngine;

public class Cube : MonoBehaviour
{
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rotate(Vector3 pos)
    {
        this.transform.Rotate(pos);
    }

    public void MoveX(float x)
    {
        cube.position = new Vector3(cube.position.x + x, cube.position.y, cube.position.z);
    }
}
