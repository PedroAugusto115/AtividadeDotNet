***********************
WEB APPLICATION DESAFIO
***********************

1. O projeto foi desenvolvido em .NET MVC 4 utilizando Visual Studio 2015;
2. Abrir o projeto com uma vers�o mais recente do Visual Studio provocar� a atualiza��o do arquivo .sln (o que poder� demorar um pouco)
3. Os casos de teste foram realizados utilizando NUnit (execut�vel encontra-se no projeto);
4. A plataforma foi executada em IIS Express (Nativo Visual Studio) e IIS 7;
5. Os dados de DDD de origem, destino e tarifa propostos no projeto foram armazenados em um arquivo XML para desenvolver uma proposta mais similar a um projeto de grande porte;
6. Como a aplica��o Web (executada pelo IIS) e aplica��o local (NUnit) tratam caminhos de formas distintas, o caminho dos arquivos XML de dados s�o passados por par�metros nos m�todos de busca.

*************************
EXECUTANDO CASOS DE TESTE
*************************

1. Para executar os casos de teste, abrir o arquivo DesafioTelzir\NUnit-2.6.4\bin\nunit.exe
2. Para carregar o projeto de teste (.dll), em "File" -> "Open Project", abra o arquivo DesafioTelzir\DesafioTelzirTestUnit\bin\Release\DesafioTelzirTestUnit.dll (dll do projeto de testes);
3. Todos os testes ser�o apresentados;
4. Clique em "Run" para executar todos os testes;
5. Caso as configura��es no ambiente estejam corretas, nenhum erro dever� ser apresentado.

****************************************
CONFIGURANDO APLICA��O WEB - IIS Express
****************************************

1. O projeto est� configurado para ser executado no IIS Express (Podendo ser alterado para o IIS Server);
2. Para executar o projeto no IIS Express, abra o projeto com o Visual Studio;
3. Na tela inicial do VS, clique em "File" -> "Open Project" e selecione o arquivo DesafioTelzir.sln;
4. A solu��o DesafioTelzir conta com dois projetos "DesafioTelzir e DesafioTelzirTestUnit";
5. Clique com o bot�o direito no projeto "DesafioTelzir" e clique na op��o "Set As StartUp Project" (Provavelmente o projeto j� estar� com essa configura��o);
6. Clique no bot�o de executar marcado pelo "Play";
7. O projeto se iniciar� com o Browser escolhido;

***************************************
CONFIGURANDO APLICA��O WEB - IIS Server
***************************************

O projeto n�o est� configurado para o IIS Server. Os passos abaixo mostram a configura��o;

1. Abra o IIS Manager;
2. Crie um novo web site ou utilize o website default;
3. Clique com o bot�o direito sobre o Web Site e escolha "Add Aplication" (Adicionar Aplica��o);
4. Escolha o "Alias" que ser� o nome da aplica��o e, em Physical Path, o caminho onde encontra-se o c�digo-fonte (Pasta onde encontra-se o arquivo Global.asax);
5. Em Application Pools, selecione um APP Pool que utilize o .Net Framework 4.5
6. Em Connect as, coloque um usu�rio que tenha permiss�o de acesso � pasta;
7. Teste a conex�o e confirme a cria��o;
8. Inicie o IIS;
9. De volta ao Visual Studio, abra o projeto (Como administrador para que ele possa acessar o IIS);
10. Clique com o bot�o direito no projeto "DesafioTelzir", em seguida em, "Properties";
11. Selecione a op��o "Web" e, em Servers, desmarque a op��o "Use IIS Express" e coloque o caminho configurado no IIS. Ex.:
	http://localhost:81/DesafioTelzir (IP : Porta / Alias da aplica��o);
12. Realize um Rebuild do projeto, altere o projeto DesafioTelzir para "Set As StartUp Project";
13. Clique em Executar e a aplica��o ser� carregada no Browser Escolhido.

Observa��o IIS Server: Caso os arquivos .css ou .js n�o carreguem no IIS Server, por�m carreguem no IIS Express, 
� poss�vel que seja uma quest�o de configura��o do IIS Server. Verificar as configura��es de MIME Types e instala��o
do IIS, como a op��o "Common HTTP Features" no "Turn Windows Features On or Off" deve estar ativada para que o IIS
interprete os arquivos .css.