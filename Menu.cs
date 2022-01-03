public class Menu {
    public static void UserSlc(){

        Console.WriteLine("Selecione seu nível de Usuário: ");
        Console.WriteLine("|0| para Funcionário ou |1| para Cliente...");
        return;
    }

    public static void FuncOpt1(){

        Console.WriteLine("Funcionário");
        Console.WriteLine("O que deseja fazer? ");
        Console.WriteLine("|0| para Consultar ou |1| para Editar Registros...");
        return;
    }

    public static void FuncEdit(){
        Console.WriteLine("Na edição de registros você pode realizar as seguintes ações: ");
        Console.WriteLine("1 - Adicionar um Carro. ");
        Console.WriteLine("2 - Remover um Carro. ");
        Console.WriteLine("3 - Alterar a Versão de Um carro ");
        Console.WriteLine("O que deseja fazer? -Digite 1, 2 ou 3-");
    }

    public static void tabelaitens(){

            Console.WriteLine("Possui Ar-condicionado? |Digite 0-Não ou 1-Sim|");
            MenuExe.ar =  new string(Console.ReadLine());
                             
            Console.WriteLine("Possui Vidro Elétrico? |Digite 0-Não ou 1-Sim|");
            MenuExe.vidro =  new string(Console.ReadLine());
                                
            Console.WriteLine("Possui Direção Hidráulica? |Digite 0-Não ou 1-Sim|");
            MenuExe.direcao =  new string(Console.ReadLine());
                                
            Console.WriteLine("Possui Teto Solar? |Digite 0-Não ou 1-Sim|");
            MenuExe.teto =  new string(Console.ReadLine());
                                
            Console.WriteLine("Possui 4 Portas? |Digite 0-Não ou 1-Sim|");
            MenuExe.porta =  new string(Console.ReadLine());

            return;
        }

        public static void PreencheCar() {
            Console.WriteLine("Para Adicionar um carro escreva a Marca: ");
                MenuExe.marca= new string(Console.ReadLine());
                Console.WriteLine("Escreva o Modelo: ");
                MenuExe.modelo= new string(Console.ReadLine());
                Console.WriteLine("Escreva a Versão: ");
                MenuExe.versao= new string(Console.ReadLine());
                Console.WriteLine("Escreva o Ano: ");
                MenuExe.ano= new string(Console.ReadLine());
                Console.WriteLine("Escreva o Preço: ");
                MenuExe.preco= new string(Console.ReadLine());
        }

        public static void ConfirmaCarAdd()
        {
            Console.WriteLine("Confirma a adição do carro Marca: {0}, Modelo: {1}, Versão: {2}, Ano: {3} e Preço: {4}?",MenuExe.marca,MenuExe.modelo,MenuExe.versao,MenuExe.ano,MenuExe.preco);
            Console.WriteLine("Com os seguintes Itens -> Ar-Condicionado: {0}, Vidro Elétrico: {1}, Direção Hidráulica: {2}, Teto Solar: {3} e 4 Portas: {4}?",MenuExe.ar,MenuExe.vidro,MenuExe.direcao,MenuExe.teto,MenuExe.porta);
            Console.WriteLine("|0| Para Confirmar ou |1| para Cancelar... ");
        }
}
