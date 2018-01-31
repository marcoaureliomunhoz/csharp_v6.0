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

**Interpolação de String:** recurso introduzido no C# 6.0 que facilita a formatação de strings.

- Comumente utilizamos concatenação e conversões em formtações de string.

```csharp
int idade = 18;
string nome = "Marco";
double salario = 1234.56;

//exemplo1
string frase1 = nome + " possui " + idade.ToString() + " anos de idade e ganha só R$ " + salario.ToString() + " reais por mês.";

//exemplo2
string frase2 = String.Format("{0} possui {1} anos de idade e ganha só R$ {2} reais por mês.", nome, idade, salario);

//exemplo3 = interpolação $"..{variavel}..";
string frase3 = $"{nome} possui {idade} anos de idade e ganha só R$ {salario} reais por mês.";
```

> Nos exemplos acima os resultados são os mesmos, porém com o recurso de interpolação fica muito mais fácil formatar strings. Repare que o código ficou mais curto e mais legível.

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

**Coleções:** recurso que também serve para armazenar vários dados, porém não é necessário definir a quantidade de elementos, pois a alocação é dinâmica.

- Tipos de Coleções:
    - List
    - ArrayList
    - HashTable
    - SortedList
    - LinkedList
    - Queue
    - Stack
    - Dictionary
    - SortedDictionary

- Interfaces Importantes:
    - IEnumerable: presente no namespace _System.Collection_ serve de base para todos os tipos de coleções. É mais apropriada para lidar com fontes de dados locais e em memória, pois trabalha com base em **delegates**. Nos bastidores o compilador usa **delegates** para resolver consultas e isso significa que uma consulta na base de dados, mesmo com filtro informado, o filtro será realizado do lado do cliente, ou seja, a tabela inteira será trazida para a memória e em memória através de delegates do compilador resolve a consulta e o filtro.
    - ICollection
    - IReadOnlyList
    - IReadOnlyCollection
    - IQueryable: presente no namespace _System.Linq_ serve como base para as coleções suportarem LINQ e recursos como _lazy loading_. É mais apropriada para lidar com fontes de dados remotas, pois suporta paginação e trabalha com **expressions**. Nos bastidores o compilador usa **expressions** para resolver consultas e isso significa que no caso de uma consulta na base de dados com filtro, o filtro será realizado do lado do servidor, ou seja, antes de enviar a instrução sql para o gerenciador de banco de dados o compilador resolve as **expressions** e gera uma instrução sql mais complexa e que resulta num volume menor de dados como retorno.

> Além da alocação dinâmica que já nos traz uma grande vantagem as coleções nos fornecem uma série de membros (métodos e atributos/propriedades) que facilitam muito o desenvolvimento.

- Alguns membros comuns:
    - **Add(**_elemento_**)**: método que adiciona um novo elemento da coleção.
    - **Remove(**_elemento_**)**: método que remove um elemento da coleção.
    - **Clear()**: método que "limpa" uma coleção.
    - **IndexOf(**_elemento_**)**: método que retorna a posição de um dado elemento.

**Generics:** mecanismo que permite a definição de certas classes, métodos, delegates e outros recursos sem exigir a definição primária de tipo. A definição de tipo, nestes casos, deve se feita ao declarar os recursos.

> Um exemplo de recurso que foi construído/definido com base no mecanismo de generics é a classe **List**. Na sua construção/definição não existe definição de tipo, a definição de tipo é feita ao declarar a lista.

```csharp
List<int> inteiros = new List<int>();
List<string> strings = new List<string>();
List<Ponto> pontos = new List<Ponto>();
```

**Delegate:** é uma classe especial que tem a capacidade de armazenar e gerenciar uma coleção de métodos/funções. É como se fosse uma lista de métodos/funções. No C# não tem como passar métodos/funções por parâmetro, mas tem como passar um objeto. É aí que entra o delegate, pois ele é um objeto que carrega métodos/funções e com ele podemos passar métodos/funções por parâmetro de forma indireta.

