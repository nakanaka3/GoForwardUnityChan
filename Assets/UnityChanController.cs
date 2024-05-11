using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Unityちゃんを移動させるコンポーネントを入れる（追加）
    Rigidbody2D rigid2D;
    // 地面の位置
    private float groundLevel = -3.0f;

    // ジャンプの速度の減衰（追加）
    private float dump = 0.8f;
    // ジャンプの速度（追加）●●１秒間あたり20m
    float jumpVelocity = 20;

    // ゲームオーバーになる位置（追加）
    private float deadLine = -9;

    // Start is called before the first frame updatem
    void Start()
    {
        // アニメータのコンポーネントを取得する●●GetComponent関数を使ってAnimatorコンポーネントを取得、Animatorコンポーネントを使ってユニティちゃんのアニメーション再生をスクリプトで制御する
        this.animator = GetComponent<Animator>();

        // Rigidbody2Dのコンポーネントを取得する（追加）●●ジャンプするためにRigidbody2Dコンポーネントを取得、Rigidbody2Dを使ってユニティちゃんをジャンプさせたり、ジャンプの高さを調節したりする
        //●●Rigidbodyのvelocityを使うことで物理が計算された自然なジャンプになる！
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame●●走るアニメーションを再生するために、Animatorで定義しているHorizontalパラメータとisGroundパラメータの遷移条件を設定している
    void Update()
    {
        //●●Animatorの中のFloatという名前のパラメータの値が０より大きくなったら遷移を開始するという意味、1が入っているので常に遷移する、"Horizontal"というパラメーターを1にしなさいということ
        this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる●●ユニティちゃんが着地している場合はisGroundをtrueに設定します
        //●●三項演算子；値を代入する変数 = (条件式) ? 変数1 : 変数2;　←条件式を満たした場合には左辺の変数に「変数1」が代入され、満たさなかった場合は「変数2」が代入される
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        //●●Animatorの中のBoolという名前のパラメータの値がisGround=trueになったら遷移を開始する、という意味。"isGround"というパラメータにisGroundを入れなさいということ
        this.animator.SetBool("isGround", isGround);

        // ジャンプ状態のときにはボリュームを0にする（追加）●●ユニティちゃんがジャンプ中かどうかはisGround変数で判別、isGroundがtrueの場合は音量を1、falseの場合は音量を0にする。
        // ●●ここでは、AudioSourceコンポーネントを取得すると同時にvolume変数へ音量の値を代入しています。AudioSourceクラスの「volume」変数は、音量を表しています。
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // 着地状態でクリックされた場合（追加）●●画面をタップした時にユニティちゃんが着地状態であれば、ユニティちゃんの上向きの速度を与える、GetMouseButtonDown(0)の0は左クリック、1だと右クリック
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける（追加）●●ユニティが持ってるRigidbody2DのY軸にjumpVelocity = 20を入れる。
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // クリックをやめたら上方向への速度を減速する（追加）●●タップが離された時点からユニティちゃんの上方向への速度を落として勢いを減衰させることで、タップしつづけた場合よりも、ジャンプの高さが低くなるようにしています。
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        // デッドラインを超えた場合ゲームオーバーにする（追加）
        if (transform.position.x < this.deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する（追加）
            //●●UIControllerはCanvasオブジェクトにアタッチされてるため、Find関数を使ってUIControllerがアタッチされてるCanvasオブジェクトを検索、GetComponent関数を使ってCanvasにアタッチされているUIContorllerスクリプトを取得してる
            //●●このように、Findでオブジェクトを探してGetComponentでそのオブジェクトのスクリプトを取得する方法はよく使う
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ユニティちゃんを破棄する（追加）
            Destroy(gameObject);
        }
    }
}