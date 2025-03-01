using UnityEngine;

public class GameManager : MonoBehaviour
{
     public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("create");
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지
        }
        else
        {
            Debug.Log("Destroy");
            Destroy(gameObject); // 중복 방지
        }
    }
}