> Vamos supor a seguinte situação: eu preciso realizar uma série de operações em memória e no final gravar o log destas operações em banco de dados e avisar o usuário sobre o ocorrido. Não tem como na minha aplicação eu ficar esperando o final das operações pois pode demorar e o usuário certamente vai ficar irritado. Para evitar que o usuário se irrite o ideal é usar thread. Mas introduzir a gravação do log em base de dados dentro da thread não fica legal, até porque eu já tenho uma camada que se comunica com a base de dados. É aí que entra o delegate. A solução seria então implementar um delegate que receba como parâmetro uma string, passar esse delegate para a thread que ao final do processamento aciona o delegate, que por sua vez chama a função delegada na camada de apresentação que por sua vez aciona a camada de dados e ainda dá um feedback ao usuário que por sua vez :)

```csharp
//olha como é simples declarar um delegate
//por baixo dos panos o C# gera uma classe
//que aceita e gerencia métodos com a assinatura abaixo
public delegate void DelegLog(string log);

//aqui é o momento em que o usuário aciona uma operação que desencadeia uma série de operações
public void btnProcessar_Click(object sender, EventArgs e)
{
    //o parâmetro do construtor de MinhaThread espera um delegate
    //neste caso o delegate aponta para apenas um método
    //portanto basta passar o nome do método
    MinhaThread mt = new MinhaThread(GravarLogEmBD);

    //poderíamos fazer assim também, mas a forma anterior é mais elegante quando o delegate aponta para apenas um método
    MinhaThread mt = new MinhaThead(new DelegLog(GravarLogEmBD));
}

//aqui o método para o qual será delegado
public void GravarLogEmBD(string log)
{
    //aqui aciona a camada de dados
    //...
    //aqui avisa o usuário
    MessageBox.Show("Blá blá blá blá!");
}
```

- Outras observações sobre delegate:
    - Um delegate pode referenciar vários métodos (**delegate multicast**). Para isso devemos utilizar o operador **"+"**.
    - Para remover um método do delegate usamos o operador **"-"**.
    - Ao acionar um delegate que referencia vários métodos todos os métodos serão chamados de acordo com a sequencia de referenciamento.
    - Uma outra forma de invocar um delegate de forma mais explicita é através do método **Invoke**. Veja como ficaria o exemplo acima: deleg.Invoke("log...")
    - Todo delegate possui a propriedade **Target** que aponta para a instância do método delegado.
    - Todo delegate possui a propriedade **Method** que indica se o delegate possui ou não pelo menos um método delegado.

**Modelo padrão de Eventos:** eventos são recursos muito utilizados como resposta de uma ação em aplicações "Windows Forms" e como retorno de operações com resposta tardia. Um evento nada mais é do que um **delegate** especial. A plataforma .NET, para facilitar e padronizar a utilização de eventos, definiu um modelo padrão de eventos baseado em **delegate** e em **generics**. Toda vez que um usuário clica num botão um método **emissor** invoca um delegate que chama o método final (dizemos que foi disparado um evento). De acordo com o padrão .NET, o método emissor que invocará o delegate deve ser **protected**, **virtual**, do tipo **void**, iniciar com **"On"** e esperar como parâmetro um delegate que estende **EventArgs**. A invocação do delegate deve ser feita por meio de um **delegate genérico** baseado em **EventHandler**. Como o delegate é baseado em EventHandler, o método final também deve se basear em EventHandler, ou seja, seu primeiro parâmetro deve ser do tipo **object** e o segundo deve ser do tipo do delegate que estende de EventArgs. 

> Fica claro que entre o emissor primário e o método final existe uma intermediação. Essa intermediação é feita pela classe genérica EventHandler que por sua vez sabe lidar com delegates que estendem EventArgs.

- Vamos supor a seguinte situação: eu tenho um botão customizado que toda vez que o usuário clica nele a cor do fundo é alterada de forma aleatória. Uma forma de descobrir a cor deste botão imediatamente à alteração seria usar uma thread ou um timer e ficar monitorando a cor do botão em comparação a uma cor salva em memória. Porém existe uma forma mais elegante de solucionar esse problema. A ideia é utilizar evento baseado em **EventArgs** e **EventHandler**.

**Expressões Lambda:** é um recurso que contribui para aumentar a produtividade e a legibilidade quando estamos lidando com expressões previsíveis. Você escreve só o código essencial e o compilador, nos bastidores, infere (gera) o código completo. 

> Nos bastidores o compilador usa delegates **Func<>** ou **Action<>** que são delegates genéricos e prontos para plugarmos métodos sem ter que ficar definindo delegates no código.

