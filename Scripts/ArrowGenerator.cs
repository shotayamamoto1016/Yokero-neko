using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //arrowprefabを宣言
    public GameObject arrowprefab;
    public GameObject Rarrowprefab;
    //間隔を宣言
    float span = 1.0f;
    //矢を生成した時間を宣言
    float delta = 0;

    //赤い矢を生成し、時間を管理するための変数を宣言
    float Rdelta = 0;

    GameDirector director;

    private void Start()
    {
        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }


    
    void Update()
    {
        //ゲームが止まっているときは何もしない
        if(director.stopFlag == true)
        {
            return;
        }

        //フレームごとの時間差をthis.deltaに代入
        //Time.deltaTimeは前フレームからの時間差を表す
        this.delta += Time.deltaTime;

        this.Rdelta += Time.deltaTime;

        if(this.delta > this.span)
        {
            this.delta = 0;
            //instantiateメソッドは引数にprefabを渡すと、返り値としてprefabのインスタンスを返してくれる
            GameObject go = Instantiate(arrowprefab);
            //矢の位置をランダムに設定
            int px = Random.Range(-6, 7);
            //矢の位置を設定
            go.transform.position = new Vector3(px, 7, 0);


        }

        //30秒経過で赤い矢が降る
        if (this.Rdelta > 31)
        {
            this.Rdelta = 30;
            GameObject go2 = Instantiate(Rarrowprefab);
            //赤い矢の位置をランダムに設定
            int px = Random.Range(-6, 7);
            //赤い矢の位置を設定
            go2.transform.position = new Vector3(px, 7, 0);
        }
       
    }
}
