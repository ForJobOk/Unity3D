using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInChecker : MonoBehaviour {

    //全てのホールに対して、同色のボールが入っているかどうか監視する


    //Inspectorで各色のホールを登録
    public Hole red;
    public Hole blue;
    public Hole green;


    //ボールが入ったどうか判定後に、メッセージ表示するメソッド
    private void OnGUI()
    {
        string label = " ";

        if (red.IsFallIn() && blue.IsFallIn() && green.IsFallIn())
        //IsFallIn　は　bool型のメソッドなので条件式内で呼び出すだけでtrueとして扱える
        //(red.IsFallIn()==true && blue.IsFallIn()==true && green.IsFallIn()==true)みたいな感じ
        {
            label = "Fall in hole！";
        }

        GUI.Label(new Rect(0, 0, 100, 30), label); 
        //Labelはカッコ内でパラメータの設定と渡す文字または文字の入った変数を書く
        //Rect(x,y,width,height)
         

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
