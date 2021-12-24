using System;
using System.Text;
using System.Data.SqlClient;

namespace SqlServerSample
{
    class Program
    {
        public static int user;
        
        public static string marca,modelo,versao,ano,preco,sql,ar,vidro,direcao,teto,porta;


        static void Main(){

            escolheuser:
            Console.Clear();

            Console.WriteLine("Selecione seu nível de Usuário: ");
            Console.WriteLine("|0| para Funcionário ou |1| para Cliente...");

            user = int.Parse(Console.ReadLine());

            switch(user){

                case 0: funcionario:
                Console.Clear();
                Console.WriteLine("Funcionário");
                Console.WriteLine("O que deseja fazer? ");
                Console.WriteLine("|0| para Consultar ou |1| para Editar Registros...");
                var escolhe = int.Parse(Console.ReadLine());

                switch(escolhe){
                    case 0: Console.WriteLine("Abrindo Opções de Consulta... ");
                            string consulta = "SELECT * FROM tb_carros;";
                            AbreConexaoBanco();
                            SqlCommand executa = new SqlCommand(consulta, conexao);
                            SqlDataReader linha  = executa.ExecuteReader();
                           while (linha.Read()){
                               
                               Console.WriteLine("ID: "+ linha[0] + "| Marca: "+ linha[1] + " Modelo: "+ linha[2] + " Versão: "+ linha[3] + " Ano: "+ linha[4] + " Preço: "+ linha[5]);
                        
                           } 
                            
                            FechaConexaoBanco();
                    break;

                    case 1: Console.WriteLine("Na edição de registros você pode realizar as seguintes ações: ");
                    Console.WriteLine("1 - Adicionar um Carro. ");
                    Console.WriteLine("2 - Remover um Carro. ");
                    Console.WriteLine("3 - Alterar a Versão de Um carro ");
                    Console.WriteLine("O que deseja fazer? -Digite 1, 2 ou 3-");
                    var edit = int.Parse(Console.ReadLine());
                    switch(edit){
                        case 1: Console.WriteLine("Para Adicionar um carro escreva a Marca: ");
                                marca= new string(Console.ReadLine());
                                Console.WriteLine("Escreva o Modelo: ");
                                modelo= new string(Console.ReadLine());
                                Console.WriteLine("Escreva a Versão: ");
                                versao= new string(Console.ReadLine());
                                Console.WriteLine("Escreva o Ano: ");
                                ano= new string(Console.ReadLine());
                                Console.WriteLine("Escreva o Preço: ");
                                preco= new string(Console.ReadLine());

                                tabelaitens();
                            
                                confirmar:
                                Console.Clear();
                                Console.WriteLine("Confirma a adição do carro Marca: {0}, Modelo: {1}, Versão: {2}, Ano: {3} e Preço: {4}?",marca,modelo,versao,ano,preco);
                                Console.WriteLine("Com os seguintes Itens -> Ar-Condicionado: {0}, Vidro Elétrico: {1}, Direção Hidráulica: {2}, Teto Solar: {3} e 4 Portas: {4}?",ar,vidro,direcao,teto,porta);
                                Console.WriteLine("|0| Para Confirmar ou |1| para Cancelar... ");
                                var confirma = int.Parse(Console.ReadLine());

                                switch (confirma){
                                    case 0:
                                    string dados = string.Format("INSERT INTO tb_carros(marca, modelo, versao,  ano, preco) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",marca,modelo,versao,ano,preco);
                                    string pega_id = string.Format("SELECT MAX(id) FROM tb_carros;");
                                AbreConexaoBanco();
                                SqlCommand insert = new SqlCommand(dados, conexao);
                                insert.ExecuteNonQuery();
                                SqlCommand sql = new SqlCommand(pega_id, conexao);
                                SqlDataReader puxaID = sql.ExecuteReader();
                                puxaID.Read();
                                    var id_carro = puxaID[0];
                                FechaConexaoBanco();

                                    string itens = string.Format("INSERT INTO tbitens(id, ar, vidro,  direcao, tetosolar, quatroportas) VALUES ('{5}', '{0}', '{1}', '{2}', '{3}', '{4}')",ar,vidro,direcao,teto,porta,id_carro);
                                    AbreConexaoBanco();
                                    SqlCommand insert2 = new SqlCommand(itens, conexao);
                                    insert2.ExecuteNonQuery();
                                    FechaConexaoBanco();
                                    break;
                                    case 1: Console.WriteLine("Operação Cancelada");
                                    break;
                                    default: Console.WriteLine("Opção Inválida, tente novamente");
                                    goto confirmar;
                                }
                        break;
                        case 2: 
                                deletando:
                                Console.Clear();
                                Console.WriteLine("Para Remover um Carro do Estoque, insira o seu ID");
                                var cod = int.Parse(Console.ReadLine());                                
                                string exclui = string.Format(@"delete from tb_carros where id ="+"{0}",cod);
                              
                                Console.WriteLine("Confirma a Exclusão do carro: S/N");
                                string confere = string.Format("SELECT * FROM tb_carros WHERE id = "+"{0};",cod);
                                AbreConexaoBanco();
                                SqlCommand lista = new SqlCommand(confere, conexao);
                                SqlDataReader puxa = lista.ExecuteReader();
                                while (puxa.Read()){
                                    Console.WriteLine("ID: "+ puxa[0] + "| Marca: "+ puxa[1] + " Modelo: "+ puxa[2] + " Versão: "+ puxa[3] + " Ano: "+ puxa[4] + " Preço: "+ puxa[5]);
                                }
                                FechaConexaoBanco();
                                var resp = char.Parse(Console.ReadLine());
                                switch (resp) {
                                    
                                    case 'S': 
                                    case 's': AbreConexaoBanco();
                                              SqlCommand delete = new SqlCommand();
                                              delete.CommandText = exclui;
                                              delete.Connection = conexao;
                                              delete.ExecuteNonQuery();
                                              FechaConexaoBanco();
                                         break;
                                    
                                    case 'n':
                                    case 'N':
                                          goto deletando;

                                    default: Console.WriteLine("Opção Inválida");
                                    break;
                                }
                        break;
                        case 3: 
                        atualizacarroestoque:
                        Console.Clear();
                        Console.WriteLine("Para Atualizar um Carro do Estoque, insira o seu ID");
                        var carro = int.Parse(Console.ReadLine());
                        Console.WriteLine("Confirma a Atualização do carro: S/N");
                                string confere2 = string.Format("SELECT * FROM tb_carros WHERE id = "+"{0};",carro);
                                AbreConexaoBanco();
                                SqlCommand lista1 = new SqlCommand(confere2, conexao);
                                SqlDataReader puxa1 = lista1.ExecuteReader();
                                while (puxa1.Read()){
                                    Console.WriteLine("ID: "+ puxa1[0] + "| Marca: "+ puxa1[1] + " Modelo: "+ puxa1[2] + " Versão: "+ puxa1[3] + " Ano: "+ puxa1[4] + " Preço: "+ puxa1[5]);
                                }
                                FechaConexaoBanco();
                                resp = char.Parse(Console.ReadLine());

                                switch (resp) {
                                    
                                    case 'S': 
                                    case 's': Console.WriteLine("Escreva a nova Versão: ");
                                              versao= new string(Console.ReadLine());
                                              
                                              tabelaitens();

                                Console.WriteLine("Confirma a adição do carro Marca: {0}, Modelo: {1}, Versão: {2}, Ano: {3} e Preço: {4}?",marca,modelo,versao,ano,preco);
                                Console.WriteLine("Com os seguintes Itens -> Ar-Condicionado: {0}, Vidro Elétrico: {1}, Direção Hidráulica: {2}, Teto Solar: {3} e 4 Portas: {4}?",ar,vidro,direcao,teto,porta);
                                Console.WriteLine("|S| Para Confirmar ou |N| para Cancelar... ");
                                resp = char.Parse(Console.ReadLine());
                                switch (resp) {
                                    
                                    case 'S': 
                                    case 's': 
                                    string atualizacarro = string.Format("UPDATE tb_carros SET versao ="+"'{0}'"+"WHERE id = "+"{1};",versao,carro);
                                    string atualizaitem = string.Format("UPDATE tbitens SET ar = "+"'{0}'"+", vidro = "+"'{1}'"+", direcao = "+"'{2}'"+", tetosolar = "+"'{3}'"+", quatroportas = "+"'{4}' "+"WHERE id = "+"{5};",ar,vidro,direcao,teto,porta,carro);
                                    AbreConexaoBanco();
                                    SqlCommand sql = new SqlCommand();
                                    sql.CommandText = atualizacarro;
                                    sql.Connection = conexao;
                                    sql.ExecuteNonQuery();
                                    FechaConexaoBanco();
                                        AbreConexaoBanco();
                                       // SqlCommand sql = new SqlCommand();
                                        sql.CommandText = atualizaitem;
                                        sql.Connection = conexao;
                                        sql.ExecuteNonQuery();
                                        FechaConexaoBanco();
                                         break;
                                    
                                    case 'n':
                                    case 'N':
                                          goto atualizacarroestoque;

                                    default: Console.WriteLine("Opção Inválida");
                                    break;
                                }
                                break;

                                case 'n':
                                case 'N': Console.WriteLine("Programa encerrando");
                                break;

                                default: Console.WriteLine("Programa encerrando");
                                break;
                                }                                    
                        break;

                        default: Console.WriteLine("Opção Inválida");
                        break;
                    }

                    break;

                    default: Console.WriteLine("Opção inválida");
                    System.Threading.Thread.Sleep(2300);
                    goto funcionario;
                }
                break;
                case 1: Console.WriteLine("Cliente");
                AbreConexaoBanco();
                Console.WriteLine("Conexão Aberta");
                FechaConexaoBanco();
                Console.WriteLine("Conexão Fechada");

                break;

                default: Console.WriteLine("Opção inválida");
                System.Threading.Thread.Sleep(2300);
                goto escolheuser;
            }
                 
        }
        public static SqlConnection conexao;

