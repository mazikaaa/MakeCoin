using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム上のチュートリアルを管理するマネージャクラス
/// </summary>
public class TaskManager : MonoBehaviour
{
    // チュートリアル用UI
    protected RectTransform tutorialTextArea;
    protected Text TutorialTitle;
    protected Text TutorialText;
    protected GameObject NextButton;
    protected GameObject BackButton;
    public GameObject GoButton;

    // チュートリアルタスク
    protected ITutorialTask currentTask;
    protected List<ITutorialTask> tutorialTask;

    protected int Tasknum=0;//現在のリストの番号を保持する

    // チュートリアル表示フラグ
    private bool isEnabled;


    void Start()
    {
        // チュートリアル表示用UIのインスタンス取得
        tutorialTextArea = GameObject.Find("TextBoard").GetComponent<RectTransform>();
        TutorialTitle = tutorialTextArea.Find("Title").GetComponent<Text>();
        TutorialText = tutorialTextArea.Find("Text").GetComponentInChildren<Text>();
        NextButton = GameObject.Find("Next");
        BackButton = GameObject.Find("Back");

        // チュートリアルの一覧
        tutorialTask = new List<ITutorialTask>()
        {
            new InitTask(),
            new SceneTask1(),
            new SceneTask2(),
            new GameTask1(),
            new GameTask2(),
            new GameTask3(),
            new GameTask4(),
            new GameTask4_2(),
            new DropTask1(),
            new DropTask1_2(),
            new ClearTask(),
            new FinishTask(),
        };

        currentTask = tutorialTask.First();

        // 最初のチュートリアルを設定
        StartCoroutine(SetCurrentTask(currentTask));

        isEnabled = true;
    }

    void Update()
    {
        if (currentTask.CheckTask())
        {
            currentTask.NextTask();
            if (Tasknum == 4||Tasknum==7||Tasknum==5||Tasknum==8)
            {
                Tasknum++;
                Debug.Log(Tasknum);
                StartCoroutine(SetCurrentTask(tutorialTask.ElementAt(Tasknum)));
            }else if (Tasknum==11)
            {
                GoButton.SetActive(true);
            }
        }
    }

    /// 新しいチュートリアルタスクを設定する
 
    protected IEnumerator SetCurrentTask(ITutorialTask task, float time = 0)
    {

        // timeが指定されている場合は待機
        yield return new WaitForSeconds(time);

        currentTask = task;

        // UIにタイトルと説明文を設定
        TutorialTitle.text = task.GetTitle();
        TutorialText.text = task.GetText();

        //ボタンの表示を設定
        NextButton.SetActive(task.GetNextButton());
        BackButton.SetActive(task.GetBackButton());

        // チュートリアルタスク設定時用の関数を実行
        task.OnTaskSetting();

    }

    public void MoveNextTask()
    {
        Tasknum++;
        currentTask.NextTask();
        StartCoroutine(SetCurrentTask(tutorialTask.ElementAt(Tasknum)));
    }

    public void MoveBackTask()
    {
        Tasknum--;
        StartCoroutine(SetCurrentTask(tutorialTask.ElementAt(Tasknum)));
    }

    public void MoveGoStart()
    {
        SceneManager.LoadScene("StartScene");
    }
    /// <summary>
    /// チュートリアルの有効・無効の切り替え
    /// </summary>
    protected void SwitchEnabled()
    {
        isEnabled = !isEnabled;

        // UIの表示切り替え
        float alpha = isEnabled ? 1f : 0;
        tutorialTextArea.GetComponent<CanvasGroup>().alpha = alpha;
    }

}