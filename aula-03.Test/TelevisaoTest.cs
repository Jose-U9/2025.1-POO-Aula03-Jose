using aula_03;

namespace aula_03.Test;

public class Televisao
{
    public float Tamanho { get; private set; }
    public int Volume { get; private set; }
    public int Canal { get; private set; }
    private bool Mudo { get; set; }

    private const int VolumeMaximo = 30;
    private const int VolumeMinimo = 0;

    public Televisao(float tamanho)
    {
        if (tamanho < 22f || tamanho > 80f)
            throw new ArgumentOutOfRangeException($"O tamanho({tamanho}) não é suportado!");

        Tamanho = tamanho;
        Volume = 10;  // Volume padrão
        Canal = 1;    // Canal inicial
        Mudo = false; // Inicia sem mudo
    }

    public void AumentarVolume()
    {
        if (!Mudo && Volume < VolumeMaximo) // Verifica se o mudo está desativado
            Volume++;
    }

    public void DiminuirVolume()
    {
        if (!Mudo && Volume > VolumeMinimo) // Verifica se o mudo está desativado
            Volume--;
    }

    public void AlternarModoMudo()
    {
        Mudo = !Mudo;
        if (Mudo)
        {
            Volume = 0;  // Muda o volume para 0 quando muta
        }
        else
        {
            Volume = 10;  // Restaura o volume anterior ao desmutar
        }
    }

    public void AumentarCanal()
    {
        Canal++;
    }

    public void DiminuirCanal()
    {
        if (Canal > 1) Canal--;
    }

    public void SelecionarCanal(int numeroCanal)
    {
        Canal = numeroCanal;
    }
}
[TestMethod]
public void Deve_Manter_Mudo_Ao_Tentar_Alterar_Volume()
{
    Televisao televisao = new Televisao(25f);
    const int volumeInicial = 10;

    // Ativa o mudo
    televisao.AlternarModoMudo();
    
    // Tenta aumentar o volume enquanto o mudo está ativado
    televisao.AumentarVolume();
    Assert.AreEqual(0, televisao.Volume);  // O volume deve permanecer 0, pois está no mudo

    // Desativa o mudo e verifica o volume
    televisao.AlternarModoMudo();
    Assert.AreEqual(volumeInicial, televisao.Volume);  // O volume deve voltar para o valor inicial (10)
}
[TestMethod]
public void Deve_Alterar_Canal_Aumentando()
{
    Televisao televisao = new Televisao(25f);
    televisao.AumentarCanal();
    Assert.AreEqual(2, televisao.Canal);
}

[TestMethod]
public void Deve_Alterar_Canal_Diminuindo()
{
    Televisao televisao = new Televisao(25f);
    televisao.AumentarCanal();
    televisao.DiminuirCanal();
    Assert.AreEqual(1, televisao.Canal);
}

[TestMethod]
public void Deve_Selecionar_Canal_Pelo_Numero()
{
    Televisao televisao = new Televisao(25f);
    televisao.SelecionarCanal(505);
    Assert.AreEqual(505, televisao.Canal);
}
