# Recursos do C# até versão 6.0

**Classe Object:** toda classe em C# descende direta ou indiretamente da classe Object. Qualquer classe criada em C# possui no mínimo os seguintes membros:

Membro | Descrição
--- | ---
Equals | método que pode ser usado para verificar se um objeto é igual a outro. Para tipos básicos a implementação base funciona, mas para tipos complexos você deve sobrescrever o método e implementar a rotina.
GetHashCode | método que retorna o código hash que é gerado para cada instância. Este hash é único e é usado para identificar as instâncias internamente.
GetType | método que retorna o tipo e o namespace (full identifier) de um objeto.
ToString | método que pode ser usado para retornar uma string que represente o objeto. Para tipos básicos a implementação base funciona, mas para tipos complexos você deve sobrescrever o método e implementar a rotina.

```csharp
//Como em C# tipos básicos também são objetos podemos fazer assim:
Console.WriteLine("{0}", "marco".GetHashCode());
Console.WriteLine("{0}", "marco".Equals("marco"));
Console.WriteLine("{0}", "marco".GetType());
Console.WriteLine("{0}", 51.ToString());
Console.WriteLine("{0}", 51.GetType());
Console.WriteLine("{0}", 51.Equals("uma boa ideia"));
Console.WriteLine("{0}", 51.Equals("51"));
Console.WriteLine("{0}", 51.Equals(51));

//Implicitamente Ponto estende Object
public class Ponto
{
    private int _x = 0;
    private int _y = 0;
    
    public Ponto(int x, int y)
    {
        SetPosicao(x, y);
    }

    public void SetPosicao(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public int GetX()
    {
        return _x;
    }

    public int GetY()
    {
        return _y;
    }

    public override string ToString()
    {
        return "(" + _x.ToString() + ";" + _y.ToString() + ")";
    }

    public override bool Equals(object obj)
    {
        if (obj is Ponto)
        {
            Ponto p = (Ponto)obj;
            return p.GetX() == _x && p.GetY() == _y;
        }
        return false;
    }
}

Ponto p1 = new Ponto(20, 50);
Ponto p2 = new Ponto(30, 40);
Console.WriteLine("{0}", p1.ToString());
Console.WriteLine("{0}", p2.ToString());
Console.WriteLine("{0}", p1.Equals(p2));
p1.SetPosicao(p2.GetX(), p2.GetY());
Console.WriteLine("{0}", p1.Equals(p2));
```

**Variáveis:** ao declarar uma variável no C# é preciso determinar o tipo de dado que será "armazenado". Por isso dizemos que C# é **type safe**.

**Tipos Básicos:** no C# os tipos básicos também são objetos. As palavras reservadas para os tipos básicos são apenas _alias_ para os tipos "reais" do **CTS (Common Type System)**.

Tipo Básico (alias) | Tipo Real (CTS) | Faixa de Valores
--- | --- | ---
bool | System.Boolean | true ou false
byte | System.Byte | 0 a 255
sbyte | System.SByte | -128 a 127
char | System.Char | 
decimal | System.Decimal | 
double | System.Double | 
float | System.Single | 
int | System.Int32 | 
long | System.Int64 | 
short | System.Int16 | -32.768 a 32.767
ushort | System.UInt16 | 0 a 65.535
uint | System.UInt32 | 
ulong | System.UInt64 | 
string | System.String | 
Object | System.Object | 

```csharp
short valorInt16 = 16;
int valorInt32 = 32;
long valorInt64 = 64;
byte menorByte = 0;
sbyte menorSByte = -128;
float valorFloat = 3.4f;

Console.WriteLine("{0}", valorInt16.GetType());
Console.WriteLine("{0}", valorInt32.GetType());
Console.WriteLine("{0}", valorInt64.GetType());
Console.WriteLine("{0}", menorByte.GetType());
Console.WriteLine("{0}", menorSByte.GetType());
Console.WriteLine("{0}", valorFloat.GetType());
```

**Como as variáveis são armazenadas:** o armazenamento depende do tipo de referência, se for **value type** (por valor) o dado é armazenado diretamente na **stack** (pilha), se for **reference type** (por referência) o dado fica armazenado na **heap** e um ponteiro para o dado fica armazenado na stack.

- Value Type: 
    - Contém o dado;
    - Ao passar uma variável por valor é feita uma cópia do dado;
    - Operações em uma variável não afetam a sua cópia, pois elas são independentes;
    - Ao passar tipos básicos a referência padrão é por valor.

- Reference Type:
    - O dado fica na heap e um ponteiro fica na stack;
    - Ao passar uma variável por referência é feita uma cópia do ponteiro;
    - Operações em uma variável afetam a sua cópia, pois elas apontam para o mesmo dado;
    - Ao passar objetos a referência padrão é por referência.

**Constantes:** constantes são variáveis cujo valor não pode ser alterado em tempo de execução e a definição do valor **deve** ser feita na declaração.

```csharp
const double PI = 3.1415;
```

**Inferência de Tipo:** recurso introduzido no C# 3.0, onde não é necessário explicitar o tipo da variável. Na compilação o tipo é inferido com base no valor atribuido.

```csharp
//declaração com tipagem explícita
int numero = 10;
string nome = "marco";

//declaração com tipagem implícita (inferência)
var numero = 10;
var nome = "marco";
```