- Vejamos:
```csharp
public delegate int DelegCalc(int v);

public int Quadrado(int x)
{
    return x * x;
}

//usando
DelegCalc calc = new DelegCalc(Quadrado);
calc(2);
```

- No exemplo acima a função Quadrado é muito simples e fácil para se  inferir. Vejamos como a substituição por uma expressão lambda reduz o código e aumenta a legibilidade.
```csharp
public delegate int DelegCalc(int v);

//usando
DelegCalc calcEx = new DelegCalc(x => x * x);
calcEx(2);
```

- Com o uso do delegate **Func<>** é possível reduzir ainda mais o código acima. 
```csharp
public Func<int,int> quadrado = x => x * x;

//usando
quadrado(2);
```

> **Func<e1,e2,e3,..,en>**: o elemento _en_ indica o tipo do dado/valor que o método retornará e os demais elementos anteriores a _en_ indicam a quantidade de parâmetros e o tipo de cada um. Func é usado em métodos com retorno. Para métodos sem retorno (void) usa-se **Action**.

- Agora um exemplo mais complexo de Func com expressão lambda.
```csharp
public Func<int,double,string> concatenar = (a, b) => a.ToString() + b.ToString();

//usando
concatenar(5,6.7);
```

**Tipo Anônimo:** é mais uma "mão" do compilador para nos auxiliar na definição de classes simples e contextuais. 

- Vejamos:
```csharp
var pessoa = new { Nome = "Marco", Idade = 18 };
```

> O exemplo acima se trata de um tipo anônimo que nos bastidores o compilador se encarregará de gerar algo assim:

```csharp
internal class NomeGeradoPeloCompilador
{
    private string _nome;
    private int _idade;
    public NomeGeradoPeloCompilador(string nome, int idade)
    {
        _nome = nome;
        _idade = idade;
    }
    public string Nome { get { return _nome; } }
    public int Idade { get { return _idade; } }
}
```

> e a trocará a chamada por:

```csharp
NomeGeradoPeloCompilador pessoa = new NomeGeradoPeloCompilador("Marco", 18);
```

> Ao utilizar o recurso de tipo anônimo sempre devemos usar a keyword **var**.

**Manipulando Arquivos Texto:** a maioria dos recursos voltados para manipulação de arquivo texto estão no namespace **System.IO**.

- Na base de tudo está a classe **Stream**:
    - Length: retorna o tamanho em bytes do fluxo.
    - Position: retorna ou define a posição corrente do fluxo.
    - CanRead: indica se o fluxo atual oferece suporte à leitura.
    - CanWrite: indica se o fluxo atual oferece suporte à escrita.
    - CanSeek: indica se o fluxo atual oferece suporte à busca.
    - BeginRead(): inicia uma operação de leitura assíncrona.
    - EndRead(): aguarda a leitura assíncrona pendente terminar.
    - BeginWrite(): inidica uma operação de escrita assíncrona.
    - EndWrite(): termina uma operação de escrita assíncrona.
    - Dispose(): libera recursos (como soquetes e identificadores de arquivos) associados ao fluxo.
    - Close(): fecha o fluxo e libera recursos.
    - CopyTo(Stream): copia os dados do fluxo para uma Stream.
    - Flush(): limpa todos os buffers para esse fluxo e faz com que alguns dados armazenados em buffer sejam gravados no dispositivo subjacente.
    - Read(): lê uma sequência de bytes de fluxo atual e avança a posição no fluxo pelo número de bytes lidos.
    - Write(): grava uma sequência de bytes no fluxo atual e avança a posição atual dentro desse fluxo pelo número de bytes escritos.
    - Seek(): define a posição corrente.
    - SetLength(): define o tamanho do fluxo.

