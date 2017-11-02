[System.Serializable]

public class Item
{
    public int DadoID;

    public string Nome;

    public string Sexo;

    public int Idade;

    public int Peso;

    // Relacionamento Item -> TipoItem

    public int TipoIntID;
}