        public static SqlConnection AbreConexaoBanco()
        {
            conexao = new SqlConnection("Server=DESKTOP-O1J22ES\\SQLEXPRESS;Database=Loja_de_Carros;Trusted_Connection=True;");
            conexao.Open();
            return conexao;
        }

        public static SqlConnection FechaConexaoBanco()
        {
            conexao = new SqlConnection("Server=DESKTOP-O1J22ES\\SQLEXPRESS;Database=Loja_de_Carros;Trusted_Connection=True;");
            conexao.Close();
            return conexao;
        }

        public static string preencheitens;
        public static string tabelaitens(){

            Console.WriteLine("Possui Ar-condicionado? |Digite 0-Não ou 1-Sim|");
            ar =  new string(Console.ReadLine());
                             
            Console.WriteLine("Possui Vidro Elétrico? |Digite 0-Não ou 1-Sim|");
            vidro =  new string(Console.ReadLine());
                                
            Console.WriteLine("Possui Direção Hidráulica? |Digite 0-Não ou 1-Sim|");
            direcao =  new string(Console.ReadLine());
                                
            Console.WriteLine("Possui Teto Solar? |Digite 0-Não ou 1-Sim|");
            teto =  new string(Console.ReadLine());
                                
            Console.WriteLine("Possui 4 Portas? |Digite 0-Não ou 1-Sim|");
            porta =  new string(Console.ReadLine());

            return preencheitens;
        }
    }
    
}
