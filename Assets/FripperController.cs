using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //タッチの回数を取得
        var touchCount = Input.touchCount;

        //タッチする毎に処理を実行
        for (var i = 0; i < touchCount; i++)
        {
            //タッチの状態とタッチ位置の情報を取得
            var touch = Input.touches[i];
            var pos = Input.touches[i].position;

            switch (touch.phase)
            {
                //タッチ、長押し、指が移動しているときの処理
                case TouchPhase.Began:
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (pos.x < Screen.width / 2.0f && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    else if (pos.x > Screen.width / 2.0f && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    break;
                //指を離した時の処理
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                        SetAngle(this.defaultAngle);
                    break;
             }
         }

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //右矢印キーを押した時右フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //画面から指を話したらフリッパーを元に戻す
            if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}