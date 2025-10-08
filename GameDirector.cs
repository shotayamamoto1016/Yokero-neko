using Unity.VisualScripting;
using UnityEngine;
//UIを使用するので追加
using UnityEngine.UI;
//TextMeshProを使用
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    //hpGaugeを宣言
    GameObject hpGauge;

    GameObject GameOverText;

    GameObject timerText;
    //カウントダウンを設定
    float countTime = 60;

    //ゲームを止めるフラグ
    public bool stopFlag;

    public Button ReturnButton;

    public GameObject GameClearText;
    
    
    void Start()
    {
        this.timerText = GameObject.Find("TimeText");
        //シーン内のhpGaugeオブジェクトを探してhpgaugeに代入
        this.hpGauge = GameObject.Find("hpGauge");

        GameOverText = GameObject.Find("GameOverText");

        //ゲーム開始時は非表示にする
        GameOverText.SetActive(false);

        ReturnButton.gameObject.SetActive(false);

        GameClearText.SetActive(false);

     
    }
    private void Update()
    {
        //ストップフラグがtrueになったらすべてのオブジェクトを停止する
        if (stopFlag == true)
        {
            countTime = 0;
            this.timerText.GetComponent<TextMeshProUGUI>().text = this.countTime.ToString("F2");
            return;
        }
        this.countTime -= Time.deltaTime;
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.countTime.ToString("F2");

        //カウントダウンが０になったらゲームクリアー
        if (countTime <= 0)
        {
            //ゲームクリアを表示する
            Debug.Log("ゲームクリア");

            stopFlag = true;

            //ReturnButtonを表示
            ReturnButton.gameObject.SetActive(true);

            //GameClearを表示
            GameClearText.SetActive(true);
        }
    }

    
    //hpGaugeの処理をする
   　public void DecreaseHp(float damege)
    {
       

        //hpGaugeにアッタチされているImageコンポーネントを取得
        //GetComponentはinspectorウィンドウにあるimageという部品を取得する
        this.hpGauge.GetComponent<Image>().fillAmount -= damege;

        //hpが０になったときゲームオーバーを表示する
        if (hpGauge.GetComponent <Image >().fillAmount <= 0)
        {
            //GameOverを表示
            GameOverText.SetActive(true);

            //ゲームを止めるフラグを立てる
            stopFlag = true;

            //ReturnButtonを表示
            ReturnButton.gameObject.SetActive(true);
        }

       
 
    }

    //タイトルシーンへ遷移
    public void ReturnGame()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
