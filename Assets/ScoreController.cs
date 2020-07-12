using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    //点数を表示するテキスト
    private GameObject scoreText;

    //点数の初期値
    public int score = 0;

    // Use this for initialization
    void Start () {
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update () {

    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {

        //衝突したオブジェクトによって点数を変える
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 5;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 15;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 20;
        }

        scoreText.GetComponent<Text>().text = score + "点";

    }

}
