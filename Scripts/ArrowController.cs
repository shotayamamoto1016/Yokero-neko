using UnityEngine;

public class ArrowController : MonoBehaviour
{
    //playerという変数がプレイヤーキャラを参照
    GameObject player;

    GameDirector director;

    //ダメージを0.1に設定
    public float damege = 0.1f;

    
    void Start()
    {
        //playerにシーン内の"player_0"という名前の変数に代入
        this.player = GameObject.Find("player_0");

        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    
    void Update()
    {
        //ゲームが止まっているときは何もしない
        if (director.stopFlag == true)
        {
            return;
        }

        //フレームごとに等速で落下させる
        transform.Translate(0, -0.1f, 0);

        //画面外に出たらオブジェクトを破壊する
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //当たり判定
        //矢の中心座標
        Vector2 p1 = transform.position;
        //プレイヤの中心座標
        Vector2 p2 = this.player.transform.position;
        //距離を計算
        Vector2 dir = p1 - p2;
        //kk
        float d = dir.magnitude;
        //矢の半径
        float r1 = 0.5f;
        //プレイヤの半径
        float r2 = 1.0f;

        if(d <r1 + r2)
        {
            //監督スクリプトにプレイヤと衝突したことを伝える
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp(damege);

            //衝突した場合は矢を消す
            Destroy(gameObject);
        }

       

    }
}
