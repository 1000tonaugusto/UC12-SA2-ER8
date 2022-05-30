using System.Text.RegularExpressions;
using er8.Interfaces;

namespace er8.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        // Atributos
        public string ?cnpj {get; set;}

        public string ?razaoSocial {get; set;}

        public string? caminho {get; private set;} = "DataBase/PessoaJuridica.csv";

        // Metodos
        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000) {
                return (rendimento / 100) * 3;
            } else if (rendimento<=6000) {
                return (rendimento / 100) * 5;
            } else if (rendimento <= 10000) {
                return (rendimento / 100) * 7;
            } else {
                return (rendimento / 100) * 9;
            }
        }

        public bool validarCnpj(string cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}/.\d{4}-\d{2})|(\d{14})$)"))
            {
                if (cnpj.Length == 18)
                {
                    if (cnpj.Substring(11,4) == "0001")
                    {
                        return true;
                    }
                }
                else if (cnpj.Substring(8,4) == "0001")
                {
                    if (cnpj.Substring(8,4) == "0001")
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        public bool ValidarCnpj2(string cnpj)
        {
           string cnpjTratado =  cnpj.Replace(".","").Replace("/","").Replace("-","");

           if (cnpjTratado.Substring(8,4) == "0001")
           {
               return true;
           }
           return false;
        }


        public void Inserir(PessoaJuridica PJ) {
            string[] PJString = {$"{PJ.nome},{PJ.cnpj},{PJ.razaoSocial}"};

            VerificarPastaArquivo(caminho);

            File.AppendAllLines(caminho,PJString);
        }

        public List<PessoaJuridica> Ler() {

            List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPJ = new PessoaJuridica();

                cadaPJ.nome = atributos[0];
                cadaPJ.cnpj = atributos[1];
                cadaPJ.razaoSocial = atributos[2];

                listaPJ.Add(cadaPJ);
            }

            return listaPJ;
        }
    }
}