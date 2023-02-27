using System.Collections;
using UnityEngine;
using WCP;
using UnityEngine.UI;


public class ChatPanelExample : MonoBehaviour
{
    public WChatPanel wcp;
    [SerializeField] private Text message;
	string story;
	private int countPhone = 0;

	private IEnumerator DebugChat()
    {
        wcp.AddChatAndUpdate(true, "Привет");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(false, "Привет");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(true, "Я переезжаю");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(false, "Смешная шутка");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(true, "Я не шучу");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(false, "не верю");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(true, "Ну не хочешь - не верь.");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(false, "А куда?");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(true, ".");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(false, "БЛИН");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(true, "Через");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(false, "Клааасс");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(true, "Ну");
        yield return new WaitForSeconds(2);
        wcp.AddChatAndUpdate(true, "Сегодня");








    }

    private void Start()
    {
        StartCoroutine("DebugChat");
    }

    public void PerformanceTest(int count)
    {
        for (int i = 0; i < count; i++)
            wcp.AddChat(Random.Range(0.0f, 1.0f) > 0.5f, i.ToString(), Random.Range(0, wcp.configFile.photoSpriteList.Count));

        wcp.Rebuild();
    }
}