using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Codificacao2
{
    class TesteTodasClasses
    {
        static void Main(String[] args)
        {
            List<Area> areas = new List<Area>();
            List<Habilidade> habilidades = new List<Habilidade>();
            List<Formacao> formacoes = new List<Formacao>();
            List<Usuario> usuarios = new List<Usuario>();
            List<Perfil> perfis = new List<Perfil>();

            // variaveis para manipular arquivos usado por todas as classes.
            string linha;
            char[] delimitador = new char[] { ';' };

            //Criando lista para areas;
            using (StreamReader file = new StreamReader(@"C:\\Users\\Natanael\\Desktop\\Natanael\\Faculdade\\Ciência da Computação\\3° semestre\\PI III\\Codificacao\\Base de dados\\area.txt"))
            {
                while((linha = file.ReadLine()) != null)
                {
                    string[] campo = linha.Split(delimitador, StringSplitOptions.RemoveEmptyEntries);
                    int codigo = int.Parse(campo[0]);
                    string descricao = campo[1];
                    areas.Add(new Area(codigo, descricao));
                    Area.conta_codigo_area = codigo; // para prevenir caso algum item no meio da lista seja eliminado, supondo que alguém possa eliminar algum item da lista
                }
            }// fim da leitura e criacao para areas;
            //Criando lista para habilidades;
            using(StreamReader file = new StreamReader(@"C:\\Users\\Natanael\\Desktop\\Natanael\\Faculdade\\Ciência da Computação\\3° semestre\\PI III\\Codificacao\\Base de dados\\habilidade.txt"))
            {
                while((linha = file.ReadLine()) != null)
                {
                    string[] campo = linha.Split(delimitador, StringSplitOptions.RemoveEmptyEntries);
                    int codigo = int.Parse(campo[0]);
                    int codigo_de_area = int.Parse(campo[1]);
                    string descricao = campo[2];
                    habilidades.Add(new Habilidade(descricao, codigo_de_area, codigo));
                    Habilidade.conta_codigo_habilidade = codigo; // para prevenir caso algum item no meio da lista seja eliminado, supondo que alguém possa eliminar algum item da lista
                }
            }// fim da leitura e cricao para habilidades;
           //Criando lista para formacoes;
            using (StreamReader file = new StreamReader(@"C:\\Users\\Natanael\\Desktop\\Natanael\\Faculdade\\Ciência da Computação\\3° semestre\\PI III\\Codificacao\\Base de dados\\formacao.txt"))
            {
                while((linha = file.ReadLine()) != null)
                {
                    string[] campo = linha.Split(delimitador, StringSplitOptions.RemoveEmptyEntries);
                    int codigo = int.Parse(campo[0]);
                    int codigo_de_area = int.Parse(campo[1]);
                    string descricao = campo[2];
                    formacoes.Add(new Formacao(descricao, codigo_de_area, codigo));
                    Formacao.conta_codigo_formacao = codigo; // para prevenir caso algum item no meio da lista seja eliminado, supondo que alguém possa eliminar algum item da lista
                }
            }// fim da leitura e criacao para habilidades;
            //Criando lista para usuarios;
            using (StreamReader file = new StreamReader(@"C:\\Users\\Natanael\\Desktop\\Natanael\\Faculdade\\Ciência da Computação\\3° semestre\\PI III\\Codificacao\\Base de dados\\usuario.txt"))
            {
                while((linha = file.ReadLine()) != null)
                {
                    string[] campo = linha.Split(delimitador, StringSplitOptions.RemoveEmptyEntries);
                    int codigo = int.Parse(campo[0]);
                    string nome = campo[1];
                    int tipo = int.Parse(campo[2]);
                    string docto = campo[3];
                    usuarios.Add(new Usuario(nome, docto, tipo, codigo));
                    Usuario.conta_codigo_usuario = codigo; // para prevenir caso algum item no meio da lista seja eliminado, supondo que alguém possa eliminar algum item da lista
                }
            }// fim da leitura e cricao para usuarios;
             //Criando lista para Perfis;
            using (StreamReader file = new StreamReader(@"C:\\Users\\Natanael\\Desktop\\Natanael\\Faculdade\\Ciência da Computação\\3° semestre\\PI III\\Codificacao\\Base de dados\\perfil.txt"))
            {
                while ((linha = file.ReadLine()) != null)
                {
                    string[] campo = linha.Split(delimitador);
                    int codigo = int.Parse(campo[0]);
                    int codigo_de_usuario = int.Parse(campo[1]);
                    string nome = campo[2];
                    int tipo = int.Parse(campo[3]);
                    string docto = campo[4];
                    string endereco = campo[5];
                    string telefone = campo[6];
                    int codigo_de_area = int.Parse(campo[7]);
                    double salario;
                    if (campo[15] == "")
                        salario = 0.0;
                    else
                        salario = double.Parse(campo[15]);
                    Perfil perf1 = new Perfil(codigo, codigo_de_usuario, nome, tipo, docto, endereco, telefone, codigo_de_area, salario);
                    int i = 8;
                    while (i <= 14)
                    {
                        int ger; // generica int
                        if(campo[i] == "")
                            ger = 0;
                        else
                            ger = int.Parse(campo[i]);

                        if ((i == 8) || (i == 9))
                            perf1.formacoes_perfil.Add(formacoes.Find(x => x.GetCodigo() == ger));
                        else
                            perf1.habilidades_perfil.Add(habilidades.Find(x => x.GetCodigo() == ger));
                        ++i;
                    }
                    perfis.Add(perf1);
                    Perfil.conta_codigo_perfil  = codigo; // para prevenir caso algum item no meio da lista seja eliminado, supondo que alguém possa eliminar algum item da lista
                }
            }
            Console.WriteLine("Comprovacao da leitura e cricao das listas");
            Console.WriteLine("Areas: " + areas.Count);
            Console.WriteLine("Habilidades: " + habilidades.Count);
            Console.WriteLine("Formacoes: " + formacoes.Count);
            Console.WriteLine("Usuarios: " + usuarios.Count);
            Console.WriteLine("Perfis: " + perfis.Count);
            // Até aqui tudo certo - 14/05/2017 - 17:15
        }
    }
}
