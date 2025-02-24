using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro Label;
    Vector2Int Coordinate = new Vector2Int();

    void Awake() 
    {
        Label = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.isPlaying)
        {
            Coordinate.x = Mathf.RoundToInt(transform.parent.position.x);
        }
    }
}
