using er8.Classes;

Console.WriteLine(@$"
================================================
|     Bem vindo ao sistema de cadastro de      |
|     Pessoas Fisicas e Pessoas Juridicas      |
================================================
");

BarraCarregamento("Carregando ",500);

string? opcao;
List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPJ=new List<PessoaJuridica>();

do
{

    Console.Clear();
    Console.WriteLine(@$"
================================================
|        Escolha uma das opções abaixo         |
|                                              |
|        1 - Pessoa Fisica                     |
|        2 - Pessoa Juridica                   |
|        0 - Sair                              |
================================================
    ");

opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            PessoaFisica metodoPf = new PessoaFisica();

            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
================================================
|        Escolha uma das opções abaixo         |
|                                              |
|        1 - Cadastrar Pessoa Fisica           |
|        2 - Listar Pessoas  Fisicas           |
|        0 - Retornar ao menu anterior         |
================================================
        ");
                opcaoPf = Console.ReadLine();
                
                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novoPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa: ");
                        novoPf.nome = Console.ReadLine();
                        string dataValida;
                        do
                        {
                            Console.WriteLine($"Digita a data de nascimento: ");
                            string dataNascimento = Console.ReadLine();
                            dataValida = metodoPf.validarDataNascimento(dataNascimento);
                            if (dataValida != "Data Invalida!") {
                                novoPf.dataNascimento = dataNascimento;
                            } else {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data invalida, Digite novamente: ");
                                Console.ResetColor();
                            }
                        } while (dataValida == "Data Invalida!");

                        Console.WriteLine($"Digite o numero do CPF: ");
                        novoPf.cpf= Console.ReadLine();

                        Console.WriteLine($"Informe o valor do rendimento (somente numero): ");
                        novoPf.rendimento= float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o endereço: ");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero do endereço: ");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o completemento: ");            
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial: (S/N) ");
                        string endComercial = Console.ReadLine().ToUpper();

                        if (endComercial == "S") {
                            novoEnd.endComercial = true;
                        } else {
                            novoEnd.endComercial = false;
                        }

                        novoPf.endereco = novoEnd;

                        Console.WriteLine($"Nome: {novoPf.nome}");
                        Console.WriteLine($"Cpf: {novoPf.cpf}");
                        Console.WriteLine($"Data de Nascimento: {novoPf.dataNascimento}");
                        Console.WriteLine($"Rendimento: {novoPf.rendimento}");
                        Console.WriteLine($"Endereco: {novoPf.endereco.logradouro}, {novoPf.endereco.numero}");

                        string retorno1 = metodoPf.validarDataNascimento(new String(novoPf.dataNascimento));
                        Console.WriteLine($"Imposto a pagar: {metodoPf.PagarImposto(novoPf.rendimento)}");
                        Console.WriteLine(retorno1);

                        Console.WriteLine(" ");

                        string retorno2 = novoPf.validarDataNascimento(new string("2021,01,01"));

                        Console.WriteLine(retorno2);

                        string retorno3 = novoPf.validarDataNascimento(new string("2021//01/01"));

                        Console.WriteLine(retorno3);

                        //listaPf.Add(novoPf);

                        using (StreamWriter escritor = new StreamWriter($"{novoPf.nome}.txt"))
                        {
                            escritor.WriteLine(novoPf.nome);
                        }

                        Console.WriteLine($"Cadastro Ok! Aperte 'Enter' para continuar");
                        Console.ReadLine();

                        break;

                    case "2":
                        Console.Clear();

                        using (StreamReader leitor = new StreamReader("milton.txt"))
                        {
                            string linha;
                            while ((linha = leitor.ReadLine()) != null)
                            {
                                Console.WriteLine($"{linha}");
                                Thread.Sleep(3000);
                            }
                        }

                        Console.WriteLine($"Aperte 'Enter' para continuar");
                        Console.ReadLine();

                        break;
                        
                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção invalida, favor digitar outra opção");
                        Thread.Sleep(2000);
                        break;
                }
                
            } while (opcaoPf != "0");

            
            break;
        case "2":


            PessoaJuridica metodoPJ = new PessoaJuridica();

            string? opcaoPJ;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
================================================
|        Escolha uma das opções abaixo         |
|                                              |
|        1 - Cadastrar Pessoa Juridica         |
|        2 - Listar Pessoas  Juridicas         |
|        0 - Retornar ao menu anterior         |
================================================
        ");
                opcaoPJ = Console.ReadLine();
                
                switch (opcaoPJ)
                {
                    case "1":
                        PessoaJuridica novoPJ = new PessoaJuridica();
                        Endereco novoEndPJ = new Endereco();

                        Console.WriteLine($"Digite o nome fantasia da empresa: ");
                        novoPJ.nome = Console.ReadLine();
                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digita o CPNJ: ");
                            string cnpjParaValidar = Console.ReadLine();
                            cnpjValido = metodoPJ.ValidarCnpj2(cnpjParaValidar);
                            if (cnpjValido) {
                                novoPJ.cnpj = cnpjParaValidar;
                            } else {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"CNPJ invalido, Digite novamente: ");
                                Console.ResetColor();
                            }
                        } while (cnpjValido==false);

                        Console.WriteLine($"Digita a Razao Social da empresa: ");
                        novoPJ.razaoSocial= Console.ReadLine();

                        Console.WriteLine($"Informe o valor do rendimento (somente numero): ");
                        novoPJ.rendimento= float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o endereço: ");
                        novoEndPJ.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero do endereço: ");
                        novoEndPJ.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o completemento: ");            
                        novoEndPJ.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial: (S/N) ");
                        string endComercial = Console.ReadLine().ToUpper();

                        if (endComercial == "S") {
                            novoEndPJ.endComercial = true;
                        } else {
                            novoEndPJ.endComercial = false;
                        }

                        novoPJ.endereco = novoEndPJ;

                        //listaPJ.Add(novoPJ);

                        metodoPJ.Inserir(novoPJ);

                        List<PessoaJuridica> listaPj = metodoPJ.Ler();

                        foreach (PessoaJuridica cadaItem in listaPj)
                        {

                            Console.Clear();
                            Console.WriteLine(@$"
Nome: {novoPJ.nome}
Razao Social: {novoPJ.razaoSocial}
CNPJ: {novoPJ.cnpj}");
                            
                        }

                        Console.WriteLine($"Cadastro Ok! Aperte 'Enter' para continuar");
                        Console.ReadLine();

                        break;

                    case "2":
                        Console.Clear();

                        using (StreamReader leitor = new StreamReader("DataBase/PessoaJuridica.csv"))
                        {
                            string linha;
                            while ((linha = leitor.ReadLine()) != null)
                            {
                                Console.WriteLine($"{linha}");
                                Thread.Sleep(3000);
                            }
                        }

                        Console.WriteLine($"Aperte 'Enter' para continuar");
                        Console.ReadLine();

                        break;
                        
                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção invalida, favor digitar outra opção");
                        Thread.Sleep(2000);
                        break;
                }
                
            } while (opcaoPJ != "0");

            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Obrigado por utilizar nosso sistema");
            BarraCarregamento("Finalizando", 200);
            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção invalida, favor digitar outra opção");
            Thread.Sleep(2000);
            break;
    }

    
} while (opcao != "0");

static void BarraCarregamento(string texto, int tempo) {
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.Write($"{texto}");

    for (var contador = 0; contador < 5; contador++) {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }

    Console.ResetColor();

}