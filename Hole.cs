//学習内容:①位置ベクトルについて
//①transform.positionをVector型変数に代入すると位置ベクトルとして扱える。それを利用してオブジェクト→オブジェクトというベクトルを計算できる。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    bool fallIn;

    public string activeTag;　　//タグの割り当て機能をInspectorに

    public bool IsFallIn()
    {
        return fallIn;
    }

    //ホールにボールが入ったかどうか自動判定する

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == activeTag)
        {
            fallIn = true;
        } 
    }
    private void OnTriggerExit(Collider other)  //コライダーが離れたとき
    {
        if(other.gameObject.tag == activeTag)　　//離れていったオブジェクトのタグを確認して同じ色なら
        {
            fallIn = false;　　　　　　　　　　　//「入ってない」を判定
        }
    }


    void OnTriggerStay(Collider other)   //OnTriggerStay -> 一定のフレームごとに呼び出される
    {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>(); //Rigidbodyコンポーネント取得

        Vector3 direction = transform.position - other.gameObject.transform.position;　
        //自分の位置ベクトル－ほかのオブジェクトの位置ベクトル　Vectorに代入するtransform.positionは位置ベクトルとなる
        //ベクトルの引き算　始点の同じA,Bのベクトルの場合　A-B＝C　なら　Bの終点からAの終点の方向に繋いだものがベクトルCとなる

        direction.Normalize();   //Normalize -> ベクトルの値そのものを１に書き換える。ほとんどnomalizeと同じ。

    　　if(other.gameObject.tag == activeTag)
        {
            r.velocity *= 0.9f;　　　//吸い込まれる力に対して減速する力を与える

            r.AddForce(direction * r.mass * 20.0f);　//吸い込まれる力
        }
        else
        {
            r.AddForce(-direction * r.mass * 80.0f); //対応するタグに触れるまではホールの外方向に力を加えておく
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
