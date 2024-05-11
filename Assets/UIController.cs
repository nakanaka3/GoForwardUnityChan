using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //（追加）●●スクリプトでシーンに関するクラスを使うために、using UnityEngine.SceneManagement;を記述しています。

public class UIController : MonoBehaviour
{

    // ゲームオーバーテキスト
    private GameObject gameOverText;

    // 走行距離テキスト
    private GameObject runLengthText;

    // 走った距離
    private float len = 0;

    // 走る速度
    private float speed = 5f;

    // ゲームオーバーの判定
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する
        //●●作成した2つのUI(GameOverとRunLength)に表示する文字列を更新するため、Start関数のなかでFind関数を使ってシーン中からこれらのオブジェクトを探し、gameOverText変数とrunLengthText変数にそれぞれ代入している
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            // 走った距離を更新する●●len変数にspeed変数を加算して走行距離を算出している。フレームレートによって差を出さないためにTime.deltaTimeを掛けている
            this.len += this.speed * Time.deltaTime;

            // 走った距離を表示する●●runLengthText変数のtextに代入するときはlen.ToString ("F2")としてlen変数をToString関数を使って文字列に変換しています
            //●●「ToString()」は数値を文字列に変換する関数。引数には文字列に変換する際の書式を指定でき、ここでは浮動小数点の値を文字列に変換。引数を"F2"とすることで、小数部を2桁まで表示するように書式指定しています
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }

        // ゲームオーバーになった場合（追加）
        if (this.isGameOver == true)
        {
            // クリックされたらシーンをロードする（追加）●●ゲームオーバー時に画面がタップされた時、GameSceneを読み込むスクリプト
            if (Input.GetMouseButtonDown(0))
            {
                //SampleSceneを読み込む（追加）●●SceneManagerクラスのLoadScene関数を使うとシーンを読み込むことができます。引数には読み込むシーン名を渡します。
                //●●ここでは"SampleScene"を渡して同じシーンを再読み込みすることで、ゲームオーバーとなった時にワンタッチで再びゲームを開始しています。
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    //●●GameOver関数は、先ほど作成したGameOverのtextに「Game Over」の文字列を代入して画面に表示します。ゲームオーバーになると、UnityChanControllerがこの関数を呼ぶことになります。
    public void GameOver()
    {
        // ゲームオーバーになったときに、画面上にゲームオーバを表示する
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}