***********************
WEB APPLICATION DESAFIO
***********************

1. O projeto foi desenvolvido em .NET MVC 4 utilizando Visual Studio 2015;
2. Abrir o projeto com uma versão mais recente do Visual Studio provocará a atualização do arquivo .sln (o que poderá demorar um pouco)
3. Os casos de teste foram realizados utilizando NUnit (executável encontra-se no projeto);
4. A plataforma foi executada em IIS Express (Nativo Visual Studio) e IIS 7;
5. Os dados de DDD de origem, destino e tarifa propostos no projeto foram armazenados em um arquivo XML para desenvolver uma proposta mais similar a um projeto de grande porte;
6. Como a aplicação Web (executada pelo IIS) e aplicação local (NUnit) tratam caminhos de formas distintas, o caminho dos arquivos XML de dados são passados por parâmetros nos métodos de busca.

*************************
EXECUTANDO CASOS DE TESTE
*************************

1. Para executar os casos de teste, abrir o arquivo DesafioTelzir\NUnit-2.6.4\bin\nunit.exe
2. Para carregar o projeto de teste (.dll), em "File" -> "Open Project", abra o arquivo DesafioTelzir\DesafioTelzirTestUnit\bin\Release\DesafioTelzirTestUnit.dll (dll do projeto de testes);
3. Todos os testes serão apresentados;
4. Clique em "Run" para executar todos os testes;
5. Caso as configurações no ambiente estejam corretas, nenhum erro deverá ser apresentado.

****************************************
CONFIGURANDO APLICAÇÃO WEB - IIS Express
****************************************

1. O projeto está configurado para ser executado no IIS Express (Podendo ser alterado para o IIS Server);
2. Para executar o projeto no IIS Express, abra o projeto com o Visual Studio;
3. Na tela inicial do VS, clique em "File" -> "Open Project" e selecione o arquivo DesafioTelzir.sln;
4. A solução DesafioTelzir conta com dois projetos "DesafioTelzir e DesafioTelzirTestUnit";
5. Clique com o botão direito no projeto "DesafioTelzir" e clique na opção "Set As StartUp Project" (Provavelmente o projeto já estará com essa configuração);
6. Clique no botão de executar marcado pelo "Play";
7. O projeto se iniciará com o Browser escolhido;

***************************************
CONFIGURANDO APLICAÇÃO WEB - IIS Server
***************************************

O projeto não está configurado para o IIS Server. Os passos abaixo mostram a configuração;

1. Abra o IIS Manager;
2. Crie um novo web site ou utilize o website default;
3. Clique com o botão direito sobre o Web Site e escolha "Add Aplication" (Adicionar Aplicação);
4. Escolha o "Alias" que será o nome da aplicação e, em Physical Path, o caminho onde encontra-se o código-fonte (Pasta onde encontra-se o arquivo Global.asax);
5. Em Application Pools, selecione um APP Pool que utilize o .Net Framework 4.5
6. Em Connect as, coloque um usuário que tenha permissão de acesso à pasta;
7. Teste a conexão e confirme a criação;
8. Inicie o IIS;
9. De volta ao Visual Studio, abra o projeto (Como administrador para que ele possa acessar o IIS);
10. Clique com o botão direito no projeto "DesafioTelzir", em seguida em, "Properties";
11. Selecione a opção "Web" e, em Servers, desmarque a opção "Use IIS Express" e coloque o caminho configurado no IIS. Ex.:
	http://localhost:81/DesafioTelzir (IP : Porta / Alias da aplicação);
12. Realize um Rebuild do projeto, altere o projeto DesafioTelzir para "Set As StartUp Project";
13. Clique em Executar e a aplicação será carregada no Browser Escolhido.

Observação IIS Server: Caso os arquivos .css ou .js não carreguem no IIS Server, porém carreguem no IIS Express, 
é possível que seja uma questão de configuração do IIS Server. Verificar as configurações de MIME Types e instalação
do IIS, como a opção "Common HTTP Features" no "Turn Windows Features On or Off" deve estar ativada para que o IIS
interprete os arquivos .css.