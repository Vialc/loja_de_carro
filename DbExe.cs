using System.Data.SqlClient;
public class DbExe{
    static public SqlCommand cmdsql;
    static public SqlDataReader cmdread;
    static public string carro,exclui,confere,consulta;

    public static void DbConsulta(){
    consulta = "SELECT * FROM tb_carros;";
    Conecta.AbreConexaoBanco();
    cmdsql = new SqlCommand(consulta, Conecta.conexao);
    SqlDataReader linhas  = cmdsql.ExecuteReader();
    while (linhas.Read()){
                               
        Console.WriteLine("ID: "+ linhas[0] + "| Marca: "+ linhas[1] + " Modelo: "+ linhas[2] + " Versão: "+ linhas[3] + " Ano: "+ linhas[4] + " Preço: "+ linhas[5]);
                        
        } 
                            
    Conecta.FechaConexaoBanco();
}

public static void CmdAddCar(){
    string dados = string.Format("INSERT INTO tb_carros(marca, modelo, versao,  ano, preco) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",MenuExe.marca,MenuExe.modelo,MenuExe.versao,MenuExe.ano,MenuExe.preco);
    string pega_id = string.Format("SELECT MAX(id) FROM tb_carros;");
    Conecta.AbreConexaoBanco();
    cmdsql = new SqlCommand(dados, Conecta.conexao);
    cmdsql.ExecuteNonQuery();
    cmdsql = new SqlCommand(pega_id, Conecta.conexao);
    SqlDataReader puxaID = cmdsql.ExecuteReader();
    puxaID.Read();
    var id_carro = puxaID[0];
    Conecta.FechaConexaoBanco();

    string itens = string.Format("INSERT INTO tbitens(id, ar, vidro,  direcao, tetosolar, quatroportas) VALUES ('{5}', '{0}', '{1}', '{2}', '{3}', '{4}')",MenuExe.ar,MenuExe.vidro,MenuExe.direcao,MenuExe.teto,MenuExe.porta,id_carro);
    Conecta.AbreConexaoBanco();
    cmdsql = new SqlCommand(itens, Conecta.conexao);
    cmdsql.ExecuteNonQuery();
    Conecta.FechaConexaoBanco();
}
public static void CmdDelCar(){

Console.WriteLine("Para Remover um Carro do Estoque, insira o seu ID");
var cod = int.Parse(Console.ReadLine());                                
exclui = string.Format(@"delete from tb_carros where id ="+"{0}",cod);
Console.WriteLine("Confirma a Exclusão do carro: S/N");
confere = string.Format("SELECT * FROM tb_carros WHERE id = "+"{0};",cod);
Conecta.AbreConexaoBanco();
cmdsql = new SqlCommand(confere, Conecta.conexao);
cmdread = cmdsql.ExecuteReader();
while (cmdread.Read()){
    Console.WriteLine("ID: "+ cmdread[0] + "| Marca: "+ cmdread[1] + " Modelo: "+ cmdread[2] + " Versão: "+ cmdread[3] + " Ano: "+ cmdread[4] + " Preço: "+ cmdread[5]);
     }
Conecta.FechaConexaoBanco();

}

public static void Deletar(){
    Conecta.AbreConexaoBanco();
    cmdsql.CommandText =  exclui;
    cmdsql.Connection = Conecta.conexao;
    cmdsql.ExecuteNonQuery();
    Conecta.FechaConexaoBanco();
}

public static void CmdAttCar(){
    Console.WriteLine("Para Atualizar um Carro do Estoque, insira o seu ID");
    carro = new string(Console.ReadLine());
    Console.WriteLine("Confirma a Atualização do carro: S/N");
    confere = string.Format("SELECT * FROM tb_carros WHERE id = "+"{0};",carro);
    Conecta.AbreConexaoBanco();
    cmdsql = new SqlCommand(confere, Conecta.conexao);
    cmdread = cmdsql.ExecuteReader();
    while (cmdread.Read()){
    Console.WriteLine("ID: "+ cmdread[0] + "| Marca: "+ cmdread[1] + " Modelo: "+ cmdread[2] + " Versão: "+ cmdread[3] + " Ano: "+ cmdread[4] + " Preço: "+ cmdread[5]);
    }
    Conecta.FechaConexaoBanco();
    
   // AttExe(carro);
}

public static void AttExe(){

string atualizacarro = string.Format("UPDATE tb_carros SET versao ="+"'{0}'"+"WHERE id = "+"{1};",MenuExe.versao,carro);
string atualizaitem = string.Format("UPDATE tbitens SET ar = "+"'{0}'"+", vidro = "+"'{1}'"+", direcao = "+"'{2}'"+", tetosolar = "+"'{3}'"+", quatroportas = "+"'{4}' "+"WHERE id = "+"{5};",MenuExe.ar,MenuExe.vidro,MenuExe.direcao,MenuExe.teto,MenuExe.porta,carro);
Conecta.AbreConexaoBanco();
Console.WriteLine(atualizacarro);
Console.WriteLine(carro);
cmdsql.CommandText = atualizacarro;
cmdsql.Connection = Conecta.conexao;
cmdsql.ExecuteNonQuery();
Conecta.FechaConexaoBanco();
Conecta.AbreConexaoBanco();
cmdsql.CommandText = atualizaitem;
cmdsql.Connection = Conecta.conexao;
cmdsql.ExecuteNonQuery();
 Conecta.FechaConexaoBanco();
}
}