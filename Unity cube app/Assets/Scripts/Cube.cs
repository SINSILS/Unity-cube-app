using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Rotate(Vector3 pos)
    {
        this.transform.Rotate(pos);
    }

    void MoveX(float x)
    {
        this.transform.position.Set(x, this.transform.position.y, this.transform.position.z);
    }
}