- Classes e métodos importantes para manipulação de arquivos texto:
    - **File**: classe estática que fornece métodos comuns de acesso a arquivo.
        - File.Exists("caminho_completo")
        - File.Create("caminho_completo)
    - **StreamWriter**: classe que serve para escrever em arquivos texto. Esta classe deriva da classe abstrata **TextWriter**.
    - **StreamReader**: classe que serve para ler arquivos texto. Esta classe deriva da classe abstrata **TextReader**.

- Propriedades e métodos da classe StreamWriter:
    - Write()
    - WriteLine()
    - NewLine()
    - Flush()
    - Dispose()
    - Close()

- Propriedade e métodos da classe StreamReader:
    - Read()
    - ReadLine()
    - ReadBlock()
    - ReadToEnt()
    - Peek()
    - Dispose()
    - Close()

**Manipulando XML:** a maioria dos recursos voltados para manipulação de XML estão nos namespaces **System.Xml**, **System.Xml.Linq** e **System.Data.Linq**.

- Para ler XML: 
    - **XmlTextReader**: classe que nos permite percorrer um XML, de forma rápida, para mapear ou buscar elementos e dados.
    - **XmlDocument**: classe que representa um XML com base no padrão **Document Object Model (DOM)**, onde cada nó do documento é representado por uma classe derivada (**XmlAttribute, XmlDocument, XmlDocumentFragment, XmlEntity, XmlLinkedNode, e XmlNotation**) da classe abstrata **XMLNode**.
    - **XPath**: linguagem de alto nível baseada no padrão **XSLT** que facilita a navegação em arquivos XML representados no padrão DOM. Em "XPath" um documento é "enxergado" como uma estrutura de diretórios. As classes DOM fornecem dois métodos de seleção XPath: o método **SelectSingleNode** e o método **SelectNodes**. O método SelectSingleNode retorna o primeiro nó que corresponde aos critérios de seleção. O método SelectNodes retorna um XmlNodeList que contém os nós correspondentes.
    - **LINQ to XML**: conjunto de recursos para leitura e escrita baseados em LINQ.

- Para criar/escrever XML:
    - **XmlTextWriter**
    - **XmlDocument**
    - **LINQ to XML**

**Manipulando JSON:** JSON significa JavaScript Object Notation e é um padrão aberto para representar dados como atributos com valores. Originalmente derivado da sintaxe do JavaScript (daí o seu nome) para uso em aplicações web como uma alternativa ao XML, é agora usado para serialização de dados e de transporte em muitas aplicações standalone e web. JSON fornece um meio ideal para encapsular os dados entre o cliente e o servidor. Dessa forma, JSON é um protocolo leve para intercâmbio de dados e está baseado em um subconjunto da linguagem de programação JavaScript, sendo independente desta e de qualquer linguagem. (Macoratti)

- Algumas opções para trabalhar com JSON:
    - Opção 1: classe assembly **DataContractJsonSerializer** presente no namespace **System.Runtime.Serialization**.
    - Opção 2: biblioteca **Json.NET** (também conhecida como **Newtonsoft**). Essa biblioteca é obtida através de **NuGet Package**.
    - Opção 3: biblioteca **Jil**, famosa por ser mais performática que as outras bibliotecas. Essa biblioteca é obtida através de **NuGet Package**.

**Programação Paralela:** Muitos computadores pessoais e estações de trabalho possuem dois ou quatro núcleos (ou seja, CPUs) que permitem a execução de várias threads ao mesmo tempo. Em um futuro próximo, espera-se que os computadores possuam um número de núcleos significativamente maior. Para tirar proveito do hardware de hoje e do futuro, podemos paralelizar o código para distribuir o trabalho entre vários processadores. É possível fazer a manipulação em baixo nível de threads e de bloqueios, mas a partir do .NET Framework 4 o suporte à programação paralela foi aprimorado com a disponibilização de um novo tempo de execução, novos tipos de biblioteca de classes e novas ferramentas de diagnóstico. Esses novos recursos simplificam o desenvolvimento paralelo para que seja possível escrever código paralelo eficiente, refinado e dimensionável em uma linguagem natural sem precisar trabalhar diretamente com threads ou com pool de threads. (Guia do .NET)

- Como era antes: uma das formas de gerar paralelismo é através da classe **Thread** que fica no namespace **System.Threading**. Ao utilizarmos esse recurso a sincronização de threads fica por nossa responsabilidade. A sincronização é necessária quando temos duas ou mais threads acessando recursos em comum. Nesses casos, o namespace System.Threading fornece as seguintes classes para sincronização de threads: **Mutex**, **Monitor**, **Interlocked**, **AutoResetEvent** e **ManualResetEvent**. Além destas classes podemos utilizar a **instrução lock** que implicitamente implementa _Monitor_ e consequentemente facilita a nossa vida.

```csharp
static void Main(string[] args)
{
    Console.WriteLine("# inicio thread principal");

    var threadParalela = new Thread(ThreadParalela_Run);
    threadParalela.Start();

    for (var i = 0; i < 100; i++)
    {
        Console.WriteLine($"# passo thread principal ... {i}");
        Thread.Sleep(500);
    }

    Console.WriteLine("# fim thread principal");
}

static void ThreadParalela_Run()
{
    Console.WriteLine("@ inicio thread paralela");
    for (var i = 0; i < 100; i++)
    {
        Console.WriteLine($"@ passo thread paralela ... {i}");
        Thread.Sleep(500);
    }
    Console.WriteLine("@ fim thread paralela");
}
```

- E agora: a partir do .NET Framework 4, a programação multi-threading foi simplificada com as classes **System.Threading.Tasks.Parallel** e **System.Threading.Tasks.Task**, com **PLINQ (LINQ Paralelo)**, com as novas classes de _coleta simultânea_ no namespace **System.Collections.Concurrent** e um novo _modelo de programação assíncrona baseada em tarefas (TAP)_ em vez de threads. 

> Task é um dos componentes centrais do modelo de programação assíncrona baseado em tarefas e é uma implementação do [Modelo Promise de assincronia](https://en.wikipedia.org/wiki/Futures_and_promises).

```csharp
static void Main(string[] args)
{
    Console.WriteLine("# inicio thread principal");

    var threadParalela = Task.Run(() => {
        Console.WriteLine("@ inicio thread paralela");
        for (var i = 0; i < 100; i++)
        {
            Console.WriteLine($"@ passo thread paralela ... {i}");
            Thread.Sleep(500);
        }
        Console.WriteLine("@ fim thread paralela");
    });

    for (var i = 0; i < 100; i++)
    {
        Console.WriteLine($"# passo thread principal ... {i}");
        Thread.Sleep(500);
    }

    Console.WriteLine("# fim thread principal");

    Console.ReadKey();
}
```

```csharp
static void Main(string[] args)
{
    Console.WriteLine("# main - ini #");

    //executa o processo principal e aguarda
    ProcessoPrincipal().Wait();

    Console.WriteLine("# main - fim #");
    
    Console.ReadKey();
}

static async Task ProcessoPrincipal()
{
    //processamento inicial
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Processo1");
        Thread.Sleep(500);
    }

    //cria uma task especial que executa em paralelo
    var processo2 = ProcessoAsync();

    //aqui não precisamos do retorno de processo2
    //então podemos executar
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Processo3");
        Thread.Sleep(500);
    }

    //aqui precisamos do resultado do processo2
    //não podemos continuar, temos que esperar
    var resultado = await processo2;

    //agora sim, depois de obter o resultado do processo2
    //podemos executar o processo4
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Processo4 => {resultado}");
        Thread.Sleep(500);
    }
}

//processamento "pesado"
static async Task<string> ProcessoAsync()
{
    for (int i=0; i<5; i++)
    {
        Console.WriteLine("ProcessoAsync - bloco1");
    }

    Console.WriteLine("ProcessoAsync - bloco2");

    //quando chegar aqui, ou seja, ao encontrar um await dentro de um método async Task
    //é que o processamento assíncrono ocorre
    await Task.Delay(10000);

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("ProcessoAsync - bloco3");
    }

    return "resultado_do_processamento_assincrono";
}
```

- Referências
    - [docs.microsoft.com/.../index](https://docs.microsoft.com/pt-br/dotnet/standard/parallel-programming/index)
    - [docs.microsoft.com/.../threading](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/threading/)
    - [albahari.com/threading](http://www.albahari.com/threading/)

**Novidades do C# 6.0**

- **Using Static Class Statements**: com a importação de classes estáticas não precisamos ficar fazendo referência à classes estáticas toda vez que vamos usar um método estático. Um exemplo clássico são os métodos da classe **System.Console**.

> Como era antes

```csharp
using System;

static void Main(string[] args)
{
    Console.WriteLine("Blá Blá Blá ...");
    Console.ReadKey();
}
```  

> Agora podemos 

```csharp
using System;
using static System.Console;

static void Main(string[] args)
{
    WriteLine("Blá Blá Blá ...");
    ReadKey();
}
```

- **Auto Property Initializer**

> Como era antes

```csharp
public class Editora 
{
    public string Nome { get; set; }
    public string Pais { get; set; }

    public Editora()
    {
        Nome = "";
        Pais = "Brasil";
    }
}
```

> Agora podemos

```csharp
public class Editora 
{
    public string Nome { get; set; } = "";
    public string Pais { get; set; } = "Brasil";
}
```

- **Expression Bodied Members:** não precisamos informar as chaves de abertura e fechamento para métodos simples.

```csharp
using System;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        WriteLine(GetDataFormatada());
        WriteLine(GetDataFormatadaExp());
        ReadKey();
    }

    //Sem Expression
    static string GetDataFormatada()
    {
        return "Hoje é " + DateTime.Now.ToLongDateString();
    }

    //Com Expression
    static string GetDataFormatadaExp() => "Hoje é " + DateTime.Now.ToLongDateString();
}
```

- **String Interpolation:** facilita a formatação de strings.

```csharp
using System;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        //formatando string com concatenação e conversões
        var forma1 = "Hoje é " + DateTime.Now.ToLongDateString();
        WriteLine(forma1);

        //formatando string com o auxílio de um método especial
        var forma2 = String.Format("Hoje é {0}", DateTime.Now.ToLongDateString());
        WriteLine(forma2);

        //formatando string com interpolação
        var forma3 = $"Hoje é {DateTime.Now.ToLongDateString()}";
        WriteLine(forma3);

        ReadKey();
    }
}
```

- **Null Propagation Operator:** facilita o tratamento de instâncias nulas. Uma alternativa mais verbosa seria usar o operador ternário.

```csharp
using System;
using static System.Console;

class Editora
{
    public int Codigo { get; set; }
    public string Nome { get; set; }

    public override string ToString()
    {
        return $"[ Codigo: {Codigo}, Nome: {Nome} ]";
    }
}

class Livro
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public Editora Editora { get; set; }

    public override string ToString()
    {
        //aqui pode dar erro se Editora não for uma instância
        //é aí que entra o operador de propagação de null
        return $"[ Codigo: {Codigo}, Nome: {Nome}, Editora: {Editora?.ToString() ?? "<null>"} ]";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Editora novatec = new Editora();
        novatec.Codigo = 1;
        novatec.Nome = "novatec";

        Livro useCabeca = new Livro();
        useCabeca.Codigo = 1;
        useCabeca.Nome = "Use a Cabeça";
        useCabeca.Editora = novatec;

        Livro phpModerno = new Livro();
        phpModerno.Codigo = 2;
        phpModerno.Nome = "PHP Moderno";

        WriteLine(useCabeca.ToString());
        WriteLine(phpModerno.ToString());

        ReadKey();
    }
}
```

- **Nameof Operator:** com o operador nameof fica fácil substituir nomes de recursos concatenados em strings de log. Sem este recurso somos obrigados a concatenar o nome literal.

```csharp
using System;
using static System.Console;

class Calculadora
{
    public int Somar(int a, int b) => a + b;
}

class Program
{
    static Calculadora recurso1;

    static void Main(string[] args)
    {
        Metodo1();
        Metodo2();
        ReadKey();
    }

    static void Metodo1()
    {
        try
        {
            recurso1.Somar(2, 2);
        }
        catch (Exception ex)
        {
            //WriteLine($"Erro ao acessar recurso1: {ex.Message}");
            WriteLine($"Erro ao acessar {nameof(recurso1)}: {ex.Message}");
        }
    }

    static void Metodo2()
    {
        try
        {
            recurso1.Somar(3, 3);
        }
        catch (Exception ex)
        {
            //WriteLine($"Erro ao acessar recurso1: {ex.Message}");
            WriteLine($"Erro ao acessar {nameof(recurso1)}: {ex.Message}");
        }
    }
}
```

- **Exception Filtering:** podemos incluir uma estrutura condicional em um **catch** para tomadas de decisões antes de entrar no bloco catch.

```csharp
try
{
    int n = 0;
    int x = 10 / n;
}
catch (Exception ex) when (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
{
    //envia e-mail para o gerente
}
catch (Exception ex)
{
    //envia e-mail para o suporte
} 
```