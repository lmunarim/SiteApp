Projeto Web (Site)

Contém página de login e pagina de produto onde será mostrada a listagem de produtos.

Account/Login

Nesta view, é necessário entrar com as credenciais: Usuario --> "teste" , Senha --> "123456"

Neste método Login, validamos junto a api "http://localhost:35480/token" (Projeto serviceApi) o usuário e senha, deixei hardcode no código,
esse usuário e senha para facilitar no teste.
Nesta validação será retornado o token, e neste momento eu gravo no banco de dados via serviceApi pelo endereço http://localhost:35480/api/Token/
Faço a gravação dos dados em session para consulta futura.
Com esta etapa concluída, direciono a página para a controller Produto.

Produto/Index 

Para concluir essa listagem, validamos via api "http://localhost:35480/api/Token/" o token gerado anteriormente. No caso de sucesso 
a listagem é feita através de api http://localhost:35480/api/Produto.

Projeto Web (serviceApi)

Repositorio
Foi criado uma pasta Repositorio que contém classe de contexto do banco de dados e classes de dados Produto e Token.

Produto --> responsável pela listagem dos produtos
Token --> responsável pela busca de token valido ou não / "OK", "NOK": , também responsável pela gravação de novos tokens gerados.

Utilizado Ef6 para persistência de dados e migrations , Seed de produtos : Configuration.cs

Banco de dados criado em arquivo.

Banco de dados: ..\SiteApp\serviceApi\App_Data\DBProduto.mdf


p_ackages_ --> renomear para packages e colocar na pasta rais, please!!

DBProduto_ponto_mdf.TXT --> Renomear para DBProduto.mdf
DBProduto_log_pontoldf.TXT --> Renomear para DBProduto.ldf

Esses arquivos de banco de dados precisam ser adicionados dentro da pasta App_Data do projeto serviceApi.
