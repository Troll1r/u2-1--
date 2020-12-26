using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chat : MonoBehaviour
{

    [SerializeField] Text chatText;
    [SerializeField] InputField chatInput;
    public float timer = 15;

    Queue<string> chat = new Queue<string>(5);


    public void SendChatMessenge(string val)
    {

        if (chat.Count == 5) chat.Dequeue();
        chat.Enqueue(chatInput.text);
        chatInput.text = "";

        chatText.text = string.Join("\n",chat);
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (chat.Count > 0)
            {
                chat.Dequeue();
                chatText.text = string.Join("\n",chat);

            }
                timer = 15;
           
        }

        if(Input.GetKeyDown(KeyCode.Y))
        chatInput.gameObject.SetActive(!chatInput.gameObject.activeInHierarchy);
    }



}
