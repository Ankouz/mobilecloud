[System.Serializable]

public class Item
{
    public int ItemID;

    public string Nome;

    public string Descricao;

    public int Idade;

    public int Peso;

    // Relacionamento Item -> TipoItem

    public int TipoIntID;
}
