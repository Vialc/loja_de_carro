using System;
using System.Text;
using System.Data.SqlClient;

namespace SqlServerSample
{
    class Program
    {
        public static int user;
        static void Main(){

            escolheuser:
            Console.Clear();
            Menu.UserSlc();
            user = int.Parse(Console.ReadLine());

            switch(user){

                case 0: funcionario:
                Console.Clear();
                Menu.FuncOpt1();
                var escolhe = int.Parse(Console.ReadLine());

                switch(escolhe){
                    case 0: Console.WriteLine("Abrindo Opções de Consulta... ");
                            DbExe.DbConsulta();
                    break;

                    case 1: 
                    Menu.FuncEdit();
                    var edit = int.Parse(Console.ReadLine());
                    switch(edit){
                        case 1: MenuExe.CarAdd();
                                var confirma = int.Parse(Console.ReadLine());
                                if (confirma == 0){
                                    DbExe.CmdAddCar();
                                }else {
                                    Console.WriteLine("Operação Cancelada");
                                }
                        break;
                        case 2: 
                                deletando:
                                Console.Clear();
                                DbExe.CmdDelCar();
                                var resp = char.Parse(Console.ReadLine());
                                switch (resp) {
                                    
                                    case 'S': 
                                    case 's': DbExe.Deletar();
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
                        DbExe.CmdAttCar();
                        resp = char.Parse(Console.ReadLine());
                            switch (resp) {
                                    case 'S': 
                                    case 's': Console.WriteLine("Escreva a nova Versão: ");
                                              MenuExe.versao= new string(Console.ReadLine());
                                              
                                              Menu.tabelaitens();

                                MenuExe.CarAtt();
                                resp = char.Parse(Console.ReadLine());
                                switch (resp) {
                                    
                                    case 'S': 
                                    case 's': 
                                              DbExe.AttExe();
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
                Conecta.AbreConexaoBanco();
                Console.WriteLine("Conexão Aberta");
                Conecta.FechaConexaoBanco();
                Console.WriteLine("Conexão Fechada");

                break;

                default: Console.WriteLine("Opção inválida");
                System.Threading.Thread.Sleep(2300);
                goto escolheuser;
            }        
        }
    }
}
