Projeto Web (Site)

Cont�m p�gina de login e pagina de produto onde ser� mostrada a listagem de produtos.

Account/Login

Nesta view, � necess�rio entrar com as credenciais: Usuario --> "teste" , Senha --> "123456"

Neste m�todo Login, validamos junto a api "http://localhost:35480/token" (Projeto serviceApi) o usu�rio e senha, deixei hardcode no c�digo,
esse usu�rio e senha para facilitar no teste.
Nesta valida��o ser� retornado o token, e neste momento eu gravo no banco de dados via serviceApi pelo endere�o http://localhost:35480/api/Token/
Fa�o a grava��o dos dados em session para consulta futura.
Com esta etapa conclu�da, direciono a p�gina para a controller Produto.

Produto/Index 

Para concluir essa listagem, validamos via api "http://localhost:35480/api/Token/" o token gerado anteriormente. No caso de sucesso 
a listagem � feita atrav�s de api http://localhost:35480/api/Produto.

Projeto Web (serviceApi)

Repositorio
Foi criado uma pasta Repositorio que cont�m classe de contexto do banco de dados e classes de dados Produto e Token.

Produto --> respons�vel pela listagem dos produtos
Token --> respons�vel pela busca de token valido ou n�o / "OK", "NOK": , tamb�m respons�vel pela grava��o de novos tokens gerados.

Utilizado Ef6 para persist�ncia de dados e migrations , Seed de produtos : Configuration.cs

Banco de dados criado em arquivo.

Banco de dados: ..\SiteApp\serviceApi\App_Data\DBProduto.mdf
