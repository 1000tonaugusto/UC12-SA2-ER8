using er8.Interfaces;

namespace er8.Classes
{
    public abstract class Pessoa : IPessoa
    {

        // Atributos //
        public string ?nome {get; set;}

        public Endereco ?endereco {get; set;}

        public float rendimento {get; set;}

        // Metodos //
        public abstract float PagarImposto(float rendimento);

        public void VerificarPastaArquivo(string caminho) {
            string nomePasta = caminho.Split("/")[0];

            if (!Directory.Exists(nomePasta))
            {
                Directory.CreateDirectory(nomePasta);
            }

            if (!File.Exists(caminho))
            {
                using (File.Create(caminho))
                {
                    
                }
            }
        }
    }
}