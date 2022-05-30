using er8.Interfaces;

namespace er8.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {

        // Atributos
        public string ?cpf {get; set;}

        public string ?dataNascimento {get; set;}

        // Metodos
        public string validarDataNascimento(string dataNascimento)
        {
            DateTime dataConvertida;
            if (DateTime.TryParse(dataNascimento, out dataConvertida))
            {
                DateTime dataAtual = DateTime.Today;


                // Soma a data de nascimento 6574 dias (corresponte a 18 anos)
                if (dataAtual >= dataConvertida.AddDays(6574))
                {
                    //Console.Write("De maior");
                    return "De Maior";
                } else {
                    //Console.Write("De menor");
                    return "De Menor";
                }

            } else {
                return "Data Invalida!";
            }

        }
        

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500) {
                return 0;
            } else if (rendimento<=3500) {
                return (rendimento / 100) * 2;
            } else if (rendimento <= 6000) {
                return (rendimento / 100) * 3.5f;
            } else {
                return (rendimento / 100) * 5;
            }
        }
    }
}