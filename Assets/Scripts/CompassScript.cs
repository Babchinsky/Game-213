using UnityEngine;

public class CompassScript : MonoBehaviour
{
    private Transform arrow;
    private Transform character;
    private Transform coin;

    void Start()
    {
        arrow = transform.Find("Arrow");    
        character = GameObject.Find("Character").transform;    
        coin = GameObject.Find("Coin").transform;
        GameEventSystem.AddListener(OnCoinSpawnEvent, "CoinSpawn");
    }

    void Update()
    {
        Vector3 d = coin.position - character.position;
        Vector3 camFwd = Camera.main.transform.forward;
        d.y = 0f;
        camFwd.y = 0f;

        float angle = Vector3.SignedAngle(camFwd, d, Vector3.down);
        arrow.eulerAngles = new Vector3(0, 0, angle);
    }

    private void OnCoinSpawnEvent(string type, object payload)
    {
        coin = ((GameObject)payload).transform;
    }

    private void OnDestroy()
    {
        GameEventSystem.RemoveListener(OnCoinSpawnEvent, "CoinSpawn");
    }
}
