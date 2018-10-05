//学習内容:①エディター確認_②加速度センサー_③Normalize,normalize
//①ApplicationクラスのisEditorでエディター上でプレイしているか確認できる。これにif文を組み合わせて、PC上では不可能な操作はスキップできる。
//②Input.acceleration.方向;　で指定した方向の加速度センサーの反応を取得できる。
//③Normalize、normalizeそれぞれでベクトルを正規化（１に）できる。微妙に違うらしいが説明見てもよくわからん。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {


    private const float Gravity = 9.81f;   //重力加速度

    public float gravityScale;   //重力の大きさ　のちInspectorで設定できるようにpublic修飾子に


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 vector = new Vector3();　　//重力ベクトルの初期化

        if (Application.isEditor)
        {
            //キー入力でベクトルを定める
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            if (Input.GetKey("z"))
            {
                vector.y = 1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }
        }
        else
        {
            //加速度センサーを利用
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.z;
            vector.y = Input.acceleration.y;
        }
        //ベクトルの方向に合わせて変化

        Physics.gravity = Gravity * vector.normalized * gravityScale; //normalizedでベクトルの大きさを正規化(1に)
    }
}
