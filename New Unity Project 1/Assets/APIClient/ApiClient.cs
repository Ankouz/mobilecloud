using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour {

    const string baseUrl = "http://localhost:51370/API";
    // Use this for initialization
    void Start () {
        StartCoroutine(GetItensApiAsync());
        StartCoroutine(PostItemApiAsync());
    }
    IEnumerator PostItemApiAsync()
    {
        WWWForm form = new WWWForm();
        form.AddField("Nome", "ItemFromUnity");
        form.AddField("Sexo", "Item enviado por POST para Unity3d(2)");
        form.AddField("Idade", "50");
        form.AddField("Peso", "90");
        form.AddField("TipoItemID", "2");

        using (UnityWebRequest request = UnityWebRequest.Post(baseUrl + "/Itens/Create", form))
        {
            yield return request.Send();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Envio do iem efetuado com sucesso");
            }
        }
    }

        IEnumerator GetItensApiAsync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Itens");
        yield return request.Send();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);

        }
        else
        {
            string response = request.downloadHandler.text;
            Debug.Log(response);

            byte[] bytes = request.downloadHandler.data;

            Item[] itens = JsonHelper.getJsonArray<Item>(response);

            foreach (Item i in itens)
            {
                ImprimirItem(i);
            }

        }
    }

    private void ImprimirItem(Item i)
    {
        Debug.Log("========= Dados do Objeto ==========");
        Debug.Log("ID: " +i.DadoID);
        Debug.Log("Nome" + i.Nome);
        Debug.Log("Sexo: " + i.Sexo);
        Debug.Log("Idade: " + i.Idade);
        Debug.Log("Peso: " + i.Peso);
    }
}