**Struct:** estrutura é um tipo de dado complexo. Sua declaração é parecida com a de uma classe. A principal diferença entre _struct_ e _class_ é que na _struct_ o armazenamento padrão é por valor e na _class_ é por referência. Isso significa que ao passar uma _struct_ é feita uma cópia de todo o seu conteúdo.

- Não existe herança entre structs.
- São alocadas na _stack_ (pilha) e não na _heap_ (memória).
- Podemos implementar _interfaces_.
- Aceita construtores, atributos/propriedades e métodos. Os construtores devem ser customizados.
- Não aceita destrutores.
- Não aceita métodos virtuais (não tem sentido, pois não existe herança).

```csharp
//sintaxe de declaração
[modificador] struct <nome> : [interface]
{
    //membros...
}

//usando
<struct_nome> variavel = new <struct_nome>([parametros_do_construtor]);
```

**enum:** enum é um tipo de dado para lista de constantes. Por padrão as constantes são associados a valores inteiros, mas é possível mudar, o que por sua vez exige o uso de **cast explícito**.

```csharp
//exemplo1
public enum Dia 
{
    Domingo,
    Segunda,
    Terca,
    Quarta,
    Quinta,
    Sexta,
    Sabado
};

//exemplo2
public enum Dia
{
    Domingo = 1,
    Segunda = 2, 
    Terca   = 3,
    Quarta  = 4,
    Quinta  = 5,
    Sexta   = 6,
    Sabado  = 7
};
```

> No exemplo1 Domingo = 0 (zero), ou seja, é possível definir o valor para cada constante, mas quando não definido o valor inicial é 0 (zero).

**string/String:** string ou String é uma matriz de caracteres **imutável**, ou seja, seu valor não pode ser alterado depois de atribuído. Toda manipulação de string gera outra string como resultado.

- Aceita caracteres de escape como **"\n"** para nova linha e **"\t"** para tabulação.
- Para ignorar caracteres de escape podemos usar o símbolo "**@ (arroba)**".
- Para concatenar strings podemos usar o símbolo "**+**".
- Para comparar strings podemos usar o símbolo "**==**", porém é mais indicado o uso do método "_string1.**Equals(**_string2_**)**_".

**Conversão:** conversão ou **cast** é a operação que deve ser realizada antes de se transferir o conteúdo de uma variável para outra de variável de tipo diferente. Existem dois tipos de conversão, **implícita** e **explícita**. 

- A conversão explícita é necessária quando ocorre a transferência de uma variável de um tipo de dado "maior" para outra variável de um tipo de dado "menor".
```csharp
double numero = 12.3;
int parteInteira = (int) numero;
```
> No caso acima, como a variável double "não cabe" em um variável int somos obrigados a explicitar o cast.

- A conversão implícita ou transparente ocorre na transferência de uma variável de um tipo de dado "menor" para outra variável de um tipo de dado "maior".
```csharp
int menor = 10;
long maior = menor;
```
> No caso acima, como a variável int "cabe" em uma variável long não é preciso explicitar o cast. Tudo é feito de forma transparente.

**Método com _params_:** recurso que pode ser usado na passagem de muitos parâmetros de um mesmo tipo.

```csharp
int Somar(params int[] numeros)
{
    int soma = 0;
    foreach (int numero in numeros)
    {
        soma += numero;
    }
    return soma;
}
//usando
Somar(1,4);
Somar(2,6,8);
Somar(3,8,9,2,3);
```

> O recurso _params_ pode ser usado com outros parâmetros, porém o parâmetro _params_ deve ser sempre o último.

**Vetor e Matriz:** recurso que serve para armazenar vários dados do mesmo tipo. Os dados podem ser armazenados de forma **unidimensional** (array/vetor), de forma **bidimensional** (matriz) ou de forma **multidimensional**. Diferentemente de outras linguagens como C e C++, em C# **arrays** são objetos da classe **System.Array** e não apenas regiões endereçáveis de memória contígua.

- Membros da classe **System.Array**:
    - **Length:** propriedade que retorna o número total de elementos de todas as dimensões de um array.
    - **Rank:** propriedade que retorna o número de dimensões de um array.
    - **GetLength(**_dimensao_**):** método que retorna o número total de elementos de uma dada _dimensão_.
    - **Reverse(**_array_**):** método estático que inverte a ordem dos elementos de um dado _array_. Essa inversão pode ser completa ou parcial.
    - **Sort(**_array_**):** método estático que ordena um dado _array_.


- Declarando **arrays**:

```csharp
//declarando vetor com inicialização
int[] mesesAno = {1,2,3,4,5,6,7,8,9,10,11,12};

//declarando vetor sem inicialização
string[] diasSemana = new string[12];
diasSemana[0] = "dom";
diasSemana[1] = "seg";
diasSemana[2] = "ter";
diasSemana[3] = "qua";
diasSemana[4] = "qui";
diasSemana[5] = "sex";
diasSemana[6] = "sab";

//declarando matriz com inicialização
int[,] quadrado1 = {{10,11} , {50,51}};

//declarando matriz sem inicialização
int[,] quadrado2 = new int[2,2];
quadrado2[0,0] = 10;
quadrado2[0,1] = 11;
quadrado2[1,0] = 50;
quadrado2[1,1] = 51;
```