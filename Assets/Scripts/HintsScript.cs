using UnityEngine;

public class HintsScript : MonoBehaviour
{
    private Transform coin;

    void Start()
    {
        coin = GameObject.Find("Coin").transform;
    }
    
    void Update()
    {
        //Vector3 ws = Camera.main.WorldToScreenPoint(Vector3.zero);      // px  
        Vector3 wv = Camera.main.WorldToViewportPoint(coin.position);    // 0..1
        if (Input.GetKeyDown(KeyCode.V))
        {
            string pos = "";
            if (wv.x >= 0f && wv.x <= 1f && wv.y >= 0f && wv.y <= 1f && wv.z >= 0f) pos = "Visible";
            else if (wv.x < 0) pos = "Left";
            else pos = "Right";

            Debug.Log($"wv = {wv}, {pos}");
        }
    }
}
