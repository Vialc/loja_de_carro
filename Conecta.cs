using System.Data.SqlClient;


public class Conecta {

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
}
