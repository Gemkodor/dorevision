using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text coins;

    void Start()
    {
        coins.text = GlobalGameManager.instance.GetCoins().ToString();
    }
}
