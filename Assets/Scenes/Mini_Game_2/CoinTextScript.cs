using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTextScript : MonoBehaviour
{
    public Text coinText;
    public static int coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();
    }
}
